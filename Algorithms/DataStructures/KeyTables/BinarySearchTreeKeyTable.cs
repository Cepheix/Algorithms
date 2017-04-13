using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures.KeyTables
{
    public class BinarySearchTreeKeyTable<Key, Value> : IKeyTable<Key, Value> where Key : IComparable<Key>, IEquatable<Key>
    {
        private Key[] keys;
        private Value[] values;

        private int N;

        public bool Contains(Key key)
        {
            throw new NotImplementedException();
        }

        public void Delete(Key key)
        {
            throw new NotImplementedException();
        }

        public Value Get(Key key)
        {
            if (IsEmpty())
            {
                return default(Value);
            }

            int i = Rank(key);

            if (i < N && keys[i].CompareTo(key) == 0)
            {
                return values[i];
            }
            else
            {
                return default(Value);
            }
        }

        private int Rank(Key key)
        {
            int low = 0;
            int high = N - 1;

            while (low <= high)
            {
                int mid = (high - low) / 2;
                int compare = key.CompareTo(keys[mid]);

                if (compare < 0)
                {
                    high = mid - 1;
                }
                else if(compare > 1)
                {
                    low = mid + 1;
                }
                else if(compare == 0)
                {
                    return mid;
                }
            }

            return low;
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Key> Keys()
        {
            throw new NotImplementedException();
        }

        public void Put(Key key, Value value)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}
