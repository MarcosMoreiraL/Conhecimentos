using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Algorithms
{
    public class FloydWarshallPathFinding
    {
        public static void FloydWarshalAlgorithm(int[,] graph, int verticesCount)
        {
            int[,] distance = new int[verticesCount, verticesCount];

            for(int i = 0; i < verticesCount; i++)
                for(int j = 0; j < verticesCount; j++)
                    distance[i, j] = graph[i, j];

            for (int k = 0; k < verticesCount; k++)
                for (int l = 0; l < verticesCount; l++)
                    for (int m = 0; m < verticesCount; m++)
                    {
                        if (distance[l,k] + distance[k,m] < distance[l, m])
                            distance[l,m] = distance[l,k] + distance[k,m];
                    }
        }
    }
}
