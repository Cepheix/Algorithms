using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DataStructures.Graphs
{
    public abstract class Graph
    {
        /// <summary>
        /// Create an empty graph with V verivcies
        /// </summary>
        /// <param name="V"></param>
        public Graph(int V)
        {
        }

        /// <summary>
        /// Add an edge connecting verticies v-w
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        public abstract void AddEdge(int v, int w);

        /// <summary>
        /// Get vericies adjacent to v
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public abstract IEnumerable<int> Adjacent(int v);

        /// <summary>
        /// Number of vericies
        /// </summary>
        /// <returns></returns>
        public abstract int V();

        /// <summary>
        /// Number of edges
        /// </summary>
        /// <returns></returns>
        public abstract int E();

        /// <summary>
        /// String representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int v = 0; v < V(); v++)
            {
                foreach (int w in Adjacent(v))
                {
                    result.Append(String.Format("{0} - {1}", v, w));
                }
            }

            return result.ToString();
        }
    }
}
