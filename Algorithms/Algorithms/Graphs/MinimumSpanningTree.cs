using Algorithms.DataStructures.Graphs;
using System.Collections.Generic;

namespace Algorithms.Algorithms.Graphs
{
    public abstract class MinimumSpanningTree
    {
        MinimumSpanningTree(EdgeWeightedAbstractGraph graph) { }

        public abstract IEnumerable<Edge> Edges();
        public abstract double Weight();
    }
}
