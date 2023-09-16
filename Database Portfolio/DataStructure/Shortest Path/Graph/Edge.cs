using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Shortest_Path.Graph
{
    public class Edge<E, V> : DecorablePosition<E>
    {
        protected E weight;
        protected Vertex<V, E> origin, destination;

        protected Dictionary<string, string> assignedLabels;

        public Edge(Vertex<V, E> o, Vertex<V, E> d)
        {
            origin = o;
            destination = d;
            o.addIncidentEdge(this);
            d.addIncidentEdge(this);
            assignedLabels = new Dictionary<string, string>();
        }
        public Edge(Vertex<V, E> o, Vertex<V, E> d, E w)
            : this(o, d)
        {
            weight = w;
        }

        public E getElement()
        {
            return weight;
        }
        public void setWeight(E w)
        {
            weight = w;
        }
        public Vertex<V, E>[] endVertices()
        {
            Vertex<V, E>[] x = { origin, destination };
            return x;
        }

        public void removingEdge()
        {
            origin.getIncidentEdges().Remove(this);
            destination.getIncidentEdges().Remove(this);
        }

        public void put(string k, string x)
        {
            assignedLabels[k] = x;
        }
        public string get(string k)
        {
            return assignedLabels[k];
        }
        public string remove(string k)
        {
            string removedValue = assignedLabels[k];
            if (assignedLabels.Remove(k))
                return removedValue;
            return "";
        }
        public Dictionary<string, string> entrySet()
        {
            return assignedLabels;
        }

        ////add Icomparable to compare other values return 1
        //public int CompareTo(E other) 
        //{
        //    return getElement().CompareTo(other);
        //}
    }
}
