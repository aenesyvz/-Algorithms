using System;
using System.Collections;
using System.IO;

namespace HuffmanAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadFile methodu sayesinde orijinal veri değişkene aktarılır
            string input = ReadFile("metin.txt");
            HuffmanTreeManager huffmanTreeManager = new HuffmanTreeManager();
            huffmanTreeManager.BuildTree(input);

            EncodeManager encodedManager = new EncodeManager(huffmanTreeManager);
            DecodeManager decodeManager = new DecodeManager(huffmanTreeManager);
            
            //BitArray encodedText = huffmanTreeManager.EncodeText(input);
            BitArray encodedText = encodedManager.Encode(input);

            PrintEncode(encodedText);


            //string decodedText = huffmanTreeManager.DecodeText(encodedText);
            string decodedText = decodeManager.Decode(encodedText);

            PrintDecode(decodedText);

            huffmanTreeManager.PrintFrequencies();

        }
        //Çözümlenmiş veriyi dosyaya yazan method
        private static void PrintDecode(string decoded)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"D:\HuffmanAlgorithm\HuffmanAlgorithm\HuffmanAlgorithm\decode.txt"))
            {
                streamWriter.Write(decoded);
            }
        }
        //Sıkıştırılmış veriyi dosyaya yazan method
        private static void PrintEncode(BitArray encoded)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"D:\HuffmanAlgorithm\HuffmanAlgorithm\HuffmanAlgorithm\encode.txt"))
            {
                foreach (bool bit in encoded)
                {
                    streamWriter.Write((bit ? 1 : 0) + "");
                }
            }
        }
        //Orijinal veriyi okuyup veriyi döndürür
        private static string ReadFile(string file)
        {
            string input = "";
           
            using (StreamReader streamReader = new StreamReader(@"D:\HuffmanAlgorithm\HuffmanAlgorithm\HuffmanAlgorithm\" + file))
            {
                string satir;
                while ((satir = streamReader.ReadLine()) != null)
                {
                    input += satir;
                }
            }

            return input;
        }
    }
}
