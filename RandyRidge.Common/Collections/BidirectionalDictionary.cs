using System.Collections.Generic;

namespace RandyRidge.Common.Collections {
    /// <summary>
    ///     Provides a bi-directional dictionary.
    /// </summary>
    public sealed class BidirectionalDictionary<TKey, TValue> where TKey : notnull where TValue : notnull {
        private readonly Dictionary<TKey, TValue> left;
        private readonly Dictionary<TValue, TKey> right;

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public BidirectionalDictionary() {
            left = new Dictionary<TKey, TValue>();
            right = new Dictionary<TValue, TKey>();
            Left = new Indexer<TKey, TValue>(left);
            Right = new Indexer<TValue, TKey>(right);
        }

        /// <summary>
        ///     Provides an index accessor.
        /// </summary>
        /// <typeparam name="TIndexKey">
        ///     The key type.
        /// </typeparam>
        /// <typeparam name="TIndexValue">
        ///     The value type.
        /// </typeparam>
        public sealed class Indexer<TIndexKey, TIndexValue> where TIndexKey : notnull where TIndexValue : notnull {
            private readonly Dictionary<TIndexKey, TIndexValue> dictionary;

            /// <summary>
            ///     Creates a new instance.
            /// </summary>
            /// <param name="dictionary">
            ///     The dictionary to initialize from.
            /// </param>
            public Indexer(Dictionary<TIndexKey, TIndexValue> dictionary) {
                this.dictionary = dictionary;
            }

            /// <summary>
            ///     Provides index access to underlying dictionary.
            /// </summary>
            /// <param name="index">
            ///     The key to lookup.
            /// </param>
            /// <returns>
            ///     The corresponding value.
            /// </returns>
            public TIndexValue this[TIndexKey index] => dictionary[index];
        }

        /// <summary>
        ///     Gets the number of items in the dictionary.
        /// </summary>
        public int Count => left.Count;

        /// <summary>
        ///     Gets the left side, key to value.
        /// </summary>
        public Indexer<TKey, TValue> Left { get; }

        /// <summary>
        ///     Gets the right side, value to key.
        /// </summary>
        public Indexer<TValue, TKey> Right { get; }

        /// <summary>
        ///     Adds a new key / value pair.
        /// </summary>
        /// <param name="key">
        ///     The key to add.
        /// </param>
        /// <param name="value">
        ///     The corresponding value.
        /// </param>
        public void Add(TKey key, TValue value) {
            left.Add(key, value);
            right.Add(value, key);
        }
    }
}
