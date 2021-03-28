using NUnit.Framework;
using System;

namespace List.Tests
{
    public class ArrayListTests
    {
        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 100 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -10 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 })]
        public void Add_WhenValidValuePassed_ShouldAddToListinLastPosition(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void AddFirst_WhenValidValuePassed_ShouldAddToListFisrPosition(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-10, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, -10, 2, 3, 4, 5 })]
        [TestCase(0, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 0, 4, 5 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 })]
        public void AddByIndex_WhenValidValuePassed_ShouldAddToListByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-10, -10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, 6, new int[] { 1, 2, 3, 4, 5 })]
        public void AddByIndex_WhenInvalidPaseed_ShoultReturnIndexOutOfRangeException(int value, int index, int[] actualArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value, index));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void Remove_WhenValidValuePassed_SholdRemoveLastElement(int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirst_WhenValidValuePassed_SholdRemoveFirstElement(int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { -10, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 3, 4, 5 })]
        [TestCase(3, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 4, 5 })]
        [TestCase(4, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 5 })]
        public void RemoveByIndex_WhenValidValuePassed_SholdRemoveElementByIndex(int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveByIndex_WhenInvalidPaseed_ShoultReturnIndexOutOfRangeException(int index, int[] actualArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }

        [TestCase(0, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { -10, 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(3, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2 })]
        [TestCase(4, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { -10, 1 })]
        [TestCase(5, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { -10 })]
        [TestCase(6, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(7, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { })]
        public void RemoveNElements_WhenValidValuePassed_SholdRemoveNElement(int n, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.RemoveNElements(n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(3, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(4, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(5, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { 5 })]
        [TestCase(6, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(7, new int[] { -10, 1, 2, 3, 4, 5 }, new int[] { })]
        public void RemoveNElementsFromStart_WhenValidValuePassed_SholdRemoveNElementForStart(int n, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.RemoveNElementsFromStart(n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(1, 1, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 2, 3, 4, 5 })]
        [TestCase(2, 2, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 4, 5 })]
        [TestCase(3, 3, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2 })]
        [TestCase(4, 4, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3 })]
        [TestCase(0, 4, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        public void RemoveNElementsByIndex_WhenValidValuePassed_SholdRemoveNElementByIndex(int n, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.RemoveNElementsByIndex(n, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-100, 0, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 2, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 3, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 4, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(-100, 5, new int[] { 100, 1, 2, 3, 4, 5 })]
        public void RemoveNElementsByIndex_WhenInvalidValuePassed_SholdReturnArgumentException(int n, int index, int[] actualArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveNElementsByIndex(n, index));
        }

        [TestCase(100, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 3, 4, 5 })]
        [TestCase(3, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 4, 5 })]
        [TestCase(4, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 5 })]
        [TestCase(5, new int[] { 100, 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, })]
        public void RemoveElementByValue_WhenValidValuePassed_SholdRemoveFirstEntryElementByValue(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.RemoveElementByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new string[] { "1", "2", "3", "4", "5" })]
        public void RemoveElementByValue_WhenInvalidValuePassed_SholdReturnArgumentException(string value, string[] actualArray)
        {
            ArrayList<string> actual = new ArrayList<string>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveElementByValue(value));
        }

        [TestCase(100, new int[] { 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 100, 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 100, 100, 100, 100, 100, 100, 100, 0 }, new int[] { 0 })]
        public void RemoveAllElementsByValue_WhenValidValuePassed_SholdRemoveAllElementByValue(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.RemoveAllElementsByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new string[] { "100", "1", "2", "3", "4", "5" })]
        public void RemoveAllElementsByValue_WhenInalidValuePassed_SholdReturnArgumentException(string value, string[] actualArray)
        {
            ArrayList<string> actual = new ArrayList<string>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveAllElementsByValue(value));
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
        public void GetIndexbyValue_WhenValidIndexPassed_ShouldReturnIndexIfListContainsValueOrminusOneIfNoContainsValue(int value, int[] actualArray, int expected)
        {
            ArrayList<int> array = new ArrayList<int>(actualArray);

            int actual = array.GetIndexbyValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, new string[] { "100", "1", "2", "3", "4", "5" })]
        public void GetIndexbyValue_WhenInvalidValuePassed_SholdReturnArgumentException(string value, string[] actualArray)
        {
            ArrayList<string> actual = new ArrayList<string>(actualArray);

            Assert.Throws<ArgumentException>(() => actual.GetIndexbyValue(value));
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        public void Revers_WhenValidListPassed_shouldRevertList(int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 500)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 99999)]
        public void GetMaxValue_WhenValidListPassed_ShouldReturnMaxValueInList(int[] actualArray, int expected)
        {
            ArrayList<int> array = new ArrayList<int>(actualArray);

            int actual = array.GetMaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, -5)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, -1000)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, -999999)]
        public void GetMinValue_WhenValidListPassed_ShouldReturnMinxValueInList(int[] actualArray, int expected)
        {
            ArrayList<int> array = new ArrayList<int>(actualArray);

            int actual = array.GetMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 5)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 0)]
        public void GetIndexMinValue_WhenValidListPassed_ShouldReturnIndexMinValueInList(int[] actualArray, int expected)
        {
            ArrayList<int> array = new ArrayList<int>(actualArray);

            int actual = array.GetIndexMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { -5, -4, -3, -2, -1, 0 }, 5)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 100, 200, 300, 400, 500, -1000 }, 4)]
        [TestCase(new int[] { -999999, 99999, 1, 0, 542 }, 1)]
        public void GetIndexMaxValue_WhenValidListPassed_ShouldReturnIndexMaxValueInList(int[] actualArray, int expected)
        {
            ArrayList<int> array = new ArrayList<int>(actualArray);

            int actual = array.GetIndexMaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void AddArrayList_WhenValidListPassed_ShouldAddedListToList(int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);
            ArrayList<int> addedList = new ArrayList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

            actual.AddArrayList(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 1 })]
        public void AddArrayListToStart_WhenValidListPassed_ShouldAddedListToList(int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);
            ArrayList<int> addedList = new ArrayList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

            actual.AddArrayListToStart(addedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 10, 20, 30, 40, 50, 60, 70, 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 10, 20, 30, 40, 50, 60, 70, 3, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 20, 30, 40, 50, 60, 70, 4, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 10, 20, 30, 40, 50, 60, 70, 5 })]
        public void AddArrayListByIndex_WhenValidListPassed_ShouldAddedListToList(int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);
            ArrayList<int> addedList = new ArrayList<int>(new int[] { 10, 20, 30, 40, 50, 60, 70 });

            actual.AddArrayListByIndex(addedList, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, 100, new string[] { "1", "2", "3", "4", "5" })]
        public void AddArrayListByIndex_WhenInvlidValuePassed_SholdReturnIndexOutOfRangeException(ArrayList<string> value, int index, string[] actualArray)
        {
            ArrayList<string> actual = new ArrayList<string>(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddArrayListByIndex(value, index));
        }

        [TestCase(new int[] { 5, 12, -14, 0, 1 }, new int[] { -14, 0, 1, 5, 12 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 100 }, new int[] { 100 })]
        public void Sort_WhenValidSortPasse_ShouldSortingListAscending(int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.Sort(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 12, -14, 0, 1 }, new int[] { 12, 5, 1, 0, -14 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 100 }, new int[] { 100 })]
        public void Sort_WhenValidSortPasse_ShouldSortingListDescending(int[] actualArray, int[] expectedArray)
        {
            ArrayList<int> actual = new ArrayList<int>(actualArray);
            ArrayList<int> expected = new ArrayList<int>(expectedArray);

            actual.Sort(true);

            Assert.AreEqual(expected, actual);
        }
    }
}