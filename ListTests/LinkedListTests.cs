﻿using System;
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
    }
}
