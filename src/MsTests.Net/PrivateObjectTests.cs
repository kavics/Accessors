using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MsTests.Net
{
    [TestClass]
    public class PrivateObjectTests
    {
        [TestMethod]
        public void Priv_Invoke_Public_withoutParam()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var actual = targetAcc.Invoke("PublicMethod");
            Assert.AreEqual("PublicMethod", actual);
        }
        [TestMethod]
        public void Priv_Invoke_Private_withoutParam()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var actual = targetAcc.Invoke("PrivateMethod");
            Assert.AreEqual("PrivateMethod", actual);
        }
        [TestMethod]
        public void Priv_Invoke_Public_withParams()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var actual = targetAcc.Invoke("PublicMethod", 42);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void Priv_Invoke_Private_withParams()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var actual = targetAcc.Invoke("PrivateMethod", 42, 0);
            Assert.AreEqual(44, actual);
        }
        [TestMethod]
        public void Priv_Invoke_Public_withParamsAndTypes()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var paramTypes = new[] { typeof(int) };
            var values = new object[] { 42 };
            var actual = targetAcc.Invoke("PublicMethod", paramTypes, values);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void Priv_Invoke_Private_withParamsAndTypes()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var paramTypes = new[] { typeof(int), typeof(int) };
            var values = new object[] { 42, 0 };
            var actual = targetAcc.Invoke("PrivateMethod", paramTypes, values);
            Assert.AreEqual(44, actual);
        }

        [TestMethod]
        public void Priv_Field_Public()
        {
            StringFieldTest("PublicField");
        }
        [TestMethod]
        public void Priv_Field_Private()
        {
            StringFieldTest("_privateField");
        }

        [TestMethod]
        public void Priv_Property_Public()
        {
            StringPropertyTest("PublicProperty");
        }
        [TestMethod]
        public void Priv_Property_Private()
        {
            StringPropertyTest("PrivateProperty");
        }

        private void StringFieldTest(string fieldName)
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
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
            var targetAcc = new PrivateObjectWrapper(target);
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
            var targetAcc = new PrivateObjectWrapper(target);
            var expected = Guid.NewGuid().ToString();

            var actual = targetAcc.GetFieldOrProperty(memberName);
            Assert.IsNull(actual);

            targetAcc.SetFieldOrProperty(memberName, expected);
            actual = targetAcc.GetFieldOrProperty(memberName);
            Assert.AreEqual(expected, actual);
        }
    }
}
