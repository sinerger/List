﻿using NUnit.Framework;
using System;

namespace List.Tests
{
    //[TestFixture("ArrayList")]
    [TestFixture("LinkedList")]
    //[TestFixture("DoubleLinkedList")]
    public class Tests
    {
        private IList<int> actual;
        private IList<int> expected;
        private IList<int> addedList;
        private string _parameter = string.Empty;

        public Tests(string param)
        {
            _parameter = param;
        }

        public void Setup(int[] actualArray, int[] expectedArray, int[] addedArray)
        {
            switch (_parameter)
            {
                //    case "ArrayList":
                //        actual = new ArrayList<int>(actualArray);
                //        expected = new ArrayList<int>(expectedArray);
                //        addedList = new ArrayList<int>(list);
                //        break;
                case "LinkedList":
                    if (actualArray != null)
                        actual = LinkedList<int>.Create(actualArray);
                    if (expectedArray != null)
                        expected = LinkedList<int>.Create(expectedArray);
                    if (addedArray != null)
                        addedList = LinkedList<int>.Create(addedArray);
                    break;
                    //    case "DoubleLinkedList":
                    //        actual = new DoubleLinkedList<int>(actualArray);
                    //        expected = new DoubleLinkedList<int>(expectedArray);
                    //        addedList = new DoubleLinkedList<int>(list);
                    //        break;
            }
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
            Setup(actualArray, expectedArray, null);

            for (int i = 0; i < count; i++)
            {
                actual.Add(value);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 1 }, new int[] { 0, 1 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        public void AddFirst_WhenValidValuePassed_ShouldAddToListFisrPosition(int value, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-10, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, -10, 2, 3, 4, 5 })]
        [TestCase(-10, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, -10, 3, 4, 5 })]
        [TestCase(0, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 0, 4, 5 })]
        [TestCase(6, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 6, 5 })]
        [TestCase(6, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(1, 0, new int[] { }, new int[] { 1 })]
        public void AddByIndex_WhenValidValuePassed_ShouldAddToListByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, new int[] { 1 }, new int[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, new int[] { }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void AddRange_WhenValidListPassed_ShouldAddedListToList(int[] array, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, array);

            actual.AddRange(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, new int[] { 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, new int[] { }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void AddRangeFirst_WhenValidListPassed_ShouldAddedListToList(int[] array, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, array);

            actual.AddRangeFirst(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 10, 20, 30, 40, 50, 60, 70, 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 10, 20, 30, 40, 50, 60, 70, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 10, 20, 30, 40, 50, 60, 70, 3, 4, 5 })]
        [TestCase(3, new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 20, 30, 40, 50, 60, 70, 4, 5 })]
        [TestCase(4, new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 10, 20, 30, 40, 50, 60, 70, 5 })]
        [TestCase(5, new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 10, 20, 30, 40, 50, 60, 70 })]
        [TestCase(0, new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { }, new int[] { 10, 20, 30, 40, 50, 60, 70 })]
        [TestCase(0, new int[] { }, new int[] { 0 }, new int[] { 0 })]
        [TestCase(0, new int[] { }, new int[] { }, new int[] { })]
        public void AddRangeByIndex_WhenValidListPassed_ShouldAddedListToList(int index, int[] array, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, array);

            actual.AddRangeByIndex(index, addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void Remove_WhenValidValuePassed_SholdRemoveLastElement(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirst_WhenValidValuePassed_SholdRemoveFirstElement(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

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
            Setup(actualArray, expectedArray, null);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveByIndex_WhenInvalidPaseed_ShoultReturnIndexOutOfRangeException(int index, int[] actualArray)
        {
            Setup(actualArray, null, null);

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
            Setup(actualArray, expectedArray, null);

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
        public void RemoveRangeFirst_WhenValidValuePassed_SholdRemoveNElementForStart(int count, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

            actual.RemoveRangeFirst(count);

            Assert.AreEqual(expected, actual);
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
            Setup(actualArray, expectedArray, null);

            actual.RemoveRangeByIndex(index, count);

            Assert.AreEqual(expected, actual);
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
            Setup(actualArray, expectedArray, null);

            actual.RemoveByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, new int[] { 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 1, 100, 2, 100, 3, 100, 4, 100, 5, 100 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 100, 100, 100, 0 }, new int[] { 0 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 100, 100, 100 }, new int[] { })]
        [TestCase(100, new int[] { 100 }, new int[] { })]
        public void RemoveAllByValue_WhenValidValuePassed_SholdRemoveAllElementByValue(int value, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

            int temp = actual.RemoveAllByValue(value);

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
        [TestCase(12, new int[] { 0 }, -1)]
        [TestCase(12, new int[] { }, -1)]
        public void GetIndex_WhenValidIndexPassed_ShouldReturnIndexIfListContainsValueOrminusOneIfNoContainsValue(int value, int[] actualArray, int expected)
        {
            Setup(actualArray, null, null);

            int actualInt = actual.GetIndex(value);

            Assert.AreEqual(expected, actualInt);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 5)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 0)]
        [TestCase(new int[] { }, -1)]
        public void GetMinIndex_WhenValidListPassed_ShouldReturnIndexMinValueInList(int[] actualArray, int expected)
        {
            Setup(actualArray, null, null);

            int actualInt = actual.GetMinIndex();

            Assert.AreEqual(expected, actualInt);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 5)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 4)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 1)]
        [TestCase(new int[] { }, -1)]
        public void GetMaxIndex_WhenValidListPassed_ShouldReturnIndexMaxValueInList(int[] actualArray, int expected)
        {
            Setup(actualArray, null, null);

            int actualInt = actual.GetMaxIndex();

            Assert.AreEqual(expected, actualInt);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, -5)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, -1000)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, -999999)]
        public void GetMin_WhenValidListPassed_ShouldReturnMinxValueInList(int[] actualArray, int expected)
        {
            Setup(actualArray, null, null);

            int actualInt = actual.GetMin();

            Assert.AreEqual(expected, actualInt);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 500)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 99999)]
        public void GetMax_WhenValidListPassed_ShouldReturnMaxValueInList(int[] actualArray, int expected)
        {
            Setup(actualArray, null, null);

            int actualInt = actual.GetMax();

            Assert.AreEqual(expected, actualInt);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Revers_WhenValidListPassed_shouldRevertList(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 12, -14, 0, 1 }, new int[] { -14, 0, 1, 5, 12 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 100 }, new int[] { 100 })]
        public void Sort_WhenValidSortPasse_ShouldSortingListAscending(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

            actual = actual.Sort(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 12, -14, 0, 1 }, new int[] { 12, 5, 1, 0, -14 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 100 }, new int[] { 100 })]
        public void Sort_WhenValidSortPassed_ShouldSortingListDescending(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

            actual = actual.Sort(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(false, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(false, new int[] { 0, 1, 2, 3, 4 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(false, new int[] { }, new int[] { 1 })]
        [TestCase(false, new int[] { 0 }, new int[] { })]
        [TestCase(true, new int[] { }, new int[] { })]
        public void Equals_WhenValidEqualsPassed_ShouldEqualsreturnFalsAndTrue(bool expectedBool, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, null);

            bool actualBool = expected.Equals(actual);

            Assert.AreEqual(expectedBool, actualBool);
        }
    }
}
