using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public interface IList<T>
    {
        public void Add(T value);

        public void AddFirst(T value);

        public void AddByIndex(int index, T value);

        public void AddRange(IList<T> list);

        public void AddRangeFirst(IList<T> list);

        public void AddRangeByIndex(IList<T> list, int index);

        public void Remove();

        public void RemoveFirst();

        public void RemoveByIndex(int index);

        public void RemoveRange(int count);

        public void RemoveRangeFirst(int count);

        public void RemoveRangeByIndex(int index, int count);

        public int RemoveByValue(T value);

        public int RemoveAllByValue(T value);

        public void Reverse();

        public int GetIndex(T value);

        public T GetMin();

        public T GetMax();

        public int GetMinIndex();

        public int GetMaxIndex();

        public IList<T> Sort(bool isDescending);
    }
}
