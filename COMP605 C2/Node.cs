using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP605_C2
{
    internal class Node
    {
        public string Word { get; set; }
        public int LengthCount { get; set; }

        public Node Next { get; set; }
        public Node Prev { get; set; }
        

        public Node()
        {
            Next = null;
            Prev = null;
            Word = null;
            LengthCount = 0;
        }

        public Node(string word)
        {
            this.Word = word;
            LengthCount = word.Length;
            Next = null;
            Prev = null;
        }

        // Print method to output the contents of the node
        public string ToPrint()
        {
            return Word.ToString();
        }
    }
}

