using System.Collections.Generic;

namespace Algorithms1
{
    public class InsertionSortAlgorithms : IAlgorithmService
    {
        public void Work(List<int> values)
        {
            int key, i;
            for (int j = 1; j < values.Count; j++)
            {
                key = values[j];
                i = j - 1; 
                while (i >= 0 && values[i] > key)
                {
                    values[i + 1] = values[i];  
                    i = i - 1;  
                }
                values[i + 1] = key;
            }
        }
    }
}
