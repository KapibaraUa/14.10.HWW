using System;
using System.Collections.Generic;

namespace UniversityApp;

public class Course
{
    private static uint _courseCount;
    private string _title = String.Empty;
    private List<CourseModule> _modules;
    private List<Student> _students;

    static Course()
    {
        _courseCount = 0;
    }

    public static uint GetCourseCount()
    {
        return _courseCount;
    }

    public string Title
    {
        get { return _title; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва курсу не може бути порожньою.");
            _title = value;
        }
    }

    public Course()
    {
        Title = "Новий курс";
        _modules = new List<CourseModule>
        {
            new CourseModule("Вступ", 2)
        };
        _students = new List<Student>();
        _courseCount++;
    }

    public Course(string title, params string[] moduleTitles)
    {
        Title = title;
        _modules = new List<CourseModule>();
        for (int i = 0; i < moduleTitles.Length; i++)
        {
            _modules.Add(new CourseModule(moduleTitles[i], 4));
        }
        _students = new List<Student>();
        _courseCount++;
    }

    public void AddModule(string title, ushort hours)
    {
        _modules.Add(new CourseModule(title, hours));
    }

    public void AddStudent(Student student)
    {
        if (student == null)
            throw new ArgumentException("Студент не може бути null.");

        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i].Id == student.Id)
                throw new ArgumentException($"Студент {student.Name} (ID: {student.Id}) вже записаний на курс \"{Title}\".");
        }

        _students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        if (student == null)
            throw new ArgumentException("Студент не може бути null.");

        _students.Remove(student);
    }

    public Student? FindStudentByName(string name)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                return _students[i];
        }
        return null;
    }

    public Student? FindStudentById(int id)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i].Id == id)
                return _students[i];
        }
        return null;
    }

    public void DisplayModules()
    {
        Console.WriteLine($"Модулі курсу \"{Title}\":");
        if (_modules.Count == 0)
        {
            Console.WriteLine("  Модулів немає.");
            return;
        }

        for (int i = 0; i < _modules.Count; i++)
        {
            Console.WriteLine($"  - {_modules[i]}");
        }
    }

    public void DisplayStudents()
    {
        Console.WriteLine($"Студенти курсу \"{Title}\":");
        if (_students.Count == 0)
        {
            Console.WriteLine("  Студентів немає.");
            return;
        }

        for (int i = 0; i < _students.Count; i++)
        {
            Console.WriteLine($"  - {_students[i]}");
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"=== Курс: {Title} ===");
        DisplayModules();
        DisplayStudents();
    }
}