using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Refact
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Questions();
            WriteLine("Здраствуйте, вас приветствует математическая программа.");

            var s = int.Parse(q.Question<int>("Для получения факториала пожалуйста введите число (для выхода введите пустую строку): ", new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', }));
            if (s != 0)
            {
                var factor = s.Factorial();
                WriteLine($"Факториал числа {s} равет: {factor}");
                WriteLine($"Сумма чисел факториала от 0 до {s} равна: {s.SumOfTheSequenceFactorial()}");
                WriteLine($"Максимальное четное число меньше {s} равно: {factor.MaximumEvenNumber()}");
                ReadLine();
            }            
        }
    }
}
