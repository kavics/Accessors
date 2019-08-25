using Accessors;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MsTests
{
    [TestClass]
    public class AccessorTests
    {
        /* ============================================================= Type construction tests */

        [TestMethod]
        public void TA_Ctor()
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            Assert.AreEqual(typeof(StaticClass1), targetAcc.TargetType);
        }
        [TestMethod]
        public void TA_Ctor_Dynamic()
        {
            var targetAcc = new TypeAccessor("ClassLibrary1", "ClassLibrary1.StaticClass1");
            Assert.AreEqual(typeof(StaticClass1), targetAcc.TargetType);
        }

        /* ============================================================= Object construction tests */

        [TestMethod]
        public void OA_Ctor_2Params()
        {
            var parameters = new object[] { 42, 43L };
            var targetAcc = new ObjectAccessor(typeof(Class1), parameters);
            var target = (Class1)targetAcc.Target;
            Assert.AreEqual(42, target.A);
            Assert.AreEqual(43L, target.B);
        }
        [TestMethod]
        public void OA_Ctor_Dynamic_2Params()
        {
            var parameters = new object[] { 42, 43L };

            var targetAcc = new ObjectAccessor("ClassLibrary1", "ClassLibrary1.Class1", parameters);

            var target = (Class1)targetAcc.Target;
            Assert.AreEqual(42, target.A);
            Assert.AreEqual(43L, target.B);
        }
        [TestMethod]
        public void OA_Ctor_MemberToAccess()
        {
            Assert.Inconclusive();

            var targetAcc = new ObjectAccessor(new Class1(), "C");
            var actual = targetAcc.Invoke("GetNinetyNine");
            Assert.AreEqual(99, actual);

            targetAcc = new ObjectAccessor(new Class1(), "C.D");
            actual = targetAcc.Invoke("GetNinetyEight");
            Assert.AreEqual(98, actual);
        }
        [TestMethod]
        public void OA_Ctor_Generic()
        {
            var types = new[] { typeof(long), typeof(DateTime) };
            var now = DateTime.Now;
            var values = new object[] { 42L, now };

            var targetAcc = new ObjectAccessor(typeof(Class2<long, DateTime>), types, values);

            var target = (Class2<long, DateTime>)targetAcc.Target;
            Assert.AreEqual(42L, target.A);
            Assert.AreEqual(now, target.B);
        }
        [TestMethod]
        public void OA_Ctor_DynamicGeneric()
        {
            Assert.Inconclusive();

            var types = new[] { typeof(long), typeof(DateTime) };
            var now = DateTime.Now;
            var values = new object[] { 42L, now };

            var targetAcc = new ObjectAccessor("ClassLibrary1", "ClassLibrary1.Class2`2[System.Int64, System.DateTime]", types, values);

            var target = (Class2<long, DateTime>)targetAcc.Target;
            Assert.AreEqual(42L, target.A);
            Assert.AreEqual(now, target.B);
        }

        /* ============================================================= Static property and field tests */

        [TestMethod]
        public void TA_Field_Public()
        {
            StaticStringFieldTest("PublicField");
        }
        [TestMethod]
        public void TA_Field_Private()
        {
            StaticStringFieldTest("_privateField");
        }

        [TestMethod]
        public void TA_Property_Public()
        {
            StaticStringPropertyTest("PublicProperty");
        }
        [TestMethod]
        public void TA_Property_Private()
        {
            StaticStringPropertyTest("PrivateProperty");
        }

        private void StaticStringFieldTest(string fieldName)
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            var expected = Guid.NewGuid().ToString();

            targetAcc.SetStaticField(fieldName, null);
            var actual = targetAcc.GetStaticField(fieldName);
            Assert.IsNull(actual);

            targetAcc.SetStaticField(fieldName, expected);
            actual = targetAcc.GetStaticField(fieldName);
            Assert.AreEqual(expected, actual);

            StaticStringFieldOrPropertyTest(fieldName);
        }
        private void StaticStringPropertyTest(string propertyName)
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            var expected = Guid.NewGuid().ToString();

            targetAcc.SetStaticProperty(propertyName, null);
            var actual = targetAcc.GetStaticProperty(propertyName);
            Assert.IsNull(actual);

            targetAcc.SetStaticProperty(propertyName, expected);
            actual = targetAcc.GetStaticProperty(propertyName);
            Assert.AreEqual(expected, actual);

            StaticStringFieldOrPropertyTest(propertyName);
        }
        private void StaticStringFieldOrPropertyTest(string memberName)
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            var expected = Guid.NewGuid().ToString();

            targetAcc.SetStaticFieldOrProperty(memberName, null);
            var actual = targetAcc.GetStaticFieldOrProperty(memberName);
            Assert.IsNull(actual);

            targetAcc.SetStaticFieldOrProperty(memberName, expected);
            actual = targetAcc.GetStaticFieldOrProperty(memberName);
            Assert.AreEqual(expected, actual);
        }

        /* ============================================================= Instance property and field tests */

        [TestMethod]
        public void OA_Field_Public()
        {
            StringFieldTest("PublicField");
        }
        [TestMethod]
        public void OA_Field_Private()
        {
            StringFieldTest("_privateField");
        }

        [TestMethod]
        public void OA_Property_Public()
        {
            StringPropertyTest("PublicProperty");
        }
        [TestMethod]
        public void OA_Property_Private()
        {
            StringPropertyTest("PrivateProperty");
        }

        private void StringFieldTest(string fieldName)
        {
            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var expected = Guid.NewGuid().ToString();

            var actual = targetAcc.GetField(fieldName);
            Assert.IsNull(actual);

            targetAcc.SetField(fieldName, expected);
            actual = targetAcc.GetField(fieldName);
            Assert.AreEqual(expected, actual);

            StringFieldOrPropertyTest(fieldName);
        }
        private void StringPropertyTest(string propertyName)
        {
            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var expected = Guid.NewGuid().ToString();

            var actual = targetAcc.GetProperty(propertyName);
            Assert.IsNull(actual);

            targetAcc.SetProperty(propertyName, expected);
            actual = targetAcc.GetProperty(propertyName);
            Assert.AreEqual(expected, actual);

            StringFieldOrPropertyTest(propertyName);
        }
        private void StringFieldOrPropertyTest(string memberName)
        {
            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var expected = Guid.NewGuid().ToString();

            var actual = targetAcc.GetFieldOrProperty(memberName);
            Assert.IsNull(actual);

            targetAcc.SetFieldOrProperty(memberName, expected);
            actual = targetAcc.GetFieldOrProperty(memberName);
            Assert.AreEqual(expected, actual);
        }

        /* ============================================================= Static method tests */

        [TestMethod]
        public void TA_Invoke_Public_withoutParam()
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            var actual = targetAcc.InvokeStatic("PublicMethod");
            Assert.AreEqual("PublicStaticMethod", actual);
        }
        [TestMethod]
        public void TA_Invoke_Private_withoutParam()
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            var actual = targetAcc.InvokeStatic("PrivateMethod");
            Assert.AreEqual("PrivateStaticMethod", actual);
        }
        [TestMethod]
        public void TA_Invoke_Public_withParams()
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            var actual = targetAcc.InvokeStatic("PublicMethod", 42);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void TA_Invoke_Private_withParams()
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            var actual = targetAcc.InvokeStatic("PrivateMethod", 42, 0);
            Assert.AreEqual(44, actual);
        }
        [TestMethod]
        public void TA_Invoke_Public_withParamsAndTypes()
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            var paramTypes = new[] { typeof(int) };
            var values = new object[] { 42 };
            var actual = targetAcc.InvokeStatic("PublicMethod", paramTypes, values);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void TA_Invoke_Private_withParamsAndTypes()
        {
            var targetAcc = new TypeAccessor(typeof(StaticClass1));
            var paramTypes = new[] { typeof(int), typeof(int) };
            var values = new object[] { 42, 0 };
            var actual = targetAcc.InvokeStatic("PrivateMethod", paramTypes, values);
            Assert.AreEqual(44, actual);
        }

        /* ============================================================= Instance method tests */

        [TestMethod]
        public void OA_Invoke_Public_withoutParam()
        {
            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var actual = targetAcc.Invoke("PublicMethod");
            Assert.AreEqual("PublicMethod", actual);
        }
        [TestMethod]
        public void OA_Invoke_Private_withoutParam()
        {
            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var actual = targetAcc.Invoke("PrivateMethod");
            Assert.AreEqual("PrivateMethod", actual);
        }
        [TestMethod]
        public void OA_Invoke_Public_withParams()
        {
            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var actual = targetAcc.Invoke("PublicMethod", 42);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void OA_Invoke_Private_withParams()
        {
            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var actual = targetAcc.Invoke("PrivateMethod", 42, 0);
            Assert.AreEqual(44, actual);
        }
        [TestMethod]
        public void OA_Invoke_Public_withParamsAndTypes()
        {
            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var paramTypes = new[] { typeof(int) };
            var values = new object[] { 42 };
            var actual = targetAcc.Invoke("PublicMethod", paramTypes, values);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void OA_Invoke_Private_withParamsAndTypes()
        {
            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var paramTypes = new[] { typeof(int), typeof(int) };
            var values = new object[] { 42, 0 };
            var actual = targetAcc.Invoke("PrivateMethod", paramTypes, values);
            Assert.AreEqual(44, actual);
        }
        [TestMethod]
        public void OA_Invoke_Public_Generic()
        {
            Assert.Inconclusive();

            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var types = new[] { typeof(long), typeof(DateTime) };
            var values = new object[] { 42L, DateTime.Now };
            var actual = targetAcc.Invoke("PublicGenericMethod", types, values, types);
            Assert.AreEqual("Int64 DateTime", actual);
        }
        [TestMethod]
        public void OA_Invoke_Private_Generic()
        {
            Assert.Inconclusive();

            var target = new Class1();
            var targetAcc = new ObjectAccessor(target);
            var types = new[] { typeof(long), typeof(DateTime) };
            var values = new object[] { 42L, DateTime.Now };
            var actual = targetAcc.Invoke("PrivateGenericMethod", types, values, types);
            Assert.AreEqual("Int64 DateTime", actual);
        }
    }
}
