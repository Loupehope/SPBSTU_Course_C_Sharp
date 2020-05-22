using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lab1
{
    class Program
    {
        private static readonly string backSpace = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? @"\"
                                                                                                       : @"/";
        private static readonly string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        private static readonly string writeFileName = @"output.txt";
        private static readonly string readFileName = @"input.txt";
        private static readonly string endCompression = "Text has been compressed!";

        private static string writePath
        {
            get
            {
                return projectDirectory + backSpace + writeFileName;
            }
        }

        private static string readPath
        {
            get
            {
                return projectDirectory + backSpace + readFileName;
            }
        }

        /// <summary>
        /// Точка входа для приложения.
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            FileManagerInterface fileManager = new FileManager();
            CompressionManagerInterface compressionManager = new CompressionManager();
            List<string> rows;

            try
            {
                rows = fileManager.read(readPath);

            } catch
            {
                Console.WriteLine(Error.FileDoesNotExist);
                return;
            }
            
            List<string> archivedRows = compressionManager.compress(rows);
            
            try
            {
                fileManager.write(writePath, archivedRows);

            } catch
            {
                Console.WriteLine(Error.CouldNotWriteInFile);
                return;
            }

            Console.WriteLine(endCompression);
        }
    }

}
