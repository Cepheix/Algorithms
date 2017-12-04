using Algorithms.DataStructures.Graphs;

namespace Algorithms.Algorithms.Graphs
{
    public class StrongConnectedComponent
    {
        private bool[] _marked;
        private int[] _id;
        private int _count;
        public StrongConnectedComponent(DirectedGraph graph)
        {
            _marked = new bool[graph.V()];
            _id = new int[graph.V()];
            DepthFirstOrder dfs = new DepthFirstOrder(graph.Reverse());
            foreach (int v in dfs.ReversePost())
            {
                if (!_marked[v])
                {
                    Dfs(graph, v);
                    _count++;
                }
            }
        }
        private void Dfs(DirectedGraph graph, int v)
        {
            _marked[v] = true;
            _id[v] = _count;
            foreach (int w in graph.Adjacent(v))
            {
                if (!_marked[w])
                {
                    Dfs(graph, w);
                }
            }
        }
        public bool stronglyConnected(int v, int w)
        {
            return _id[v] == _id[w];
        }
    }
}
