using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class IntegerList : IIntegerList
    {
        private int[] _integerStorage;
        public int Count
        {
            get
            {
                return index + 1;
            }
        }
        private int index = -1;

        public IntegerList()
        {
            _integerStorage = new int[4];
        }
        public IntegerList(int initialSize)
        {
            if (initialSize <= 0)
                _integerStorage = new int[4];
            else 
                _integerStorage = new int[initialSize];
        }
        public void Add(int item)
        {
            if(index == _integerStorage.Length - 1)
            {
                int[] oldStorage = _integerStorage;
                _integerStorage = new int[_integerStorage.Length << 1];
                Copy(oldStorage);
            }
            _integerStorage[++index] = item;
        }

        public void Clear()
        {
            _integerStorage = new int[_integerStorage.Length];
            index = -1;
        }

        public bool Contains(int item)
        {
            for(int i=0; i<index; i++)
            {
                if (_integerStorage[i] == item) return true;
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index > _integerStorage.Length) throw new IndexOutOfRangeException();
            return _integerStorage[index];
        }

        public int IndexOf(int item)
        {
            for(int i=0; i<=index; i++)
            {
                if (_integerStorage[i] == item) return i;
            }
            return -1;
        }

        public bool Remove(int item)
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

        private void Copy(int[] oldStorage)
        {
            for(int i=0; i<oldStorage.Length; i++)
            {
                _integerStorage[i] = oldStorage[i];
            }
        }

        private void Adjust(int position)
        {
            int i;
            for(i=position; i<index; i++)
            {
                _integerStorage[i] = _integerStorage[i + 1];
            }
            _integerStorage[i] = 0;
            index--;
        }
    }
}
