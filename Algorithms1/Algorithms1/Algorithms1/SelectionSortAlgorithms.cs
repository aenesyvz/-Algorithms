using System.Collections.Generic;

namespace Algorithms1
{
    public class SelectionSortAlgorithms : IAlgorithmService
    {
        public void Work(List<int> values)
        {
            int n = values.Count;
            int temp;
            int min_idx;
            for (int i = 0; i < n - 1; i++)  
            {
                min_idx = i; 
                for (int j = i + 1; j < n; j++)
                    if (values[j] < values[min_idx])
                        min_idx = j;

                temp = values[min_idx];  
                values[min_idx] = values[i]; 
                values[i] = temp;
            }
        }
    }
}
