using System;
using NUnit.Framework;

namespace List.Tests
{
    class LinkedListTests
    {
        [TestCase(9, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9)]
        [TestCase(8, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 8)]
        [TestCase(7, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7)]
        [TestCase(6, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 6)]
        [TestCase(5, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5)]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 4)]
        [TestCase(3, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3)]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2)]
        [TestCase(1, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1)]
        [TestCase(0, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0)]
        [TestCase(12, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1)]
        public void GetIndex_WhenValidIndexPassed_ShouldReturnIndexIfListContainsValueOrminusOneIfNoContainsValue(int value, int[] actualArray, int expected)
        {
            LinkedList<int> array = new LinkedList<int>(actualArray);

            int actual = array.GetIndex(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new string[] { "100", "1", "2", "3", "4", "5" })]
        public void GetIndexbyValue_WhenInvalidValuePassed_SholdReturnArgumentException(string value, string[] actualArray)
        {
            LinkedList<string> actual = new LinkedList<string>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.GetIndex(value));
        }
    }
}
