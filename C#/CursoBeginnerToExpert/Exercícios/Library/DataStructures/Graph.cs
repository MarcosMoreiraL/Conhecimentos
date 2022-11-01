using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Graph
    {
        public class GraphNode
        {
            public List<GraphNode> Neighbors { get; set; }
            public int Data { get; set; } = 0;
        }

        public int NumberOfVertices { get; set; }
        public List<GraphNode> Vertices { get; set; }

        public Graph(int size)
        {
            NumberOfVertices = size;
            Vertices = new List<GraphNode>();

            for (int i = 0; i < size; i++)
            {
                Vertices.Add(new GraphNode());
            }
        }

        public void AddEdge(GraphNode source, GraphNode destination)
        {
            source.Neighbors.Add(destination);
            destination.Neighbors.Add(source);
        }

        public void RemoveEdge(GraphNode source, GraphNode destination)
        {
            source.Neighbors.Remove(destination);
            destination.Neighbors.Remove(source);
        }

        public bool isAdjacent(GraphNode node1, GraphNode node2)
        {
            return node1.Neighbors.Contains(node2);
        }
    }
}
