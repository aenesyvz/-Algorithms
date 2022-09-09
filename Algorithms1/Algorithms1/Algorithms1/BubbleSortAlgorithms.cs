using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms1
{
    public class BubbleSortAlgorithms : IAlgorithmService
    {
        public void Work(List<int> values)
        {
            int temp;
            for (int i = 0; i < values.Count - 1; i++)
            {
                for (int j = 1; j < values.Count - i; j++)
                {
                    if (values[j] < values[j - 1])
                    {
                        temp = values[j - 1];
                        values[j - 1] = values[j];
                        values[j] = temp;
                    }
                }
            }
        }
    }
}
