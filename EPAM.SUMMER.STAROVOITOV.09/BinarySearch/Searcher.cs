using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    /// <summary>
    /// Contains method to find index of element in sorted one-dimensional, zero-based array.
    /// </summary>
    public static class Searcher
    {
        /// <summary>
        /// Searches an entire one-dimensional sorted array for a value using the specified
        /// Comparison<T> generic delegate.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="sortedArray">The sorted one-dimensional, zero-based System.Array to search.</param>
        /// <param name="element">The object to search for.</param>
        /// <param name="comparer">Delegate comparer that represents the method that compare elements.</param>
        /// <returns>
        /// The index of the specified value in the specified array, if value is found. If value is not found a negative number.
        /// </returns>
        public static int BinarySearch<T>(T[] sortedArray, T element, Comparison<T> comparer)
        {
            if (ReferenceEquals(sortedArray, null) || ReferenceEquals(comparer, null))
                throw new ArgumentNullException();
            if (!(element is ValueType))
                if (ReferenceEquals(element, null))
                    throw new ArgumentNullException();

            if (comparer(element, sortedArray[0]) < 0 || comparer(element, sortedArray[sortedArray.Length - 1]) > 0)
                return -1;

            int firstIndex = 0;
            int lastIndex = sortedArray.Length;
            while (firstIndex < lastIndex)
            {
                int midIndex = firstIndex + ((lastIndex - firstIndex) >> 1);
                if (comparer(element, sortedArray[midIndex]) <= 0)
                    lastIndex = midIndex;
                else
                    firstIndex = midIndex + 1;
            }
            return comparer(element, sortedArray[lastIndex]) == 0 ? lastIndex : -1;
        }
    }
}
