using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgorithm
{
    public class HuffmanTreeManager
    {
        public List<Node> NodeList = new List<Node>();
        public Node Base { get; set; }
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();
        //Huffman ağacını yapılandırır
        public void BuildTree(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Frequencies.ContainsKey(input[i]))                           //Okunan sembolun sözlükte mevcut olup olmadığı kontrolü yapılır
                {                                                                 //Okunan sembol mevcutta varsa frekans değeri artırılır
                    Frequencies.Add(input[i], 0);                                 //Okunan sembol mevcutta yoksa sözlüğü eklenir
                }

                Frequencies[input[i]]++;
            }

            foreach (KeyValuePair<char, int> frequency in Frequencies)            //Düğüm listesi oluşturulur
            {
                NodeList.Add(new Node()  { 
                                        Symbol = frequency.Key, 
                                        Frequency = frequency.Value 
                                       });
            }

            while (NodeList.Count > 1)
            {
                List<Node> sequentialNodes = NodeList.OrderBy(x => x.Frequency).ToList();         //Düğümler küçükten büyüğe sıralanır

                if (sequentialNodes.Count >= 2)
                {
                    // En küçük frekansa sahip ilk iki öğeyi alır
                    List<Node> section = sequentialNodes.Take(2).ToList();

                    // Frekans değerlerini birleştirerek bir ana düğüm oluşturur
                    Node ancestor = new Node()
                    {
                        Symbol = '*',
                        Frequency = section[0].Frequency + section[1].Frequency,
                        Left = section[0],
                        Right = section[1]
                    };

                    NodeList.Remove(section[0]);                                                    //Toplanan ilk iki düğüm listeden kaldırılır
                    NodeList.Remove(section[1]);
                    NodeList.Add(ancestor);                                                           //Ata düğüm listenin en sonuna eklenir
                }

                this.Base = NodeList.FirstOrDefault();                                              //nodeList listesinin ilk elemanı seçilir

            }

        }

        /*public BitArray EncodeText(string input)
        {
            List<bool> result = new List<bool>();

            for (int i = 0; i < input.Length; i++)
            {
                List<bool> nodeSymbol = this.Base.TraverseTree(input[i], new List<bool>());
                result.AddRange(nodeSymbol);
            }

            BitArray bitArray = new BitArray(result.ToArray());

            return bitArray;
        }*/

        /*public string DecodeText(BitArray bits)
        {
            Node instantNode = this.Base;
            string result = "";

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (instantNode.Right != null)
                    {
                        instantNode = instantNode.Right;
                    }
                }
                else
                {
                    if (instantNode.Left != null)
                    {
                        instantNode = instantNode.Left;
                    }
                }

                if (CheckLeaf(instantNode))
                {
                    result += instantNode.Symbol;
                    instantNode = this.Base;
                }
            }

            return result;
        }*/
        
        public bool CheckLeaf(Node knot)                             //Düğümün yaprak düğüm olup olmadığı kontorl edilir
        {
            return (knot.Left == null && knot.Right == null);
        }


        public void PrintFrequencies()                                  //Her bir sembolün frekans değerini yazdırır
        {
            foreach (KeyValuePair<char, int> frequency in Frequencies)
            {
                Console.WriteLine(frequency.Key + " => "  + frequency.Value);
            }
        }
    }
}
