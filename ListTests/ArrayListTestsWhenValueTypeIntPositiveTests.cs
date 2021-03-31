namespace List.Tests
{
    class ArrayListTestsWhenValueTypeIntPositiveTests : AbstractBaseTestsWhenValueTypeIntPositiveTests
    {
        public override void CreateLists(int[] actualArray, int[] expectedArray, int[] addedArray)
        {
            if (actualArray != null)
            {
                actual = ArrayList<int>.Create(actualArray);
            }
            if (expectedArray != null)
            {
                expected = ArrayList<int>.Create(expectedArray);
            }
            if (addedArray != null)
            {
                addedList = ArrayList<int>.Create(addedArray);
            }
        }
    }
}
