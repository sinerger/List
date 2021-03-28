using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Previous { get; set; }

        public DoubleLinkedListNode(T value)
        {
            if(!(value is null))
            {
            Value = value;
            }
        }
    }
}
