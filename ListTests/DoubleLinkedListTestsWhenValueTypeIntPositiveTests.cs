using System;
using System.Collections.Generic;
using System.Text;

namespace List.Tests
{
    class DoubleLinkedListTestsWhenValueTypeIntPositiveTests : AbstractBaseTestsWhenValueTypeIntPositiveTests
    {
        public override void CreateLists(int[] actualArray, int[] expectedArray, int[] addedArray)
        {
            if (actualArray != null)
            {
                actual = DoubleLinkedList<int>.Create(actualArray);
            }
            if (expectedArray != null)
            {
                expected = DoubleLinkedList<int>.Create(expectedArray);
            }
            if (addedArray != null)
            {
                addedList = DoubleLinkedList<int>.Create(addedArray);
            }
        }
    }
}
