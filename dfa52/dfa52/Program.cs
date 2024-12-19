using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 { 
    
using System;
using System.Linq;



class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите номер задания (1-14) или 0 для выхода:");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                continue;
            }

            if (choice == 0)
            {
                break;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;
                    case 7:
                        Task7();
                        break;
                    case 8:
                        Task8();
                        break;
                    case 9:
                        Task9();
                        break;
                    case 10:
                        Task10();
                        break;
                    case 11:
                        Task11();
                        break;
                    case 12:
                        Task12();
                        break;
                    case 13:
                        Task13();
                        break;
                    case 14:
                        Task14();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}. Попробуйте снова.");
            }
        }
    }

    static void Task1()
    {
        int[] array = InputArray(14);
        int count = array.Count(x => x % 2 == 0);
        Console.WriteLine($"Количество четных элементов: {count}");
    }

    static void Task2()
    {
        int[] array = InputArray(12);
        int average = (int)Math.Round(array.Average(), MidpointRounding.AwayFromZero);
        array[4] = average;
        Console.WriteLine("Массив после замены пятого элемента:");
        PrintArray(array);
    }

    static void Task3()
    {
        int[] array = InputArray(11);
        double average = array.Average();
        int count = array.Count(x => Math.Abs(x) > average);
        Console.WriteLine($"Количество элементов, абсолютное значение которых больше среднего арифметического: {count}");
    }

    static void Task4()
    {
        int[] array = InputArray(10);
        int maxIndex = Array.IndexOf(array, array.Max());
        (array[0], array[maxIndex]) = (array[maxIndex], array[0]);
        Console.WriteLine("Массив после замены максимального и первого элемента:");
        PrintArray(array);
    }

    static void Task5()
    {
        int[] array = InputArray(9);


        int maxIndex = Array.IndexOf(array, array.Max());
        int minIndex = Array.IndexOf(array, array.Min());
        (array[maxIndex], array[minIndex]) = (array[minIndex], array[maxIndex]);
        Console.WriteLine("Массив после замены максимального и минимального элемента:");
        PrintArray(array);
    }

    static void Task6()
    {
        int[] array = InputArray(20);
        int evenCount = array.Count(x => x % 2 == 0);
        int oddCount = array.Length - evenCount;
        Console.WriteLine(evenCount > oddCount ? "Четных больше" : "Нечетных больше");
    }

    static void Task7()
    {
        double[] array = InputArrayDouble(15);
        double first = array[0];
        int count = array.Count(x => x > first);
        Console.WriteLine($"Количество элементов, больше первого: {count}");
    }

    static void Task8()
    {
        double[] array = InputArrayDouble(16);
        int maxIndex = Array.IndexOf(array, array.Max());
        int minIndex = Array.IndexOf(array, array.Min());
        Console.WriteLine($"Индекс максимального: {maxIndex}, индекс минимального: {minIndex}");
    }

    static void Task9()
    {
        int[] array = InputArray(15);
        double average = array.Average();
        int[] newArray = array.Select(x => x - (int)average).ToArray();
        Console.WriteLine("Новый массив:");
        PrintArray(newArray);
    }

    static void Task10()
    {
        int[] array = InputArray(17);
        var negatives = array.Where(x => x < 0).Select(Math.Abs);
        if (!negatives.Any())
        {
            Console.WriteLine("Нет отрицательных элементов.");
            return;
        }
        double negativeAverage = negatives.Average();
        int sum = array.Where(x => Math.Abs(x) > negativeAverage).Sum();
        Console.WriteLine($"Сумма элементов, абсолютное значение которых больше среднего арифметического модулей отрицательных элементов: {sum}");
    }

    static void Task11()
    {
        int[] array = InputArray(14);
        var evenPositive = array.Where(x => x > 0 && x % 2 == 0);
        Console.WriteLine($"Количество: {evenPositive.Count()}, сумма: {evenPositive.Sum()}");
    }

    static void Task12()
    {
        double[] array = InputArrayDouble(12);
        Array.Sort(array);
        Array.Reverse(array);
        Console.WriteLine("Массив в порядке убывания:");
        PrintArray(array);
        Console.WriteLine($"Сумма максимального и минимального: {array.Max() + array.Min()}");
    }

    static void Task13()
    {
        int[] array = InputArray(15);
        int max = array.Max();
        int min = array.Min();
        Console.WriteLine($"Сумма: {max + min}, разность: {max - min}");
    }

    static void Task14()
    {
        int[] array = InputArray(17);
        int oddSum = array.Where(x => x % 2 != 0).Sum();
        array = array.Select(x => x % 3 == 0 && x != 0 ? oddSum : x).ToArray();
        Console.WriteLine("Массив после замены:");
        PrintArray(array);
    }

    static int[] InputArray(int size)
    {
        Console.WriteLine($"Введите массив из {size} элементов:");
        while (true)
        {
            try
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (input.Length != size)
                {
                    throw new Exception($"Массив должен содержать ровно {size} элементов.");
                }
                return input;
            }
            catch
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
    }


    static double[] InputArrayDouble(int size)
    {
        Console.WriteLine($"Введите массив из {size} элементов (вещественные числа):");
        while (true)
        {
            try
            {
                var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                if (input.Length != size)
                {
                    throw new Exception($"Массив должен содержать ровно {size} элементов.");
                }
                return input;
            }
            catch
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
    }

    static void PrintArray<T>(T[] array)
    {
        Console.WriteLine(string.Join(" ", array));
    }
}
}