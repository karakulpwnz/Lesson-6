using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Володин Артем

//3. Переделать программу Пример использования коллекций для решения следующих задач:
//а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
//б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный
//массив);
//в) отсортировать список по возрасту студента;
//г) * отсортировать список по курсу и возрасту студента;
//д) ** разработать единый метод подсчета количества студентов по различным параметрам
//выбора с помощью делегата и методов предикатов

namespace Task_3
{
    class Program
    {
        static int MyDelegat(Student st1, Student st2) // Создаем метод для сравнения для экземпляров
        {
            return String.Compare(Convert.ToString(st1.age), Convert.ToString(st2.age)); // Сравниваем две строки по возрасту
        }

        static int MyDelegat2(Student st1, Student st2)//создаем метод сравнения 
        {
            int result = String.Compare(Convert.ToString(st1.course), Convert.ToString(st2.course));//сраниваем две строки по курсу
            if (result == 0)
            {
                result = String.Compare(Convert.ToString(st1.age), Convert.ToString(st2.age));//если по курсу равны - сраниваем по возрасту
            }
            return result;
        }

        static void Main(string[] args)
        {
            int bakalavr = 0;
            List<Student> list = new List<Student>();
            // Создаем список студентов
            StreamReader sr = new StreamReader("students_6.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество учащихся на 5 и 6 курсах
                    if (int.Parse(s[6]) > 4) bakalavr++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");// Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();

            Console.WriteLine("\nВсего студентов:" + list.Count);
            Console.WriteLine("\nУчащихся 5 и 6 курсов:{0}", bakalavr);

            //создание массива с распредлением студентов определенного возраста по курсам
            int[] course = new int[] { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].age >= 18 && list[i].age <= 20)
                {
                    course[list[i].course - 1]++;
                }
            }
            Console.WriteLine("\nРаспределение студентов от 18 до 20 по курсам:" +
                "\n1 курс: {0}\n2 курс: {1}\n3 курс: {2}\n4 курс: {3}\n5 курс: {4}\n6 курс: {5}", course[0], course[1], course[2], course[3], course[4], course[5]);

            //сортируем по возрасту
            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("\nСтуденты, отсортирвоанные по возрасту: ");
            foreach (var v in list) Console.WriteLine("{0} {1}", v.lastName, v.age);

            //сортируем по курсу и возрасту
            Console.WriteLine("\nСписок, упорядоченный по курсу и возрасту студентов: ");
            list.Sort(new Comparison<Student>(MyDelegat2));
            foreach (var v in list) Console.WriteLine(v.firstName + " " + v.course + " " + v.age);

            //применение метода для поиска произвольного заданного параметра
            int n = 0;
            List<Student> sorted = SearchMethods.Search(list, SearchMethods.Age, "18", out n);
            Console.WriteLine("\n" + n + " студентов возраста 18: ");
            foreach (var v in sorted) Console.WriteLine(v.lastName);

            Console.ReadKey();
        }
    }
}