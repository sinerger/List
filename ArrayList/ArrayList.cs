using List;
using System;
using System.Text;

namespace List
{
    public class ArrayList<T> : IList<T> where T : IComparable<T>
    {
        private int _length;
        private T[] _array;
        private const int InitLength = 10;

        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
                _length = value >= 0 ? value : 0;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                {
                    return _array[index];
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Length)
                {
                    _array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public ArrayList()
        {
            Length = 0;
            _array = new T[InitLength];
        }

        private ArrayList(T value)
        {
            Length = 1;
            _array = new T[InitLength];
            _array[0] = value;
        }

        private ArrayList(T[] values)
        {
            if (values != null)
            {
                Length = values.Length;
                _array = new T[(int)(values.Length * 2)];

                for (int i = 0; i < Length; i++)
                {
                    _array[i] = values[i];
                }
            }
        }

        public static ArrayList<T> Create(T value)
        {
            if (value != null)
            {
                ArrayList<T> list = new ArrayList<T>(value);

                return list;
            }

            throw new ArgumentException("Value is null");
        }

        public static ArrayList<T> Create(T[] array)
        {
            if (array != null)
            {
                return new ArrayList<T>(array);
            }

            throw new ArgumentException("Array is null");
        }

        /// <summary>
        /// Adds a value to the end of the list.
        /// </summary>
        /// <param value="value">Value to be added.</param>
        public void Add(T value)
        {
            AddByIndex(index: Length, value);
        }

        /// <summary>
        /// Adds a value to the beginning of the list.
        /// </summary>
        /// <param value="value">Value to be added.</param>
        public void AddFirst(T value)
        {
            AddByIndex(index: 0, value);
        }

        /// <summary>
        /// Adds a value at the specified index.
        /// </summary>
        /// <param value="value">Value to be added.</param>
        /// <param index="index">Index by which the value is inserted.</param>
        public void AddByIndex(int index, T value)
        {
            if (value != null)
            {
                if (index >= 0 && index <= Length)
                {
                    if (Length >= _array.Length)
                    {
                        UpSize();
                    }

                    for (int i = Length; i > index; i--)
                    {
                        _array[i] = _array[i - 1];
                    }

                    _array[index] = value;
                    ++Length;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentException("Value is null");
            }
        }

        /// <summary>
        /// Remove the last item in the list.
        /// </summary>
        public void Remove()
        {
            --Length;
            DownSize();
        }

        /// <summary>
        /// Remove the first item in the list.
        /// </summary>
        public void RemoveFirst()
        {
            if (Length != 0)
            {
                RemoveByIndex(index: 0);
            }
        }

        /// <summary>
        /// Remove an element by index from the array.
        /// </summary>
        /// <param Index="index">Index by which the value is removed</param>
        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == Length - 1)
                {
                    --Length;
                }
                else
                {
                    for (int i = index; i < Length; i++)
                    {
                        _array[i] = _array[i + 1];
                    }

                    --Length;

                    DownSize();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Remove H items from the end of the list.
        /// </summary>
        /// <param count="count">Count of items to be removed.</param>
        public void RemoveRange(int count)
        {
            if (count == 1)
            {
                RemoveRangeByIndex(index: Length - 1, count);
            }
            else if (count >= Length)
            {
                Length = 0;

                DownSize();
            }
            else if (count == 0)
            {
                return;
            }
            else
            {
                int targetIndex = Length - count;

                RemoveRangeByIndex(targetIndex, count);
            }
        }

        /// <summary>
        /// Remove H items from the beginning of the list.
        /// </summary>
        /// <param count="count">Count of items to be removed.</param>
        public void RemoveRangeFirst(int count)
        {
            RemoveRangeByIndex(index: 0, count);
        }

        /// <summary>
        /// Remove H elements starting from the specified index.
        /// </summary>
        /// <param count="count">Count of items to be removed.</param>
        /// <param index="index">Index from which items will be removed.</param>
        public void RemoveRangeByIndex(int index, int count)
        {
            if (Length > 0 && count >= 0)
            {
                if (index >= 0 && index < Length)
                {
                    if (count + index > Length)
                    {
                        Length = index;
                    }
                    else
                    {
                        for (int i = index; i < Length; i++)
                        {
                            if (i + count < _array.Length)
                            {
                                _array[i] = _array[i + count];
                            }
                        }

                        Length -= count;
                    }

                    DownSize();
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else if (count < 0)
            {
                throw new ArgumentException("Incorrect count");
            }
        }

        /// <summary>
        /// Removing the first occurrence of a value.
        /// </summary>
        /// <param value="value">Value to be removed.</param>
        /// <returns>Index of the removed item.</returns>
        public int RemoveByValue(T value)
        {
            if (value != null)
            {
                int result = -1;

                for (int i = 0; i < Length; i++)
                {
                    if (_array[i].CompareTo(value) == 0)
                    {
                        RemoveByIndex(i);

                        result = i;
                        break;
                    }
                }

                return result;
            }

            throw new ArgumentException("Value is null");
        }

        /// <summary>
        /// Remove all occurrences of an element.
        /// </summary>
        /// <param value="value">Value to be removed.</param>
        /// <returns>Returns the number of items removed.</returns>
        public int RemoveAllByValue(T value)
        {
            if (value != null)
            {
                int countRemoveElements = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (_array[i].CompareTo(value) == 0)
                    {
                        RemoveByIndex(i);

                        --i;
                        ++countRemoveElements;
                    }
                }

                if (countRemoveElements == 0)
                {
                    countRemoveElements -= 1;
                }

                return countRemoveElements;
            }

            throw new ArgumentException("Value is null");
        }

        /// <summary>
        /// Returns the index of the first occurrence.
        /// </summary>
        /// <param value="value">The value by which the index will be searched for.</param>
        /// <returns>Index of the first occurrence of the value.</returns>
        public int GetIndex(T value)
        {
            if (value != null)
            {
                int result = -1;

                if (Length != 0)
                {
                    for (int i = 0; i < Length; i++)
                    {
                        if (_array[i].CompareTo(value) == 0)
                        {
                            result = i;
                        }
                    }
                }

                return result;
            }

            throw new ArgumentException("Value is null");
        }

        /// <summary>
        /// Reverse the array.
        /// </summary>
        public void Reverse()
        {
            if (_array.Length > 0)
            {
                for (int i = 0; i < Length / 2; i++)
                {
                    Swap(firstIndex: i, secondIndex: Length - 1 - i);
                }
            }
        }

        /// <summary>
        /// Return max value of list.
        /// </summary>
        /// <returns>Max value.</returns>
        public T GetMax()
        {
            return _array[GetMaxIndex()];
        }

        /// <summary>
        /// Return min value of list.
        /// </summary>
        /// <returns>Min value.</returns>
        public T GetMin()
        {
            return _array[GetMinIndex()];
        }

        /// <summary>
        /// Return index min value of list.
        /// </summary>
        /// <returns>Index min value.</returns>
        public int GetMinIndex()
        {
            if (_array.Length > 0)
            {
                T minValue = _array[0];
                int indexMinValue = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (_array[i].CompareTo(minValue) == -1)
                    {
                        minValue = _array[i];
                        indexMinValue = i;
                    }
                }

                return indexMinValue;
            }
            else
            {
                throw new ArgumentException("Array no contain elements");
            }
        }

        /// <summary>
        /// Return index max value of list.
        /// </summary>
        /// <returns>Index max value.</returns>
        public int GetMaxIndex()
        {
            if (_array.Length > 0)
            {
                T maxValue = _array[0];
                int indexMaxValue = 0;
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i].CompareTo(maxValue) == 1)
                    {
                        maxValue = _array[i];
                        indexMaxValue = i;
                    }
                }

                return indexMaxValue;
            }
            else
            {
                throw new ArgumentException("Array no contain elements");
            }
        }

