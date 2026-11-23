using System;
using System.Collections.Generic;

namespace UniversityApp;

public class University
{
    private string _name = String.Empty;
    private Address _address;
    private List<Teacher> _teachers;

    public string Name
    {
        get { return _name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва університету не може бути порожньою.");
            _name = value;
        }
    }

    public University()
    {
        Name = "Невідомий університет";
        _address = new Address();
        _teachers = new List<Teacher>();
    }

    public University(string name, string city, string street, string building)
    {
        Name = name;
        _address = new Address(city, street, building);
        _teachers = new List<Teacher>();
    }

    public string GetAddressInfo()
    {
        return _address.ToString();
    }

    public void AddTeacher(Teacher teacher)
    {
        if (teacher == null)
            throw new ArgumentException("Викладач не може бути null.");

        _teachers.Add(teacher);
    }

    public void DisplayTeachers()
    {
        Console.WriteLine($"Викладачі університету \"{Name}\":");
        if (_teachers.Count == 0)
        {
            Console.WriteLine("  Викладачів немає.");
            return;
        }

        for (int i = 0; i < _teachers.Count; i++)
        {
            Console.WriteLine($"  - {_teachers[i]}");
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"=== Університет: {Name} ===");
        Console.WriteLine($"Адреса: {GetAddressInfo()}");
        DisplayTeachers();
    }
}