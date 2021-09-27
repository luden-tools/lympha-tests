using Lympha;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompilerTests
{
    [TestClass]
    public class RuntimeTests
    {
        private Compiler compiler = new();

        [TestMethod]
        public void PrintTest()
        {
            var result = compiler.Compile("print hello-world");
            result.Get(out string resultAsText);

            Assert.AreEqual("hello-world", resultAsText);
        }

        [TestMethod]
        public void PrintOutputTest()
        {
            var result = compiler.Compile("print (print hello) world");
            result.Get(out string resultAsText);

            Assert.AreEqual("hello world", resultAsText);
        }

        [TestMethod]
        public void SumIntNumbers()
        {
            var result = compiler.Compile("sum 1 2 3 4 5");
            result.Get(out float resultAsNumber);

            Assert.AreEqual(15, resultAsNumber);
        }

        [TestMethod]
        public void SumFloatNumbers()
        {
            var result = compiler.Compile("sum -.1 -0.1 -2.2 -3.3 -4.4 -5.5 .1 0.1 2.2 3.3 4.4 5.5");
            result.Get(out float resultAsNumber);

            Assert.AreEqual(0f, resultAsNumber, 0.00001f);
        }

        [TestMethod]
        public void CommandInTheMiddle()
        {
            var result = compiler.Compile("1 :sum 2 3");
            result.Get(out float resultAsNumber);

            Assert.AreEqual(6, resultAsNumber);
        }

        [TestMethod]
        public void PrintTheSum()
        {
            var result = compiler.Compile("print (sum 1 2 3)");
            result.Get(out string resultAsText);

            Assert.AreEqual("6", resultAsText);
        }

        [TestMethod]
        public void NamedArguments()
        {
            var result = compiler.Compile("print hello prefix: -- append: ##");
            result.Get(out string resultAsText);

            Assert.AreEqual("--hello##", resultAsText);
        }
    }
}
