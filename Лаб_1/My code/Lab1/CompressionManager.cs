using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1
{
    public class CompressionManager : CompressionManagerInterface
    {
        /// <summary>
        /// Функция для сжатия строк на основе счётчика повторяющихся символов
        /// </summary>
        /// <param name="data">Лист строк, которые необходимо сжать</param>
        /// <returns>Лист сжатых строк</returns>
        public List<string> compress(List<string> data)
        {
            List<string> archiveRows = new List<string>();
            foreach (string row in data)
            {
                archiveRows.Add(string.IsNullOrEmpty(row) ? row
                                                          : compress(row));
            }
            return archiveRows;
        }


        /// <summary>
        /// Функция для сжатия строки на основе счётчика повторяющихся символов
        /// </summary>
        /// <param name="row">Строка, которую необходимо сжать</param>
        /// <returns>Сжатая строка</returns>
        private string compress(string row)
        {
            string result = String.Empty;
            char c, prev;
            try
            {
                c = row.First();
            }
            catch (ArgumentNullException)
            {
                return result;

            }

            int index = 0;
            result += c;
            prev = c;

            foreach (char element in row)
            {
                if (c == element && Char.IsLetterOrDigit(c))
                    index++;

                if (c != element && c == prev)
                {
                    c = element;
                    result += index > 1 ? $"{index}{c}"
                                        : $"{c}";
                    index = 1;
                }
                else if (!Char.IsLetterOrDigit(c))
                {
                    c = element;
                    result += element;
                }

                prev = element;
            }

            result += index > 1 ? $"{index}"
                                : String.Empty;
            return result;
        }

    }
}