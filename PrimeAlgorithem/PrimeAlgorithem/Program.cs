using System;

namespace PrimeAlgorithem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = GraphGenerator.GenerateUndirectedGraphWithCircles(5, 8, 7);
            graph.PrintGraph();

            DFS.RunDFS(graph, graph.Vertices[0]);

            var mstTree = Prime.GetMstPrim(graph, graph.Vertices[0]);
            mstTree.PrintGraph();

        }
    }
}
