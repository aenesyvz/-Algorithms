using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Algorithms2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            ReadFile(list);
            int option = 1;
            if (option == 0)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                WorstAlgorithm(list);
                stopwatch.Stop();
                Console.WriteLine("Süre : " + stopwatch.Elapsed.TotalMilliseconds);
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                ImprovedAlgorithm(list);
                stopwatch.Stop();
                Console.WriteLine("Süre : " + stopwatch.Elapsed.TotalMilliseconds);
            }
            
        }

        private static int ImproveSearch(List<int> list)
        {
            int sum = 100000;
            
            AlgorithmManager algorithmManager = new AlgorithmManager();
            IAlgorithmService algorithmService = new MergeSortAlgorithm();  // Tercihe bağlı
            algorithmManager.Work(algorithmService, list);
            
            //list.Sort();                                      //standart kitaplığında => quick sort  
            
            int count = list.Count - 1;
            for (int i = 0; list[i] < 0; i++)
            {
                for (int j = count; 0 < list[j]; j--)
                {
                    if (Math.Abs(list[i] + list[j]) < sum && Math.Abs(list[i] + list[j]) != 0)
                    {
                        sum = Math.Abs(list[i] + list[j]);
                    }
                    else if (list[i] + list[j] <= -2 && j + 1 > count)
                    {
                        break;
                    }
                    else if (list[i] + list[j] <= -2 && j + 2 > count)
                    {
                        j = j + 1;
                        break;
                    }
                    else if (list[i] + list[j] <= -2)
                    {
                        j = j + 2;
                        break;
                    }
                }
            }

            return sum;
        }

        private static void ImprovedAlgorithm(List<int> list)
        {
            int sum = ImproveSearch(list);
            int quantity = 0;
            
            AlgorithmManager algorithmManager = new AlgorithmManager();
            IAlgorithmService algorithmService = new MergeSortAlgorithm();  // Tercihe bağlı
            algorithmManager.Work(algorithmService, list);

            //list.Sort();                                   //standart kitaplığında => quick sort 

            int count = list.Count - 1;
            for (int i = 0; list[i] < 0; i++)
            {
                for (int j = count; 0 < list[j]; j--)
                {
                    if (Math.Abs(list[i] + list[j]) == sum)
                    {
                        Console.WriteLine("=> ({0},{1})", list[i], list[j]);
                        quantity++;
                    }
                    else if (list[i] + list[j] <= -2 && j + 1 > count)
                    {
                        break;
                    }
                    else if (list[i] + list[j] <= -2 && j + 2 > count)
                    {
                        j = j + 1;
                        break;
                    }
                    else if (list[i] + list[j] <= -2)
                    {
                        j = j + 2;
                        break;
                    }
                }
            }
            Console.WriteLine("İki elemanın sıfıra en yakın toplamı : " + sum);
            Console.WriteLine("İki elemanlı çift sayısı : " + quantity);
        }

        private static int WorstSearch(List<int> list)
        {

            int sum = 10000000;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i+1; j < list.Count; j++)
                {
                    if (Math.Abs(list[i] + list[j]) < sum && Math.Abs(list[i] + list[j]) != 0)
                    {
                        sum = Math.Abs(list[i] + list[j]);
                    }
                }
            }

            return sum;
        }

        private static void WorstAlgorithm(List<int> list)
        {
            int sum = WorstSearch(list);
            int count = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i+1; j < list.Count; j++)
                {
                    if (Math.Abs(list[i] + list[j]) == sum)
                    {
                        Console.WriteLine("=> ({0},{1})", list[i], list[j]);
                        count++;
                    }
                }
            }
            Console.WriteLine("İki elemanın sıfıra en yakın toplamı : " + sum);
            Console.WriteLine("İki elemanlı çift sayısı : " + count);
        }

        private static void CreateRandomList(List<int> list)
        {
            int size = 10000;
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(-50000, 50000));
            }
        }

        private static void WriterFile(List<int> list)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"D:\Algorithms2\Algorithms2\Homework4\Default10000.txt"))
            {
                foreach (var item in list)
                {
                    streamWriter.Write(item + " ");
                }
            }
        }

        private static void ReadFile(List<int> list)
        {
            string file = "1000"; //5000 - 10000  // Tercihe bağlı
            using (StreamReader streamReader = new StreamReader(@"D:\Algorithms2\Algorithms2\Homework4\Default" + file + ".txt"))
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
