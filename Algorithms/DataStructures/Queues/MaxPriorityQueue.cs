using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Rodzaj kolejki gdzie usuwany jest zawsze największy element
    /// Implementacja za pomocą complete binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MaxPriorityQueue<T> : IQueue<T> where T : IComparable<T>
    {
        private int N;
        private T[] _queue;

        public MaxPriorityQueue(int capacity)
        {
            this._queue = new T[capacity];
        }

        /// <summary>
        /// Sortowanie
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void HeapSort<T>(IList<T> collection) where T : IComparable<T>
        {
            int n = collection.Count;

            for (int i = 0; i < n; i++)
            {
                Sink(collection, i, n);
            }

            while (n > 1)
            {
                Exch(collection, 1, n);
                Sink(collection, 1, --n);
            }
        }

        public void Enque(T item)
        {
            // zwiększ rozmiar o 1
            N++;
            // dodaj na ostatnim miejscu w tablic nowy element
            _queue[N] = item;
            // zamieniaj go z jego godzicami aż ustawi się we właściwym miejscu (wypłynie)
            Swim(N);
        }

        public T Deque()
        {
            // największ element to root drzewa
            T max = _queue[1];
            // zmniejsz rozmiar drzewa o 1
            N--;
            // zamień root z ostatnim elementem
            Exch(1, N + 1);
            // zamieniaj nowy root z jego dziećmi aż nie znajdzie się we właściwym miejscu (utonie)
            Sink(1);
            // ustaw usnięty element na null
            _queue[N + 1] = default(T);
            // zwróc poprzedni root
            return max;
        }

        public bool IsEmpty()
        {
            return this.N == 0;
        }

        public int Size()
        {
            return this.N;
        }

        private void Swim(int k)
        {
            // dopóki element mniejszy niż jego rodzic zamieniaj je miejscami
            while (k > 1 && (_queue[k/2].CompareTo(_queue[k]) < 0))
            {
                Exch(k, k/2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                // sprawdź czy nie koniec drzewa i czy elementy o indeksach j i j + 1 (dzieci elementu o indeksie k) są we właściwej kolejności 
                if (j < N && (_queue[j].CompareTo(_queue[j + 1]) < 0))
                {
                    // jeśli tak to wszystko w porządku zwiększ licznik
                    j++;
                }
                // sprawdź czy większe z jego dzieci jest od niego mniejsze
                else if (_queue[k].CompareTo(_queue[j]) > 0)
                {
                    // jeśli tak to jest już we właściwym miejscu - zakończ
                    break;
                }

                // zamień element z większym z jego dzieci
                Exch(k, j);
                k = j;
            }
        }

        private void Exch(int i, int j)
        {
            T t = _queue[i];
            _queue[i] = _queue[j];
            _queue[j] = t;
        }

        private static void Exch<T>(IList<T> collection, int i, int j) where T : IComparable<T>
        {
            T t = collection[i];
            collection[i] = collection[j];
            collection[j] = t;
        }

        private static void Sink<T>(IList<T> collection, int k, int N) where T : IComparable<T>
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                // sprawdź czy nie koniec drzewa i czy elementy o indeksach j i j + 1 (dzieci elementu o indeksie k) są we właściwej kolejności 
                if (j < N && (collection[j].CompareTo(collection[j + 1]) < 0))
                {
                    // jeśli tak to wszystko w porządku zwiększ licznik
                    j++;
                }
                // sprawdź czy większe z jego dzieci jest od niego mniejsze
                else if (collection[k].CompareTo(collection[j]) > 0)
                {
                    // jeśli tak to jest już we właściwym miejscu - zakończ
                    break;
                }

                // zamień element z większym z jego dzieci
                Exch(collection, k, j);
                k = j;
            }
        }
    }
}
