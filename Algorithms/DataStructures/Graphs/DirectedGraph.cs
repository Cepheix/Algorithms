using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public abstract class DirectedGraph : Graph
    {
        public DirectedGraph(int V) : base(V)
        {
        }

        public abstract DirectedGraph Reverse();
    }
}
