namespace Algorithms.DataStructures.Graphs
{
    public class Edge : AbstractEdge
    {
        private readonly int _v;
        private readonly int _w;
        private readonly double _weight;

        public Edge(int v, int w, double weight) : base(w, v, weight)
        {
            this._v = v;
            this._w = w;
            this._weight = weight;
        }

        public override int CompareTo(AbstractEdge other)
        {
            if (this._weight < other.Weight())
                return -1;
            else if (this._weight > other.Weight())
                return +1;
            else return 0;
        }

        public override int Either()
        {
            return _v;
        }

        public override int Other(int vertex)
        {
            if (vertex == _v)
                return _w;
            else
                return _v;
        }

        public override double Weight()
        {
            return _weight;
        }
    }
}
