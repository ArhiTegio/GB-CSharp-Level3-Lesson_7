using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Refact
{
    /// <summary>
    /// Класс запроса данных у пользователя
    /// </summary>
    class Questions
    {
        /// <summary>
        /// Перевести первый символ в заглавный
        /// </summary>
        /// <param name="text">Корректируемый текст</param>
        /// <returns></returns>
        public string FirstUpper(string text) => text.Substring(0, 1).ToUpper() + (text.Length > 1 ? text.Substring(1) : "");

        /// <summary>
        /// Запрос данных у пользователя
        /// </summary>
        /// <typeparam name="T">Тип выводимых значений (проверка на string)</typeparam>
        /// <param name="text">Текст запроса значения у пользователя</param>
        /// <param name="arraySym">Массив допустимых вводимых символов пользователем</param>
        /// <returns></returns>
        public string Question<T>(string text, HashSet<char> arraySym)
        {
            Console.Write(text);
            var textAnswer = new StringBuilder();
            while (true)
            {
                var symbol = Console.ReadKey(true);
                if (arraySym.Contains(symbol.KeyChar))
                {
                    textAnswer.Append(symbol.KeyChar.ToString());
                    Console.Write(symbol.KeyChar.ToString());
                }

                if (symbol.Key == ConsoleKey.Backspace && textAnswer.Length > 0)
                {
                    textAnswer.Remove(textAnswer.Length - 1, 1);
                    Console.Write(symbol.KeyChar.ToString());
                    Console.Write(" ");
                    Console.Write(symbol.KeyChar.ToString());
                }

                if (typeof(T) == typeof(string))
                {
                    if (symbol.Key == ConsoleKey.Enter && textAnswer.Length > 0)
                        break;
                }
                else
                    if (symbol.Key == ConsoleKey.Enter &&
                        double.TryParse(textAnswer.ToString()
                            .Replace(".", ","),
                            out var number))
                    break;
            }
            Console.WriteLine("");
            return textAnswer.ToString();
        }
    }

}