        /// <summary>
        /// Adds an ArrayList to the end of the list.
        /// </summary>
        /// <param list="list">ArrayList.</param>
        public void AddRange(IList<T> list)
        {
            AddRangeByIndex(index: Length, list);
        }

        /// <summary>
        /// Adds an ArrayList to the beginning of the list.
        /// </summary>
        /// <param list="list">ArrayList.</param>
        public void AddRangeFirst(IList<T> list)
        {
            AddRangeByIndex(index: 0, list);
        }

        /// <summary>
        /// Adds an ArrayList to the list by index.
        /// </summary>
        /// <param list="list">ArrayList.</param>
        /// <param index="index">Index by which the value will be inserted.</param>
        public void AddRangeByIndex(int index, IList<T> list)
        {
            ArrayList<T> arrayList = Create(list.ToArray());

            if (index >= 0 && index <= Length)
            {
                int oldLength = Length;
                Length += arrayList.Length;

                if (Length >= _array.Length)
                {
                    UpSize();
                }

                int n = arrayList.Length;

                for (int i = index; i < oldLength; i++)
                {
                    Swap(i, i + n);
                }

                for (int i = index, count = 0; i < Length; i++, count++)
                {
                    if (count < arrayList.Length)
                    {
                        _array[i] = arrayList[count];
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Sorts the list with inserts.
        /// </summary>
        /// <param isDescending="isDescending">If true, it sorts in descending order. If false, it sorts in ascending order.</param>
        public IList<T> Sort(bool isDescending = false)
        {
            ArrayList<T> list = new ArrayList<T>();

            for (int i = 0; i < Length; i++)
            {
                list.Add(_array[i]);
            }

            int coef = isDescending ? -1 : 1;

            for (int i = 1; i < list.Length; i++)
            {
                T currentValue = list[i];
                int currentIndex = i;

                while (currentIndex > 0 && (list[currentIndex - 1].CompareTo(currentValue) == coef))
                {
                    list.Swap(currentIndex, currentIndex - 1);

                    --currentIndex;
                }

                list[currentIndex] = currentValue;
            }

            return list;
        }

        public T[] ToArray()
        {
            T[] result = new T[] { };

            if (Length > 0)
            {
                result = new T[Length];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = _array[i];
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                result.Append($"{_array[i]} ");
            }

            return result.ToString().Trim();
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is ArrayList<T>)
            {
                ArrayList<T> list = (ArrayList<T>)obj;
                result = true;

                if (this.Length == list.Length)
                {
                    for (int i = 0; i < Length; i++)
                    {
                        if (!this._array[i].Equals(list._array[i]))
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            else if (obj is null)
            {
                throw new ArgumentNullException("Object is null");
            }

            return result;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            T tempVaue = _array[firstIndex];

            _array[firstIndex] = _array[secondIndex];
            _array[secondIndex] = tempVaue;
        }

        private void UpSize()
        {
            int tempLength = (int)(Length * 1.33d + 1);
            T[] tempArray = new T[tempLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }

        private void DownSize()
        {
            if (Length < _array.Length / 2 + 1)
            {
                int tempLength = (int)(Length * 1.33d + 1);
                T[] tempArray = new T[tempLength];

                for (int i = 0; i < Length; i++)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
        }
    }
}
