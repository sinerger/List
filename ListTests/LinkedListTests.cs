using System;
using NUnit.Framework;

namespace List.Tests
{
    class LinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void Remove_WhenValidValuePassed_SholdRemoveLastElement(int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirst_WhenValidValuePassed_SholdRemoveFirstElement(int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 3, 4, 5 })]
        [TestCase(3, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 4, 5 })]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 5 })]
        [TestCase(5, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        public void RemoveByIndex_WhenValidValuePassed_SholdRemoveElementByIndex(int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveByIndex_WhenInvalidPaseed_ShoultReturnIndexOutOfRangeException(int index, int[] actualArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }

        [TestCase(0, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(3, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2 })]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1 })]
        [TestCase(5, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0 })]
        [TestCase(6, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(7, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(100, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1000, new int[] { }, new int[] { })]
        public void RemoveRange_WhenValidValuePassed_SholdRemoveNElement(int n, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.RemoveRange(n);

            Assert.AreEqual(expected, actual);
        }
    }
}
