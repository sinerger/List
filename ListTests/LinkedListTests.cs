using System;
using NUnit.Framework;

namespace List.Tests
{
    class LinkedListTests
    {
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 5)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 0)]
        [TestCase(new int[] { }, -1)]
        public void GetIndexMinValue_WhenValidListPassed_ShouldReturnIndexMinValueInList(int[] actualArray, int expected)
        {
            LinkedList<int> array = new LinkedList<int>(actualArray);

            int actual = array.GetIndexMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 5)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 4)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 1)]
        [TestCase(new int[] { }, -1)]
        public void GetIndexMaxValue_WhenValidListPassed_ShouldReturnIndexMaxValueInList(int[] actualArray, int expected)
        {
            LinkedList<int> array = new LinkedList<int>(actualArray);

            int actual = array.GetIndexMaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, -5)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, -1000)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, -999999)]
        public void GetMin_WhenValidListPassed_ShouldReturnMinxValueInList(int[] actualArray, int expected)
        {
            LinkedList<int> array = new LinkedList<int>(actualArray);

            int actual = array.GetMin();

            Assert.AreEqual(expected, actual);
        }
    }
}
