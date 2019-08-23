using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTests.Net
{
    internal class PrivateTypeWrapper : PrivateType
    {
        public PrivateTypeWrapper(Type type) : base(type) { }
        public PrivateTypeWrapper(string assemblyName, string typeName) : base(assemblyName, typeName) { }

        public new object GetStaticField(string name)
        {
            return base.GetStaticField(name);
        }
        public new void SetStaticField(string name, object value)
        {
            base.SetStaticField(name, value);
        }

        public new object GetStaticFieldOrProperty(string name)
        {
            return base.GetStaticFieldOrProperty(name);
        }
        public new void SetStaticFieldOrProperty(string name, object value)
        {
            base.SetStaticFieldOrProperty(name, value);
        }

        public new object GetStaticProperty(string name, params object[] args)
        {
            return base.GetStaticProperty(name, args);
        }
        public new void SetStaticProperty(string name, object value, params object[] args)
        {
            base.SetStaticProperty(name, value, args);
        }

        public new object InvokeStatic(string name, params object[] args)
        {
            return base.InvokeStatic(name, args);
        }
        public new object InvokeStatic(string name, Type[] parameterTypes, object[] args)
        {
            return base.InvokeStatic(name, parameterTypes, args);
        }
    }
}
