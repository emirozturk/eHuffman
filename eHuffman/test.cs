using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHuffman
{
    class test
    {
        //Test amacıyla kod sözlüğünün dosyaya yazılması
        internal static void dosyayaYaz(Dictionary<string, bool[]> kodSozlugu)
        {
            List<string> kodlar = new List<string>();
            foreach (string key in kodSozlugu.Keys)
                kodlar.Add(key + "-" + stringeCevir(kodSozlugu[key]));
            File.WriteAllLines("sozlukTest.txt", kodlar.ToArray());

        }
        //Test amacıyla kod sözlüğünün dosyaya yazılması
        internal static void dosyayaYaz(Dictionary<bool[], string> sozluk)
        {
            List<string> kodlar = new List<string>();
            foreach (bool[] key in sozluk.Keys)
                kodlar.Add(sozluk[key] + "-" + stringeCevir(key));
            File.WriteAllLines("tersSozlukTest.txt", kodlar.ToArray());
        }
        //Bool dizisinin binary string'e çevrilmesi
        private static string stringeCevir(bool[] p)
        {
            string bitString = "";
            for (int i = 0; i < p.Length; i++)
                if (p[i]) bitString += "1";
                else bitString += "0";
            return bitString;
        }
        //Bitarray cinsinde huffman kodunun dosyaya yazılması
        internal static void huffmanKoduYaz(BitArray ba, string ad)
        {
            string kod = "";
            for (int i = 0; i < ba.Length; i++)
                if (ba[i]) kod += "1\n";
                else kod += "0\n";
            File.WriteAllText(ad, kod);
        }
    }
}
