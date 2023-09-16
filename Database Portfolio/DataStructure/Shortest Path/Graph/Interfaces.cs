using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Shortest_Path.Graph
{
    public interface Position<T>
    {
        T getElement();
    }
    public interface DecorablePosition<T> : Position<T>
    {
        // Dictionary (Key-Value Data Structure)
        void put(string k, string x);
        string get(string k);
        string remove(string k);
        Dictionary<string, string> entrySet();
    }
}
