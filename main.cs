using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
          Вариант Б16
1.Ввести пять различных ненулевых целых чисел. Найти произведение двух наибольших чисел.
2. Проверить истинность высказывания: "Квадратное уравнение A·x2 + B·x + C = 0 с данными коэффициентами A (A не равно 0), B, C имеет ровно один вещественный корень".
3.Проверить истинность высказывания: "Среди трех данных целых положительны чисел введенных с клавиатуры, есть хотя бы одна пара совпадающих".
4.Задано целое положительное четырехзначное число N (N > 0). Найти сумму между произведениями первых двух и последних двух его цифр.
5. Дан номер месяца N - целое положительное число в диапазоне от 1 до 12 (1 - январь, 2 - февраль, ..., 12 - декабрь). Определить количество дней в этом месяце для не високосного года.

*/

namespace PR02
{
    internal class main
    {
        static void Main(string[] args)
        {
            #region Задание 1
            Console.Write("Последовательно введите 5 ненулевых целочисленных значения\n");

            uint a, b, c, d, e;

        task1_Input:
            try 
            {
                Console.Write("Введите 1-ое значение: ");
                a = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Введите 2-ое значение: ");
                b = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Введите 3-е значение: ");
                c = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Введите 4-ое значение: ");
                d = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Введите 5-ое значение: ");
                e = Convert.ToUInt32(Console.ReadLine()); 
            }

            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое, либо отрицательное значение");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task1_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task1_Input;
            }

            uint[] nums = { a, b, c, d, e };

            uint maxNumValue01 = nums.Max();
            int maxNumIndex = nums.ToList().IndexOf(maxNumValue01);

            //Преобразуем массив в список для использования метода RemoveAt()
            var numsList = nums.ToList();
            numsList.RemoveAt(maxNumIndex);

            //Находим второе максимальное значение уже в списке, а не массиве
            uint maxNumValue02 = numsList.Max();

            Console.Write("\nПроизведение двух наибольших чисел: {0}\n", maxNumValue01*maxNumValue02);
            Console.Write("\nНажмите любую клавишу для продолжения... ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 2
            Console.WriteLine("Последовательно введите коэффициенты уравнения");

            double coef_a, coef_b, coef_c, discriminant;

            task2_Input:
            try
            {
                Console.Write("Введите 1-ое значение: ");
                coef_a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите 2-ое значение: ");
                coef_b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите 3-е значение: ");
                coef_c = Convert.ToDouble(Console.ReadLine());
                discriminant = coef_b * coef_b - 4 * coef_a * coef_c;
            }
            catch (OverflowException) 
            {
                Console.WriteLine("\nВведено слишком большое значение");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task2_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task2_Input;
            }

            if (discriminant == 0) Console.WriteLine("\nИстина");
            else Console.WriteLine("\nЛожь");

            Console.Write("\nНажмите любую клавишу для продолжения... ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 3

            Console.Write("Последовательно введите 3 ненулевых целочисленных значения\n");

            uint task3_a, task3_b, task3_c;

        task3_Input:
            try
            {
                Console.Write("Введите 1-ое значение: ");
                task3_a = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Введите 2-ое значение: ");
                task3_b = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Введите 3-е значение: ");
                task3_c = Convert.ToUInt32(Console.ReadLine());
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое, либо отрицательное значение");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task3_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task3_Input;
            }

            if (task3_a == task3_b && task3_b == task3_c) Console.WriteLine("\nИстина");
            else if (task3_a == task3_b) Console.WriteLine("\nИстина");
            else if (task3_a == task3_c) Console.WriteLine("\nИстина");
            else if (task3_c == task3_b) Console.WriteLine("\nИстина");
            else Console.WriteLine("\nЛожь");

            Console.Write("\nНажмите любую клавишу для продолжения... ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 4
            uint N;

         task4_Input:
            try
            {
                Console.WriteLine("Введите четырёхзначное значение N");
                N = Convert.ToUInt32(Console.ReadLine());
                if (N.ToString().Length != 4)
                {
                    Console.WriteLine("Число должно быть четырёхзначным");
                    Console.Write("Для перезапуска задания нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                    goto task4_Input;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое, либо отрицательное значение");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task4_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task4_Input;
            }

            uint n1 = N;
            var uintList = new List<uint>(4);

            while (n1 > 0)
            {
                uintList.Add(n1 % 10);
                n1 /= 10;
            }

            uintList.Reverse();
            var uintArray = uintList.ToArray();
            uint task4_comp12 = uintArray[0] * uintArray[1];
            uint task4_comp34 = uintArray[2] * uintArray[3];
            uint task4_sum = task4_comp12 + task4_comp34;


            Console.Write("\n\nРезультат: {0}", task4_sum);
            Console.Write("\nНажмите любую клавишу для продолжения... ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 5
            uint month;
        task5_Input:
            try
            {
                Console.Write("Введите нужный месяц (1-12): ");
                month = Convert.ToUInt32(Console.ReadLine());
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое, либо отрицательное значение");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task5_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.Write("Для перезапуска задания нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                goto task5_Input;
            }

            switch (month)
            {
                case uint maxMonths when (maxMonths > 12):
                    Console.WriteLine("В году лишь 12 месяцев");
                    Console.Write("Для перезапуска задания нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                    goto task5_Input;
                default:
                    Console.WriteLine("\n" + DateTime.DaysInMonth(2023, (int)month));
                    Console.Write("\nНажмите любую клавишу для завершения работы... ");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
            #endregion
        }
    }
}
