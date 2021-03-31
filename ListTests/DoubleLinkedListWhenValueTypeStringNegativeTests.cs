using System;
using System.Collections.Generic;
using System.Text;

namespace List.Tests
{
    public class DoubleLinkedListWhenValueTypeStringNegativeTests:AbstractBaseTestsWhenValueTypeStringNegativeTests
    {
        public override void CreateList(string[] actualArray)
        {
            actual = DoubleLinkedList<string>.Create(actualArray);
        }

        public override void CreateList(string[] actualArray, string[] addedArray)
        {
            actual = DoubleLinkedList<string>.Create(actualArray);
            addedList = DoubleLinkedList<string>.Create(addedArray);
        }
    }
}
