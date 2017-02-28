using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Strukura danych - tablica gdzie każdemu elementowi na początku odpowiada jego indeks
    /// Przy połączeniu dwóch elementów należy zmienić id jednego elementu
    /// na drugi element (jego indeks)
    /// wtedy ten element do niego wskazuje a pierwszy jest jego korzeniem (root)
    /// przy kolejnym łączeniu należy zmienić id roota tego elementu na element (indeks), który jest rootem drugiego elementu
    /// </summary>
    public class QuickUnion
    {
        private int[] _id;

        public QuickUnion(int N)
        {
            _id = new int[N];

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

            _id[i] = j;
        }
    }
}
