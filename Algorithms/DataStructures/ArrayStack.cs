using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    class ArrayStack<T> : IStack<T>
    {
        private T[] _stack;
        private int _current;

        public ArrayStack()
        {
            this._stack = new T[10];
            this._current = 0;
        }

        public void Push(T item)
        {
            // if array is to small resize
            if (_current >= _stack.Length)
            {
                Resize();
            }

            // get the item at current index and return it
            _stack[_current] = item;
            _current++;
        }

        public T Pop()
        {
            // get the last item in stack
            T returnItem = _stack[_current - 1];

            // set the last item in array as null and decrement the current index
            _stack[_current - 1] = default(T);
            _current--;

            // return the previous saved item
            return returnItem;
        }

        public bool IsEmpty()
        {
            return _current <= 0;
        }

        public int Size()
        {
            return _current;
        }

        private void Resize()
        {
            T[] newStack = new T[2 * this._stack.Length];

            for (int i = 0; i < _stack.Length; i++)
            {
                newStack[i] = _stack[i];
            }

            this._stack = newStack;
        }
    }
}
