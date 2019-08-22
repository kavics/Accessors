using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTests.Net
{
    public class PrivateObjectWrapper : PrivateObject
    {
        //
        // Summary:
        //     Initializes a new instance of the Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject
        //     class that wraps the given object.
        //
        // Parameters:
        //   obj:
        //     object to wrap
        public PrivateObjectWrapper(object obj) : base(obj) { }
        //
        // Summary:
        //     Initializes a new instance of the Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject
        //     class that contains the already existing object of the private class
        //
        // Parameters:
        //   obj:
        //     object that serves as starting point to reach the private members
        //
        //   memberToAccess:
        //     the derefrencing string using . that points to the object to be retrived as in
        //     m_X.m_Y.m_Z
        public PrivateObjectWrapper(object obj, string memberToAccess) : base(obj, memberToAccess) { }
        //
        // Summary:
        //     Initializes a new instance of the Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject
        //     class that wraps the specified type.
        //
        // Parameters:
        //   type:
        //     type of the object to create
        //
        //   args:
        //     Argmenets to pass to the constructor
        public PrivateObjectWrapper(Type type, params object[] args) : base(type, args) { }
        //
        // Summary:
        //     Initializes a new instance of the Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject
        //     class that wraps the given object.
        //
        // Parameters:
        //   obj:
        //     object to wrap
        //
        //   type:
        //     PrivateType object
        public PrivateObjectWrapper(object obj, PrivateType type) : base(obj, type) { }
        //
        // Summary:
        //     Initializes a new instance of the Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject
        //     class that wraps the specified type.
        //
        // Parameters:
        //   assemblyName:
        //     Name of the assembly
        //
        //   typeName:
        //     fully qualified name
        //
        //   args:
        //     Argmenets to pass to the constructor
        public PrivateObjectWrapper(string assemblyName, string typeName, params object[] args) : base(assemblyName, typeName, args) { }
        //
        // Summary:
        //     Initializes a new instance of the Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject
        //     class that wraps the specified type.
        //
        // Parameters:
        //   type:
        //     type of the object to create
        //
        //   parameterTypes:
        //     An array of System.Type objects representing the number, order, and type of the
        //     parameters for the constructor to get
        //
        //   args:
        //     Argmenets to pass to the constructor
        public PrivateObjectWrapper(Type type, Type[] parameterTypes, object[] args) : base(type, parameterTypes, args) { }
        //
        // Summary:
        //     Initializes a new instance of the Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject
        //     class that wraps the specified type.
        //
        // Parameters:
        //   assemblyName:
        //     Name of the assembly
        //
        //   typeName:
        //     fully qualified name
        //
        //   parameterTypes:
        //     An array of System.Type objects representing the number, order, and type of the
        //     parameters for the constructor to get
        //
        //   args:
        //     Argmenets to pass to the constructor
        public PrivateObjectWrapper(string assemblyName, string typeName, Type[] parameterTypes, object[] args) : base(assemblyName, typeName, args) { }


        public new object GetField(string name)
        {
            return base.GetField(name);
        }
        public new object GetFieldOrProperty(string name)
        {
            return base.GetFieldOrProperty(name);
        }
        //
        // Summary:
        //     Invokes the specified method
        //
        // Parameters:
        //   name:
        //     Name of the method
        //
        //   parameterTypes:
        //     An array of System.Type objects representing the number, order, and type of the
        //     parameters for the method to get.
        //
        //   args:
        //     Arguments to pass to the member to invoke.
        //
        //   typeArguments:
        //     An array of types corresponding to the types of the generic arguments.
        //
        // Returns:
        //     Result of method call
        public new object Invoke(string name, Type[] parameterTypes, object[] args, Type[] typeArguments)
        {
            return base.Invoke(name, parameterTypes, args, typeArguments);
        }

        public new object Invoke(string name, Type[] parameterTypes, object[] args)
        {
            return base.Invoke(name, parameterTypes, args);
        }
        public new object Invoke(string name, params object[] args)
        {
            return base.Invoke(name, args);
        }
        public new void SetField(string name, object value)
        {
            base.SetField(name, value);
        }
        public new void SetFieldOrProperty(string name, object value)
        {
            base.SetFieldOrProperty(name, value);
        }
    }
}
