using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTests.Net
{
    [TestClass]
    public class PrivateTypeTests
    {
        /* ============================================================= Construction tests */

        [TestMethod]
        public void PrivType_Ctor()
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            Assert.AreEqual(typeof(StaticClass1), targetAcc.ReferencedType);
        }
        [TestMethod]
        public void PrivType_Ctor_Dynamic()
        {
            var targetAcc = new PrivateTypeWrapper("ClassLibrary1", "ClassLibrary1.StaticClass1");
            Assert.AreEqual(typeof(StaticClass1), targetAcc.ReferencedType);
        }

        /* ============================================================= Property and field tests */

        [TestMethod]
        public void PrivType_Field_Public()
        {
            StringFieldTest("PublicField");
        }
        [TestMethod]
        public void PrivType_Field_Private()
        {
            StringFieldTest("_privateField");
        }

        [TestMethod]
        public void PrivType_Property_Public()
        {
            StringPropertyTest("PublicProperty");
        }
        [TestMethod]
        public void PrivType_Property_Private()
        {
            StringPropertyTest("PrivateProperty");
        }

        private void StringFieldTest(string fieldName)
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            var expected = Guid.NewGuid().ToString();

            targetAcc.SetStaticField(fieldName, null);
            var actual = targetAcc.GetStaticField(fieldName);
            Assert.IsNull(actual);

            targetAcc.SetStaticField(fieldName, expected);
            actual = targetAcc.GetStaticField(fieldName);
            Assert.AreEqual(expected, actual);

            StringFieldOrPropertyTest(fieldName);
        }
        private void StringPropertyTest(string propertyName)
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            var expected = Guid.NewGuid().ToString();

            targetAcc.SetStaticProperty(propertyName, null);
            var actual = targetAcc.GetStaticProperty(propertyName);
            Assert.IsNull(actual);

            targetAcc.SetStaticProperty(propertyName, expected);
            actual = targetAcc.GetStaticProperty(propertyName);
            Assert.AreEqual(expected, actual);

            StringFieldOrPropertyTest(propertyName);
        }
        private void StringFieldOrPropertyTest(string memberName)
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            var expected = Guid.NewGuid().ToString();

            targetAcc.SetStaticFieldOrProperty(memberName, null);
            var actual = targetAcc.GetStaticFieldOrProperty(memberName);
            Assert.IsNull(actual);

            targetAcc.SetStaticFieldOrProperty(memberName, expected);
            actual = targetAcc.GetStaticFieldOrProperty(memberName);
            Assert.AreEqual(expected, actual);
        }

        /* ============================================================= Method tests */

        [TestMethod]
        public void PrivType_Invoke_Public_withoutParam()
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            var actual = targetAcc.InvokeStatic("PublicMethod");
            Assert.AreEqual("PublicStaticMethod", actual);
        }
        [TestMethod]
        public void PrivType_Invoke_Private_withoutParam()
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            var actual = targetAcc.InvokeStatic("PrivateMethod");
            Assert.AreEqual("PrivateStaticMethod", actual);
        }
        [TestMethod]
        public void PrivType_Invoke_Public_withParams()
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            var actual = targetAcc.InvokeStatic("PublicMethod", 42);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void PrivType_Invoke_Private_withParams()
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            var actual = targetAcc.InvokeStatic("PrivateMethod", 42, 0);
            Assert.AreEqual(44, actual);
        }
        [TestMethod]
        public void PrivType_Invoke_Public_withParamsAndTypes()
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            var paramTypes = new[] { typeof(int) };
            var values = new object[] { 42 };
            var actual = targetAcc.InvokeStatic("PublicMethod", paramTypes, values);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void PrivType_Invoke_Private_withParamsAndTypes()
        {
            var targetAcc = new PrivateTypeWrapper(typeof(StaticClass1));
            var paramTypes = new[] { typeof(int), typeof(int) };
            var values = new object[] { 42, 0 };
            var actual = targetAcc.InvokeStatic("PrivateMethod", paramTypes, values);
            Assert.AreEqual(44, actual);
        }
    }
}
