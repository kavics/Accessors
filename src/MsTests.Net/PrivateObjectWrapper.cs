using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTests.Net
{
    internal class PrivateObjectWrapper : PrivateObject
    {
        public PrivateObjectWrapper(object obj) : base(obj) { }
        public PrivateObjectWrapper(object obj, string memberToAccess) : base(obj, memberToAccess) { }
        public PrivateObjectWrapper(Type type, params object[] args) : base(type, args) { }
        public PrivateObjectWrapper(string assemblyName, string typeName, params object[] args) : base(assemblyName, typeName, args) { }
        public PrivateObjectWrapper(Type type, Type[] parameterTypes, object[] args) : base(type, parameterTypes, args) { }
        public PrivateObjectWrapper(string assemblyName, string typeName, Type[] parameterTypes, object[] args) : base(assemblyName, typeName, parameterTypes, args) { }

        public new object GetField(string name)
        {
            return base.GetField(name);
        }
        public new void SetField(string name, object value)
        {
            base.SetField(name, value);
        }

        public new object GetFieldOrProperty(string name)
        {
            return base.GetFieldOrProperty(name);
        }
        public new void SetFieldOrProperty(string name, object value)
        {
            base.SetFieldOrProperty(name, value);
        }

        public new object GetProperty(string name, params object[] args)
        {
            return base.GetProperty(name, args);
        }
        public new void SetProperty(string name, object value, params object[] args)
        {
            base.SetProperty(name, value, args);
        }

        public new object Invoke(string name, Type[] parameterTypes, object[] args)
        {
            return base.Invoke(name, parameterTypes, args);
        }
        public new object Invoke(string name, params object[] args)
        {
            return base.Invoke(name, args);
        }
        public new object Invoke(string name, Type[] parameterTypes, object[] args, Type[] typeArguments)
        {
            return base.Invoke(name, parameterTypes, args, typeArguments);
        }
    }
}
