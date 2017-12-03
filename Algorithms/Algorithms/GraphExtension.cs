using Algorithms.DataStructures.Graphs;

namespace Algorithms.Algorithms
{
    public static class GraphExtension
    {
        /// <summary>
        /// compute the degree of v
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static int Degree(this Graph graph, int v)
        {
            int degree = 0;

            foreach (int w in graph.Adjacent(v))
            {
                degree++;
            }

            return degree;
        }


        /// <summary>
        /// Compute maximum degree of graph
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static int MaxDegree(this Graph graph)
        {
            int max = 0;

            for (int v = 0; v < graph.V(); v++)
            {
                if (Degree(graph, v) > max)
                {
                    max = Degree(graph, v);
                }
            }

            return max;
        }

        /// <summary>
        /// Compute average degree of graph
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static double AverageDegree(this Graph graph)
        {
            return 2.0 * graph.E() / graph.V();
        }

        /// <summary>
        /// Count self loops
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static int NumberOfSelfLoops(Graph graph)
        {
            int count = 0;

            for (int v = 0; v < graph.V(); v++)
            {
                foreach (int w in graph.Adjacent(v))
                {
                    if (v == w)
                    {
                        count++;
                    }
                }
            }

            return count / 2;
        }
    }
}
