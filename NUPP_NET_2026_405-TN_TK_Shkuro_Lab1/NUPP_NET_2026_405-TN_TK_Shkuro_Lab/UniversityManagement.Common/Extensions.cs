namespace UniversityManagement.Common;

public static class Extensions
{
    // Метод розширення для підрахунку студентів, які мають прохідний середній бал
    public static int CountPassingStudents(this IEnumerable<Student> students) =>
        students.Count(student => Student.IsPassingGrade(student.AverageGrade));
}
