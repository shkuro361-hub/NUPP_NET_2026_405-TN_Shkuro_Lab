namespace UniversityManagement.Common;

public class Teacher : UniversityMember
{
    public string Department { get; set; }
    public string AcademicTitle { get; set; }
    public int YearsOfExperience { get; set; }

    // Конструктор похідного класу
    public Teacher(string fullName, string email, string department, string academicTitle, int yearsOfExperience)
        : base(fullName, email)
    {
        Department = department;
        AcademicTitle = academicTitle;
        YearsOfExperience = yearsOfExperience;
    }

    public override string GetDetails() =>
        $"Викладач: {FullName}; кафедра: {Department}; посада/звання: {AcademicTitle}; досвід: {YearsOfExperience} р.";
}
