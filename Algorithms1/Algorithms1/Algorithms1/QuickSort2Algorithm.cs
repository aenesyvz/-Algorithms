using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms1
{
    public class QuickSort2Algorithm : IAlgorithmService
    {
        static void swap(List<int> arr, int low, int pivot)
        {
            int tmp = arr[low];
            arr[low] = arr[pivot];
            arr[pivot] = tmp;
        }
        static int partition(List<int> arr, int low, int high)
        {
            int p = low, j;
            for (j = low + 1; j <= high; j++)
                if (arr[j] < arr[low])
                    swap(arr, ++p, j);

            swap(arr, low, p);
            return p;
        }

        static void quicksort(List<int> values, int low, int high)
        {
            if (low < high)
            {
                int p = partition(values, low, high);
                quicksort(values, low, p - 1);
                quicksort(values, p + 1, high);
            }
        }
        public void Work(List<int> values)
        {
            quicksort(values, 0, values.Count - 1);
        }
    }
}
