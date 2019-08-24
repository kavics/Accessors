using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accessors
{
    public class TypeAccessor : Accessor
    {
        public Type TargetType { get; }

        public TypeAccessor(Type target)
        {
            TargetType = target;
        }
        public TypeAccessor(string assemblyName, string typeName)
        {
            var asm = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name == assemblyName);
            if (asm == null)
                throw new TypeLoadException("Unknown assembly: " + assemblyName);

            var type = asm.GetTypes()
                .FirstOrDefault(t => t.FullName == typeName);
            if (type == null)
                throw new TypeLoadException("Unknown type: " + typeName);

            TargetType = type;
        }

        public object GetStaticField(string fieldName)
        {
            throw new NotImplementedException();
        }
        public void SetStaticField(string fieldName, object value)
        {
            throw new NotImplementedException();
        }

        public object GetStaticProperty(string propertyName)
        {
            throw new NotImplementedException();
        }
        public void SetStaticProperty(string propertyName, object value)
        {
            throw new NotImplementedException();
        }

        public object GetStaticFieldOrProperty(string memberName)
        {
            throw new NotImplementedException();
        }
        public void SetStaticFieldOrProperty(string memberName, object value)
        {
            throw new NotImplementedException();
        }

        public object InvokeStatic(string name, params object[] args)
        {
            throw new NotImplementedException();
        }
        public object InvokeStatic(string name, Type[] parameterTypes, object[] args)
        {
            throw new NotImplementedException();
        }

    }
}
