using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2
{
    public class AlgorithmManager
    {
        public void Work(IAlgorithmService algorithmService,List<int> values)
        {
            algorithmService.Work(values);
        }
    }
}
