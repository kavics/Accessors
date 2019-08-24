using System;
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
            throw new NotImplementedException();
        }
        public void SetField(string fieldName, object value)
        {
            throw new NotImplementedException();
        }

        public object GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }
        public void SetProperty(string propertyName, object value)
        {
            throw new NotImplementedException();
        }

        public object GetFieldOrProperty(string memberName)
        {
            throw new NotImplementedException();
        }
        public void SetFieldOrProperty(string memberName, object value)
        {
            throw new NotImplementedException();
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
