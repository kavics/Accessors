using System;

namespace ClassLibrary1
{
    public class Class1
    {
        private string _privateField;
        public string PublicField;

        private string PrivateProperty { get; set; }
        public string PublicProperty { get; set; }

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
    }
}
