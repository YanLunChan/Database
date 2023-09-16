using System;
using System.Collections.Generic;
using System.Numerics;

namespace Sorting_Algorithms.Shortest_Path.Graph
{
    public class Dijkstra_Algorithm<V> 
    {
        protected Graph<V, float> graph;
        protected Vertex<V, float> start;
        public Dijkstra_Algorithm(Graph<V, float> g, Vertex<V, float> s)
        {
            graph = g;
            start = s;
        }
        public void execute(Vertex<V, float> target)
        {
            //three variables are needed the vertex, edge, and total distance travel from start point to desired vertex
            Dictionary<Vertex<V, float>, (Edge<float, V>, float)> shortestRoute = new Dictionary<Vertex<V, float>, (Edge<float, V>, float)>();
            //create starting point dictionary
            shortestRoute.Add(start, (null, 0));
            Dijkstra(start, target, shortestRoute);

            //check if there's a path...
            try
            {
                DisplayDic(shortestRoute, target);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Path does not exist.", ex);
            }

        }
        public void Dijkstra(Vertex<V, float> v, Vertex<V, float>  target, Dictionary<Vertex<V, float>, (Edge<float, V>, float)> c)
        {

            // for every incident edge e on vertex v
            foreach (Edge<float, V> e in graph.incidentEdges(v))
            {
                Vertex<V, float> other = graph.opposite(v, e);
                //check if vertex is in the dictionary if not create
                if (!c.ContainsKey(other))
                {
                    float total = Convert.ToSingle(e.getElement()) + Convert.ToSingle(c[v].Item2);
                    c.Add(other, (e, total));
                    Dijkstra(other,target, c);
                }
                //already exist
                else
                {
                    //compare current dictionary value from start to element of edge
                    int overwrite = Convert.ToInt32(c[other].Item2) + Convert.ToInt32(e.getElement());
                    if (overwrite < c[v].Item2)
                        c[v] = (e, overwrite);
                }
            }
        }
        public void DisplayDic(Dictionary<Vertex<V, float>, (Edge<float, V>, float)> dic, Vertex<V, float> endPoint)
        {
            //testing each iteration
            //foreach (var v in dic)
            //    Console.WriteLine($"Vertex : {v.Key.getElement()} , distance from start : {v.Value.Item2} ,");
            List<Vertex<V, float>> result = new List<Vertex<V, float>>();
            CalculateDirection(dic, endPoint, result);
            Console.WriteLine($"The following Path to {endPoint.getElement()} is ...");
            for (int i = result.Count - 1; i >= 0; i--)
                Console.WriteLine(result[i].getElement() + " weight of:  " + dic[result[i]].Item1?.getElement());
        }
        public void CalculateDirection(Dictionary<Vertex<V, float>, (Edge<float, V>, float)> d, Vertex<V, float> v, List<Vertex<V, float>> resultB)
        {
            //it's backwards so make sure to reverse the order when showing result on display
            resultB.Add(v);
            if (v == start)
                return;
            CalculateDirection(d, graph.opposite(v, d[v].Item1), resultB);
        }
    }
}
