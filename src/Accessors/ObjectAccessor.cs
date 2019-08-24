﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Accessors
{
    public class ObjectAccessor : Accessor
    {
        private Type _targetType;
        private BindingFlags _publicFlags = BindingFlags.Instance | BindingFlags.Public;
        private BindingFlags _privateFlags = BindingFlags.Instance | BindingFlags.NonPublic;

        public object Target { get; }

        public ObjectAccessor(object target)
        {
            Target = target;
            _targetType = Target.GetType();
        }
        public ObjectAccessor(Type type, params object[] arguments)
        {
            throw new NotImplementedException();
        }
        public ObjectAccessor(string assemblyName, string typeName, params object[] arguments)
        {
            throw new NotImplementedException();
        }
        public ObjectAccessor(object target, string memberToAccess)
        {
            throw new NotImplementedException();
        }


        public object GetField(string fieldName)
        {
            var field = GetFieldInfo(fieldName);
            return field.GetValue(Target);
        }
        public void SetField(string fieldName, object value)
        {
            var field = GetFieldInfo(fieldName);
            field.SetValue(Target, value);
        }
        private FieldInfo GetFieldInfo(string name, bool throwOnError = true)
        {
            var field = _targetType.GetField(name, _publicFlags) ?? _targetType.GetField(name, _privateFlags);
            if (field == null && throwOnError)
                throw new ApplicationException("Field not found: " + name);
            return field;
        }

        public object GetProperty(string propertyName)
        {
            var property = GetPropertyInfo(propertyName);
            var method = property.GetGetMethod(true) ?? property.GetGetMethod(false);
            return method.Invoke(Target, null);
        }
        public void SetProperty(string propertyName, object value)
        {
            var property = GetPropertyInfo(propertyName);
            var method = property.GetSetMethod(true) ?? property.GetSetMethod(false);
            method.Invoke(Target, new object[] { value });
        }
        private PropertyInfo GetPropertyInfo(string name, bool throwOnError = true)
        {
            var property = _targetType.GetProperty(name, _publicFlags) ?? _targetType.GetProperty(name, _privateFlags);
            if (property == null && throwOnError)
                throw new ApplicationException("Property not found: " + name);
            return property;
        }

        public object GetFieldOrProperty(string memberName)
        {
            var field = GetFieldInfo(memberName, false);
            if (field != null)
                return field.GetValue(Target);

            var property = GetPropertyInfo(memberName, false);
            if (property == null)
                throw new ApplicationException("Field or property not found: " + memberName);

            var method = property.GetGetMethod(true) ?? property.GetGetMethod(false);
            if (method == null)
                throw new ApplicationException("The property does not have getter: " + memberName);

            return method.Invoke(Target, null);
        }
        public void SetFieldOrProperty(string memberName, object value)
        {
            var field = GetFieldInfo(memberName, false);
            if (field != null)
            {
                field.SetValue(Target, value);
                return;
            }

            var property = GetPropertyInfo(memberName, false);
            if (property == null)
                throw new ApplicationException("Field or property not found: " + memberName);

            var method = property.GetSetMethod(true) ?? property.GetSetMethod(false);
            if (method == null)
                throw new ApplicationException("The property does not have setter: " + memberName);

            method.Invoke(Target, new object[] { value });
        }

        public object Invoke(string name, params object[] args)
        {
            var paramTypes = args.Select(x => x.GetType()).ToArray();
            var method = _targetType.GetMethod(name, _privateFlags, null, paramTypes, null)
                ?? _targetType.GetMethod(name, _publicFlags, null, paramTypes, null);
            return method.Invoke(Target, args);
        }
        public object Invoke(string name, Type[] parameterTypes, object[] args)
        {
            throw new NotImplementedException();
        }
        public object Invoke(string name, Type[] parameterTypes, object[] args, Type[] typeArguments)
        {
            throw new NotImplementedException();
        }
    }
}
