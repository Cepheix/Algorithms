using System;

namespace Algorithms.DataStructures.Graphs
{
    /// <summary>
    /// weighted edge v-w
    /// </summary>
    public abstract class AbstractEdge : IComparable<AbstractEdge>
    {
        public AbstractEdge(int v, int w, double weight)
        { }

        /// <summary>
        /// either endpoint
        /// </summary>
        /// <returns></returns>
        public abstract int Either();

        /// <summary>
        /// the endpoint that's not v
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public abstract int Other(int v);

        public abstract int CompareTo(AbstractEdge other);

        /// <summary>
        /// the weight
        /// </summary>
        /// <returns></returns>
        public abstract double Weight();
    }
}
