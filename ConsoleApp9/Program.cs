using System;

namespace UniversityApp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Student student1 = new Student("Артем Косяніч", 19);
            Student student2 = new Student("Олександр Новак", 20);
            Student student3 = new Student("Катерина Іванова", 19);

            Teacher teacher1 = new Teacher("Олена Петрівна", "Програмування C#");
            Teacher teacher2 = new Teacher("Ігор Сергійович", "Бази даних");

            University? university = new University("IT Step University", "Одеса", "Садова", "3");
            university.AddTeacher(teacher1);
            university.AddTeacher(teacher2);

            Course? csharpCourse = new Course("Платформа .NET та C#", "Типи даних", "Класи та структури");
            csharpCourse.AddModule("Агрегація та композиція", 6);

            Course dbCourse = new Course("Бази даних", "Основи SQL", "Проєктування БД");

            csharpCourse.AddStudent(student1);
            csharpCourse.AddStudent(student2);
            dbCourse.AddStudent(student2);
            dbCourse.AddStudent(student3);

            university.DisplayInfo();
            Console.WriteLine();

            csharpCourse.DisplayInfo();
            Console.WriteLine();

            dbCourse.DisplayInfo();
            Console.WriteLine();

            Console.WriteLine($"Всього створено курсів: {Course.GetCourseCount()}\n");

            try
            {
                csharpCourse.AddStudent(student1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Перевірка дублікату: {ex.Message}\n");
            }

            Student? foundByName = csharpCourse.FindStudentByName("Олександр Новак");
            Console.WriteLine(foundByName != null ? $"Знайдено за ім'ям: {foundByName}" : "Студента не знайдено.");

            Student? foundById = dbCourse.FindStudentById(student3.Id);
            Console.WriteLine(foundById != null ? $"Знайдено за ID: {foundById}\n" : "Студента не знайдено.\n");

            csharpCourse.RemoveStudent(student2);
            Console.WriteLine("Після видалення студента з курсу:");
            csharpCourse.DisplayStudents();
            Console.WriteLine($"Видалений студент все ще існує окремо: {student2}\n");

            Console.WriteLine("=== Демонстрація різниці між агрегацією та композицією ===");
            university = null;
            csharpCourse = null;

            Console.WriteLine("Університет та курс видалено (присвоєно null).");
            Console.WriteLine("Доступ до адреси університету та модулів курсу втрачено (композиція).");
            Console.WriteLine("Але викладачі та студенти продовжують існувати незалежно (агрегація):");
            teacher1.DisplayInfo();
            student1.DisplayInfo();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка даних: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Непередбачена помилка: {ex.Message}");
        }
    }
}