using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool s;
            int b;
            int i = 1;
            string a = "true";
            b = int.Parse(a);
            Assert.AreEqual(b, i);
        }
    }
}
