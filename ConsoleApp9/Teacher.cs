using System;

namespace UniversityApp;

public class Teacher
{
    private string _name = String.Empty;
    private string _subject = String.Empty;

    public string Name
    {
        get { return _name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ім'я викладача не може бути порожнім.");
            _name = value;
        }
    }

    public string Subject
    {
        get { return _subject; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Предмет не може бути порожнім.");
            _subject = value;
        }
    }

    public Teacher()
    {
        Name = "Без імені";
        Subject = "Не вказано";
    }

    public Teacher(string name, string subject)
    {
        Name = name;
        Subject = subject;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Викладач: {Name}, предмет: {Subject}";
    }
}