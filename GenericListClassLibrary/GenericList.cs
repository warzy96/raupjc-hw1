using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListClassLibrary
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _genericStorage;
        public int Count
        {
            get
            {
                return index + 1;
            }
        }
        private int index = -1;

        public GenericList()
        {
            _genericStorage = new X[4];
        }
        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
                _genericStorage = new X[4];
            else
                _genericStorage = new X[initialSize];
        }
        public void Add(X item)
        {
            if (index == _genericStorage.Length - 1)
            {
                X[] oldStorage = _genericStorage;
                _genericStorage = new X[_genericStorage.Length << 1];
                Copy(oldStorage);
            }
            _genericStorage[++index] = item;
        }

        public void Clear()
        {
            _genericStorage = new X[_genericStorage.Length];
            index = -1;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i <= index; i++)
            {
                if (_genericStorage[i].Equals(item)) return true;
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index > _genericStorage.Length) throw new IndexOutOfRangeException();
            return _genericStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i <= index; i++)
            {
                if (_genericStorage[i].Equals(item)) return i;
            }
            return -1;
        }

        public bool Remove(X item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index > _genericStorage.Length) throw new IndexOutOfRangeException();
            if (index == -1 || index > this.index) return false;
            Adjust(index);
            return true;
        }

        private void Copy(X[] oldStorage)
        {
            for (int i = 0; i < oldStorage.Length; i++)
            {
                _genericStorage[i] = oldStorage[i];
            }
        }

        private void Adjust(int position)
        {
            int i;
            for (i = position; i < index; i++)
            {
                _genericStorage[i] = _genericStorage[i + 1];
            }
            _genericStorage[i] = default(X);
            index--;
        }
        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class GenericListEnumerator<X> : IEnumerator<X>
        {
            private GenericList<X> genericList;
            private int position = -1;

            public GenericListEnumerator(GenericList<X> genericList)
            {
                this.genericList = genericList;
            }

            public X Current
            {
                get
                {
                    return genericList._genericStorage[position];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (position == genericList.index)
                {
                    return false;
                }
                position++;
                return true;

            }

            public void Reset()
            {
                position = default(int);
            }
        }
    }
   
}
