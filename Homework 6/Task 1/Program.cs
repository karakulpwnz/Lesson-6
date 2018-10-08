using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Володин Артем

//1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции
//типа double (double, double). Продемонстрировать работу на функции с функцией a*x^2 и
// функцией a* sin(x).

namespace Task_1
{
    delegate double Fun(double x, double a);

    class Program
    {
        public static void Table(Fun F, double x, double b, double a)
        {
            Console.WriteLine("----- A -------- X -------- Y ----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, F(x,a));
                x += 1;
            }
            Console.WriteLine("----------------------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double FuncQuad(double x, double a)
        {
            return a * x * x;
        }

        public static double FuncSin(double x, double a)
        {
            return a * Math.Sin(x);
        }

        static void Main()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции a*x^2:");
            Table(new Fun(FuncQuad), -2, 2, 3);
            Console.WriteLine("Таблица функции a*sin(x):");
            Table(new Fun(FuncSin), -2, 2, 4);

            Console.ReadLine();
        }
        
    }
}
