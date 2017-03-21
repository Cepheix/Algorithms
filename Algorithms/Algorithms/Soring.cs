using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algorithms
{
    public static class Soring
    {

        /// <summary>
        /// Znajdź najmniejszy element na prawo od aktualnego indeksu, zamień go z nim i zwiększ indeks, powtórz dla wszystkich
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void SelectionSort<T>(IList<T> collection) where T : IComparable<T>
        {
            for (int i = 0; i < collection.Count; i++)
            {
                int min = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[min]) < 0)
                    {
                        min = j;
                    }
                }
                Swap(collection, i, min);
            }
        }

        public static void SelectionSort<T>(IList<T> collection, Func<T, T, bool> compareFunction)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                int min = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (compareFunction(collection[j], collection[min]))
                    {
                        min = j;
                    }
                }
                Swap(collection, i, min);
            }
        }

        /// <summary>
        /// Dla każdego elementu sprawdź wszystkie elementy po jego lewej stronie i jeśli są w niepoprawnej kolejności zamień je ze sobą
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void InsertionSort<T>(IList<T> collection) where T : IComparable<T>
        {
            for (int i = 0; i < collection.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (collection[j].CompareTo(collection[j-1]) > 0)
                    {
                        Swap(collection, j, j - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Wykonaj sortowanie przez wstawianie ale nie co 1 tylko co jakąś dużą wartość a następnie zmniejszaj ją aż do 1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void ShellSort<T>(IList<T> collection) where T : IComparable<T>
        {
            // knuth 3x + 1 sequence
            int h = 1;
            while (h >= 1)
            {
                for (int i = h; i < collection.Count; i++)
                {
                    for (int j = i; j >= h && collection[j].CompareTo(collection[j - h]) > 0; j -= h)
                    {
                        Swap(collection, j, j - h);
                    }
                }

                h = h / 3;
            }
        }

        public static bool IsSorted<T>(IList<T> collection) where T : IComparable<T>
        {
            for (int i = 1; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(collection[i-1]) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Ustawia elementy w losowej kolejności
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void Shuffle<T>(IList<T> collection)
        {
            Random random = new Random();
            for (int i = 0; i < collection.Count; i++)
            {
                int r = random.Next(0, i - 1);
                Swap(collection, i, r);
            }
        }

        private static void Swap<T>(IList<T> collection, int index1, int index2)
        {
            T swap = collection[index1];
            collection[index1] = collection[index2];
            collection[index2] = swap;
        }

        private static bool Less(IComparable item1, IComparable item2)
        {
            return item1.CompareTo(item2) < 0;
        }
    }
}
