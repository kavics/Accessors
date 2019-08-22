using System;

namespace Accessors
{
    public abstract class Accessor
    {
        public static ObjectAccessor Create(object target)
        {
            return new ObjectAccessor(target);
        }
        public static TypeAccessor Create(Type target)
        {
            return new TypeAccessor(target);
        }
    }
}
