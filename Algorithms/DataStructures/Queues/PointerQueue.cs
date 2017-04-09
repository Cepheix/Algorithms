using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class PointerQueue<T> : IQueue<T>
    {
        private Node _first;
        private Node _last;
        private int _count;

        public PointerQueue()
        {
            this._first = null;
            this._last = null;
            this._count = 0;
        }

        public void Enque(T item)
        {
            Node oldLast = this._last;
            this._last = new Node();
            this._last.Item = item;
            this._last.Next = null;

            if (IsEmpty())
            {
                this._first = this._last;
            }
            else
            {
                oldLast.Next = this._last;
            }
        }

        public T Deque()
        {
            T returnItem = this._first.Item;
            this._first = this._first.Next;

            if (IsEmpty())
            {
                this._last = null;
            }

            return returnItem;
        }

        public bool IsEmpty()
        {
            return this._first == null;
        }

        public int Size()
        {
            return this._count;
        }

        private class Node
        {
            public T Item;
            public Node Next;
        }
    }
}
