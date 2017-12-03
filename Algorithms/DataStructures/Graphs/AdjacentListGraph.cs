using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public class AdjacentListGraph : Graph
    {
        private readonly int _v;
        private List<int>[] _adj;

        public AdjacentListGraph(int V) : base(V)
        {
            this._v = V;
            this._adj = new List<int>[V];

            for (int v = 0; v < V; v++)
            {
                this._adj[v] = new List<int>();
            }
        }

        public override void AddEdge(int v, int w)
        {
            this._adj[v].Add(w);
            this._adj[w].Add(v);
        }

        public override IEnumerable<int> Adjacent(int v)
        {
            return this._adj[v];
        }

        public override int E()
        {
            throw new NotImplementedException();
        }

        public override int V()
        {
            return this._v;
        }
    }
}
