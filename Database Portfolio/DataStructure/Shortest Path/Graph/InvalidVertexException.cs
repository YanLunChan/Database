using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Shortest_Path.Graph
{
    public class InvalidVertexException : Exception
    {
        public InvalidVertexException(String m) : base(m) {}
    }
}
