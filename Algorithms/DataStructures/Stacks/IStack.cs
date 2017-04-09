using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public interface IStack<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty();
        int Size();
    }
}
