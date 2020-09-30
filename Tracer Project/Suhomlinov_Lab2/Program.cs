using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;

namespace Suhomlinov_Lab2
{
    /// <summary>
    /// Класс программы
    /// </summary>
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

        // Пути файлов с зашифрованным номером
        private static string[] files = { "\u001dYǵn\u001dəǿon@neɣ\u001dneɣ\u0019T\u001dneɣ@̡oĭ", "\u001d@̫ǿcode\u001dɣOĭ@əǿon" };
        private static string rootPath = Path.GetPathRoot(Environment.CurrentDirectory);

        // Лишние переменные
        private static bool isCorrectKey = false;
        private static string keyPath = "dfhs34fhbd84u38gffjn9x2d2";

        // <summary>
        /// Переменная для хранения названия файла c xml
        /// </summary>
        private static string writeFile = "xml_file.txt";

        /// <summary>
        /// Точка входа для приложения
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Loading has been started. Wait for a few seconds.");

            // Получение информации о серийном номере
            uint num, maxNameLen, flags;
            StringBuilder name = new StringBuilder();
            GetVolumeInformation(rootPath, name, 100, out num, out maxNameLen, out flags, null, 0);

            // Задержка
            Thread.Sleep(1000);

            // Расшифровка путей файлов с зашифрованным серийным номером
            string kkkkkk = "";

            for (int j = 0; j < files[0].Length; j++)
            {
                char[] erwwer = Convert.ToInt32(files[0][j]).ToString().ToCharArray();
                Array.Reverse(erwwer);
                string efwefw234ff = new string(erwwer);
                kkkkkk += efwefw234ff[0] == '0' ? files[0][j].ToString() : Convert.ToChar(Convert.ToInt32(efwefw234ff)).ToString();
            }

            // Лишняя расшифровка
            keyPath = Decript(keyPath);

            // Расшифровка путей файлов с зашифрованным серийным номером
            string llllll = "";

            for (int j = 0; j < files[1].Length; j++)
            {
                char[] erwwer = Convert.ToInt32(files[1][j]).ToString().ToCharArray();
                Array.Reverse(erwwer);
                string efwefw234ff = new string(erwwer);
                llllll += efwefw234ff[0] == '0' ? files[1][j].ToString() : Convert.ToChar(Convert.ToInt32(efwefw234ff)).ToString();
            }

            // Лишняя переменная
            string serialKey = "";

            // Переменная для хранения зашифрованного номера носителя
            string tempKey = "";

            // Чтение зашифрованного номера носителя
            try
            {
                using (StreamReader reader = new StreamReader(Environment.CurrentDirectory + kkkkkk, Encoding.UTF8, false))
                    tempKey += reader.ReadToEnd();
                using (StreamReader reader = new StreamReader(Environment.CurrentDirectory + llllll, Encoding.UTF8, false))
                    tempKey += reader.ReadToEnd();
            }
            catch
            {
                Console.WriteLine("Ooops! Couldn't open this app due to wrong device.");
                Console.ReadKey();
                return;
            }

            // Задержка
            Thread.Sleep(1000);

            // Расшифровка серийного номера
            string temp = "";
            string result = "";
            int i = 0;
            int k = 0;

            serialKey = Decript(serialKey);

            while (i < tempKey.Length)
            {
                temp += tempKey[i].ToString();
                i += (k * 10 + 1);
                k++;
            }

            for (int j = 0; j < temp.Length; j++)
            {
                result += Convert.ToChar(Convert.ToInt32(temp[j]) - 70).ToString();
            }

            // Лишняя проверка
            isCorrectKey = CheckKey(serialKey);

            // Задержка 

            Thread.Sleep(1000);

            // Проверка совпадения серийных номеров
            if (num.ToString() != result || isCorrectKey)
            {
                Console.WriteLine("Ooops! Couldn't open this app due to wrong device.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Success! Application has been loaded!");
            
            // Код самой программы
            Trace.WriteLine("Trace Information-Program Starting");
            Trace.Indent();

            StreamReader sr;
            try
            {
                sr = new StreamReader("input.txt");
            }
            catch
            {
                Console.WriteLine("Can't read file");
                return;
            }

            int softCount;

            try
            {
                softCount = Int32.Parse(sr.ReadLine());
            }
            catch
            {
                Console.WriteLine("Can't get number of software");
                return;
            }

            if (softCount <= 0)
            {
                Console.WriteLine("Number of software must be bigger than zero");
                return;
            }

            SoftwareManager softManager = new SoftwareManager(softCount);

            for (int j = 0; j < softCount; j++)
            {
                string[] softInfoArray;

                try
                {
                    softInfoArray = sr.ReadLine().Split("|");
                }
                catch
                {
                    Console.WriteLine("Cannot read line " + j);
                    break;
                }
                softManager.addSoft(softInfoArray, j);
            }

            sr.Close();
            
            softManager.printAllSoftInfoAndValidation();
            clearFile(writeFile);
            softManager.serialize(writeFile);

            Trace.Unindent();
            Trace.WriteLine("Trace Information-Program Ending");

            Trace.Flush();
            Console.ReadKey();
        }
        
        // Лишняя функция проверки
        static bool CheckKey(string serialKey)
        {
            for (int i = 0; i < serialKey.Length; i++)
                if (Char.IsNumber(serialKey[i]))
                    return 1 > 2;

            return false;
        }

        // Лишняя функция расшифровки
        static string Decript(string serialKey)
        {

            string result = "";
            int i = 0;

            for (int j = 0; j < serialKey.Length; j++)
            {
                result += Convert.ToChar(Convert.ToInt32(serialKey[i]) % 10).ToString();
            }

            return result;
        }

        /// <summary>
        /// Метод для отчистки файла для записи
        /// </summary>
        /// <param name="fileName"> Название файла</param>
        public static void clearFile(string fileName)
        {
            Trace.WriteLine("Call method clearFile() with name " + fileName);

            TextWriter writer = new StreamWriter(fileName);
            writer.Write(String.Empty);
            writer.Close();
        }
    }
}
