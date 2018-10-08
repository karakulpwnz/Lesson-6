using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Володин Артем

//2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
//а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
//б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
//в) * Переделайте функцию Load, чтобы она возвращала массив считанных значений.Пусть она
//возвращает минимум через параметр.


namespace Task_2
{
    class Program
    {
        public delegate double Fun(double x);

        //квадрат числа
        public static double Squared(double x)
        {
            return x * x;
        }

        //куб числа
        public static double Cubed(double x)
        {
            return x * x * x;
        }

        // гипербола
        public static double Giper(double x)
        {
            return 1/(x-1);
        }

        //возведение в степень самого себя
        public static double Exp(double x)
        {
            double result = 1;
            
            for(int i = 0; i < x; i++)
            {
                result = result * x;
            }

            return result;
        }

        public static void SaveFunc(Fun F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static List<double> Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            List<double> result = new List<double>();
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                //добавляем посчитанное значение функции в список
                result.Add(d);
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return result;
        }
        static void Main(string[] args)
        {
            //создаем список с функциями
            List<Fun> list = new List<Fun> { Squared, Cubed, Giper, Exp };

            //просим выбрать функцию
            Console.WriteLine("Нажмите номер функции, для которой вы хотите посчитать минимум:\n" + "1) x^2\n" + "2) x^3\n" + "3) 1/(x-1)\n" + "4) x^x");
            int k = Convert.ToInt32(Console.ReadLine());

            //просим указать отрезок
            Console.Write("\nУкажите отрезок, на котором нужно посчитать минимум функции.\nНачало отрезка: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Конец отрезка: ");
            int b = Convert.ToInt32(Console.ReadLine());

            SaveFunc(list[k], "data.bin", a, b, 0.5);
            double min;
            List<double> n = Load("data.bin", out min);
            Console.WriteLine("\nМинимум функции {0} на отрезке [{1};{2}] равен: {3}", k, a, b, min);

            //проверка корректной работы записи в список
            //Console.WriteLine("Вывод списка значений:\n");
            //for(int i = 0; i < n.Count; i++)
            //{
            //    Console.WriteLine(n[i]);
            //}
            Console.ReadKey();
        }
    }
}
