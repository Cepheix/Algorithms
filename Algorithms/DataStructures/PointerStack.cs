using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class PointerStack<T> : IStack<T>
    {
        private Node _first;

        PointerStack()
        {
            this._first = null;
        }

        public void Push(T item)
        {
            // save a link to the list
            Node oldFirst = _first;

            // create a new node for the beginning
            _first = new Node();

            // set the instance variable in the new node
            _first.Item = item;
            _first.Next = oldFirst;
        }

        public T Pop()
        {
            // save item to return
            Node returnItem = _first;

            // delete first node and set its pointer to next element as new first
            _first = _first.Next;

            // return saved item
            return returnItem.Item;
        }

        public bool IsEmpty()
        {
            return _first == null;
        }

        public int Size()
        {
            int result = 0;

            Node currentElement = _first;

            while (currentElement != null)
            {
                currentElement = currentElement.Next;
                result++;
            }

            return result;
        }

        private class Node
        {
            public T Item;
            public Node Next;
        }
    }
}
