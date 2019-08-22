using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Accessors
{
    public class ObjectAccessor : Accessor
    {
        private object _target;
        private Type _targetType;
        private BindingFlags _publicFlags = BindingFlags.Instance | BindingFlags.Public;
        private BindingFlags _privateFlags = BindingFlags.Instance | BindingFlags.NonPublic;

        public ObjectAccessor(object target)
        {
            _target = target;
            _targetType = _target.GetType();
        }

        public object Invoke(string methodName, params object[] parameters)
        {
            var paramTypes = parameters.Select(x => x.GetType()).ToArray();
            var method = _targetType.GetMethod(methodName, _privateFlags, null, paramTypes, null)
                ?? _targetType.GetMethod(methodName, _publicFlags, null, paramTypes, null);
            return method.Invoke(_target, parameters);
        }
    }
}
