using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Class2<T1, T2>
    {
        public Class2<long, DateTime> OneImplementation = null;

        public T1 A { get; }
        public T2 B { get; }

        public Class2(T1 a, T2 b)
        {
            A = a;
            B = b;
        }
    }
}
