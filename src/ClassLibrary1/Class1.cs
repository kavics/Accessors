using System;

namespace ClassLibrary1
{
    public class Class1
    {
        private string _privateField;
        public string PublicField;

        private string PrivateProperty { get; set; }
        public string PublicProperty { get; set; }

        /* =========================================== for constructor tests */

        public Class1() { }

        /* -------------------------------------------------------- */

        public int A { get; }
        public long B { get; }
        public Class1(int a, long b)
        {
            A = a;
            B = b;
        }

        /* -------------------------------------------------------- */

        private class InnerClass1
        {
            private class InnerClass2 { internal int GetNinetyEight() { return 98; } }

            internal int GetNinetyNine() { return 99; }

            private InnerClass2 D { get { return new InnerClass2(); } }
        }

        private InnerClass1 C { get { return new InnerClass1(); } }

        /* =========================================== Methods */

        public string PublicMethod()
        {
            return "PublicMethod";
        }
        private string PrivateMethod()
        {
            return "PrivateMethod";
        }

        public int PublicMethod(int a)
        {
            return a + 1;
        }
        private int PrivateMethod(int a, int b = 0)
        {
            return a + b + 2;
        }

        public string PublicGenericMethod<T1, T2>(T1 o1, T2 o2)
        {
            return o1.GetType().Name + " " + o2.GetType().Name;
        }
        private string PrivateGenericMethod<T1, T2>(T1 o1, T2 o2)
        {
            return o1.GetType().Name + " " + o2.GetType().Name;
        }
    }
}
