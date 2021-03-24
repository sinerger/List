using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace List.Tests
{
    class LinkedListTests
    {
        [TestCase(100,1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 100 })]
        [TestCase(-10,2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -10, -10 })]
        [TestCase(0,3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0,0,0 })]
        [TestCase(10,4, new int[] { }, new int[] { 10, 10, 10, 10, })]
        [TestCase(10, 6, new int[] { }, new int[] { 10, 10, 10, 10, 10, 10, })]
        [TestCase(10, 7, new int[] { }, new int[] { 10, 10, 10, 10, 10, 10, 10, })]
        [TestCase(10, 8, new int[] { }, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, })]
        public void Add_WhenValidValuePassed_ShouldAddToListinLastPosition(int value, int count, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            for (int i = 0; i < count; i++)
            {
                actual.Add(value);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void AddFirst_WhenValidValuePassed_ShouldAddToListFisrPosition(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-10, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, -10, 2, 3, 4, 5 })]
        [TestCase(0, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 0, 4, 5 })]
        [TestCase(6, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 4 })]
        public void AddByIndex_WhenValidValuePassed_ShouldAddToListByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);

            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void AddArrayList_WhenValidListPassed_ShouldAddedListToList(int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);
            LinkedList<int> addedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

            actual.AddList(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 1 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void AddArrayListToStart_WhenValidListPassed_ShouldAddedListToList(int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);
            LinkedList<int> addedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

            actual.AddListFirst(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 10, 20, 30, 40, 50, 60, 70, 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 10, 20, 30, 40, 50, 60, 70, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 10, 20, 30, 40, 50, 60, 70, 3, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 20, 30, 40, 50, 60, 70, 4, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 10, 20, 30, 40, 50, 60, 70 })]
        public void AddArrayListByIndex_WhenValidListPassed_ShouldAddedListToList(int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList<int> actual = new LinkedList<int>(actualArray);
            LinkedList<int> expected = new LinkedList<int>(expectedArray);
            LinkedList<int> addedList = new LinkedList<int>(new int[] { 10, 20, 30, 40, 50, 60, 70 });

            actual.AddListByIndex(addedList, index);

            Assert.AreEqual(expected, actual);
        }
    }
}
