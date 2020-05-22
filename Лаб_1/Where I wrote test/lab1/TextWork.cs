using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab1
{
    /// <summary>
    /// Класс для работы с текстовым файлом.</summary>
    public class TextWork
    {
        /// <summary>
        /// Путь файла.</summary>
        private String path;

        /// <summary>
        /// Данные из файла.</summary>
        private String line;

        /// <summary>
        /// Конструктор класса. </summary>
        public TextWork(String path)
        {
            this.path = path;
        }

        /// <summary>
        /// Функция для чтения файла.</summary>
        /// <returns>
        /// Ничего не возвращает</returns>
        public void Reading()
        {
            if (path == null) 
            {
                throw new ArgumentNullException("path");
            }
            if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                throw new ArgumentException("path");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("path");
            }
            StreamReader sr = new StreamReader(path);
            try
            {   
                this.line = sr.ReadToEnd();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Функция для возврата числа.</summary>
        /// <returns>
        /// Возвращает считанное число типа Int32</returns>
        public int RetInt()
        {
            int res;
            if (Int32.TryParse(this.line,out res))
            {
                return res;
            }
            else
            {
                throw new FormatException();
            }
        }

        /// <summary>
        /// Метод записи данных в файл с указанным путем. </summary>
        /// <param name="data">Данные для записи</param>
        /// <param name="path">Путь, куда записываются данные</param>
        /// <returns>
        /// Ничего не возвращает</returns>
        public void Writing(String data,String path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                throw new ArgumentException("path");
            }
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(data);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
