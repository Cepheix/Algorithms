using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algorithms
{
    public class ArrayExtension
    {
        public static int BinarySearch(int[] table, int key)
        {
            int lo = 0;
            int hi = table.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (key < table[mid])
                {
                    hi = mid - 1;
                }
                else if (key > table[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public static int BinarySearch<T>(T[] array, T key) where T : IComparable<T>
        {
            int lo = 0;
            int hi = array.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (key.CompareTo(array[mid]) < 0)
                {
                    hi = mid - 1;
                }
                else if (key.CompareTo(array[mid]) > 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}
