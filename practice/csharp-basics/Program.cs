using System;
using System.Linq; // Для работы Min() и Average()
Console.OutputEncoding = System.Text.Encoding.UTF8;
namespace CSharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Создаем массив из 5 чисел (можешь поменять числа на свои)
            int[] numbers = { 8, 3, 15, 2, 7 };

            // 2. Находим минимум
            int min = numbers.Min();

            // 3. Находим среднее арифметическое
            double average = numbers.Average();

            // 4. Выводим результат в консоль
            Console.WriteLine("Массив чисел: " + string.Join(", ", numbers));
            Console.WriteLine($"Минимальное значение: {min}");
            Console.WriteLine($"Среднее арифметическое: {average}");
        }
    }
}