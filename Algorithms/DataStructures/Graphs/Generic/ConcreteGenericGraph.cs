using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs.Generic
{
    public class ConcreteGenericGraph<T> : GenericGraph<T>
    {
        private Graph _graph;
        private Dictionary<T, int> _matchingTable;

        public ConcreteGenericGraph(int V) : base(V)
        {
            this._matchingTable = new Dictionary<T, int>();
            this._graph = new AdjacentListGraph(V);
        }

        public override void AddEdge(T v, T w)
        {
            this._graph.AddEdge(_matchingTable[v], _matchingTable[w]);
        }

        public override IEnumerable<T> Adjacent(T v)
        {
            //List<T> result = new List<T>();

            //foreach (int x in this._graph.Adjacent(_matchingTable[v]))
            //{
            //    result.Add(_matchingTable[x]);
            //}

            throw new NotImplementedException();
        }

        public override int E()
        {
            return this._graph.E();
        }

        public override int V()
        {
            return this._graph.V();
        }
    }
}
