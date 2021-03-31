using System;
using System.Collections.Generic;
using System.Text;

namespace List.Tests
{
    public class ArrayListTestsWhenValueTypeStringNegativeTests :AbstractBaseTestsWhenValueTypeStringNegativeTests
    {
        public override void CreateList(string[] actualArray)
        {
            actual = ArrayList<string>.Create(actualArray);
        }

        public override void CreateList(string[] actualArray, string[] addedArray)
        {
            actual = ArrayList<string>.Create(actualArray);
            addedList = ArrayList<string>.Create(addedArray);
        }
    }
}
