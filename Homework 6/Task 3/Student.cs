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
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        // Создаем конструктор
        public Student(string lastName, string firstName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }
}