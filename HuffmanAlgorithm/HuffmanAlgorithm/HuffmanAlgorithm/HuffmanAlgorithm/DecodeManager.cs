using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgorithm
{          //Ödevde 2 tane kaynak kod istendiği için ayrı bir şekilde yazılmıştır.
    public class DecodeManager
    {
        HuffmanTreeManager _huffmanTreeManager;
        public DecodeManager(HuffmanTreeManager huffmanTreeManager)
        {
            _huffmanTreeManager = huffmanTreeManager;
        }
        public string Decode(BitArray bits)
        {
           
            Node instantNode = _huffmanTreeManager.Base;
            string result = "";

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (instantNode.Right != null)
                    {
                        instantNode = instantNode.Right;
                    }
                }
                else
                {
                    if (instantNode.Left != null)
                    {
                        instantNode = instantNode.Left;
                    }
                }

                if (_huffmanTreeManager.CheckLeaf(instantNode))
                {
                    result += instantNode.Symbol;
                    instantNode = _huffmanTreeManager.Base;
                }
            }

            return result;
        }
    }
}
