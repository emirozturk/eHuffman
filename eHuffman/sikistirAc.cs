using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHuffman
{
    class sikistirAc
    {
        huffman h = new huffman();
        public float sikistir(string dosyaAdi, int ngram, int yuzde)
        {
            string kodlanacak = dosyadanOku(dosyaAdi);//Kodlanacak metnin okunması
            Dictionary<string, int> ngramListesi = h.ngramCikar(kodlanacak, ngram);//İstenen ngramların metinden çıkartılması
            Dictionary<string, int> monogramListesi = h.ngramCikar(kodlanacak, 1);//Monogramların tümünün metinden çıkartılması
            Dictionary<string, int> sozluk = h.sozlukOlustur(ngramListesi, monogramListesi, yuzde);//ngramların istenen % değerinde alınması ve monogramlarla birleştirilmesi
            dugum kok = h.huffmanAgaciOlustur(sozluk);//Elde edilen monogram + ngram sözlüğü ile huffman ağacının oluşturulması
            Dictionary<string, bool[]> kodSozlugu = h.kodSozluguOlustur(kok);//Huffman ağacından huffman kodlarının elde edilmesi
            h.agaciOku(kok);//Ağacın dosyaya yazılması amacıyla preorder gezilmesiyle bir bit dizisi ve sembol listesinin oluşturulması
            Tuple<BitArray, byte> yazilacak = h.kodla(kodlanacak, kodSozlugu, ngram);//Okunan metnin kodlanarak yazılacak bit dizisinin elde edilmesi
            h.headerOlustur(yazilacak.Item2, kodSozlugu.Count);//Kod sözlüğünün uzunluğunun ve bit dizisindeki artık bitlerin header struct'ına yazılması
            return h.koduDosyayaYaz(dosyaAdi, yazilacak);//Kodun dosyaya yazılması
        }
        public void ac(string dosyaAdi)
        {
            BitArray kod = h.koduDosyadanOku(dosyaAdi);//Headerın ve Dosyanın okunup, çözülecek bit dizisinin elde edilmesi
            Dictionary<string, string> kodSozlugu = h.acilmisKodSozluguOlustur();//Header içerisindeki 1d kod ve ngramlardan ağaç oluşturulması ve bu sayede kod sözlüğünün elde edilmesi
            string metin = h.koduAc(kod, kodSozlugu);//Kod sözlüğünün kullanılmasıyla orijinal metnin elde edilmesi
            dosyayaYaz(dosyaAdi, metin);//Elde edilen açılmış metnin dosyaya yazılması
        }
        private string dosyadanOku(string dosyaAdi)
        {
            return File.ReadAllText(dosyaAdi, Encoding.Default);//Metnin tüm karakterlerinin dosyadan okunması
        }
        private void dosyayaYaz(string dosyaAdi, string metin)
        {
            //Açılmış metnin dosya adına (a) eklenmesiyle oluşturulması 
            dosyaAdi = dosyaAdi.Replace(".ehf", "");
            dosyaAdi = Path.GetDirectoryName(dosyaAdi) + "\\" + Path.GetFileNameWithoutExtension(dosyaAdi) + "(a)" + Path.GetExtension(dosyaAdi);
            File.WriteAllText(dosyaAdi, metin, Encoding.Default);
        }
    }
}
