using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public static class StaticClass1
    {
        private static string _privateField;
        public static string PublicField;

        private static string PrivateProperty { get; set; }
        public static string PublicProperty { get; set; }

        public static string PublicMethod()
        {
            return "PublicStaticMethod";
        }
        private static string PrivateMethod()
        {
            return "PrivateStaticMethod";
        }

        public static int PublicMethod(int a)
        {
            return a + 1;
        }
        private static int PrivateMethod(int a, int b = 0)
        {
            return a + b + 2;
        }

        public static string PublicGenericMethod<T1, T2>(T1 o1, T2 o2)
        {
            return o1.GetType().Name + " " + o2.GetType().Name;
        }
        private static string PrivateGenericMethod<T1, T2>(T1 o1, T2 o2)
        {
            return o1.GetType().Name + " " + o2.GetType().Name;
        }
    }
}
