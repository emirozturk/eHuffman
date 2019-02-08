using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHuffman
{
    //Huffman ağacı için düğüm yapısı
    class dugum
    {
        //Düğümün sakladığı veri, Eğer yaprak ise ngramları, değilse ½ değerini saklar
        public string veri { get; set; }
        //Huffman ağacı oluşturulurken kullanılacak frekans değerleri
        public int frekans { get; set; }
        //Huffman ağacının dosyadan okunduktan sonra kolayca oluşturulabilmesi için her düğümün atasının tutulması
        public dugum ata { get; set; }
        public dugum sol { get; set; }
        public dugum sag { get; set; }
        //Düğümün sahip olduğu kod. Eğer yaprak düğümse huffman kodu elde edilir.
        public string kod { get; set; }
        public dugum()
        {

        }
        public dugum(string _veri, int _frekans, dugum _sol, dugum _sag)
        {
            veri = _veri;
            frekans = _frekans;
            sol = _sol;
            sag = _sag;
        }
        public dugum(string _veri, int _frekans)
        {
            veri = _veri;
            frekans = _frekans;
        }
    }
}
