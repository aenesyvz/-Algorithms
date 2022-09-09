using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms1
{
    public class RadixSortAlgorithm : IAlgorithmService
    {
        public static void CountingSort(List<int> array, int length, int exponent)
        {
            
            int[] output = new int[length];  
            int i;

           
            int[] count = new int[10];
            for (i = 0; i < 10; i++)
            {
                count[i] = 0;
            }
            for (i = 0; i < length; i++)
            {
                count[(array[i] / exponent) % 10]++;
            }

           
            for (i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (i = length - 1; i >= 0; i--)
            {
                output[count[(array[i] / exponent) % 10] - 1] = array[i];
                count[(array[i] / exponent) % 10]--;
            }

           
            for (i = 0; i < length; i++)
            {
                array[i] = output[i];
            }
        }
        public void Work(List<int> values)
        {
            int length = values.Count;
            int max = values.Max();
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(values, length, exp);
            }
        }
    }
}
