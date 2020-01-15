using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refact
{
    public static class Int32Ext
    {
        /// <summary>
        /// Факториал числа
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public static int Factorial(this int step) => step == 0 ? 1 : Enumerable.Range(1, step).Aggregate((i, j) => i * j);

        /// <summary>
        /// Сумма чисел факториала
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public static int SumOfTheSequenceFactorial(this int step)
        {
            if (step == 0) return 1;
            var fact = 1;
            var result = 1;
            for(int i = 1; i <= step; fact *= ++i) 
                result += fact;
            return result;
        }

        /// <summary>
        /// Максимальное положительное число
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public static int MaximumEvenNumber(this int step) => step % 2 == 0 ? step : step - 1;
    }
}
