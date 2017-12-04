using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public class AdjacentListDirectedGraph : DirectedGraph
    {
        private readonly int _v;
        private readonly List<int>[] _adj;

        public AdjacentListDirectedGraph(int V) : base(V)
        {
            this._v = V;
            _adj = new List<int>[V];
            for (int v = 0; v < V; v++)
            {
                _adj[v] = new List<int>();
            }
        }

        public override void AddEdge(int v, int w)
        {
            _adj[v].Add(w);
        }

        public override IEnumerable<int> Adjacent(int v)
        {
            return _adj[v];
        }

        public override int E()
        {
            throw new NotImplementedException();
        }

        public override DirectedGraph Reverse()
        {
            throw new NotImplementedException();
        }

        public override int V()
        {
            return this._v;
        }
    }
}
