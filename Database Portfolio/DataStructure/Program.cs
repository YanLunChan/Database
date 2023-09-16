using System;
using Trees;
using Sorting_Algorithms;
using Sorting_Algorithms.Shortest_Path.Graph;

class Program
{
    static void Main(string[] args)
    {
        //Create Menu here
        //Sort_Main.RunSorting();
        Tree_Main.RunTree();
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        Run_Pathfinding();
        Console.ReadLine();
    }

    public static void Run_Pathfinding() 
    {
        //example pathfinding thing goes here.
        //initialize the graph
        Graph<char, float> g = new AdjacencyListGraph<char, float>();

        Vertex<char, float> a = g.insertVertex('a');
        Vertex<char, float> b = g.insertVertex('b');
        Vertex<char, float> c = g.insertVertex('c');
        Vertex<char, float> d = g.insertVertex('d');
        Vertex<char, float> e = g.insertVertex('e');
        Vertex<char, float> f = g.insertVertex('f');

        Edge<float, char> ab = g.insertEdge(a, b, 2f);
        Edge<float, char> ad = g.insertEdge(a, d, 8f);
        Edge<float, char> be = g.insertEdge(b, e, 6f);
        Edge<float, char> bd = g.insertEdge(b, d, 5f);
        Edge<float, char> de = g.insertEdge(d, e, 3f);
        Edge<float, char> df = g.insertEdge(d, f, 2f);
        Edge<float, char> ef = g.insertEdge(e, f, 1f);
        Edge<float, char> ec = g.insertEdge(e, c, 9f);
        Edge<float, char> fc = g.insertEdge(f, c, 3f);


        Dijkstra_Algorithm<char> q2 = new Dijkstra_Algorithm<char>(g, a);
        q2.execute(f);
    }
}
