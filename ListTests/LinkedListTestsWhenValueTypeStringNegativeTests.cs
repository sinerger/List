using System;
using System.Collections.Generic;
using System.Text;

namespace List.Tests
{
    class LinkedListTestsWhenValueTypeStringNegativeTests : AbstractBaseTestsWhenValueTypeStringNegativeTests
    {
        public override void CreateList(string[] actualArray)
        {
            actual = LinkedList<string>.Create(actualArray);
        }

        public override void CreateList(string[] actualArray, string[] addedArray)
        {
            actual = LinkedList<string>.Create(actualArray);
            addedList = LinkedList<string>.Create(addedArray);
        }
    }
}
