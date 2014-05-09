using System;
using System.Collections.Generic;
using Okra.Helpers;

namespace Okra.Data
{
    public class VirtualizingList<T> : IList<T>
    {
        // *** Fields ***

        private T[] internalArray = new T[0];
        private int count = 0;

        // *** IList<T> Properties ***

        public T this[int index]
        {
            get
            {
                // Validate that the index is within range

                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

                // If the index is in a virtual part of the list then return a placeholder value

                if (index >= internalArray.Length)
                    return default(T);

                // Otherwise return the actual value

                return internalArray[index];
            }
            set
            {
                // Validate that the index is within range

                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

                // Expand the internal list with empty placeholders until the item will fit

                EnsureCapacity(index + 1);

                // Set the item

                internalArray[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        // *** Methods ***

        public void UpdateCount(int count)
        {
            // Validate that the index is within range

            if (count < 0)
                throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ParameterOutOfRange_CountMustBeZeroOrPositive"));

            // Update the count

            this.count = count;
        }

        // *** IList<T> Methods ***

        public void Add(T item)
        {
            int newIndex = count;

            count++;
            this[newIndex] = item;
        }

        public void Clear()
        {
            count = 0;
            internalArray = new T[0];
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            // Copy the array that is available

            Array.Copy(internalArray, 0, array, arrayIndex, count);

            // Set the remaining items to the placeholder

            for (int i = internalArray.Length + arrayIndex; i < count + arrayIndex; i++)
                array[i] = default(T);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < internalArray.Length; i++)
            {
                T internalItem = internalArray[i];

                if (internalItem != null && internalItem.Equals(item))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            // Validate that the index is within range

            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

            // Ensure that there is enough room in the collection

            int requiredSize = Math.Max(index, internalArray.Length + 1);
            EnsureCapacity(requiredSize);

            // If there are items after the inserted item them move them along

            Array.Copy(internalArray, index, internalArray, index + 1, internalArray.Length - index - 1);

            // Insert the new item

            count++;
            internalArray[index] = item;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
                return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            // Validate that the index is within range

            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

            // Reduce the count

            count--;

            // Move all items after the removed item to the left

            Array.Copy(internalArray, index, internalArray, index - 1, internalArray.Length - index);
        }

        // *** IEnumerable<T> Methods ***

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return this[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        // *** Private Methods ***

        private void EnsureCapacity(int requiredSize)
        {
            if (internalArray.Length < requiredSize)
            {
                // If the capacity is too small, then make the list required size x 2

                int desiredSize = requiredSize * 2;
                T[] newArray = new T[desiredSize];

                // Copy the existing data

                Array.Copy(internalArray, 0, newArray, 0, internalArray.Length);
                internalArray = newArray;
            }
        }
    }
}
