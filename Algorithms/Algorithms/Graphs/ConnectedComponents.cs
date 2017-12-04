using Algorithms.DataStructures.Graphs;

namespace Algorithms.Algorithms.Graphs
{
    /// <summary>
    /// find connected components in G 
    /// </summary>
    public class ConnectedComponents
    {
        private bool[] _marked;
        private int[] _id;
        private int _count;

        public ConnectedComponents(Graph graph)
        {
            _marked = new bool[graph.V()];
            _id = new int[graph.V()];

            for (int v = 0; v < graph.V(); v++)
            {
                if (!_marked[v])
                {
                    Dfs(graph, v);
                    _count++;
                }
            }
        }

        /// <summary>
        /// are v and w connected?
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool Connected(int v, int w)
        {
            return _id[v] == _id[w];
        }

        /// <summary>
        /// number of connected components
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this._count;
        }

        /// <summary>
        /// component identifier for v
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int Id(int v)
        {
            return _id[v];
        }

        private void Dfs(Graph graph, int v)
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
    }
}
