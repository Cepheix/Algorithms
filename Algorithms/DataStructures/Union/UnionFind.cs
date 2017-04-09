using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Strukura danych - tablica gdzie każdemu elementowi na początku odpowiada jego indeks
    /// Przy połączeniu dwóch elementów należy zmienić id jednego elementu (i wszystkich które są z nim połączone)
    /// na drugi element (jego indeks)
    /// </summary>
    public class UnionFind
    {
        private int[] _id;

        public UnionFind(int N)
        {
            this._id = new int[N];
            for (int i = 0; i < N; ++i)
            {
                _id[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            int pid = _id[p];
            int qid = _id[q];

            for (int i = 0; i < _id.Length; i++)
            {
                if (_id[i] == pid)
                {
                    _id[i] = qid;
                }
            }
        }

        public bool Connected(int p, int q)
        {
            return _id[p] == _id[q];
        }

        int Count()
        {
            return _id.Length;
        }
    }
}
