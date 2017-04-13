using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures.KeyTables
{
    public interface IKeyTable<Key, Value> where Key : IComparable<Key>, IEquatable<Key>
    {
        void Put(Key key, Value value);

        Value Get(Key key);

        void Delete(Key key);

        bool Contains(Key key);

        bool IsEmpty();

        int Size();

        IEnumerator<Key> Keys();
    }
}
