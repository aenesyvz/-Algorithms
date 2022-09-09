using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Algorithms1
{
    class Program    
    {
        static void Main(string[] args)
        {

            List<int> list = new List<int>();

            ReadFile(list);

            AlgorithmManager algorithmManager = new AlgorithmManager();
            IAlgorithmService algorithmServices = new QuickSortAlgorithm();  // ya da new RadixSortAlgorithm()
            
            //algorithmServices = ChooseAlgorithm();

            algorithmManager.WorkAlgorithm(algorithmServices, list);

            //CreateRandomList(list);

            //WriteFile(list);
        }

        //Algoritma Seç
        private static IAlgorithmService ChooseAlgorithm()
        {
            IAlgorithmService algorithmServices;
            string select;
            Console.WriteLine("Kullanmak istediğiniz algoritmayı seciniz" +
                "\n=> Bubble Sort (1)" +
                "\n=> Shell Sort (2)" +
                "\n=> Insertion Sort (3)" +
                "\n=> Selection Sort (4)" +
                "\n=> Quick Sort (Son eleman pivot) (5)" +
                "\n=> Quick Sort (İlk eleman pivot) (6)" +
                "\n=> Merge Sort (7)" +
                "\n=> Heap Sort (8)" +
                "\n=> Radix Sort (9)" +
                "\nSeciniz : ");

            select = Console.ReadLine();

            if (select == "1")
            {
                algorithmServices = new BubbleSortAlgorithms();
            }
            else if (select == "2")
            {
                algorithmServices = new ShellSortAlgorithms();
            }
            else if (select == "3")
            {
                algorithmServices = new InsertionSortAlgorithms();
            }
            else if (select == "4")
            {
                algorithmServices = new SelectionSortAlgorithms();
            }
            else if (select == "5")
            {
                algorithmServices = new QuickSortAlgorithm();
            }
            else if (select == "6")
            {
                algorithmServices = new QuickSort2Algorithm();
            }
            else if (select == "7")
            {
                algorithmServices = new MergeSortAlgorithm();
            }
            else if(select == "8")
            {
                algorithmServices = new HeapSortAlgorithm();
            }
            else
            {
                algorithmServices = new RadixSortAlgorithm();
            }

            return algorithmServices;
        }

        //Rastgele Liste Oluşturma 
        private static void CreateRandomList(List<int> list)
        {
            int size = 10000;
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(100000, 999999));
            }
        }

        //Dosyaya Yaz
        private static void WriteFile(List<int> list)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"D:\Algorithms1\Algorithms1\Homework3Data\Default3_3.txt"))
            {
                foreach (var item in list)
                {
                    streamWriter.Write(item + " ");
                }
            }
        }

        //Dosya Oku
        private static void ReadFile(List<int> list)
        {
           /* string file = "tersten_sirali.txt";
            string select;
            
            Console.WriteLine("Kullanmak istediginiz metin dosyasini seciniz :" +
                "\n=> input.txt (1)" +
                "\n=> sirali.txt (2)" +
                "\n=> tersten_sirali.txt (3)" +
                "\nSeciniz : ");
            select = Console.ReadLine();
            
            if(select == "1")
            {
                file = "input.txt";
            }else if(select == "2")
            {
                file = "sirali.txt";
            }
            else
            {
                file = "tersten_sirali.txt";
            }*/

            using (StreamReader streamReader = new StreamReader(@"D:\Algorithms1\Algorithms1\Homework3Data\Default2_1.txt"))
            {
                string line;
                string[] values;
                while ((line = streamReader.ReadLine()) != null)
                {
                    values = line.Split(" ");
                    foreach (var item in values)
                    {
                           list.Add(Convert.ToInt32(item));
                    }
                }
            }
        }
    }
}


