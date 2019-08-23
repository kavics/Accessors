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

        /* =========================================== Methods */

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
    }
}
