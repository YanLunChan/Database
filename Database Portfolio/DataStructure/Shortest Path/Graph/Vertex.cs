using System.Collections.Generic;


namespace Sorting_Algorithms.Shortest_Path.Graph
{
    public class Vertex<V, E> : DecorablePosition<V>
    {
        protected V label;
        protected List<Edge<E, V>> incidentEdges;

        protected Dictionary<string, string> assignedLabels;

        public Vertex()
        {
            incidentEdges = new List<Edge<E, V>>();
            assignedLabels = new Dictionary<string, string>();
        }
        public Vertex(V l)
            : this()
        {
            label = l;
        }
        public V getElement()
        {
            return label;
        }
        public void setLabel(V l)
        {
            label = l;
        }

        public List<Edge<E, V>> getIncidentEdges()
        {
            return incidentEdges;
        }
        public void addIncidentEdge(Edge<E, V> e)
        {
            incidentEdges.Add(e);
        }
        public void clearIncidentEdges()
        {
            incidentEdges.Clear();
        }

        public int getDegree()
        {
            return incidentEdges.Count;
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
    }
}
