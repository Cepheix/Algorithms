using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.DataStructures.Graphs;

namespace Algorithms.Algorithms.Graphs
{
    public class BreadthFirstSearchPaths : Paths
    {
        private bool[] _marked;
        private int[] _edgeTo;

        public BreadthFirstSearchPaths(Graph graph, int s) : base(graph, s)
        {
            this._marked = new bool[graph.V()];
            this._edgeTo = new int[graph.V()];

            Bfs(graph, s);
        }

        public override bool HasPathTo(int v)
        {
            return _marked[v];
        }

        public override IEnumerable<int> PathTo(int v)
        {
            throw new NotImplementedException();
        }

        private void Bfs(Graph g, int s)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            _marked[s] = true;
            while (q.Any())
            {
                int v = q.Dequeue();
                foreach (int w in g.Adjacent(v))
                {
                    if (!_marked[w])
                    {
                        q.Enqueue(w);
                        _marked[w] = true;
                        _edgeTo[w] = v;
                    }
                }
            }
        }
    }
}
