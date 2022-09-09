using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgorithm
{        //Ödevde 2 tane kaynak kod istendiği için ayrı bir şekilde yazılmıştır.
    public class EncodeManager
    {
        HuffmanTreeManager _huffmanTreeManager;
        public EncodeManager(HuffmanTreeManager huffmanTreeManager)
        {
            _huffmanTreeManager = huffmanTreeManager;
        }
        public BitArray Encode(string input)
        {
            
            List<bool> result = new List<bool>();

            for (int i = 0; i < input.Length; i++)
            {
                List<bool> nodeSymbol = _huffmanTreeManager.Base.TraverseTree(input[i], new List<bool>());
                result.AddRange(nodeSymbol);
            }

            BitArray bitArray = new BitArray(result.ToArray());

            return bitArray;
        }

    }
}
