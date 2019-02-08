using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHuffman
{
    static class stringIslem
    {
        //n uzunluktaki binary stringin byte dizisine dönüştürülmesi
        public static byte[] stringToByte(string bitString)
        {
            //Eğer n 8'in katı değilse tamamlama işlemi, fazladan 8e tamamlanana kadar 0 biti yerleştirilir
            byte copSayisi = 0;
            if (bitString.Length % 8 != 0) copSayisi = Convert.ToByte(8 - bitString.Length % 8);
            for (int i = 0; i < copSayisi; i++)
                bitString += "0";
            List<byte> bytelar = new List<byte>();
            //Stringin 8 bitlik parçalara bölünüp byte'a çevrilmesi
            for (int i = 0; i < bitString.Length; i += 8)
            {
                string byteString = bitString.Substring(i, 8);
                bytelar.Add(Convert.ToByte(byteString, 2));
            }
            //Byte dizisinin döndürülmesi
            return bytelar.ToArray();
        }
        //Verilen byte dizisi 8'lik bit stringine dönüştürülür
        public static string byteToString(byte[] byteLar, int kodUzunlugu)
        {
            string bitler = "";
            for (int i = 0; i < byteLar.Length; i++)
                bitler += Convert.ToString(byteLar[i], 2).PadLeft(8, '0');
            bitler = bitler.Substring(0, kodUzunlugu);
            return bitler;
        }
        //Bool dizisini binary stringe çevirme işlemi
        public static string stringeCevir(bool[] p)
        {
            StringBuilder sonuc = new StringBuilder();
            for (int i = 0; i < p.Length; i++)
                sonuc.Append((p[i]) ? "1" : "0");
            return sonuc.ToString();
        }
        //Ngramlar içerisinde büyük harf var ise bool dizisi içerisinde bu harflerin indisleri true olur.
        //Buna göre bool dizisinde true olan harfler büyük harfe çevrilir.
        public static string harfBuyut(string bulunan, bool[] buyukler)
        {
            string yeniString = "";
            for (int i = 0; i < bulunan.Length; i++)
                if (buyukler[i])
                    yeniString += bulunan[i].ToString().ToUpper();
                else
                    yeniString += bulunan[i];
            return yeniString;
        }
    }
}
