namespace Shortest_Path__with_Dijkstra_s_algorithm_
{
    internal class Program
    {
        /// <summary>
        /// 用Dijkstra’s algorithm來找出最短路徑
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[,] graph = {
            {0, 2, 4, 0, 0},  // 城市0到其他城市的距離
            {2, 0, 3, 0, 0},  // 城市1到其他城市的距離
            {4, 3, 0, 1, 6},  // 城市2到其他城市的距離
            {0, 0, 1, 0, 6},  // 城市3到其他城市的距離
            {0, 0, 5, 4, 0}   // 城市4到其他城市的距離
        };

            int result = FindShortestPath(graph, 0, 4);
            Console.WriteLine("起點到終點的最短路徑距離為：" + result);
        }

        static int FindShortestPath(int[,] graph, int start, int end)
        {
            int nodesCount = graph.GetLength(0); // 找一維陣列的長度，即共有多少個城市
            int[] distance = new int[nodesCount];
            bool[] visited = new bool[nodesCount];

            // initialize
            for (int i = 0; i < nodesCount; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }

            distance[start] = 0;

            for (int i = 0; i < nodesCount - 1; i++)
            {
                int minDistance = int.MaxValue;
                int minIndex = -1;

                for (int j = 0; j < nodesCount; j++)
                {
                    if (!visited[j] && distance[j] < minDistance)
                    {
                        minDistance = distance[j];
                        minIndex = j;
                    }
                }

                visited[minIndex] = true;

                for (int j = 0; j < nodesCount; j++)
                {
                    if (!visited[j] && graph[minIndex, j] != 0 && distance[minIndex] != int.MaxValue &&
                        distance[minIndex] + graph[minIndex, j] < distance[j])
                    {
                        distance[j] = distance[minIndex] + graph[minIndex, j];
                    }
                }
            }

            return distance[end];
        }
    }
}