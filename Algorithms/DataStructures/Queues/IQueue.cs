using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public interface IQueue<T>
    {
        void Enque(T item);
        T Deque();
        bool IsEmpty();
        int Size();
    }
}
