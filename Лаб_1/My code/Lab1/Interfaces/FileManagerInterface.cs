using System.Collections.Generic;

namespace Lab1
{
    public interface FileManagerInterface
    {
        /// <summary>
        /// Функция для чтения строк из текстового файла
        /// </summary>
        /// <param name="path">Путь файла для чтения</param>
        /// <returns>Лист прочитанных строк</returns>
        List<string> read(string path);

        /// <summary>
        /// Функция для записи строк в текстовый файл
        /// </summary>
        /// <param name="path">Путь папки для создания файла</param>
        /// <param name="text">Лист строк для записи в файл</param>
        void write(string path, List<string> text);
    }
}
