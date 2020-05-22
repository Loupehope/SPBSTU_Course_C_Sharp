using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        Stopwatch stopWatch = new Stopwatch();
        [TestMethod]
        public void ReadNonExistentFile()
        {
            stopWatch.Start();
            FileManager file = new FileManager();
            string name_file = "/NOTEXIST.txt";

            Assert.ThrowsException<System.IO.FileNotFoundException>(() => file.read(name_file));

            stopWatch.Stop();
            System.Console.WriteLine("ReadNonExistentFile: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void ReadInvalidFilePath()
        {
            stopWatch.Start();
            FileManager file = new FileManager();
            string name_file = @"D:--\\\\<<";

            Assert.ThrowsException<System.IO.FileNotFoundException>(() => file.read(name_file));

            stopWatch.Stop();
            System.Console.WriteLine("ReadInvalidFilePath: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void ReadNullFilePath()
        {
            stopWatch.Start();
            FileManager file = new FileManager();
            string name_file = "";

            Assert.ThrowsException<System.ArgumentNullException>(() => file.read(name_file));

            stopWatch.Stop();
            System.Console.WriteLine("ReadNullFilePath: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void WriteStrangeDirectoryPath()
        {
            stopWatch.Start();
            FileManager file = new FileManager();
            string name_file = @"D------";
            List<string> text = new List<string>() { "text" };

            file.write(name_file, text);

            stopWatch.Stop();
            System.Console.WriteLine("WriteInvalidFilePath: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void WriteNullFilePath()
        {
            stopWatch.Start();
            FileManager file = new FileManager();
            string name_file = "";
            List<string> text = new List<string>() { "text" };

            Assert.ThrowsException<System.ArgumentNullException>(() => file.write(name_file, text));

            stopWatch.Stop();
            System.Console.WriteLine("WriteNullFilePath: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void WriteEmptyData()
        {
            stopWatch.Start();
            FileManager file = new FileManager();
            string name_file = "output.txt";
            List<string> text = new List<string>() { "" };

            file.write(name_file, text);

            stopWatch.Stop();
            System.Console.WriteLine("WriteNullData: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void NullArgumentCompress()
        {
            stopWatch.Start();
            CompressionManager cmp = new CompressionManager();
            List<string> str = new List<string>() { "" };
            List<string> expected = new List<string>() { "" };
            List<string> actual = cmp.compress(str);

            CollectionAssert.AreEqual(expected, actual, "Incorrect solve!");

            stopWatch.Stop();
            System.Console.WriteLine("NullArgumentCompress: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void CorrectResolve1()
        {
            stopWatch.Start();
            CompressionManager cmp = new CompressionManager();
            List<string> str = new List<string>() { "ннаааабркк" };
            List<string> expected = new List<string>() { "н2а4брк2" };
            List<string> actual = cmp.compress(str);

            CollectionAssert.AreEqual(expected, actual, "Incorrect solve!");

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve1: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void CorrectResolve2()
        {
            stopWatch.Start();
            CompressionManager cmp = new CompressionManager();
            List<string> str = new List<string>() { "ннаааабркк      ннаааабркк \nннаааабркк" };
            List<string> expected = new List<string>() { "н2а4брк2      н2а4брк2 \nн2а4брк2" };
            List<string> actual = cmp.compress(str);

            CollectionAssert.AreEqual(expected, actual, "Incorrect solve!");

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve2: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }


        [TestMethod]
        public void CorrectResolve3()
        {
            stopWatch.Start();
            CompressionManager cmp = new CompressionManager();
            List<string> str = new List<string>() { "ннаааабркк      ннаааабркк \nннаааабркк" };
            List<string> expected = new List<string>() { "н2а4брк2      н2а4брк2 \nн2а4брк2" };
            List<string> actual = cmp.compress(str);

            CollectionAssert.AreEqual(expected, actual, "Incorrect solve!");

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve3: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void CorrectResolve4()
        {
            stopWatch.Start();
            CompressionManager cmp = new CompressionManager();
            List<string> str = new List<string>() { "fffЩЩЩ" };
            List<string> expected = new List<string>() { "f3Щ3" };
            List<string> actual = cmp.compress(str);

            CollectionAssert.AreEqual(expected, actual, "Incorrect solve!");

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve4: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void CorrectResolve5()
        {
            stopWatch.Start();
            CompressionManager cmp = new CompressionManager();
            List<string> str = new List<string>() { "f f f ЩЩЩ" };
            List<string> expected = new List<string>() { "f f f Щ3" };
            List<string> actual = cmp.compress(str);

            CollectionAssert.AreEqual(expected, actual, "Incorrect solve!");

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve5: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void CorrectResolve6()
        {
            stopWatch.Start();
            CompressionManager cmp = new CompressionManager();
            List<string> str = new List<string>() { "f f f Щ Щ Щ аaаa" };
            List<string> expected = new List<string>() { "f f f Щ Щ Щ аaаa" };
            List<string> actual = cmp.compress(str);

            CollectionAssert.AreEqual(expected, actual, "Incorrect solve!");

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve6: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void CorrectResolve7()
        {
            stopWatch.Start();
            CompressionManager cmp = new CompressionManager();
            List<string> str = new List<string>() { "3333" };
            List<string> expected = new List<string>() { "34" };
            List<string> actual = cmp.compress(str);

            CollectionAssert.AreEqual(expected, actual, "Incorrect solve!");

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve7: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        public void CorrectResolve8()
        {
            stopWatch.Start();
            CompressionManager cmp = new CompressionManager();
            List<string> str = new List<string>() { "        " };
            List<string> expected = new List<string>() { "         " };
            List<string> actual = cmp.compress(str);

            CollectionAssert.AreEqual(expected, actual, "Incorrect solve!");

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }
    }
}
