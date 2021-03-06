﻿namespace Sentinel.OAuth.Core.Models.Tokens
{
    using System;

    using Newtonsoft.Json;
    using Sentinel.OAuth.Core.Converters;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    [JsonConverter(typeof(JsonWebTokenComponentConverter))]
    public abstract class JsonWebTokenComponent : ICollection<KeyValuePair<string, object>>
    {
        /// <summary>The inner collection.</summary>
        private readonly Collection<KeyValuePair<string, object>> inner;

        /// <summary>Initializes a new instance of the <see cref="JsonWebTokenComponent" /> class.</summary>
        protected JsonWebTokenComponent()
        {
            this.inner = new Collection<KeyValuePair<string, object>>();
        }

        /// <summary>Gets the item with the specified key.</summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="key">The item key.</param>
        /// <returns>The item.</returns>
        public T Get<T>(string key)
        {
            var item = this.Get(key);

            if (item != null)
            {
                var json = JsonConvert.SerializeObject(item);

                try
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                catch (JsonSerializationException)
                {
                    return default(T);
                }
            }

            return default(T);
        }

        /// <summary>Indexer to get items within this collection using array index syntax.</summary>
        /// <param name="key">The key.</param>
        /// <returns>The value.</returns>
        public object this[string key]
        {
            get
            {
                var item = this.Get(key);

                return item;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.inner.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public void Add(KeyValuePair<string, object> item)
        {
            this.inner.Add(item);
        }

        /// <summary>Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
        /// <param name="key">The key to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <param name="value">The value to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public void Add(string key, object value)
        {
            this.inner.Add(new KeyValuePair<string, object>(key, value));
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        public void Clear()
        {
            this.inner.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
        /// </returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(KeyValuePair<string, object> item)
        {
            return this.inner.Contains(item);
        }

        /// <summary>Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific key.</summary>
        /// <param name="key">The key to search for.</param>
        /// <returns>true if <paramref name="key"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.</returns>
        public bool ContainsKey(string key)
        {
            return this.inner.Any(x => x.Key == key);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception><exception cref="T:System.ArgumentException">The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.</exception>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            this.inner.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public bool Remove(KeyValuePair<string, object> item)
        {
            return this.inner.Remove(item);
        }

        /// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
        /// <param name="key">The key to search for.</param>
        /// <returns>
        /// true if <paramref name="key"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
        /// This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public bool Remove(string key)
        {
            var item = this.inner.FirstOrDefault(x => x.Key == key);

            if (item.Key != key)
            {
                return false;
            }

            return this.inner.Remove(item);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count => this.inner.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly => false;

        /// <summary>Gets the item with the specified key.</summary>
        /// <param name="key">The item key.</param>
        /// <returns>The item.</returns>
        private object Get(string key)
        {
            if (this.Any(x => x.Key == key))
            {
                var values = this.Where(x => x.Key == key);

                if (values.Count() > 1)
                {
                    return values.Select(x => x.Value);
                }

                return values.First().Value;
            }

            return null;
        }
    }
}