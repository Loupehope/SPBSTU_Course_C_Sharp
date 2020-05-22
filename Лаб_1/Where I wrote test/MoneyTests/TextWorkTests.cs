using lab1;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextWorkTests
{
    [TestClass]
    public class TextWorkTests
    {
        Stopwatch stopWatch = new Stopwatch();

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]

        public void checkReadNullPath()
        {
            stopWatch.Start();

            string path = null;

            TextWork textManager = new TextWork(path);
            textManager.Reading();

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]

        public void checkReadEmptyPath()
        {
            stopWatch.Start();

            string path = "";

            TextWork textManager = new TextWork(path);
            textManager.Reading();

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]

        public void checkReadUnknownPath()
        {
            stopWatch.Start();

            string path = "checkReadUnknownPath";

            TextWork textManager = new TextWork(path);
            textManager.Reading();

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]

        public void writeUnknownPath()
        {
            stopWatch.Start();

            string path = "writeUnknownPath";
            string str = "d";

            TextWork textManager = new TextWork(path);
            textManager.Writing(str, path);

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]

        public void writeNullPath()
        {
            stopWatch.Start();

            string path = null;
            string str = "d";

            TextWork textManager = new TextWork(path);
            textManager.Writing(str, path);

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]

        public void writeNullValue()
        {
            stopWatch.Start();

            string path = "writeNullValue";
            string str = null;

            TextWork textManager = new TextWork(path);
            textManager.Writing(str, path);

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]

        public void writeNullPathAndNullValue()
        {
            stopWatch.Start();

            string path = null;
            string str = null;

            TextWork textManager = new TextWork(path);
            textManager.Writing(str, path);

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]

        public void ConvertStringOfLettersToInt()
        {
            stopWatch.Start();

            string path = "ConvertStringOfLettersToInt";
            string str = "hh";

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(str);
            sw.Close();

            TextWork textManager = new TextWork(path);
            textManager.Reading();

            textManager.RetInt();

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]

        public void ConvertStringOfSpecSymbToInt()
        {
            stopWatch.Start();

            string path = "ConvertStringOfLettersToInt.txt";
            string str = "&& !! ";

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(str);
            sw.Close();

            TextWork textManager = new TextWork(path);
            textManager.Reading();

            textManager.RetInt();

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]

        public void ConvertStringOfSpecSymbAndNumbersToInt()
        {
            stopWatch.Start();

            string path = "ConvertStringOfSpecSymbAndNumbersToInt";
            string str = "123      !";

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(str);
            sw.Close();

            TextWork textManager = new TextWork(path);
            textManager.Reading();

            textManager.RetInt();

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]

        public void ConvertStringOfNumbersToInt()
        {
            stopWatch.Start();

            string path = "ConvertStringOfNumbersToInt";
            string str = "123";

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(str);
            sw.Close();

            TextWork textManager = new TextWork(path);
            textManager.Reading();

            textManager.RetInt();

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]

        public void ConvertStringOfALotNumbersToInt()
        {
            stopWatch.Start();

            string path = "ConvertStringOfALotNumbersToInt";
            string str = "8375495375634875684765239845632456234756239405623845603294583204958732495";

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(str);
            sw.Close();

            TextWork textManager = new TextWork(path);
            textManager.Reading();

            textManager.RetInt();

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }
    }
}
