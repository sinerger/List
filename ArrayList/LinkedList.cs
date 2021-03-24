using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LinkedList<T> where T : IComparable<T>
    {
        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value >= 0)
                {
                    _length = value;
                }
                else
                {
                    _length = 0;
                }
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
                    Node<T> currentNode = GetNodeByIndex(index);

                    currentNode.Value = value;
                }

                throw new IndexOutOfRangeException();
            }
        }

        private int _length;
        private Node<T> _root;
        private Node<T> _tail;

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

        public LinkedList(T[] values)
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

        public int GetIndexMinValue()
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
        public int GetIndexMaxValue()
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
            return this[GetIndexMinValue() + 1];
        }

        public T GetMax()
        {
            return this[GetIndexMaxValue() + 1];
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
                        Node<T> current = GetNodeByIndex(index);

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
                    Node<T> current = GetNodeByIndex(index: Length - count);

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
                    Node<T> current = GetNodeByIndex(index: count-1);

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
                        Node<T> current = GetNodeByIndex(index);

                        current.Next = null;
                        _tail = current;
                        Length = index;
                    }
                    else
                    {
                        Node<T> startRemoveRangeNode = GetNodeByIndex(index);
                        Node<T> finishRemoveRangeNode = GetNodeByIndex(index + count);

                        startRemoveRangeNode.Next = finishRemoveRangeNode.Next;
                        Length -= count;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid count");
                }
            }
            else
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
                throw new ArgumentException("Invalid count");
            }
        }

        public int RemoveAllByValue(T value)
        {
            if (value != null)
            {
                Node<T> current = _root;
                int count = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        RemoveByIndex(i);
                        --i;
                    }

                    ++count;
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
                Node<T> currentNode = new Node<T>(value);

                _root = currentNode;
                _tail = _root;
                ++Length;
            }
            else
            {
                Node<T> currentNode = new Node<T>(value);

                _tail.Next = currentNode;
                _tail = currentNode;
                _tail.Next = null;
                ++Length;
            }
        }



        public void AddFirst(T value)
        {
            Node<T> insertNode = new Node<T>(value);

            insertNode.Next = _root;
            _root = insertNode;
            ++Length;
        }
        public void AddByIndex(T value, int index)
        {
            if (index >= 0 && index <= Length)
            {
                if (index == 0)
                {
                    AddFirst(value);
                }
                else if (index == Length - 1)
                {
                    Add(value);
                }
                else
                {
                    Node<T> insertNode = new Node<T>(value);
                    Node<T> currentNode = GetNodeByIndex(index-1);

                    insertNode.Next = currentNode.Next;
                    currentNode.Next = insertNode;
                    ++Length;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddList(LinkedList<T> list)
        {
            if (list.Length != 0)
            {
                if (_tail is null)
                {
                    _root = list._root;
                }
                else
                {
                    _tail.Next = list._root;
                    _tail = list._tail;
                }

                Length += list.Length;
            }
        }

        public void AddListFirst(LinkedList<T> list)
        {
            if (list.Length != 0)
            {
                list._tail.Next = _root;
                _root = list._root;
                Length += list.Length;
            }
        }

        public void AddListByIndex(LinkedList<T> list, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    AddListFirst(list);
                }
                else if (index == Length - 1)
                {
                    AddList(list);
                }
                else
                {
                    Node<T> currentNode = GetNodeByIndex(index-1);

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

        public override bool Equals(object obj)
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
        
        private Node<T> GetNodeByIndex(int index)
        {
            Node<T> currentNode = _root;
            
            for (int i = 1; i < index; i++)
            {
            Node<T> currentNode = _root;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
    }
}
