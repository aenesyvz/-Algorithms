using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgorithm
{
    public class Node
    {
        //Düğüm için gerekli özellikler
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public List<bool> TraverseTree(char symbol, List<bool> value)
        {
            // Yaprak
            if (Right == null && Left == null)
            {
                if (symbol.Equals(this.Symbol))
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> leftList = null;
                List<bool> rightList = null;

                if (Left != null)
                {
                    List<bool> leftWay = new List<bool>();
                    leftWay.AddRange(value);
                    leftWay.Add(false);

                    leftList = Left.TraverseTree(symbol, leftWay);
                }

                if (Right != null)
                {
                    List<bool> rightWay = new List<bool>();
                    rightWay.AddRange(value);
                    rightWay.Add(true);
                    rightList = Right.TraverseTree(symbol, rightWay);
                }

                if (leftList != null)
                {
                    return leftList;
                }
                else
                {
                    return rightList;
                }
            }
        }
    }
}
