using System.Collections.Generic;

namespace Algorithms2
{
    public class QuickSortAlgorithm : IAlgorithmService
    {
        private static void Swap(List<int> arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


        private static int Partition(List<int> arr, int low, int high)
        {


            int pivot = arr[high];


            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {


                if (arr[j] < pivot)
                {


                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return (i + 1);
        }


        private static void QuickSort(List<int> arr, int low, int high)
        {
            if (low < high)
            {


                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }
        public void Work(List<int> values)
        {
            QuickSort(values, 0, values.Count - 1);
        }
    }
}
