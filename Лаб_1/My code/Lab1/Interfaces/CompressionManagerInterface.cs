using System.Collections.Generic;

namespace Lab1
{
    public interface CompressionManagerInterface
    {
        /// <summary>
        /// Функция для сжатия строк
        /// </summary>
        /// <param name="data">Лист строк, которые необходимо сжать</param>
        /// <returns>Лист сжатых строк</returns>
        List<string> compress(List<string> data);
    }
}
