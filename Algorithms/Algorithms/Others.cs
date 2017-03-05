using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algorithms
{
    public class Others
    {
        /// <summary>
        /// Sprawdza czy w tablicy licz całkowitych znajdują się 3 takie, których suma jest równa 0
        /// Złożoność obliczeniowa n^2 log(n)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool HasThreeSum(int[] array)
        {
            Array.Sort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length - 1; j++)
                {
                    if (ArrayExtension.BinarySearch(array, -1 * (array[i] + array[j])) != -1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
