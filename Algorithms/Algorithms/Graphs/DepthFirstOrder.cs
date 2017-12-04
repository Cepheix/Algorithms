using Algorithms.DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algorithms.Graphs
{
    public class DepthFirstOrder
    {
        private bool[] _marked;
        private Stack<int> _reversePost;
        public DepthFirstOrder(DirectedGraph graph)
        {
            _reversePost = new Stack<int>();
            _marked = new bool[graph.V()];
            for (int v = 0; v < graph.V(); v++)
            {
                if (!_marked[v])
                {
                    dfs(graph, v);
                }
            }
        }
        private void dfs(DirectedGraph graph, int v)
        {
            _marked[v] = true;
            foreach (int w in graph.Adjacent(v))
            {
                if (!_marked[w])
                {
                    dfs(graph, w);
                }
            }

            _reversePost.Push(v);
        }
        public IEnumerable<int> ReversePost()
        {
            return _reversePost;
        }
    }
}
