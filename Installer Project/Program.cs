using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace Installer
{
    class Program
    {
        [DllImport("Kernel32.dll", SetLastError = true)]
        extern static bool GetVolumeInformation(string vol,
            StringBuilder name,
            int nameSize,
            out uint serialNum,
            out uint maxNameLen,
            out uint flags,
            StringBuilder fileSysName,
            int fileSysNameSize);

        static string currentPath = Environment.CurrentDirectory + "\\Tracer";

        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("Install path:");

            try
            {
                path = Console.ReadLine();
                AddFiles(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Success!");

            Console.ReadKey();
            return;
        }

        // Копирование файлов программы в нужную папку
        static void CopyFilesRecursively(string SourcePath, string DestinationPath)
        {
            // First create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            // Copy all the files
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath));
        }

        // Добавление файлов проверки и программы
        static void AddFiles(string path)
        {
            // Копирование файлов программы в нужную папку
            Directory.CreateDirectory(path + "\\Tracer");
            CopyFilesRecursively(currentPath, path + "\\Tracer");

            // Получение серийного номера
            uint serialNum, maxNameLen, flags;
            string rootPath = path.Substring(0, path.IndexOf(":\\") + 2);

            StringBuilder name = new StringBuilder();
            GetVolumeInformation(rootPath, name, 100, out serialNum, out maxNameLen, out flags, null, 0);
            string serial = serialNum.ToString();

            string result = String.Empty;
            Random random = new Random();

            // Шифрование серийного номера
            for (int i = 0; i < serial.Length; i++)
            {
                string num = Convert.ToChar(Convert.ToInt32(serial[i]) + 70).ToString();
                string rand = generateRandomString(i * 10, random);
                result += num + rand;
            }

            // Сохранение серийного номера
            using (StreamWriter sw = new StreamWriter(path + "\\Tracer\\bin\\json.net\\net40\\net.log", false, Encoding.UTF8))
                sw.Write(result.Substring(0, result.Length / 2));
            using (StreamWriter sw = new StreamWriter(path + "\\Tracer\\.vscode\\tag.json", false, Encoding.UTF8))
                sw.Write(result.Substring(result.Length / 2, result.Length / 2));
        }

        // Генератор случайных строк
        static string generateRandomString(int length, Random rand)
        {
            string result = "";

            for (int i = 0; i < length; i++)
            {
                result += Convert.ToChar(rand.Next(1, 255)).ToString();
            }

            return result;
        }
    }
}
