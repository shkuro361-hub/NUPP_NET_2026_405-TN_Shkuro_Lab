namespace UniversityManagement.Common;

public class Enrollment : IEntity
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }
    public string Status { get; set; }

    public Enrollment(Guid studentId, Guid courseId, string status = "Active")
    {
        Id = Guid.NewGuid();
        StudentId = studentId;
        CourseId = courseId;
        EnrolledAt = DateTime.UtcNow;
        Status = status;
    }

    public override string ToString() =>
        $"Запис на курс: студент {StudentId}, курс {CourseId}, статус: {Status}, дата UTC: {EnrolledAt:g}";
}
