﻿using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedList<T> where T: IComparable<T>
    {
        public int Length
        {
            get
            {
                return _length;
            }
            set
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
                    DoubleLinkedListNode<T> currentNode = GetNodeByIndex(index);

                    return currentNode.Value;
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Length)
                {
                    DoubleLinkedListNode<T> currentNode = GetNodeByIndex(index);

                    currentNode.Value = value;
                }

                throw new IndexOutOfRangeException();
            }
        }

        private int _length;
        private DoubleLinkedListNode<T> _root;
        private DoubleLinkedListNode<T> _tail;

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = _root;
        }

        public DoubleLinkedList(T value)
        {
            Length = 1;
            _root = new DoubleLinkedListNode<T>(value);
            _tail = _root;
        }

        public DoubleLinkedList(T[] values)
        {
            Length = values.Length;
            if (values.Length != 0)
            {
                _root = new DoubleLinkedListNode<T>(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    DoubleLinkedListNode<T> tempNode = _tail;
                    _tail.Next = new DoubleLinkedListNode<T>(values[i]);
                    _tail = _tail.Next;
                    _tail.Previous = tempNode;
                }
            }
            else
            {
                _root = null;
                _tail = _root;
            }
        }

        public void Reverse()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;

                while (!(current is null!))
                {
                    var tempNode = current.Next;
                    current.Next = current.Previous;
                    current.Previous = tempNode;
                    current = current.Previous;
                }

                current = _root;
                _root = _tail;
                _tail = current;
            }
        }

        public int GetIndex(T value)
        {
            if (value != null)
            {
                if (Length > 0)
                {
                    DoubleLinkedListNode<T> current = _root;
                    int index = 0;

                    while (!(current is null))
                    {
                        if (current.Value.CompareTo(value) == 0)
                        {
                            return index;
                        }

                        ++index;
                        current = current.Next;
                    }

                    return -1;
                }

                return -1;
            }
            else
            {
                throw new ArgumentException("Invalid value");
            }
        }

        public int GetIndexMinValue()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;
                T minValue = current.Value;
                int indexMinValue = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value.CompareTo(minValue) == -1)
                    {
                        minValue = current.Value;
                        indexMinValue = i;
                    }

                    current = current.Next;
                }

                return indexMinValue;
            }

            return -1;
        }
        public int GetIndexMaxValue()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;
                T maxValue = current.Value;
                int indexMaxValue = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value.CompareTo(maxValue) == 1)
                    {
                        maxValue = current.Value;
                        indexMaxValue = i;
                    }

                    current = current.Next;
                }

                return indexMaxValue;
            }

            return -1;
        }

        public T GetMin()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;
                T MinValue = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value.CompareTo(MinValue) == -1)
                    {
                        MinValue = current.Value;
                    }

                    current = current.Next;
                }

                return MinValue;
            }
            else
            {
                throw new ArgumentException("Array no contain elements");
            }

        }

        public T GetMax()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;
                T maxValue = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value.CompareTo(maxValue) == 1)
                    {
                        maxValue = current.Value;
                    }

                    current = current.Next;
                }

                return maxValue;
            }
            else
            {
                throw new ArgumentException("Array no contain elements");
            }
        }

        public void Remove()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = GetNodeByIndex(index: Length - 1);

                _tail = current;
                _tail.Next = null;
                --Length;
            }
        }

        public void RemoveFirst()
        {
            if (Length == 1)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root.Next;

                _root = current;
                _root.Previous = null;
                --Length;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (Length > 0)
                {
                    if (index == 0)
                    {
                        RemoveFirst();
                    }
                    else if (index == Length - 1)
                    {
                        Remove();
                    }
                    else
                    {
                        DoubleLinkedListNode<T> current = GetNodeByIndex(index - 1);

                        current.Next = current.Next.Next;
                        current.Next.Previous = current;

                        --Length;
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void RemoveRange(int count)
        {
            if (Length > 0 && count >= 0)
            {
                if (count >= Length)
                {
                    _root = null;
                    _tail = null;
                    Length = 0;
                }
                else
                {
                    DoubleLinkedListNode<T> current = GetNodeByIndex(index: Length - count - 1);

                    current.Next = null;
                    _tail = current;
                    Length -= count;
                }
            }
            else if (count < 0)
            {
                throw new ArgumentException("Invalid count");
            }
        }

        public void RemoveRangeFromStart(int count)
        {
            if (Length > 0 && count >= 0)
            {
                if (count >= Length)
                {
                    _root = null;
                    _tail = null;
                    Length = 0;
                }
                else if (count == 0)
                {
                    return;
                }
                else
                {
                    DoubleLinkedListNode<T> current = GetNodeByIndex(index: count - 1);

                    _root = current.Next;
                    _root.Previous = null;
                    Length -= count;
                }
            }
            else if (count < 0)
            {
                throw new ArgumentException("Invalid count");
            }
        }

        public void RemoveRangeByIndex(int index, int count)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    RemoveRangeFromStart(count);
                }
                else if (count == Length - 1)
                {
                    RemoveRange(count);
                }
                else if (count > 0)
                {
                    if (count + index >= Length)
                    {
                        DoubleLinkedListNode<T> current = GetNodeByIndex(index - 1);

                        current.Next = null;
                        _tail = current;
                        Length = index;
                    }
                    else
                    {
                        DoubleLinkedListNode<T> startRemoveRangeNode = GetNodeByIndex(index - 1);
                        DoubleLinkedListNode<T> finishRemoveRangeNode = GetNodeByIndex(index + count - 1);

                        startRemoveRangeNode.Next = finishRemoveRangeNode.Next;
                        finishRemoveRangeNode.Next.Previous = startRemoveRangeNode;
                        Length -= count;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid count");
                }
            }
            else if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

        }

        public int RemoveByValue(T value)
        {
            if (value != null)
            {
                DoubleLinkedListNode<T> current = _root;
                int index = 0;

                while (!(current is null))
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        RemoveByIndex(index);

                        return index;
                    }

                    ++index;
                    current = current.Next;
                }

                return -1;
            }
            else
            {
                throw new ArgumentException("Invalid count");
            }
        }

        public int RemoveAllByValue(T value)
        {
            if (value != null)
            {
                if(Length == 1)
                {
                    _root = null;
                    _tail = null;
                    Length = 0;
                }

                DoubleLinkedListNode<T> current = _root;
                int count = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (_root.Value.CompareTo(value) == 0)
                    {
                        _root = _root.Next;
                    }

                    if (current.Value.CompareTo(value) == 0)
                    {
                        if((current.Previous is null))
                        {
                            current.Next.Previous = null;
                        }
                        else if(current.Next is null)
                        {
                            current.Previous.Next = null;
                            _tail = current.Previous;
                        }
                        else
                        {
                            current.Previous.Next = current.Next;
                            current.Next.Previous = current.Previous;
                        }

                        --i;
                        --Length;
                        ++count;
                    }

                    current = current.Next;
                }

                return count;
            }
            else
            {
                throw new ArgumentException("Invalid count");
            }
        }

        public void Add(T value)
        {
            if (_tail is null)
            {
                DoubleLinkedListNode<T> currentNode = new DoubleLinkedListNode<T>(value);

                _root = currentNode;
                _tail = _root;
                ++Length;
            }
            else
            {
                DoubleLinkedListNode<T> currentNode = new DoubleLinkedListNode<T>(value);
                var tempNode = _tail;

                _tail.Next = currentNode;
                _tail = currentNode;
                _tail.Next = null;
                _tail.Previous = tempNode;
                ++Length;
            }
        }

        public void AddFirst(T value)
        {
            DoubleLinkedListNode<T> insertNode = new DoubleLinkedListNode<T>(value);

            insertNode.Next = _root;
            _root = insertNode;
            _root.Next.Previous = insertNode;
            ++Length;
        }

        public void AddByIndex(T value, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    AddFirst(value);
                }
                else
                {
                    DoubleLinkedListNode<T> insertNode = new DoubleLinkedListNode<T>(value);
                    DoubleLinkedListNode<T> currentNode = GetNodeByIndex(index - 1);

                    insertNode.Next = currentNode.Next;
                    currentNode.Next = insertNode;
                    insertNode.Previous = currentNode;
                    insertNode.Next.Previous = insertNode;
                    ++Length;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddList(DoubleLinkedList<T> list)
        {
            if (list.Length != 0)
            {
                if (_tail is null)
                {
                    _root = list._root;
                }
                else
                {
                    list._root.Previous = _tail;
                    _tail.Next = list._root;
                    _tail = list._tail;
                }

                Length += list.Length;
            }
        }

        public void AddListFirst(DoubleLinkedList<T> list)
        {
            if(Length == 0)
            {
                _root = list._root;
                _tail = list._tail;
                Length = list.Length;
            }
            else if (list.Length != 0)
            {
                _root.Previous = list._tail;
                list._tail.Next = _root;
                _root = list._root;
                Length += list.Length;
            }
        }

        public void AddListByIndex(DoubleLinkedList<T> list, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    AddListFirst(list);
                }
                else
                {
                    DoubleLinkedListNode<T> currentNode = GetNodeByIndex(index - 1);
                    list._root.Previous = currentNode;
                    currentNode.Next.Previous = list._tail;
                    list._tail.Next = currentNode.Next;
                    currentNode.Next = list._root;
                    Length += list.Length;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        
        public DoubleLinkedList<T> Sort(bool isDescending)
        {
            DoubleLinkedList<T> list = new DoubleLinkedList<T>();
            list._root = this._root;
            list._tail = this._tail;
            list.Length = this.Length;
            return MergeSort(list, isDescending);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is null))
            {
                DoubleLinkedList<T> list = (DoubleLinkedList<T>)obj;

                if (this.Length == list.Length)
                {
                    if (this.Length == 0 && list.Length == 0)
                    {
                        return true;
                    }

                    DoubleLinkedListNode<T> currentThisNode = this._root;
                    DoubleLinkedListNode<T> currentListNode = list._root;

                    do
                    {
                        if (!(currentListNode.Next is null) || !(currentThisNode.Next is null))
                        {
                            if (currentThisNode.Value.CompareTo(currentListNode.Value) != 0)
                            {
                                return false;
                            }

                            currentListNode = currentListNode.Next;
                            currentThisNode = currentThisNode.Next;
                        }
                    }
                    while (!(currentThisNode.Next is null));

                    return true;
                }

                return false;
            }

            throw new ArgumentNullException();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(string.Empty);

            if (Length != 0)
            {
                DoubleLinkedListNode<T> currentNode = _root;

                result.Append(currentNode.Value + " ");
                while (!(currentNode.Next is null))
                {
                    currentNode = currentNode.Next;
                    result.Append(currentNode.Value + " ");
                }
            }

            return result.ToString().Trim();
        }

        private DoubleLinkedList<T> MergeSort(DoubleLinkedList<T> list, bool isDescending)
        {
            if (list.Length <= 1)
            {
                return list;
            }

            DoubleLinkedList<T> leftList = new DoubleLinkedList<T>();
            DoubleLinkedList<T> rightList = new DoubleLinkedList<T>();
            int mid = list.Length / 2;

            for (int i = 0; i < list.Length; i++)
            {
                if (i < mid)
                {
                    leftList.Add(list[i]);
                }
                else
                {
                    rightList.Add(list[i]);
                }
            }

            leftList = MergeSort(leftList, isDescending);
            rightList = MergeSort(rightList, isDescending);

            return Merge(leftList, rightList, isDescending);
        }

        private DoubleLinkedList<T> Merge(DoubleLinkedList<T> leftList, DoubleLinkedList<T> rightList, bool isDescending)
        {
            var coef = isDescending ? -1 : 1;

            DoubleLinkedList<T> result = new DoubleLinkedList<T>();

            while (leftList.Length != 0 || rightList.Length != 0)
            {
                if (leftList.Length != 0 && rightList.Length != 0)
                {
                    if (leftList[0].CompareTo(rightList[0]) == coef || leftList[0].CompareTo(rightList[0]) == 0)
                    {
                        result.Add(leftList[0]);
                        leftList.RemoveFirst();
                    }
                    else
                    {
                        result.Add(rightList[0]);
                        rightList.RemoveFirst();
                    }
                }
                else if (leftList.Length != 0)
                {
                    result.Add(leftList[0]);
                    leftList.RemoveFirst();
                }
                else if (rightList.Length != 0)
                {
                    result.Add(rightList[0]);
                    rightList.RemoveFirst();
                }
            }

            return result;
        }

        private DoubleLinkedListNode<T> GetNodeByIndex(int index)
        {

            DoubleLinkedListNode<T> currentNode = null;
            if(index < Length / 2+1)
            {
                currentNode = _root;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
            }
            else
            {
                currentNode = _tail;
                for (int i = Length-1; i >index; i--)
                {
                    currentNode = currentNode.Previous;
                }
            }

            return currentNode;
        }
    }
}
