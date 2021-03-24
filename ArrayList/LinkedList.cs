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
                Node<T> currentNode = GetNodeByIndex(index);

                return currentNode.Value;
            }
            set
            {
                Node<T> currentNode = GetNodeByIndex(index);

                currentNode.Value = value;
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

        public void Add(T value)
        {
            if (_tail is null)
            {
                Node<T> currentNode = new Node<T>(value);

                _root = currentNode;
                ++Length;
            }
            else
            {
                Node<T> currentNode = new Node<T>(value);

                _tail.Next = currentNode;
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
                    Node<T> currentNode = GetNodeByIndex(index);

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
                    Node<T> currentNode = GetNodeByIndex(index);

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
                Node<T> currentThisNode = this._root;
                Node<T> currentListNode = list._root;

                do
                {
                    if (currentThisNode.Value.CompareTo(currentListNode.Value) != 0)
                    {
                        return false;
                    }
                    if ((currentListNode.Next is null) || (currentThisNode.Next is null))
                    {
                        break;
                    }
                    currentListNode = currentListNode.Next;
                    currentThisNode = currentThisNode.Next;
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

            return result.ToString();
        }

        private Node<T> GetNodeByIndex(int index)
        {
            Node<T> currentNode = _root;
            for (int i = 1; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
    }
}
