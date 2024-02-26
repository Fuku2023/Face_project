using System;
using System.Collections.Generic;

namespace Oculus.Interaction.Collections
{
    /// <summary>
    /// Exposes a GetEnumerator method with a non-allocating
    /// HashSet.Enumerator struct.
    /// </summary>
    public interface IEnumerableHashSet<T> : IEnumerable<T>
    {
        int Count { get; }
        new HashSet<T>.Enumerator GetEnumerator();
        bool Contains(T item);
        bool IsProperSubsetOf(IEnumerable<T> other);
        bool IsProperSupersetOf(IEnumerable<T> other);
        bool IsSubsetOf(IEnumerable<T> other);
        bool IsSupersetOf(IEnumerable<T> other);
        public bool Overlaps(IEnumerable<T> other);
        public bool SetEquals(IEnumerable<T> other);
    }

    /// <summary>
    /// A Hash set that implements the <see cref="IEnumerableHashSet{T}"/>
    /// interface, to use for non-allocating iteration of a HashSet
    /// </summary>
    public class EnumerableHashSet<T> : HashSet<T>, IEnumerableHashSet<T>
    {
        public EnumerableHashSet() : base() { }
        public EnumerableHashSet(IEnumerable<T> values) : base(values) { }
    }
}
