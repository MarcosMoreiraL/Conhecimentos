using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Algorithms
{
    public class LeePathFinding
    {
        public class Node
        {
            public int x, y, distance;

            public Node(int x, int y, int distance)
            {
                this.x = x;
                this.y = y;
                this.distance = distance;
            }
        }

        private static int[] row = { -1, 0, 0, 1 };
        private static int[] column = { 0, -1, 1, 0 };

        private static bool IsValid(int[][] matrix, bool[][] visited, int row, int col)
        {
            return (row >= 0) && (row < 10) && (col >= 0) && (col < 10) && (matrix[row][col] == 1) && !visited[row][col];
        }
        public static void LeeAlgorithm()
        {
            int[][] matrix = new int[10][];

            matrix[0] = new int[10] { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
            matrix[1] = new int[10] { 0, 1, 1, 1, 1, 1, 0, 1, 0, 1 };
            matrix[2] = new int[10] { 0, 0, 1, 0, 1, 1, 1, 0, 0, 1 };
            matrix[3] = new int[10] { 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 };
            matrix[4] = new int[10] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 };
            matrix[5] = new int[10] { 1, 0, 1, 1, 1, 0, 0, 1, 1, 0 };
            matrix[6] = new int[10] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 };
            matrix[7] = new int[10] { 0, 1, 1, 1, 1, 1, 1, 1, 0, 0 };
            matrix[8] = new int[10] { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
            matrix[9] = new int[10] { 0, 0, 1, 0, 0, 1, 1, 0, 0, 1 };

            int i = 0, j = 0, x = 6, y = 4;

            bool[][] visited = new bool[10][];

            for (int c = 0; c < 10; c++)
                visited[c] = new bool[10];


            Queue<Node> queue = new Queue<Node>();
            visited[i][j] = true;
            queue.Enqueue(new Node(i, j, 0));

            int minimumDistance = int.MaxValue;

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                i = node.x;
                j = node.y;
                int dist = node.distance;

                if (i == x && j == y)
                {
                    minimumDistance = dist;
                    break;
                }

                for (int k = 0; k < 4; k++)
                {
                    if (IsValid(matrix, visited, i + row[k], j + column[k]))
                    {
                        visited[i + row[k]][j + column[k]] = true;
                        queue.Enqueue(new Node(i + row[k], j + column[k], dist + 1));
                    }
                }
            }

            if (minimumDistance != int.MaxValue)
                Console.WriteLine("Shortest path lenght: " + minimumDistance);
            else
                Console.WriteLine("Destination or Source invalid!");
        }

        public static void LeeAlgorithm(int[][] matrix, int i, int j, int x, int y)
        {
            bool[][] visited = new bool[10][];

            for (int c = 0; c < 10; c++)
                visited[c] = new bool[10];


            Queue<Node> queue = new Queue<Node>();
            visited[i][j] = true;
            queue.Enqueue(new Node(i, j, 0));

            int minimumDistance = int.MaxValue;

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                i = node.x;
                j = node.y;
                int dist = node.distance;

                if (i == x && j == y)
                {
                    minimumDistance = dist;
                    break;
                }

                for (int k = 0; k < 4; k++)
                {
                    if (IsValid(matrix, visited, i + row[k], j + column[k]))
                    {
                        visited[i + row[k]][j + column[k]] = true;
                        queue.Enqueue(new Node(i + row[k], j + column[k], dist + 1));
                    }
                }
            }

            if (minimumDistance != int.MaxValue)
                Console.WriteLine("Shortest path lenght: " + minimumDistance);
            else
                Console.WriteLine("Destination or Source invalid!");
        }
    }
}
