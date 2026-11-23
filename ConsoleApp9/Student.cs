using System;

namespace UniversityApp;

public class Student
{
    private static int _nextId;
    private int _id;
    private string _name = String.Empty;
    private ushort _age;

    static Student()
    {
        _nextId = 1;
    }

    public int Id
    {
        get { return _id; }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ім'я студента не може бути порожнім.");
            _name = value;
        }
    }

    public ushort Age
    {
        get { return _age; }
        set
        {
            if (value < 16 || value > 100)
                throw new ArgumentException("Вік студента має бути від 16 до 100 років.");
            _age = value;
        }
    }

    public Student()
    {
        _id = _nextId++;
        Name = "Без імені";
        Age = 18;
    }

    public Student(string name, ushort age)
    {
        _id = _nextId++;
        Name = name;
        Age = age;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Студент [ID: {Id}] {Name}, вік: {Age}";
    }
}