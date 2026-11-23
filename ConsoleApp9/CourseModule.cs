using System;

namespace UniversityApp;

public class CourseModule
{
    private string _title = String.Empty;
    private ushort _hours;

    public string Title
    {
        get { return _title; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва модуля не може бути порожньою.");
            _title = value;
        }
    }

    public ushort Hours
    {
        get { return _hours; }
        set
        {
            if (value == 0 || value > 500)
                throw new ArgumentException("Кількість годин має бути від 1 до 500.");
            _hours = value;
        }
    }

    public CourseModule()
    {
        Title = "Вступний модуль";
        Hours = 2;
    }

    public CourseModule(string title, ushort hours)
    {
        Title = title;
        Hours = hours;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Модуль: {Title} ({Hours} год.)";
    }
}