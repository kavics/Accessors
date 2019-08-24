using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Accessors
{
    public class TypeAccessor : Accessor
    {
        private BindingFlags _publicFlags = BindingFlags.Static | BindingFlags.Public;
        private BindingFlags _privateFlags = BindingFlags.Static | BindingFlags.NonPublic;

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
            var field = GetField(fieldName);
            return field.GetValue(null);
        }
        public void SetStaticField(string fieldName, object value)
        {
            var field = GetField(fieldName);
            field.SetValue(null, value);
        }
        private FieldInfo GetField(string name, bool throwOnError = true)
        {
            var field = TargetType.GetField(name, _publicFlags) ?? TargetType.GetField(name, _privateFlags);
            if (field == null && throwOnError)
                throw new ApplicationException("Field not found: " + name);
            return field;
        }

        public object GetStaticProperty(string propertyName)
        {
            var property = GetProperty(propertyName);
            var method =  property.GetGetMethod(true) ?? property.GetGetMethod(false);
            return method.Invoke(null, null);
        }
        public void SetStaticProperty(string propertyName, object value)
        {
            var property = GetProperty(propertyName);
            var method = property.GetSetMethod(true) ?? property.GetSetMethod(false);
            method.Invoke(null, new object[] { value });
        }
        private PropertyInfo GetProperty(string name, bool throwOnError = true)
        {
            var property = TargetType.GetProperty(name, _publicFlags) ?? TargetType.GetProperty(name, _privateFlags);
            if (property == null && throwOnError)
                throw new ApplicationException("Property not found: " + name);
            return property;
        }

        public object GetStaticFieldOrProperty(string memberName)
        {
            var field = GetField(memberName, false);
            if(field != null)
                return field.GetValue(null);

            var property = GetProperty(memberName, false);
            if (property == null)
                throw new ApplicationException("Field or property not found: " + memberName);

            var method = property.GetGetMethod(true) ?? property.GetGetMethod(false);
            if (method == null)
                throw new ApplicationException("The property does not have getter: " + memberName);

            return method.Invoke(null, null);
        }
        public void SetStaticFieldOrProperty(string memberName, object value)
        {
            var field = GetField(memberName, false);
            if (field != null)
            {
                field.SetValue(null, value);
                return;
            }

            var property = GetProperty(memberName, false);
            if (property == null)
                throw new ApplicationException("Field or property not found: " + memberName);

            var method = property.GetSetMethod(true) ?? property.GetSetMethod(false);
            if (method == null)
                throw new ApplicationException("The property does not have setter: " + memberName);

            method.Invoke(null, new object[] { value });
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
