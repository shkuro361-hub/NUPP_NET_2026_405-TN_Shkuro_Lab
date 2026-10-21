namespace UniversityManagement.Common;

public delegate void StudentCreatedHandler(Student student);

public class Student : UniversityMember
{
    private static int _createdCount;

    // Статичний конструктор виконується один раз для типу
    static Student()
    {
        _createdCount = 0;
    }

    public int StudentNumber { get; set; }
    public string Speciality { get; set; }
    public double AverageGrade { get; set; }

    // Подія повідомляє про створення екземпляра Student
    public static event StudentCreatedHandler? StudentCreated;

    public static int CreatedCount => _createdCount;

    // Конструктор похідного класу
    public Student(string fullName, string email, int studentNumber, string speciality, double averageGrade)
        : base(fullName, email)
    {
        StudentNumber = studentNumber;
        Speciality = speciality;
        AverageGrade = averageGrade;
        _createdCount++;
        StudentCreated?.Invoke(this);
    }

    // Статичний метод
    public static bool IsPassingGrade(double grade) => grade >= 60.0;

    public override string GetDetails() =>
        $"Студент: {FullName}; №: {StudentNumber}; спеціальність: {Speciality}; середній бал: {AverageGrade:F1}";
}
