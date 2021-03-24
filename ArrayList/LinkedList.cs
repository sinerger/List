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

            return result.ToString().Trim();
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
