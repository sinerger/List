using System;
using System.Text;

namespace List
{
    public class ArrayList<T> where T : IComparable<T>
    {
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

                throw new IndexOutOfRangeException();
            }
        }

        private int _length;
        private T[] _array;
        private int _initLength = 10;
        public ArrayList()
        {
            Length = 0;
            _array = new T[_initLength];
        }

        public ArrayList(T value)
        {
            if (value != null)
            {
                Length = 1;
                _array = new T[_initLength];
                _array[0] = value;
            }
            else
            {
                throw new ArgumentException("Values is null");
            }
        }

        public ArrayList(T[] values)
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
            else
            {
                throw new ArgumentException("Array is null");
            }
        }

        /// <summary>
        /// Adds a value to the end of the list.
        /// </summary>
        /// <param value="value">Value to be added.</param>
        public void Add(T value)
        {
            AddByIndex(value, index: Length);
        }

        /// <summary>
        /// Adds a value to the beginning of the list.
        /// </summary>
        /// <param value="value">Value to be added.</param>
        public void AddFirst(T value)
        {
            AddByIndex(value, index: 0);
        }

        /// <summary>
        /// Adds a value at the specified index.
        /// </summary>
        /// <param value="value">Value to be added.</param>
        /// <param index="index">Index by which the value is inserted.</param>
        public void AddByIndex(T value, int index)
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
        public void RemoveNElements(int count)
        {
            if (count == 1)
            {
                RemoveNElementsByIndex(count, index: Length - 1);
            }
            else if (count >= Length)
            {
                Length = 0;

                DownSize();
            }
            else
            {
                int targetIndex = Length - count;

                RemoveNElementsByIndex(count, targetIndex);
            }
        }

        /// <summary>
        /// Remove H items from the beginning of the list.
        /// </summary>
        /// <param count="count">Count of items to be removed.</param>
        public void RemoveNElementsFromStart(int count)
        {
            RemoveNElementsByIndex(count, index: 0);
        }

        /// <summary>
        /// Remove H elements starting from the specified index.
        /// </summary>
        /// <param count="count">Count of items to be removed.</param>
        /// <param index="index">Index from which items will be removed.</param>
        public void RemoveNElementsByIndex(int count, int index)
        {
            if (index >= 0 && index <= Length && count >= 0)
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
            else if (count < 0)
            {
                throw new ArgumentException("Incorrect count");
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Removing the first occurrence of a value.
        /// </summary>
        /// <param value="value">Value to be removed.</param>
        /// <returns>Index of the removed item.</returns>
        public int RemoveElementByValue(T value)
        {
            if (value != null)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i].CompareTo(value) == 0)
                    {
                        RemoveByIndex(i);

                        return i;
                    }
                }

                return -1;
            }

            throw new ArgumentException("Value is null");
        }

        /// <summary>
        /// Remove all occurrences of an element.
        /// </summary>
        /// <param value="value">Value to be removed.</param>
        /// <returns>Returns the number of items removed.</returns>
        public int RemoveAllElementsByValue(T value)
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

                    return countRemoveElements;
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
        public int GetIndexbyValue(T value)
        {
            if (value != null)
            {
                if (Length != 0)
                {
                    for (int i = 0; i < Length; i++)
                    {
                        if (_array[i].CompareTo(value) == 0)
                        {
                            return i;
                        }
                    }
                }

                return -1;
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
                    Swap(i, Length - 1 - i);
                }
            }
        }

        /// <summary>
        /// Return max value of list.
        /// </summary>
        /// <returns>Max value.</returns>
        public T GetMaxValue()
        {
            return _array[GetIndexMaxValue()];
        }

        /// <summary>
        /// Return min value of list.
        /// </summary>
        /// <returns>Min value.</returns>
        public T GetMinValue()
        {
            return _array[GetIndexMinValue()];
        }

        /// <summary>
        /// Return index min value of list.
        /// </summary>
        /// <returns>Index min value.</returns>
        public int GetIndexMinValue()
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

            return -1;
        }

        /// <summary>
        /// Return index max value of list.
        /// </summary>
        /// <returns>Index max value.</returns>
        public int GetIndexMaxValue()
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

            return -1;
        }

        /// <summary>
        /// Adds an ArrayList to the end of the list.
        /// </summary>
        /// <param list="list">ArrayList.</param>
        public void AddArrayList(ArrayList<T> list)
        {
            AddArrayListByIndex(list, index: Length);
        }

        /// <summary>
        /// Adds an ArrayList to the beginning of the list.
        /// </summary>
        /// <param list="list">ArrayList.</param>
        public void AddArrayListToStart(ArrayList<T> list)
        {
            AddArrayListByIndex(list, index: 0);
        }

        /// <summary>
        /// Adds an ArrayList to the list by index.
        /// </summary>
        /// <param list="list">ArrayList.</param>
        /// <param index="index">Index by which the value will be inserted.</param>
        public void AddArrayListByIndex(ArrayList<T> list, int index)
        {
            if (index >= 0 && index <= Length)
            {
                Length += list.Length;
                if (Length >= _array.Length)
                {
                    UpSize();
                }

                int n = list.Length;
                for (int i = Length - 1; i >= index; i--)
                {
                    if (i + n < _array.Length)
                    {
                        _array[i + n] = _array[i];
                    }
                }

                int count = 0;
                for (int i = index; i < Length; i++)
                {
                    if (count < list.Length)
                    {
                        _array[i] = list[count++];
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
        public void Sort(bool isDescending)
        {
            for (int i = 1; i < Length; i++)
            {
                T currentValue = _array[i];
                int currentIndex = i;
                while ((isDescending && currentIndex > 0 && (_array[currentIndex - 1].CompareTo(currentValue) == -1))
                    || (!isDescending && currentIndex > 0 && (_array[currentIndex - 1].CompareTo(currentValue) == 1)))
                {
                    Swap(currentIndex, currentIndex - 1);

                    currentIndex -= 1;
                }

                _array[currentIndex] = currentValue;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                result.Append(_array[i]);
                result.Append(", ");
            }

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is ArrayList<T>)
            {
                ArrayList<T> list = (ArrayList<T>)obj;
                bool result = true;
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

                return result;
            }

            return false;
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
