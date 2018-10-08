using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class SearchMethods
    {
        /// <summary>
        /// поиск по фамилии
        /// </summary>
        /// <param name="student"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool LastName(Student student, string search)
        {
            return Equals(search, student.lastName);
        }

        /// <summary>
        /// поиск по имени
        /// </summary>
        /// <param name="student"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool FirstName(Student student, string search)
        {
            return Equals(student.firstName, search);
        }

        /// <summary>
        /// поиск по университетe
        /// </summary>
        /// <param name="student"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool University(Student student, string search)
        {
            return Equals(student.university, search);
        }

        /// <summary>
        /// поиск по факультету
        /// </summary>
        /// <param name="student"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool Faculty(Student student, string search)
        {
            return Equals(student.faculty, search);
        }

        /// <summary>
        /// поиск по кафедре
        /// </summary>
        /// <param name="student"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool Department(Student student, string search)
        {
            return Equals(student.department, search);
        }

        /// <summary>
        /// поиск по возрасту
        /// </summary>
        /// <param name="student"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool Age(Student student, string search)
        {
            return student.age == Convert.ToInt32(search);
        }

        /// <summary>
        /// поиск по курсу
        /// </summary>
        /// <param name="student"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool Course(Student student, string search)
        {
            return student.course == Convert.ToInt32(search);
        }

        /// <summary>
        /// поиск по группе
        /// </summary>
        /// <param name="student"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool Group(Student student, string search)
        {
            return student.group == Convert.ToInt32(search);
        }

        /// <summary>
        /// поиск по городу
        /// </summary>
        /// <param name="student"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool City(Student student, string search)
        {
            return Equals(student.city, search);
        }

        /// <summary>
        /// Делегат, передающий тип искомого параметра
        /// </summary>
        /// <param name="student">элемент списка, в котором ищем</param>
        /// <param name="search">поисковый запрос</param>
        /// <returns></returns>
        public delegate bool Compare(Student student, string search);

        /// <summary>
        /// Возвращает список всех строк, содержащих указанный параметр search
        /// </summary>
        /// <param name="list">Список, по которому ищем</param>
        /// <param name="f">Параметр, по которому ищем. Указан в классе Search.Methods.</param>
        /// <param name="search">Значение искомое</param>
        /// <returns></returns>
        public static List<Student> Search(List<Student> list, Compare f, string search, out int count)
        {
            List<Student> result = new List<Student>();
            count = 0;

            foreach (var i in list)
            {
                if (f(i, search))
                {
                    result.Add(i);
                    count++;
                }
            }

            return result;
        }
    }
}
