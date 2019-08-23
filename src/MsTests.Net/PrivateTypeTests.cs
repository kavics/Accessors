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


    }
}
