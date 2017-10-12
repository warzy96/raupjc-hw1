using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_2
{
    class GenericList<X> : IGenericList<X>
    {
        private X[] _integerStorage;
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
            _integerStorage = new X[4];
        }
        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
                _integerStorage = new X[4];
            else
                _integerStorage = new X[initialSize];
        }
        public void Add(int item)
        {
            if (index == _integerStorage.Length - 1)
            {
                X[] oldStorage = _integerStorage;
                _integerStorage = new X[_integerStorage.Length << 1];
                Copy(oldStorage);
            }
            _integerStorage[++index] = item;
        }

        public void Clear()
        {
            _integerStorage = new X[_integerStorage.Length];
            index = -1;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < index; i++)
            {
                if (_integerStorage[i].Equals(item)) return true;
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index > _integerStorage.Length) throw new IndexOutOfRangeException();
            return _integerStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i <= index; i++)
            {
                if (_integerStorage[i].Equals(item)) return i;
            }
            return -1;
        }

        public bool Remove(X item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index > _integerStorage.Length) throw new IndexOutOfRangeException();
            if (index == -1 || index > this.index) return false;
            Adjust(index);
            return true;
        }

        private void Copy(X[] oldStorage)
        {
            for (int i = 0; i < oldStorage.Length; i++)
            {
                _integerStorage[i] = oldStorage[i];
            }
        }

        private void Adjust(int position)
        {
            int i;
            for (i = position; i < index; i++)
            {
                _integerStorage[i] = _integerStorage[i + 1];
            }
            _integerStorage[i] = default(X);
            index--;
        }
    }
}
}
