using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public class EdgeWeightedGraph : EdgeWeightedAbstractGraph
    {
        private readonly int _v;
        private readonly List<Edge>[] _adj;

        public EdgeWeightedGraph(int V) : base(V)
        {
            this._v = V;
            _adj = new List<Edge>[V];

            for (int v = 0; v < V; v++)
            {
                _adj[v] = new List<Edge>();
            }
        }

        public override void AddEdge(Edge edge)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Edge> Adjacent(Edge edge)
        {
            throw new NotImplementedException();
        }

        public override int E()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Edge> Edges()
        {
            throw new NotImplementedException();
        }

        public override int V()
        {
            throw new NotImplementedException();
        }
    }
}
