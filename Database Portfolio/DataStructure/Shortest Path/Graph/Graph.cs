using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Shortest_Path.Graph
{
    public interface Graph<V, E>
    {
        // Return an iterable collection of all the vertices of the graph
        IEnumerable<Vertex<V, E>> vertices();
        // Return an iterable collection of all the edges of the graph
        IEnumerable<Edge<E, V>> edges();
        // Return an iterable collection of all edges incident upon vertex v
        IEnumerable<Edge<E, V>> incidentEdges(Vertex<V, E> v);
        // Return the end vertex of edge e distinct from vertex v
        // - an error occurs of e is not incident on v
        Vertex<V, E> opposite(Vertex<V, E> v, Edge<E, V> e);
        // Return an array storing the end vertices of edge e
        Vertex<V, E>[] endVertices(Edge<E, V> e);
        // Test whether vertices v and w are adjacent
        bool areAdjacent(Vertex<V, E> v, Vertex<V, E> w);
        // Replace the element stored at vertex v with x
        V replace(Vertex<V, E> v, V x);
        // Replace the element stored at edge e with x
        E replace(Edge<E, V> e, E x);
        // Insert and return a new vertex storing element x
        Vertex<V, E> insertVertex(V x);
        // Insert and return a new undirected edge with end vertices v and w
        //                                             and storing element x
        Edge<E, V> insertEdge(Vertex<V, E> v, Vertex<V, E> w, E x);
        // Remove vertex v and all its incident edges and return the element stored at v
        V removeVertex(Vertex<V, E> v);
        // Remove edge e and return the element stored at e
        E removeEdge(Edge<E, V> e);
    }

    public class AdjacencyListGraph<V, E> : Graph<V, E>
    {
        // From the definition, a graph is defined using two sets
        // 1. The set V containing the vertices of the graph
        // 2. The set E containing the edges (pairs of vertices) of the graph
        // NOTE: In C# we use the List data structure to store the sets V and E
        protected List<Vertex<V, E>> gVertices;
        protected List<Edge<E, V>> gEdges;

        public AdjacencyListGraph()
        {
            gVertices = new List<Vertex<V, E>>();
            gEdges = new List<Edge<E, V>>();
        }

        // Return an iterable collection of all the vertices of the graph
        public IEnumerable<Vertex<V, E>> vertices()
        {
            return gVertices;
        }
        // Return an iterable collection of all the edges of the graph
        public IEnumerable<Edge<E, V>> edges()
        {
            return gEdges;
        }
        // Return an iterable collection of all edges incident upon vertex v
        public IEnumerable<Edge<E, V>> incidentEdges(Vertex<V, E> v)
        {
            return v.getIncidentEdges();
        }
        // Return the end vertex of edge e distinct from vertex v
        // - an error occurs of e is not incident on v
        public Vertex<V, E> opposite(Vertex<V, E> v, Edge<E, V> e)
        {
            Vertex<V, E>[] endVertices = e.endVertices();

            if (v == endVertices[0])
            {
                return endVertices[1];
            }
            else if (v == endVertices[1])
            {
                return endVertices[0];
            }
            else
            {
                throw new InvalidVertexException("Vertex is not incident on edge!");
            }
        }
        // Return an array storing the end vertices of edge e
        public Vertex<V, E>[] endVertices(Edge<E, V> e)
        {
            return e.endVertices();
        }
        // Test whether vertices v and w are adjacent
        // O(min(deg(v), deg(w))
        public bool areAdjacent(Vertex<V, E> v, Vertex<V, E> w)
        {
            Vertex<V, E> minDegree = v.getDegree() >= w.getDegree() ? w : v;
            Vertex<V, E> maxDegree = v.getDegree() < w.getDegree() ? w : v;

            foreach (Edge<E, V> incident in minDegree.getIncidentEdges())
                if (opposite(minDegree, incident) == maxDegree)
                    return true;
            return false;
        }
        // Replace the element stored at vertex v with x
        public V replace(Vertex<V, E> v, V x)
        {
            V oldLabel = v.getElement();
            v.setLabel(x);
            return oldLabel;
        }
        // Replace the element stored at edge e with x
        public E replace(Edge<E, V> e, E x)
        {
            E oldWeight = e.getElement();
            e.setWeight(x);
            return oldWeight;
        }
        // Insert and return a new vertex storing element x
        public Vertex<V, E> insertVertex(V x)
        {
            /// TODO: What happens if the vertex already exists?
            Vertex<V, E> newVertex = new Vertex<V, E>(x);
            gVertices.Add(newVertex);
            return newVertex;
        }
        // Insert and return a new undirected edge with end vertices v and w
        //                                             and storing element x
        public Edge<E, V> insertEdge(Vertex<V, E> v, Vertex<V, E> w, E x)
        {
            /// TODO: What happens if the edge already exists?
            /// TODO: What happens if v == w?
            Edge<E, V> newEdge = new Edge<E, V>(v, w, x);
            gEdges.Add(newEdge);
            return newEdge;
        }
        // Remove vertex v and all its incident edges and return the element stored at v
        public V removeVertex(Vertex<V, E> v)
        {
            V removedLabel = v.getElement();

            List<Edge<E, V>> removedEdges = new List<Edge<E, V>>();
            foreach (Edge<E, V> incident in v.getIncidentEdges())
            {
                removedEdges.Add(incident);
                gEdges.Remove(incident);
            }
            foreach (Edge<E, V> edge in removedEdges)
                edge.removingEdge();

            v.clearIncidentEdges();
            gVertices.Remove(v);

            return removedLabel;
        }
        // Remove edge e and return the element stored at e
        public E removeEdge(Edge<E, V> e)
        {
            E removedWeight = e.getElement();

            e.removingEdge();
            gEdges.Remove(e);

            return removedWeight;
        }
    }
}
