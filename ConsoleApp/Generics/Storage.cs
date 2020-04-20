using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Generics
{
    class Storage<T>
    {

        private T _number;

        public void Save(T number)
        {
            _number = number;
        }

        public T Get()
        {
            return _number;
        }
    }
}
