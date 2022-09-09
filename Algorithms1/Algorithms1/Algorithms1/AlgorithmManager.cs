using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms1
{
    public class AlgorithmManager
    {
        public void WorkAlgorithm(IAlgorithmService algorithmService,List<int> values)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            algorithmService.Work(values);
            stopwatch.Stop();
            Console.WriteLine("Algorithm run time : {0} milliseconds",stopwatch.Elapsed.TotalMilliseconds);
    
        }
    }
}
