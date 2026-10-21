namespace UniversityManagement.Common;

public class Course : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string CourseCode { get; set; }
    public int Credits { get; set; }
    public string InstructorName { get; set; }

    public Course(string title, string courseCode, int credits, string instructorName)
    {
        Id = Guid.NewGuid();
        Title = title;
        CourseCode = courseCode;
        Credits = credits;
        InstructorName = instructorName;
    }

    // Статичний метод для перевірки коректності кількості кредитів
    public static bool IsValidCreditCount(int credits) => credits is >= 1 and <=  ECTSMaximum;

    private const int ECTSMaximum = 60;

    public override string ToString() => $"{Title} [{CourseCode}], {Credits} кредитів, викладач: {InstructorName}";
}
