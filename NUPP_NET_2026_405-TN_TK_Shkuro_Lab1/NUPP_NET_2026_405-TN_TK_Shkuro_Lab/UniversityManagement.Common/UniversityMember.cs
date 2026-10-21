namespace UniversityManagement.Common;

public abstract class UniversityMember : IEntity
{
    // Властивості базового абстрактного класу
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }

    // Конструктор базового класу
    protected UniversityMember(string fullName, string email)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Email = email;
    }

    // Абстрактний метод, який реалізують похідні класи
    public abstract string GetDetails();

    public override string ToString() => $"{FullName} ({Email})";
}
