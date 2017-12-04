using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public abstract class EdgeWeightedAbstractGraph
    {
        public EdgeWeightedAbstractGraph(int V)
        { }

        /// <summary>
        /// add weighted edge e to this graph
        /// </summary>
        /// <param name="edge"></param>
        public abstract void AddEdge(Edge edge);

        /// <summary>
        /// edges incident to v
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
        public abstract IEnumerable<Edge> Adjacent(Edge edge);

        /// <summary>
        /// all edges in this graph
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<Edge> Edges();

        /// <summary>
        /// number of vertices
        /// </summary>
        /// <returns></returns>
        public abstract int V();

        /// <summary>
        /// number of edges
        /// </summary>
        /// <returns></returns>
        public abstract int E();
    }
}
