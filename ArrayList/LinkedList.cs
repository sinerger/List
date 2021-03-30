using System;
using System.Text;

namespace List
{
    public class LinkedList<T> : IList<T> where T : IComparable<T>
    {
        private int _length;
        private Node<T> _root;
        private Node<T> _tail;

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
                    Node<T> currentNode = GetNodeByIndex(index);

                    return currentNode.Value;
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Length)
                {
                    if (value != null)
                    {
                        Node<T> currentNode = GetNodeByIndex(index);

                        currentNode.Value = value;
                    }
                    else
                    {
                        throw new ArgumentException("Value is null");
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = _root;
        }

        public LinkedList(T value)
        {
            Length = 1;
            _root = new Node<T>(value);
            _tail = _root;
        }

        private LinkedList(T[] values)
        {
            Length = values.Length;
            if (values.Length != 0)
            {
                _root = new Node<T>(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node<T>(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = _root;
            }
        }

        public static LinkedList<T> Create(T[] array)
        {
            if (array != null)
            {
                LinkedList<T> list = new LinkedList<T>(array);

                return list;
            }

            throw new ArgumentException("Array is null");
        }

        public void Add(T value)
        {
            if (value != null)
            {
                if (_tail is null)
                {
                    _root = new Node<T>(value);
                    _tail = _root;
                    ++Length;
                }
                else
                {
                    _tail.Next = new Node<T>(value);
                    _tail = _tail.Next;
                    _tail.Next = null;
                    ++Length;
                }
            }
            else
            {
                throw new ArgumentException("Value is null");
            }
        }

        public void AddFirst(T value)
        {
            if (value != null)
            {
                Node<T> insertNode = new Node<T>(value);

                insertNode.Next = _root;
                _root = insertNode;
                ++Length;
            }
            else
            {
                throw new ArgumentException("Value is null");
            }
        }

        public void AddByIndex(int index, T value)
        {
            if (index >= 0 && index <= Length && value != null)
            {
                if (index == 0)
                {
                    AddFirst(value);
                }
                else if (index == Length)
                {
                    Add(value);
                }
                else
                {
                    Node<T> insertNode = new Node<T>(value);
                    Node<T> currentNode = GetNodeByIndex(index - 1);

                    insertNode.Next = currentNode.Next;
                    currentNode.Next = insertNode;
                    ++Length;
                }
            }
            else if (value == null)
            {
                throw new ArgumentException("Value is null");
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddRange(IList<T> list)
        {
            if (list != null)
            {
                LinkedList<T> linkedList = new LinkedList<T>(list.ToArray());

                if (linkedList.Length != 0)
                {
                    if (_tail is null)
                    {
                        _root = linkedList._root;
                    }
                    else
                    {
                        _tail.Next = linkedList._root;
                        _tail = linkedList._tail;
                    }

                    Length += linkedList.Length;
                }
            }
            else
            {
                throw new NullReferenceException("List is null");
            }
        }

        public void AddRangeFirst(IList<T> list)
        {
            if (list != null)
            {
                LinkedList<T> linkedList = new LinkedList<T>(list.ToArray());

                if (linkedList.Length != 0)
                {
                    linkedList._tail.Next = _root;
                    _root = linkedList._root;
                    Length += linkedList.Length;
                }
            }
            else
            {
                throw new NullReferenceException("List is null");
            }

        }

        public void AddRangeByIndex(int index, IList<T> list)
        {
            if (list != null)
            {
                LinkedList<T> linkedList = new LinkedList<T>(list.ToArray());

                if (index >= 0 && index <= Length)
                {
                    if (index == 0)
                    {
                        AddRangeFirst(list);
                    }
                    else if (index == Length)
                    {
                        AddRange(list);
                    }
                    else
                    {
                        Node<T> currentNode = GetNodeByIndex(index - 1);

                        linkedList._tail.Next = currentNode.Next;
                        currentNode.Next = linkedList._root;
                        Length += linkedList.Length;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new NullReferenceException("List is null");
            }
        }

        public void Remove()
        {
            if (Length > 0)
            {
                Node<T> current = GetNodeByIndex(index: Length - 1);

                _tail = current;
                _tail.Next = null;
                --Length;
            }
        }

        public void RemoveFirst()
        {
            if (Length > 0)
            {
                Node<T> current = _root.Next;

                _root = current;
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
                        Node<T> current = GetNodeByIndex(index - 1);

                        current.Next = current.Next.Next;
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
                    Node<T> current = GetNodeByIndex(index: Length - count - 1);

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

        public void RemoveRangeFirst(int count)
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
                    Node<T> current = GetNodeByIndex(index: count - 1);

                    _root = current.Next;
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
                    RemoveRangeFirst(count);
                }
                else if (count == Length - 1)
                {
                    RemoveRange(count);
                }
                else if (count > 0)
                {
                    if (count + index >= Length)
                    {
                        Node<T> current = GetNodeByIndex(index - 1);

                        current.Next = null;
                        _tail = current;
                        Length = index;
                    }
                    else
                    {
                        Node<T> startRemoveRangeNode = GetNodeByIndex(index - 1);
                        Node<T> finishRemoveRangeNode = GetNodeByIndex(index + count - 1);

                        startRemoveRangeNode.Next = finishRemoveRangeNode.Next;
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
                Node<T> current = _root;
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
                throw new ArgumentException("Value is null");
            }
        }

        // _tail??
        public int RemoveAllByValue(T value)
        {
            if (value != null)
            {
                int count = 0;
                if (Length == 1 && _root.Value.CompareTo(value) == 0)
                {
                    RemoveFirst();
                    ++count;
                }
                else if (Length > 1)
                {
                    Node<T> current = _root;

                    while (!(current.Next is null))
                    {
                        if (current.Next.Value.CompareTo(value) == 0)
                        {
                            current.Next = current.Next.Next;
                            ++count;
                            --Length;
                        }
                        else
                        {
                            current = current.Next;
                        }
                    }

                    if (_root.Value.CompareTo(value) == 0)
                    {
                        _root = _root.Next;
                        ++count;
                        --Length;
                    }
                }
                return count;
            }
            else
            {
                throw new ArgumentException("Value is null");
            }
        }

        public void Reverse()
        {
            if (Length > 0)
            {
                Node<T> previous = null;
                Node<T> current = _root;
                Node<T> following = _root;

                while (!(current is null!))
                {
                    following = following.Next;
                    current.Next = previous;
                    previous = current;
                    current = following;
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
                    Node<T> current = _root;
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
                throw new ArgumentException("Value is null");
            }
        }

        public int GetMinIndex()
        {
            if (Length > 0)
            {
                Node<T> current = _root;
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

        public int GetMaxIndex()
        {
            if (Length > 0)
            {
                Node<T> current = _root;
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
                Node<T> current = _root;
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
                Node<T> current = _root;
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

        public IList<T> Sort(bool isDescending)
        {
            LinkedList<T> list = new LinkedList<T>();
            list._root = this._root;
            list.Length = this.Length;
            int coef = isDescending ? 1 : -1;
            return MergeSort(list, coef);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is null))
            {
                LinkedList<T> list = (LinkedList<T>)obj;

                if (this.Length == list.Length)
                {
                    if (this.Length == 0 && list.Length == 0)
                    {
                        return true;
                    }

                    Node<T> currentThisNode = this._root;
                    Node<T> currentListNode = list._root;

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

            throw new ArgumentNullException("Invalid object");
        }

        public T[] ToArray()
        {
            if (Length > 0)
            {
                T[] result = new T[Length];
                Node<T> current = _root;
                for (int i = 0; i < Length; i++)
                {
                    result[i] = current.Value;
                    current = current.Next;
                }

                return result;
            }

            return new T[] { };
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(string.Empty);

            if (Length != 0)
            {
                Node<T> currentNode = _root;

                result.Append(currentNode.Value + " ");
                while (!(currentNode.Next is null))
                {
                    currentNode = currentNode.Next;
                    result.Append(currentNode.Value + " ");
                }
            }

            return result.ToString().Trim();
        }

        private LinkedList<T> MergeSort(LinkedList<T> list, int coef)
        {
            if (list.Length <= 1)
            {
                return list;
            }

            LinkedList<T> leftList = new LinkedList<T>();
            LinkedList<T> rightList = new LinkedList<T>();
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

            leftList = MergeSort(leftList, coef);
            rightList = MergeSort(rightList, coef);

            return Merge(leftList, rightList, coef);
        }

        private LinkedList<T> Merge(LinkedList<T> leftList, LinkedList<T> rightList, int coef)
        {
            LinkedList<T> result = new LinkedList<T>();

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

        private Node<T> GetNodeByIndex(int index)
        {
            if (index >= 0 && index <= Length)
            {
                Node<T> currentNode = _root;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode;
            }

            throw new IndexOutOfRangeException();
        }

    }
}
