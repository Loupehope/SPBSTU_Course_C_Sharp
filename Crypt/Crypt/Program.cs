using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Crypt
{
    class Program
    {
        enum Mode
        {
            Encrypt,
            Decrypt
        }

        static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string alphabetToReplace = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string tempFile = "tempFile.txt";
        static string roughReplacement = "roughReplacement.txt";

        static Dictionary<string, string> replacements = new Dictionary<string, string>();

        public static void Main(string[] args)
        {
            string modes = "1 - Encrypt the text\n2 - Decrypt the text\n3 - Break the code\nAny number - Exit";
            Console.WriteLine(modes);
            int mode = Int32.Parse(Console.ReadLine());

            while (mode > 0 && mode < 4)
            {
                switch (mode)
                {
                    case 1:
                        CryptAction(Mode.Encrypt);
                        break;
                    case 2:
                        CryptAction(Mode.Decrypt);
                        break;
                    case 3:
                        BreakCode();
                        break;
                }

                Console.WriteLine(modes);
                mode = Int32.Parse(Console.ReadLine());
            }

            // Выбор режима работы программы

            static void CryptAction(Mode mode)
            {
                int offset;
                string keyword;
                string inputFile = "";
                string outputFile = "";

                Console.WriteLine("Enter your keyword:");
                keyword = Console.ReadLine();

                Console.WriteLine("Enter the offset value:");

                offset = Int32.Parse(Console.ReadLine());

                switch (mode)
                {
                    case Mode.Encrypt:
                        Console.WriteLine("File to encrypt:");
                        inputFile = Console.ReadLine();

                        Console.WriteLine("File to write the encrypted data:");
                        outputFile = Console.ReadLine();

                        break;

                    case Mode.Decrypt:
                        Console.WriteLine("File to decrypt:");
                        inputFile = Console.ReadLine();

                        Console.WriteLine("File to write the decrypted data:");
                        outputFile = Console.ReadLine();

                        break;
                }

                if (inputFile == null || inputFile == "")
                {
                    inputFile = "/Users/vladsuhomlinov/Desktop/Crypt/file.txt";
                }

                if (outputFile == null || outputFile == "")
                {
                    var suffix = mode == Mode.Encrypt ? "enc" : "dec";

                    outputFile = "/Users/vladsuhomlinov/Desktop/Crypt/file_" + suffix + ".txt";
                }

                CaesarCrypt(mode, offset, keyword, inputFile, outputFile);

                if (mode == Mode.Encrypt)
                    Console.WriteLine("Your text was encrypted \n");
                else
                    Console.WriteLine("Your text was decrypted \n");
            }

            // Алгоритм Цезаря

            static void CaesarCrypt(Mode mode, int offset, string keyword, string inputFile, string outputFile)
            {
                string localKeyword = "";
                string newAlphabet = alphabet;

                for (int i = 0; i < keyword.Length; i++)
                {
                    if (Char.IsLetter(keyword.ToUpper()[i]) && localKeyword.IndexOf(keyword.ToUpper()[i]) == -1)
                    {
                        localKeyword += keyword.ToUpper()[i];
                    }
                }

                // удаление из алфавита символов, которые содержатся в ключевом слове
                for (int i = 0; i < localKeyword.Length; i++)
                {
                    newAlphabet = newAlphabet.Replace(localKeyword[i].ToString(), String.Empty);
                }

                if ((newAlphabet.Length - offset) < 0)
                {
                    Console.WriteLine("Your keyword/offset is too long. Please enter a smaller offset/keyword");
                    return;
                }

                // вставка в отредактированный алфавит кодового слова
                newAlphabet = newAlphabet.Substring(newAlphabet.Length - offset) + localKeyword + newAlphabet.Substring(0, newAlphabet.Length - offset);

                string indexAlphabet = mode == Mode.Encrypt ? alphabet : newAlphabet;
                string substringAlphabet = mode == Mode.Encrypt ? newAlphabet : alphabet;

                using (StreamReader sr = new StreamReader(inputFile, false))
                using (StreamWriter sw = new StreamWriter(outputFile, false))
                {
                    string textLine = sr.ReadLine();
                    int indexOfCharacter;

                    while (textLine != null)
                    {
                        for (int i = 0; i < textLine.Length; i++)
                        {
                            indexOfCharacter = indexAlphabet.IndexOf(Char.ToUpper(textLine[i]));

                            if (indexOfCharacter != -1)
                                sw.Write(substringAlphabet.Substring(indexOfCharacter, 1));
                            else
                                sw.Write(textLine[i]);
                        }

                        sw.WriteLine();
                        textLine = sr.ReadLine();
                    }
                }
            }

            // Метод для взлома сообщения

            static void BreakCode()
            {
                string encryptedFile;
                string dictionaryFile;
                string decryptedFile;

                Console.WriteLine("File to decrypt:");
                encryptedFile = Console.ReadLine();

                Console.WriteLine("DictionaryFile:");
                dictionaryFile = Console.ReadLine();

                if (dictionaryFile == null || dictionaryFile == "")
                {
                    dictionaryFile = "/Users/vladsuhomlinov/Desktop/Crypt/dict.txt";
                }

                Console.WriteLine("File to write the decrypted data:");

                decryptedFile = Console.ReadLine();

                Console.WriteLine("Waiting");

                CaesarBreakCode(encryptedFile, dictionaryFile, decryptedFile);

                Console.WriteLine("Broken!");
            }

            // Читаем данные из файла и генерируем список слов

            static List<string> MakeWordsList(string filename)
            {
                string line = "", word = "";
                List<string> res = new List<string>();
                using (StreamReader sr = new StreamReader(filename, false))
                {
                    while (line != null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (Char.IsLetter(line[i]) && (line[i] >= 65 && line[i] <= 90 || line[i] >= 97 && line[i] <= 122))
                                word += line[i].ToString().ToUpper();
                            else
                            {
                                if (word.Length > 0 && !res.Contains(word))
                                    res.Add(word);
                                word = "";
                            }
                        }
                        line = sr.ReadLine();
                    }
                }
                return res;
            }

            // Подсчитываем разницу в словах

            static int CountDifferentLetter(string word, string correctWord)
            {
                int result = 0;

                for (int i = 0; i < word.Length; i++)
                    if (word[i] != correctWord[i]) result++;

                return result;
            }

            // Добавляем буквы для замены

            static void AddLettersReplacement(string word, string correctWord)
            {
                int ind;

                for (int i = 0; i < word.Length; i++)
                {
                    try
                    {
                        if (alphabetToReplace.IndexOf(correctWord[i]) != -1)
                        {
                            replacements.Add(word[i].ToString(), correctWord[i].ToString());

                            ind = alphabetToReplace.IndexOf(correctWord[i].ToString().ToUpper());

                            if (ind >= 0) alphabetToReplace = alphabetToReplace.Remove(ind, 1);
                        }
                    }
                    catch { }

                }
            }

            // Находим близкие слова

            static void FindSimilarWord(string word, List<string> dictionary)
            {
                int diffCount;

                foreach (string correctWord in dictionary)
                {
                    if (word.Length == correctWord.Length)
                    {
                        diffCount = CountDifferentLetter(word, correctWord);

                        if (diffCount < 3)
                        {
                            AddLettersReplacement(word, correctWord);
                            break;
                        }
                    }
                }
            }


            // Формируем словарь для замены

            static void MakeLettersToReplace(List<string> encrWords, List<string> dictionary)
            {
                foreach (string word in encrWords)
                {
                    if (word.Length > 5)
                    {
                        FindSimilarWord(word, dictionary);

                    }

                    if (alphabetToReplace == "")
                    {
                        break;
                    }
                }


                foreach (string word in encrWords)
                {
                    if (word.Length < 6)
                    {
                        FindSimilarWord(word, dictionary);

                    }

                    if (alphabetToReplace == "")
                    {
                        break;
                    }
                }
            }

            // Запись взломанного текста в файл

            static void WriteDecryptedFile(string encryptedFile, string decryptedFile)
            {
                string temp = "";

                using (StreamReader sr = new StreamReader(encryptedFile, false))
                using (StreamWriter sw = new StreamWriter(decryptedFile, false))
                {
                    string textLine = sr.ReadLine();

                    while (textLine != null)
                    {
                        for (int i = 0; i < textLine.Length; i++)
                        {
                            if (Char.IsLetter(textLine[i]) && (textLine[i] >= 65 && textLine[i] <= 90 || textLine[i] >= 97 && textLine[i] <= 122))
                            {
                                temp = textLine[i].ToString();
                                sw.Write(replacements[temp]);
                            }
                            else
                            {
                                sw.Write(textLine[i]);
                            }
                        }

                        sw.WriteLine();
                        textLine = sr.ReadLine();
                    }
                }
            }

            // Грубый взлом

            static void MakeRoughReplacement(string encryptedFile, string dictionaryFile)
            {
                Dictionary<string, double> dictionaryLettFreq = CountLettersFrequency(dictionaryFile);
                Dictionary<string, double> encryptedLettFreq = CountLettersFrequency(encryptedFile);
                replacements.Clear();
                string temp = "";
                alphabetToReplace = alphabet;

                foreach (KeyValuePair<string, double> item in encryptedLettFreq)
                {
                    if (item.Key.Length == 1)
                    {
                        replacements.Add(item.Key, dictionaryLettFreq.Keys.ToList()[0]);

                        foreach (KeyValuePair<string, double> stat in dictionaryLettFreq)
                        {
                            if (stat.Key.Length == 1 && Math.Abs(item.Value - dictionaryLettFreq[replacements[item.Key]]) > Math.Abs(item.Value - stat.Value))
                            {
                                temp = stat.Key;
                                replacements[item.Key] = stat.Key;
                            }
                        }
                        dictionaryLettFreq.Remove(temp);
                    }
                }

                WriteDecryptedFile(encryptedFile, roughReplacement);
            }

            static void MoreAccurateReplacement(string encryptedFile, string dictionaryFile, string decryptedFile)
            {
                List<string> encryptedWords = MakeWordsList(encryptedFile);
                List<string> dictionaryWords = MakeWordsList(dictionaryFile);
                alphabetToReplace = alphabet;

                replacements.Clear();

                MakeLettersToReplace(encryptedWords, dictionaryWords);

                foreach (char letter in alphabet)
                {
                    try
                    {
                        replacements.Add(letter.ToString(), alphabetToReplace[0].ToString());
                        alphabetToReplace = alphabetToReplace.Substring(1);
                    }
                    catch { }
                }

                WriteDecryptedFile(encryptedFile, decryptedFile);
            }

            static void CaesarBreakCode(string encryptedFile, string dictionaryFile, string decryptedFile)
            {
                // Грубый подбор слов
                MakeRoughReplacement(encryptedFile, dictionaryFile);

                // Производим более точный подбор слов

                MoreAccurateReplacement(roughReplacement, dictionaryFile, tempFile);
                MoreAccurateReplacement(tempFile, dictionaryFile, decryptedFile);
                MoreAccurateReplacement(decryptedFile, dictionaryFile, tempFile);
                MoreAccurateReplacement(tempFile, dictionaryFile, decryptedFile);

                // удаляем временные файлы
                File.Delete(roughReplacement);
                File.Delete(tempFile);
            }


            static Dictionary<string, double> CountLettersFrequency(string filename)
            {
                string textLine = "";
                int charsTotal = 0;
                Dictionary<string, double> letterFreqs = new Dictionary<string, double>();

                using (StreamReader sr = new StreamReader(filename, false))
                {
                    while (textLine != null)
                    {
                        for (int i = 0; i < textLine.Length; i++)
                        {
                            if (Char.IsLetter(textLine[i]) && (textLine[i] >= 65 && textLine[i] <= 90 || textLine[i] >= 97 && textLine[i] <= 122))
                            {
                                charsTotal++;

                                if (letterFreqs.ContainsKey(textLine[i].ToString().ToUpper()))
                                {
                                    letterFreqs[textLine[i].ToString().ToUpper()] += 1;
                                }
                                else
                                {
                                    letterFreqs.Add(textLine[i].ToString().ToUpper(), 1);
                                }
                            }
                        }

                        textLine = sr.ReadLine();
                    }

                    foreach (KeyValuePair<string, double> item in letterFreqs.ToList())
                    {
                        letterFreqs[item.Key] = letterFreqs[item.Key] / charsTotal;
                    }
                }

                return letterFreqs;
            }

        }
    }
}
