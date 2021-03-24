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
        public void RemoveRange_WhenValidValuePassed_SholdRemoveNElement(int count, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.RemoveRange(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(3, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(5, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 5 })]
        [TestCase(6, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(7, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(100, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1000, new int[] { }, new int[] { })]
        public void RemoveRangeFromStart_WhenValidValuePassed_SholdRemoveNElementForStart(int count, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.RemoveRangeFromStart(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveRangeFromStart_WhenInvalidPaseed_ShoultReturnIndexOutOfRangeException(int count, int[] actualArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromStart(count));
        }

        [TestCase(0, 0, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(1, 1, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 2, 3, 4, 5 })]
        [TestCase(2, 2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 4, 5 })]
        [TestCase(3, 3, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2 })]
        [TestCase(4, 4, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(10, 4, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(100, 0, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1, 0, new int[] { 0 }, new int[] { })]
        public void RemoveRangeByIndex_WhenValidValuePassed_SholdRemoveNElementByIndex(int count, int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.RemoveRangeByIndex(index, count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-100, 0, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 2, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 3, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 4, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 5, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void RemoveNElementsByIndex_WhenInvalidValuePassed_SholdReturnArgumentException(int count, int index, int[] actualArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeByIndex(index, count));
        }

        [TestCase(100, 6, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, 70, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, 800, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, 900, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, -1, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void RemoveNElementsByIndex_WhenInvalidValuePassed_SholdReturnIndexOutOfRangeException(int count, int index, int[] actualArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveRangeByIndex(index, count));
        }

        [TestCase(0, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 3, 4, 5 })]
        [TestCase(3, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 4, 5 })]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 5 })]
        [TestCase(5, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        public void RemoveByValue_WhenValidValuePassed_SholdRemoveFirstEntryElementByValue(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.RemoveByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new string[] { "100", "1", "2", "3", "4", "5" })]
        public void RemoveByValue_WhenInvalidValuePassed_SholdReturnArgumentException(string value, string[] actualArray)
        {
            LinkedList<string> actual = new LinkedList<string>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveByValue(value));
        }

        [TestCase(100, new int[] { 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 100, 100, 100, 0 }, new int[] { 0 })]
        [TestCase(100, new int[] { 100 }, new int[] { })]
        public void RemoveAllByValue_WhenValidValuePassed_SholdRemoveAllElementByValue(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new string[] { "100", "1", "2", "3", "4", "5" })]
        public void RemoveAllByValue_WhenInalidValuePassed_SholdReturnArgumentException(string value, string[] actualArray)
        {
            LinkedList<string> actual = new LinkedList<string>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveAllByValue(value));
        }
    }
}
