using System.IO;
using System.Collections.Generic;

namespace Lab1
{
    public class FileManager : FileManagerInterface
    {
        /// <summary>
        /// Функция для чтения строк из текстового файла
        /// </summary>
        /// <param name="path">Путь файла для чтения</param>
        /// <returns>Лист прочитанных строк</returns>
        public List<string> read(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new System.ArgumentNullException();
            }

            if (!File.Exists(path))
            {
                throw new System.IO.FileNotFoundException();
            } else if (!Directory.Exists(path))
            {
                throw new System.IO.FileNotFoundException();
            }

            List<string> rows = new List<string>();

            using (StreamReader file = new StreamReader(path))
            {
                string row;

                while ((row = file.ReadLine()) != null)
                {
                    rows.Add(row);
                }
                file.Close();
            }

            return rows;
        }

        /// <summary>
        /// Функция для записи строк в текстовый файл
        /// </summary>
        /// <param name="path">Путь файла для записи</param>
        /// <param name="text">Лист строк для записи в файл</param>
        public void write(string path, List<string> text)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new System.ArgumentNullException();
            } 

            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (string row in text)
                {
                    file.WriteLine(row);
                }

                file.Close();
            }
        }
    }
}
