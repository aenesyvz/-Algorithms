using System.Collections.Generic;

namespace Algorithms1
{
    public class ShellSortAlgorithms : IAlgorithmService
    {
        public void Work(List<int> values)
        {
            int n = values.Count;
            int temp,j;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    temp = values[i];

                   
                    for (j = i; j >= gap && values[j - gap] > temp; j -= gap)
                        values[j] = values[j - gap];

                    values[j] = temp;
                }
            }
        }
    }
}
