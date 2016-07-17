using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinarySearch;
using static BinarySearchTests.TestComparers;

namespace BinarySearch.Tests
{
    [TestFixture]
    public class SearcherTests
    {
        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.GetDataForFirstEntryOfIntElement))]
        public void FindFirstEntryOfIntElement(int[] sortedArray, int element, int expectedIndex)
        {            
            Assert.AreEqual(expectedIndex, Searcher.BinarySearch<int>(sortedArray, element, IntComparer));
        }

        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.GetDataForElementOnRightBorder))]
        public void FindIntElementOnRightBorder(int[] sortedArray, int element, int expectedIndex)
        {
            Assert.AreEqual(expectedIndex, Searcher.BinarySearch<int>(sortedArray, element, IntComparer));
        }

        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.GetDataForNotFindElement))]
        public void NotFindElement(int[] sortedArray, int element)
        {
            Assert.AreEqual(-1, Searcher.BinarySearch<int>(sortedArray, element, IntComparer));
        }

        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.GetUnvalidData))]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitArgumentNullException(object[] sortedArray, object element,
                                              Comparison<object> comarer)
        {
            Searcher.BinarySearch<object>(sortedArray, element, comarer);
        }

        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.GetDataForObjectElement))]
        public void FindObjectElement(object[] sortedArray, object element, int expectedIndex)
        {
            Assert.AreEqual(expectedIndex, Searcher.BinarySearch<object>(sortedArray, element,
                                                                         BoxingIntComparer));
        }
    }

    public static class DataProvider
    {
        public static IEnumerable GetDataForFirstEntryOfIntElement()
        {
            yield return new TestCaseData(new int[] { 0, 1, 2, 2, 2, 8, 10 }, 2, 2);
            yield return new TestCaseData(new int[] { 2, 2, 2, 2, 9, 10, 15, 20 }, 2, 0);
            yield return new TestCaseData(new int[] { 5, 8, 9, 10, 15, 15, 15}, 15, 4);
        }
        
        public static IEnumerable GetDataForElementOnRightBorder()
        {
            yield return new TestCaseData(new int[] { 0, 1, 2, 2, 2, 8, 10 }, 10, 6);
        }

        public static IEnumerable GetDataForNotFindElement()
        {
            yield return new TestCaseData(new int[] { 0, 1, 2, 2, 2, 8, 10 }, -1);
            yield return new TestCaseData(new int[] { 2, 2, 2, 2, 9, 10, 15, 20 }, 21);
            yield return new TestCaseData(new int[] { 5, 8, 9, 10, 15, 15, 15 }, 11);
        }

        public static IEnumerable GetUnvalidData()
        {
            yield return new TestCaseData(null, 1, new Comparison<object>(BoxingIntComparer));
            yield return new TestCaseData(new object[] { 2, 2, 2, 2, 9, 10, 15, 20 },
                                          null, new Comparison<object>(BoxingIntComparer));
            yield return new TestCaseData(new object[] { 5, 8, 9, 10, 15, 15, 15 }, 11, null);
        }

        public static IEnumerable GetDataForObjectElement()
        {
            yield return new TestCaseData(new object[] { 0, 1, 2, 2, 2, 8, 10 }, 8, 5);
        }
    }   
}
