using Lympha;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompilerTests
{
    [TestClass]
    public class RuntimeTests
    {
        [TestMethod]
        public void PrintTest()
        {
            Compiler compiler = new();

            Console.WriteLine("Starting test");

            var result = compiler.Compile("print hello-world");

            Assert.AreEqual(result, "hello-world");
        }

        [TestMethod]
        public void PrintOutputTest()
        {
            Compiler compiler = new();

            Console.WriteLine("Starting test");

            var result = compiler
                .Tokenize("print (print hello) world")
                .Parse()
                .ToRuntime()
                .Run();

            Assert.AreEqual("hello world", (result as Argument).Value);
        }
    }
}
