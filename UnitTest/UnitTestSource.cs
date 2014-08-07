using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCompiler.FrontEnd;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTestSource
    {
        [TestMethod]
        public void SourceLineTest()
        {
            SourceLine line = new SourceLine();
            Assert.AreEqual<int>(-1, line.LinePos);

            line.Line = "Hello world!";
            Assert.AreEqual<int>(-1, line.LinePos);

            char c = line.NextChar;
            Assert.AreEqual<char>('H', c);

            for (int i = 0; i < 12; ++i)
                c = line.NextChar;

            Assert.AreEqual<char>('\n', c);
            Assert.IsTrue(line.IsEndOfLine);
            Assert.AreEqual<char>('\n', line.CurrentChar);

            line.Line = "new lines.";
            Assert.AreEqual<int>(-1, line.LinePos);
            Assert.IsFalse(line.IsEndOfLine);
        }

        [TestMethod]
        public void SourceTest()
        {
            TextReader reader = new StreamReader("source.txt");
            Source source = new Source(reader);
        }
    }
}
