using System;
using NUnit.Framework;

namespace List.Tests
{
    class DoubleLinkedListTests
    {
        [TestCase(new int[] { 5, 12, -14, 0, 1 }, new int[] { -14, 0, 1, 5, 12 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 100 }, new int[] { 100 })]
        public void Sort_WhenValidSortPasse_ShouldSortingListAscending(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);
            DoubleLinkedList<int> actual;

            actual = list.Sort(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 12, -14, 0, 1 }, new int[] { 12, 5, 1, 0, -14 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 100 }, new int[] { 100 })]
        public void Sort_WhenValidSortPasse_ShouldSortingListDescending(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);
            DoubleLinkedList<int> actual;

            actual = list.Sort(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        public void Revers_WhenValidListPassed_shouldRevertList(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 5)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 0)]
        [TestCase(new int[] { }, -1)]
        public void GetIndexMinValue_WhenValidListPassed_ShouldReturnIndexMinValueInList(int[] actualArray, int expected)
        {
            DoubleLinkedList<int> array = new DoubleLinkedList<int>(actualArray);
            int actual = array.GetIndexMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 100 })]
        [TestCase(-10, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -10, -10 })]
        [TestCase(0, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0, 0, 0 })]
        [TestCase(10, 4, new int[] { }, new int[] { 10, 10, 10, 10, })]
        [TestCase(10, 6, new int[] { }, new int[] { 10, 10, 10, 10, 10, 10, })]
        [TestCase(10, 7, new int[] { }, new int[] { 10, 10, 10, 10, 10, 10, 10, })]
        [TestCase(10, 8, new int[] { }, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, })]
        public void Add_WhenValidValuePassed_ShouldAddToListinLastPosition(int value, int count, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            for (int i = 0; i < count; i++)
            {
                actual.Add(value);
            }

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
            DoubleLinkedList<int> array = new DoubleLinkedList<int>(actualArray);

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
            DoubleLinkedList<int> array = new DoubleLinkedList<int>(actualArray);

            int actual = array.GetMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 500)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 99999)]
        public void GetMax_WhenValidListPassed_ShouldReturnMaxValueInList(int[] actualArray, int expected)
        {
            DoubleLinkedList<int> array = new DoubleLinkedList<int>(actualArray);

            int actual = array.GetMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void AddFirst_WhenValidValuePassed_ShouldAddToListFisrPosition(int value, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-10, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, -10, 2, 3, 4, 5 })]
        [TestCase(-10, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, -10, 3, 4, 5 })]
        [TestCase(0, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 0, 4, 5 })]
        [TestCase(6, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 6, 5 })]
        public void AddByIndex_WhenValidValuePassed_ShouldAddToListByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void AddList_WhenValidListPassed_ShouldAddedListToList(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);
            DoubleLinkedList<int> addedList = new DoubleLinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

            actual.AddList(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 1 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void AddListFirst_WhenValidListPassed_ShouldAddedListToList(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);
            DoubleLinkedList<int> addedList = new DoubleLinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

            actual.AddListFirst(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 10, 20, 30, 40, 50, 60, 70, 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 10, 20, 30, 40, 50, 60, 70, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 10, 20, 30, 40, 50, 60, 70, 3, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 20, 30, 40, 50, 60, 70, 4, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 10, 20, 30, 40, 50, 60, 70, 5 })]
        public void AddListByIndex_WhenValidListPassed_ShouldAddedListToList(int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);
            DoubleLinkedList<int> addedList = new DoubleLinkedList<int>(new int[] { 10, 20, 30, 40, 50, 60, 70 });

            actual.AddListByIndex(addedList, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void Remove_WhenValidValuePassed_SholdRemoveLastElement(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirst_WhenValidValuePassed_SholdRemoveFirstElement(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

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
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveByIndex_WhenInvalidPaseed_ShoultReturnIndexOutOfRangeException(int index, int[] actualArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);

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
        [TestCase(100, new int[] { 0 }, new int[] { })]
        [TestCase(1000, new int[] { }, new int[] { })]
        public void RemoveRange_WhenValidValuePassed_SholdRemoveNElement(int count, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

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
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            actual.RemoveRangeFromStart(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-1, new int[] { 1 })]
        [TestCase(-1, new int[] { })]
        public void RemoveRangeFromStart_WhenInvalidPaseed_ShoultReturnIndexOutOfRangeException(int count, int[] actualArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromStart(count));
        }

        [TestCase(0, 0, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(1, 5, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(1, 1, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 2, 3, 4, 5 })]
        [TestCase(2, 2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 4, 5 })]
        [TestCase(3, 3, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2 })]
        [TestCase(4, 4, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(10, 4, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(100, 0, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1, 0, new int[] { 0 }, new int[] { })]
        public void RemoveRangeByIndex_WhenValidValuePassed_SholdRemoveNElementByIndex(int count, int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            actual.RemoveRangeByIndex(index, count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-100, 0, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 2, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 3, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 4, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 5, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 0, new int[] { 0 })]
        public void RemoveRangeByIndex_WhenInvalidValuePassed_SholdReturnArgumentException(int count, int index, int[] actualArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeByIndex(index, count));
        }

        [TestCase(100, 6, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, 70, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, 800, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, 900, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, -1, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(100, -1, new int[] { 0 })]
        [TestCase(100, -1, new int[] { })]
        public void RemoveRangeByIndex_WhenInvalidValuePassed_SholdReturnIndexOutOfRangeException(int count, int index, int[] actualArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveRangeByIndex(index, count));
        }

        [TestCase(0, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 3, 4, 5 })]
        [TestCase(3, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 4, 5 })]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 5 })]
        [TestCase(5, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(5, new int[] { 5, 5, 5, 5, 5, 5 }, new int[] { 5, 5, 5, 5, 5 })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        public void RemoveByValue_WhenValidValuePassed_SholdRemoveFirstEntryElementByValue(int value, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            actual.RemoveByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new string[] { "100", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "100" })]
        [TestCase(null, new string[] { })]
        public void RemoveByValue_WhenInvalidValuePassed_SholdReturnArgumentException(string value, string[] actualArray)
        {
            DoubleLinkedList<string> actual = new DoubleLinkedList<string>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveByValue(value));
        }

        [TestCase(100, new int[] { 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 1, 100, 2, 100, 3, 100, 4, 100, 5, 100 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 100, 100, 100, 0 }, new int[] { 0 })]
        [TestCase(100, new int[] { 100 }, new int[] { })]
        public void RemoveAllByValue_WhenValidValuePassed_SholdRemoveAllElementByValue(int value, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArray);
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArray);

            int i = actual.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }

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
            DoubleLinkedList<int> array = new DoubleLinkedList<int>(actualArray);

            int actual = array.GetIndex(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new string[] { "100", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "100" })]
        [TestCase(null, new string[] { })]
        public void RemoveAllByValue_WhenInalidValuePassed_SholdReturnArgumentException(string value, string[] actualArray)
        {
            DoubleLinkedList<string> actual = new DoubleLinkedList<string>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveAllByValue(value));
        }

        public void GetIndexbyValue_WhenInvalidValuePassed_SholdReturnArgumentException(string value, string[] actualArray)
        {
            DoubleLinkedList<string> actual = new DoubleLinkedList<string>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.GetIndex(value));
        }
    }
}