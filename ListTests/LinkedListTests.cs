using System;
using System.Collections.Generic;
using System.Text;

namespace List.Tests
{
    class LinkedListTests : AbstractBaseTestsWhenValueTypeInt
    {
        public override void CreateLists(int[] actualArray, int[] expectedArray, int[] addedArray)
        {
            if (actualArray != null)
            {
                actual = LinkedList<int>.Create(actualArray);
            }
            if (expectedArray != null)
            {
                expected = LinkedList<int>.Create(expectedArray);
            }
            if (addedArray != null)
            {
                addedList = LinkedList<int>.Create(addedArray);
            }
        }
    }
}
