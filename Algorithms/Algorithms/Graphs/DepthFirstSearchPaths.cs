using System.Collections.Generic;
using Algorithms.DataStructures.Graphs;

namespace Algorithms.Algorithms.Graphs
{
    public class DepthFirstSearchPaths : Paths
    {
        private bool[] _marked;
        private int[] _edgeTo;
        private int _s;

        public DepthFirstSearchPaths(Graph graph, int s) : base(graph, s)
        {
            this._s = s;
            this._marked = new bool[graph.V()];
            this._edgeTo = new int[graph.V()];

            Dfs(graph, s);
        }

        public override bool HasPathTo(int v)
        {
            return _marked[v];
        }

        public override IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();

            for (int x = v; x != _s; x = _edgeTo[x])
            {
                path.Push(x);
            }

            return path;
        }

        private void Dfs(Graph graph, int v)
        {
            _marked[v] = true;
            foreach (int w in graph.Adjacent(v))
            {
                if (!_marked[w])
                {
                    Dfs(graph, w);
                    _edgeTo[w] = v;
                }
            }
        }
    }
}
