using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
    public static class Soring
    {

        private const int CUT_OFF = 7;

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

        /// <summary>
        /// Sortowanie przez scalanie
        /// Dzieli kolekcję na dwie części, rekursyjne sortuje każdą z nich a następnie łączy je
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void MergeSort<T>(IList<T> collection) where T : IComparable<T>
        {
            T[] auxiliary = new T[collection.Count];

            MergeSort(collection, auxiliary, 0, collection.Count - 1);
        }

        /// <summary>
        /// Sortowanie szybkie
        /// Potasuj losowo kolekcję,
        /// podziel na dwie części a następnie posortuj każdą z części rekurencyjnie
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void QuickSort<T>(IList<T> collection) where T : IComparable<T>
        {
            // potasuj losowo tablicę
            Shuffle(collection);

            // posortuj tablicę
            QuickSort(collection, 0, collection.Count - 1);
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

        #region MergeSort


        private static void MergeSort<T>(IList<T> collection, IList<T> auxiliaryCollection, int low, int high) where T : IComparable<T>
        {
            // jeżeli elementów jest mało to posrotuj przez wstawianie
            if (high <= low + CUT_OFF - 1)
            {
                InsertionSort(collection);
                return;
            }

            // podziel kolekcję na dwie części w połowie
            int mid = low + ((high - low) / 2);

            // posortuj pierwszą połowę
            MergeSort(collection, auxiliaryCollection, low, mid);
            // posortuj drugą połowę
            MergeSort(collection, auxiliaryCollection, mid + 1, high);

            // jeżeli ostatni element w pierwszej części jest mniejszy od pierwszego elementu w drugiej części to zakończ
            if (collection[mid].CompareTo(collection[mid + 1]) < 0)
            {
                return;
            }
            
            // złącz obydwie części
            Merge(collection, auxiliaryCollection, low, mid, high);
        }

        private static void Merge<T>(IList<T> collection, IList<T> auxuiliaryCollection, int low, int mid, int high) where T : IComparable<T>
        {
            // założenie kolekcja w przedziale low do mid jest posortowana i mid + 1 do high też jest posortowana

            // skopiuj zawartość sortowanej tabeli do tabeli pomocniczej
            for (int k = 0; k < collection.Count; k++)
            {
                auxuiliaryCollection[k] = collection[k];
            }

            // wskaźnik do pierwszej części kolekcji
            int i = low;
            // wskaźnik do drugiej części kolekcji
            int j = mid + 1;

            for (int k = low; k < high; k++)
            {
                // jeśli w pierwszej części już nie ma elementów weź z drugiej części i zwiększ jej wskaźnik 
                if (i > mid)
                {
                    collection[k] = auxuiliaryCollection[j++];
                }
                // jeśli w drugiej części już nie ma elementów weź z pierwszej części i zwiększ jej wskaźnik
                else if (j > high)
                {
                    collection[k] = auxuiliaryCollection[i++];
                }
                // jeśli element w drugiej części jest większy od elementu w pierwszej części weź go i zwiększ wskaźnik drugiej części
                else if (auxuiliaryCollection[j].CompareTo(auxuiliaryCollection[i]) > 0)
                {
                    collection[k] = auxuiliaryCollection[j++];
                }
                // to znaczy, że element w pierwszej części jest większy niż ten w drugiej części, weź go i zwiększ wskaźnik dla pierwszej części
                else
                {
                    collection[k] = auxuiliaryCollection[i++];
                }
            }
        }

        #endregion

        #region QuickSort

        private static void QuickSort<T>(IList<T> collection, int low, int high) where T : IComparable<T>
        {
            if (high <= low)
            {
                return;
            }

            // podziel tablicę w miejscu j, tak że wszystkie elementy na lewo od niego są od niego mniejsze lub równe
            // a na prawo są większe lub równe
            int j = Partition(collection, low, high);

            // posortuj rekurencyjnie lewą część
            QuickSort(collection, low, j - 1);

            // posortuj rekurencyjnie prawą część
            QuickSort(collection, j + 1, high);
        }

        /// <summary>
        /// Dzieli kolekcję na dwie części w miejscu j, tak że wszystkie elementy na lewo od niego są od niego mniejsze lub równe
        /// a na prawo od niego są większe lub równe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static int Partition<T>(IList<T> collection, int low, int high) where T : IComparable<T>
        {
            // zamieniaj miejscami elementy jeżeli te po prawej stronie są mniejsze niż low lub gdy te po lewej stronie są większe niż low
            // na samym końcu zmień element low z elementem pod indeksem j

            int i = low;
            int j = high + 1;
            while (true)
            {
                // dopóki elementy na lewo od miejsca low są od niego mniejsze w porządku
                while (collection[++i].CompareTo(collection[low]) < 1)
                {
                    if (i == high)
                    {
                        break;
                    }
                }

                // dopóki elementy na prawo od miejsca low są od niego większe w porządku
                while (collection[--j].CompareTo(collection[low]) > 1)
                {
                    if (j == low)
                    {
                        break;
                    }
                }

                // jeżeli wskaźniki i oraz j się przecięły zakończ
                if (i >= j)
                {
                    break;
                }

                // zamień elementy i oraz j miejscami ponieważ znajdują się w niewłaściwych częsciach
                Swap(collection, i, j);
            }

            // zamień element low na nowy element podziału znajdujący się na indeksie j
            Swap(collection, low, j);
            return j;
        }

        #endregion

    }
}
