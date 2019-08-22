using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTests.Net
{
    [TestClass]
    public class PrivateObjectTests
    {
        [TestMethod]
        public void Priv_CallPublicMethod_withoutParam()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var actual = targetAcc.Invoke("PublicMethod");
            Assert.AreEqual("PublicMethod", actual);
        }
        [TestMethod]
        public void Priv_CallPrivateMethod_withoutParam()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var actual = targetAcc.Invoke("PrivateMethod");
            Assert.AreEqual("PrivateMethod", actual);
        }
        [TestMethod]
        public void Priv_CallPublicMethod_with1param()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var actual = targetAcc.Invoke("PublicMethod", 42);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void Priv_CallPrivateMethod_with2params()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var actual = targetAcc.Invoke("PrivateMethod", 42, 0);
            Assert.AreEqual(44, actual);
        }
        [TestMethod]
        public void Priv_CallPrivateMethod_with2paramsAndTypes()
        {
            var target = new Class1();
            var targetAcc = new PrivateObjectWrapper(target);
            var paramTypes = new[] { typeof(int), typeof(int) };
            var values = new object[] { 42, 0 };
            var actual = targetAcc.Invoke("PrivateMethod", paramTypes, values);
            Assert.AreEqual(44, actual);
        }
    }
}
