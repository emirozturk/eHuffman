using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHuffman
{
    public partial class frmBatch : Form
    {
        Dictionary<string, string> dosyalar = new Dictionary<string, string>();
        //Sonuçları saklamak için struct
        struct sonuc
        {
            public string dosyaAdi;
            public int ngram, yuzde;
            public float sikistirmaOrani, sikistirmaSuresi, acmaSuresi;
        }
        List<sonuc> sonucListesi = new List<sonuc>();
        public frmBatch()
        {
            InitializeComponent();
            dgSo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgSure.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }

        private void btnDosyaEkle_Click(object sender, EventArgs e)
        {
            ofdDosyaAc.ShowDialog();
        }

        private void ofdDosyaAc_FileOk(object sender, CancelEventArgs e)
        {
            foreach (string dosyaAdi in ofdDosyaAc.FileNames)
                dosyalar.Add(dosyaAdi, Path.GetFileNameWithoutExtension(dosyaAdi));
            foreach (string key in dosyalar.Keys)
                lbDosyaListesi.Items.Add(dosyalar[key]);
        }

        private void btnSikistirAc_Click(object sender, EventArgs e)
        {
            int artim = Convert.ToInt32(tbArtim.Text);
            if (cb1.Checked) batchCalistir(1, 100);
            if (cb2.Checked) batchCalistir(2, artim);
            if (cb3.Checked) batchCalistir(3, artim);

            sonucListele(artim, cb1.Checked, cb2.Checked, cb3.Checked);
        }
        //Sonuçların datagridlerde sıkıştırma oranı ve süre olarak listelenmesi
        private void sonucListele(int artim, bool bir, bool iki, bool uc)
        {
            dgDoldur(bir, iki, uc, artim);
            int sayac = 0;
            for (int i = 0; i < sonucListesi.Count; i++)
            {
                int index = dosyaVarMi(sonucListesi[i].dosyaAdi);
                if (index == -1)
                {
                    dgSo.Rows.Add();
                    dgSure.Rows.Add();
                    index = dgSo.Rows.Count - 2;
                    dgSo.Rows[index].HeaderCell.Value = sonucListesi[i].dosyaAdi;
                    dgSure.Rows[index].HeaderCell.Value = sonucListesi[i].dosyaAdi;
                }
                dgSo.Rows[index].Cells[sonucListesi[i].ngram + "-gram " + sonucListesi[i].yuzde + "%"].Value = sonucListesi[i].sikistirmaOrani;
                dgSure.Rows[index].Cells[sonucListesi[i].ngram + "-gram " + sonucListesi[i].yuzde + "%"].Value = sonucListesi[i].sikistirmaSuresi + "/" + sonucListesi[i].acmaSuresi;
            }
        }

        private int dosyaVarMi(string p)
        {
            for (int i = 0; i < dgSo.Rows.Count; i++)
                if (dgSo.Rows[i].HeaderCell.Value != null)
                    if (dgSo.Rows[i].HeaderCell.Value.ToString() == p)
                        return i;
            return -1;
        }
        //Datagridin sütunlarının seçilen parametrelere göre belirlenmesi
        private void dgDoldur(bool bir, bool iki, bool uc, int artim)
        {
            dgSo.Rows.Clear();
            if (bir)
            {
                dgSo.Columns.Add("1-gram " + "100" + "%", "1-gram " + "100" + "%");
                dgSure.Columns.Add("1-gram " + "100" + "%", "1-gram " + "100" + "%");

            }
            if (iki)
                for (int i = artim; i <= 100; i += artim)
                {
                    dgSo.Columns.Add("2-gram " + i.ToString() + "%", "2-gram " + i.ToString() + "%");
                    dgSure.Columns.Add("2-gram " + i.ToString() + "%", "2-gram " + i.ToString() + "%");
                }
            if (uc)
                for (int i = artim; i <= 100; i += artim)
                {
                    dgSo.Columns.Add("3-gram " + i.ToString() + "%", "3-gram " + i.ToString() + "%");
                    dgSure.Columns.Add("3-gram " + i.ToString() + "%", "3-gram " + i.ToString() + "%");
                }
        }
        //Artım değeri kadar farklı ihtimal seçilen ngramlar için denenir ve sonuçlar bir struct listesi içerisinde saklanır
        //Eğer monogramlar seçilirse tek sonuç elde edilecektir.
        private void batchCalistir(int ngram, int artim)
        {
            foreach (string key in dosyalar.Keys)
            {
                for (int i = artim; i <= 100; i += artim)
                {
                    sonuc s = new sonuc();
                    //for (int j = 0; j < 10; j++)
                    //{
                    sikistirAc sa = new sikistirAc();
                    s.dosyaAdi = dosyalar[key];
                    s.ngram = ngram;
                    s.yuzde = i;

                    DateTime simdi = DateTime.Now;
                    s.sikistirmaOrani = Convert.ToSingle(Math.Round(sa.sikistir(key, ngram, i) / new FileInfo(key).Length, 2));
                    s.sikistirmaSuresi += Convert.ToSingle(Math.Round(DateTime.Now.Subtract(simdi).TotalMilliseconds, 2));

                    simdi = DateTime.Now;
                    sa.ac(key + ".ehf");
                    s.acmaSuresi += Convert.ToSingle(Math.Round(DateTime.Now.Subtract(simdi).TotalMilliseconds, 2));
                    temizle(key);
                    //}
                    //s.sikistirmaSuresi /= 10;
                    //s.acmaSuresi /= 10;
                    sonucListesi.Add(s);
                }
            }
        }
        //Sonuç alma amacıyla oluşturulan dosyaların silinmesi
        private void temizle(string key)
        {
            string sikist = key + ".ehf";
            string acilan = Path.GetDirectoryName(sikist) + "\\" + Path.GetFileNameWithoutExtension(sikist.Replace(".ehf", "")) + "(a).txt";
            if (File.Exists(sikist))
                File.Delete(sikist);
            if (File.Exists(acilan))
                File.Delete(acilan);
        }
    }
}
