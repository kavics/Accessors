using System;
using System.Collections.Generic;
using System.Text;

namespace Accessors
{
    public class TypeAccessor : Accessor
    {
        private Type target;

        public TypeAccessor(Type target)
        {
            this.target = target;
        }
    }
}
