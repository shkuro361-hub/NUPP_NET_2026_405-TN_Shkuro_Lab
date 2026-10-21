using UniversityManagement.Common;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== UniversityManagement: демонстрація лабораторної роботи №1 ===");

// Підписка на делегат/подію
Student.StudentCreated += student => Console.WriteLine($"[Подія] Створено студента: {student.FullName}");

var students = new CrudService<Student>();
var student1 = new Student("Олена Коваль", "olena.koval@example.com", 40501, "Комп'ютерні науки", 91.5);
var student2 = new Student("Андрій Мельник", "andrii.melnyk@example.com", 40502, "Інженерія ПЗ", 74.0);
var student3 = new Student("Марія Бондар", "maria.bondar@example.com", 40503, "Комп'ютерні науки", 54.0);

// CREATE
students.Create(student1);
students.Create(student2);
students.Create(student3);
Console.WriteLine("\n[CREATE] Додано трьох студентів.");

// READ
var found = students.Read(student1.Id);
Console.WriteLine($"\n[READ] Пошук за ID: {found?.GetDetails() ?? "не знайдено"}");

// READ ALL
Console.WriteLine("\n[READ ALL] Усі студенти:");
foreach (var student in students.ReadAll())
    Console.WriteLine($" - {student.GetDetails()}");

// UPDATE
student2.AverageGrade = 82.5;
students.Update(student2);
Console.WriteLine($"\n[UPDATE] Оновлений бал Андрія: {students.Read(student2.Id)?.GetDetails()}");

// Метод розширення
Console.WriteLine($"\n[EXTENSION] Студентів із прохідним балом: {students.ReadAll().CountPassingStudents()}");

// Інші класи моделі
var teacher = new Teacher("Ігор Петренко", "ihor.petrenko@example.com", "Комп'ютерні науки", "Доцент", 12);
var course = new Course("Об'єктно-орієнтоване програмування", "CS-201", 5, teacher.FullName);
var enrollment = new Enrollment(student1.Id, course.Id);
Console.WriteLine($"\n[МОДЕЛЬ] {teacher.GetDetails()}");
Console.WriteLine($"[МОДЕЛЬ] Курс: {course}");
Console.WriteLine($"[МОДЕЛЬ] {enrollment}");
Console.WriteLine($"[STATIC] Створено екземплярів Student: {Student.CreatedCount}");
Console.WriteLine($"[STATIC] 75 балів — прохідний результат? {Student.IsPassingGrade(75)}");

// SAVE + LOAD (додаткове завдання)
string dataPath = Path.Combine(AppContext.BaseDirectory, "students.json");
students.Save(dataPath);
Console.WriteLine($"\n[SAVE] Дані збережено у файл: {dataPath}");

var loadedStudents = new CrudService<Student>();
loadedStudents.Load(dataPath);
Console.WriteLine($"[LOAD] Завантажено студентів: {loadedStudents.ReadAll().Count()}");

// REMOVE
students.Remove(student3);
Console.WriteLine($"\n[REMOVE] Після видалення студентів залишилося: {students.ReadAll().Count()}");

Console.WriteLine("\n=== Демонстрацію завершено ===");
