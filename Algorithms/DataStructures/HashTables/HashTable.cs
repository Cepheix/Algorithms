using System;

namespace Algorithms.DataStructures.HashTables
{
    public class HashTable<Key, Value> where Key : IEquatable<Key>
    {
        private const int M = 30001;
        private Value[] values = new Value[M];
        private Key[] keys = new Key[M];

        public void Put(Key key, Value value)
        {
            int i;
            for (i = Hash(key); keys[i] != null ; i = (i + 1) % M)
            {
                if (keys[i].Equals(key))
                {
                    break;
                }
            }
                keys[i] = key;
            values[i] = value;
        }

        public Value Get(Key key)
        {
            for (int i = Hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (key.Equals(keys[i]))
                {
                    return values[i];
                }
            }
            return default(Value);
        }

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }
    }
}
