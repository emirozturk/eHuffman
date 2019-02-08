using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHuffman
{
    class huffman
    {
        public Int16 headerUzunlugu;//Dosyanın en başına yazılan header uzunluğu
        HashSet<string> kodSeti;//Kod açılırken var olup olmadığına daha hızlı bakılabilmesi için kullanılan hashset
        public struct header
        {
            public byte fark;//Kodlanacak bitlerin sonunda kaç bitin anlamsız olduğu
            public Int16 ngramSayisi;//Headerdan okunabilmesi için ngram sayısı
            public int kodUzunlugu;//Preorder gezilmiş ağacın kod uzunluğu
            public byte[] kod;//Preorder gezilmiş ağacın kodlarının byte'a çevrilmiş hali
            public string ngramlar;//Ngramların header içerisinde ½ ile ayrılmış stringi
        }
        header h = new header();
        string buyukHarfKodu = Convert.ToChar(1).ToString();//Test metinlerinde olmadığı için büyük harf kodu olarak 1 değeri kullanılmıştır.
        //Metinde n boyutunda bir pencere kaydırılarak ngramlar okunur.
        //Ngramlar küçük harfe çevrilip eklenir. Eğer mevcutsa frekans değeri arttırılır, değilse yeni ngram sözlüğe eklenir.
        //Ngramlarda büyük harf varsa büyük harf kodunun frekansı da güncelleştirilir.
        public Dictionary<string, int> ngramCikar(string metin, int n)
        {
            Dictionary<string, int> ngramlar = new Dictionary<string, int>();
            for (int i = 0; i < metin.Length - n + 1; i++)
            {
                string ngram = metin.Substring(i, n);
                string kucuk = ngram.ToLower();
                if (!ngramlar.ContainsKey(kucuk))
                    ngramlar.Add(kucuk, 1);
                else
                    ngramlar[kucuk]++;
                if (kucuk != ngram)
                    if (!ngramlar.ContainsKey(buyukHarfKodu))
                        ngramlar.Add(buyukHarfKodu, 1);
                    else
                        ngramlar[buyukHarfKodu]++;
            }
            return ngramlar;
        }
        //Monogramlar ve ngramlar elde edildikten sonra ngramların istenilen miktarı (%) alınır ve monogramlar ile birleştirilir.
        //Elde edilen sözlük geriye döndürülür.
        public Dictionary<string, int> sozlukOlustur(Dictionary<string, int> nGramlar, Dictionary<string, int> monogramlar, int yuzdelik)
        {
            int sayi = nGramlar.Count * yuzdelik / 100;
            List<KeyValuePair<string, int>> secilenNgramlar = (from x in nGramlar orderby x.Value descending select x).Take(sayi).ToList();
            Dictionary<string, int> sozluk = new Dictionary<string, int>();
            for (int i = 0; i < secilenNgramlar.Count; i++)
                sozluk.Add(secilenNgramlar[i].Key, secilenNgramlar[i].Value);
            foreach (string key in monogramlar.Keys)
                if (!sozluk.Keys.Contains(key))
                    sozluk.Add(key, monogramlar[key]);
            sozluk = sozluk.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return sozluk;
        }
        //Dugum listesi tüm ngramlar için oluşturulur.
        //Düğüm listesinde tek eleman (root) kalana kadar tüm düğümler frekansa göre sıralanır. 
        //En alt iki düğüm listeden çıkartılır. Bir parent dugumun yaprakları olarak atanır ve parent dugum tekrar listeye eklenir.
        //Son durumda kök düğüm kalacaktır.
        //Kök düğüm kaldığında ağaca kod atama işlemi gerçekleştirilir.
        public dugum huffmanAgaciOlustur(Dictionary<string, int> sozluk)
        {
            List<dugum> dugumListesi = new List<dugum>(sozluk.Count);
            foreach (string key in sozluk.Keys)
            {
                dugum d = new dugum(key, sozluk[key]);
                dugumListesi.Add(d);
            }
            while (dugumListesi.Count > 1)
            {
                dugumListesi = dugumListesi.OrderBy(dugum => dugum.frekans).ToList();
                List<dugum> ikili = (from x in dugumListesi select x).Take(2).ToList();
                dugum d = new dugum("½", ikili[0].frekans + ikili[1].frekans, ikili[0], ikili[1]);//½ gelmez heralde?
                dugumListesi.RemoveAt(0);
                dugumListesi.RemoveAt(0);
                dugumListesi.Add(d);
            }
            agacaKodAta(dugumListesi[0], "");
            return dugumListesi[0];
        }
        //Kod atanmış ağaçtan ngramlar ve karşılık gelen kod değerleri elde edilir.
        public Dictionary<string, bool[]> kodSozluguOlustur(dugum kok)
        {
            Dictionary<string, bool[]> kodSozlugu = new Dictionary<string, bool[]>();
            agaciGez(kok, ref kodSozlugu);
            //test.dosyayaYaz(kodSozlugu);
            return kodSozlugu;
        }
        //Ağaç gezilirken yaprak düğüm ile karşılaşılırsa (veri !=½) bu düğümün kod değeri ve içeriği kod sözlüğüne eklenir.
        public void agaciGez(dugum kok, ref Dictionary<string, bool[]> kodSozlugu)
        {
            if (kok != null)
            {
                if (kok.veri != "½")
                {
                    kodSozlugu.Add(kok.veri, kok.kod.Select(deger => deger == '1').ToArray());
                    return;
                }
                agaciGez(kok.sag, ref kodSozlugu);
                agaciGez(kok.sol, ref kodSozlugu);
            }
        }
        //Ağaç sağa 0 ve sola 1 atanarak gezilir. 
        //Son durumda yapraklarda huffman kodları elde edilmiş olur. Böylece kod sözlüğü oluşturulurken bu değer direkt olarak alınabilir.
        public void agacaKodAta(dugum kok, string kod)
        {
            if (kok != null)
            {
                kok.kod = kod;
                agacaKodAta(kok.sag, kod + "0");
                agacaKodAta(kok.sol, kod + "1");
            }
        }
        //Ağacın Preorder gezilmesi ile tek boyuta düşürülme işlemi. Bu işlemden sonra ağacın binary kod değeri ve sıralı okunmuş ngram değerleri elde edilir.
        //Kod uzunluğu, dosyadan tekrar okuma işleminde kaç bitin artık olduğunun bulunmasında kullanılır.
        //Kod byte dizisine dönüştürülerek dosyada saklanır
        public void agaciOku(dugum kok)
        {
            string kod = "";
            agaciOku(kok, ref kod, ref h.ngramlar);
            h.kodUzunlugu = kod.Length;
            h.kod = stringIslem.stringToByte(kod);
        }
        //Ağaçta bulunulan düğümün verisi ½ değilse (yapraksa) bu düğümün kodunun son hanesi (solda ise 1 sağda ise 0) kod stringine eklenir ve okunan ngram, ngram stringine eklenir
        public void agaciOku(dugum kok, ref string kod, ref string ngramlar)
        {
            if (kok != null)
            {
                if (kok.veri != "½") ngramlar += kok.veri + "½";
                if (kok.kod != "") kod += kok.kod.Substring(kok.kod.Length - 1, 1);
                agaciOku(kok.sol, ref kod, ref ngramlar);
                agaciOku(kok.sag, ref kod, ref ngramlar);
            }
        }
        //Dosyadan okunan kod ve ngramlardan ağacı yeniden oluşturma işlemi
        public dugum agaciOlustur(string kod, string[] ngramlar)
        {
            int sayac = 0;
            dugum kok = new dugum();
            kok.veri = "½";
            kok.ata = null;
            dugum bulunulan = kok;
            for (int i = 0; i < kod.Length; i++)
            {
                if (kod[i] == '1')
                {
                    if (bulunulan.sol == null)
                    {
                        dugum yeniDugum = new dugum();
                        yeniDugum.veri = "½";
                        bulunulan.sol = yeniDugum;
                        yeniDugum.ata = bulunulan;
                        bulunulan = yeniDugum;
                    }
                }
                else if (kod[i] == '0')
                {
                    bulunulan.veri = ngramlar[sayac++];
                    bulunulan = bulunulan.ata;
                    while (bulunulan.sag != null)
                        bulunulan = bulunulan.ata;
                    dugum yeniDugum = new dugum();
                    yeniDugum.veri = "½";
                    bulunulan.sag = yeniDugum;
                    yeniDugum.ata = bulunulan;
                    bulunulan = yeniDugum;
                }
            }
            bulunulan.veri = ngramlar[ngramlar.Length - 1];
            return kok;
        }
        //Okunan ngram küçük harfe çevrilir. Eğer büyük harf varsa hangi harflerin büyük olduğu 3 bitle kodlanır.
        //Küçük harfe çevrilen ngram sözlükte aranır. Varsa kod karşılığı kodlanır. Yoksa ngram monogramlar halinde kodlanır.
        public Tuple<BitArray, byte> kodla(string metin, Dictionary<string, bool[]> kodSozlugu, int n)
        {
            List<bool[]> kodlar = new List<bool[]>();
            string ngram, kucuk, mono, monoKucuk;
            for (int i = 0; i < metin.Length; i += n)
            {
                if (i + n >= metin.Length)
                {
                    ngram = "";
                    for (int j = i; j < metin.Length; j++)
                        ngram += metin[j];
                }
                else
                    ngram = metin.Substring(i, n);
                kucuk = ngram.ToLower();
                if (kodSozlugu.ContainsKey(kucuk))
                {
                    if (ngram != kucuk)
                    {
                        kodlar.Add(kodSozlugu[buyukHarfKodu]);
                        kodlar.Add(buyukHarfBool(ngram, kucuk));
                    }
                    kodlar.Add(kodSozlugu[kucuk]);
                }
                else
                {
                    for (int j = 0; j < ngram.Length; j++)
                    {
                        mono = ngram[j].ToString();
                        monoKucuk = mono.ToLower();
                        if (mono != monoKucuk)
                        {
                            kodlar.Add(kodSozlugu[buyukHarfKodu]);
                            kodlar.Add(buyukHarfBool(mono, monoKucuk));
                        }
                        kodlar.Add(kodSozlugu[monoKucuk]);
                    }
                }
            }
            List<bool> kodListesi = new List<bool>();
            for (int i = 0; i < kodlar.Count; i++)
                kodListesi.AddRange(kodlar[i]);
            BitArray ba = new BitArray(kodListesi.ToArray());
            byte fark = 0;
            if (ba.Length % 8 != 0)
                fark = Convert.ToByte(8 - ba.Length % 8);
            //test.huffmanKoduYaz(ba, "sikist.txt");
            return new Tuple<BitArray, byte>(ba, fark);
        }
        //Kod bit bit okunur, sözlükte bulunduğu zaman bir sonraki 3 bit büyüklük kontrolü için okunur.
        //Kodun karşılığı ngram kod sözlüğünden alınır ve sonra okunan 3 bit kullanılarak büyük harfe çevrilmesi gereken kısımlar çevrilir.
        public string koduAc(BitArray kod, Dictionary<string, string> acilmisKodSozlugu)
        {
            //test.huffmanKoduYaz(kod, "ad.txt");
            List<bool> aranan = new List<bool>();
            StringBuilder acilan = new StringBuilder();
            int sayac = 0;
            bool[] buyukHarfler = new bool[3];
            bool sonrakiBuyukMu = false;
            while (sayac < kod.Length)
            {
                aranan.Add(kod[sayac]);
                string bulunan = varMi(acilmisKodSozlugu, stringIslem.stringeCevir(aranan.ToArray()));
                if (bulunan != null)
                {
                    if (bulunan == buyukHarfKodu)
                    {
                        sonrakiBuyukMu = true;
                        buyukHarfler[0] = kod[++sayac]; buyukHarfler[1] = kod[++sayac]; buyukHarfler[2] = kod[++sayac];
                    }
                    else if (bulunan != buyukHarfKodu)
                    {
                        if (sonrakiBuyukMu)
                        {
                            acilan.Append(stringIslem.harfBuyut(bulunan, buyukHarfler));
                            sonrakiBuyukMu = false;
                        }
                        else
                            acilan.Append(bulunan);
                    }
                    aranan = new List<bool>();
                }
                sayac++;
            }
            return acilan.ToString();
        }
        //3 bitlik büyük harf bool dizisi, büyükse 1 değilse 0
        public bool[] buyukHarfBool(string ngram, string kucuk)
        {
            bool[] dizi = new bool[3];
            for (int i = 0; i < ngram.Length; i++)
                if (ngram[i] != kucuk[i])
                    dizi[i] = true;
                else
                    dizi[i] = false;
            return dizi;
        }
        //Hashset olan kod sözlüğünde kod varsa sözlükten o kodun ngram karşılığını döndürür.
        //Hashset'te kodun olup olmadığına bakmak sözlükte aramaktan daha az maliyetli olduğu için hashset kullanılmıştır.
        public string varMi(Dictionary<string, string> acilmisKodSozlugu, string p)
        {
            if (kodSeti.Contains(p))
                return acilmisKodSozlugu[p];
            return null;
        }
        //Açma sırasında
        //Ngramlar ½ değerinden ayrılarak elde edilir. Kod headerdan elde edilir.
        //Kod ve ngramlar kullanılarak ağaç oluşturulur ve bu ağaca kod atanır.
        //Elde edilen ağaç sıkıştırma sırasında kullanılan ağaç ile aynı olur. 
        //Bu ağaç gezilerek kod sözlüğü elde edilir.
        public Dictionary<string, string> acilmisKodSozluguOlustur()
        {
            string[] ngramlar = h.ngramlar.Split('½').Take(h.ngramlar.Split('½').Length - 1).ToArray();
            string kod = stringIslem.byteToString(h.kod, h.kodUzunlugu);
            dugum kok = agaciOlustur(kod, ngramlar);
            agacaKodAta(kok, "");
            Dictionary<string, bool[]> tersSozluk = new Dictionary<string, bool[]>();
            agaciGez(kok, ref tersSozluk);
            Dictionary<string, string> sozluk = tersSozluk.ToDictionary(x => stringIslem.stringeCevir(x.Value), x => x.Key);
            kodSeti = new HashSet<string>(sozluk.Keys);
            //test.dosyayaYaz(sozluk);
            return sozluk;
        }
        //Header için gerekli bilgiler doldurulur.
        public void headerOlustur(byte fark, int nGramSayisi)
        {
            h.fark = fark;
            h.ngramSayisi = Convert.ToInt16(nGramSayisi);
            headerUzunlugu = Convert.ToInt16(1 + h.kod.Length + 4 + h.ngramlar.Length + 2);
        }
        //ilk iki byte header uzunluğu,ikinci byte koddaki artık bit,üçüncü ve dördüncü byte ngramsayisi 
        //beşinci byte kod uzunluğu
        //byte olarak kod ve char dizisi olarak ngramlar
        //Yazılacak kod
        public float koduDosyayaYaz(string dosyaAdi, Tuple<BitArray, byte> veri)
        {
            dosyaAdi += ".ehf";
            BitArray ba = new BitArray(veri.Item1.Length + (8 - veri.Item1.Length % 8) % 8);
            for (int i = 0; i < veri.Item1.Length; i++) ba[i] = veri.Item1[i];
            byte[] yazilacak = new byte[ba.Length / 8];
            ba.CopyTo(yazilacak, 0);
            FileStream fs = new FileStream(dosyaAdi, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(Convert.ToInt16(headerUzunlugu));
            bw.Write(h.fark);
            bw.Write(h.ngramSayisi);
            bw.Write(h.kodUzunlugu);
            bw.Write(h.kod, 0, h.kod.Length);
            bw.Write(h.ngramlar.ToCharArray(), 0, h.ngramlar.Length);
            bw.Write(yazilacak, 0, yazilacak.Length);
            bw.Close();
            fs.Close();
            FileStream fsBoyut = new FileStream(dosyaAdi, FileMode.Open);
            float boyut = fsBoyut.Length;
            fsBoyut.Close();
            fs.Close();
            return boyut;
        }
        public BitArray koduDosyadanOku(string dosyaAdi)
        {
            FileStream fs = new FileStream(dosyaAdi, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            headerUzunlugu = br.ReadInt16();
            h.fark = br.ReadByte();
            h.ngramSayisi = br.ReadInt16();
            h.kodUzunlugu = br.ReadInt32();
            int uzunluk = (h.kodUzunlugu + (8 - h.kodUzunlugu % 8) % 8) / 8;
            h.kod = br.ReadBytes(uzunluk);
            int kalan = headerUzunlugu - 1 - 2 - 4 - uzunluk;
            h.ngramlar = new string(br.ReadChars(kalan));
            byte[] kod = br.ReadBytes(Convert.ToInt32(fs.Length) - headerUzunlugu - 2); //-2 heeaderuzunluğunu tutan değişken, header uzunluğu sabit, gerisi kod
            br.Close();
            fs.Close();
            BitArray baFark = new BitArray(kod);
            BitArray ba = new BitArray(kod.Length * 8 - h.fark);
            for (int i = 0; i < ba.Length; i++) ba[i] = baFark[i];
            return ba;
        }
    }
}
