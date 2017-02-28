using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class WeightedQuickUnion
    {
        private int[] _id;
        private int[] _sz;

        public WeightedQuickUnion(int N)
        {
            _id = new int[N];
            _sz = new int[N];

            for (int i = 0; i < N; i++)
            {
                _id[i] = i;
            }
        }

        private int Root(int i)
        {
            while (i != _id[i])
            {
                i = _id[i];
            }

            return i;
        }

        public bool Conntected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);

            if (i == j)
                return;

            if (_sz[i] < _sz[j])
            {
                _id[i] = j;
                _sz[j] += _sz[i];
            }
            else
            {
                _id[j] = i;
                _sz[i] += _sz[j];
            }

            _id[i] = j;
        }
    }
}
