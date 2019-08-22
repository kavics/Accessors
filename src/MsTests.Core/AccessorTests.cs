using Accessors;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTests
{
    [TestClass]
    public class AccessorTests
    {
        [TestMethod]
        public void Acc_CallPublicMethod_withoutParam()
        {
            var target = new Class1();
            var targetAcc = Accessor.Create(target);
            var actual = targetAcc.Invoke("PublicMethod");
            Assert.AreEqual("PublicMethod", actual);
        }
        [TestMethod]
        public void Acc_CallPrivateMethod_withoutParam()
        {
            var target = new Class1();
            var targetAcc = Accessor.Create(target);
            var actual = targetAcc.Invoke("PrivateMethod");
            Assert.AreEqual("PrivateMethod", actual);
        }
        [TestMethod]
        public void Acc_CallPublicMethod_with1param()
        {
            var target = new Class1();
            var targetAcc = Accessor.Create(target);
            var actual = targetAcc.Invoke("PublicMethod", 42);
            Assert.AreEqual(43, actual);
        }
        [TestMethod]
        public void Acc_CallPrivateMethod_with2params()
        {
            var target = new Class1();
            var targetAcc = Accessor.Create(target);
            var actual = targetAcc.Invoke("PrivateMethod", 42, 0);
            Assert.AreEqual(44, actual);
        }
    }
}
