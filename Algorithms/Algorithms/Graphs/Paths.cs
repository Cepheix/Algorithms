using Algorithms.DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algorithms.Graphs
{
    public abstract class Paths
    {
        /// <summary>
        /// find paths in graph from source s
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="s"></param>
        public Paths(Graph graph, int s)
        { }

        /// <summary>
        /// Is there a path from s to v
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public abstract bool HasPathTo(int v);

        /// <summary>
        /// Paths from s to v 
        /// null if there is no path
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public abstract IEnumerable<int> PathTo(int v);
    }
}
