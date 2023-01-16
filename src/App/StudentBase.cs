namespace App
{
    public abstract class StudentBase : StudentObject, IStudent
    {
        public StudentBase(string name, string surname, int age) : base(name, surname, age)
        {
        }
        public abstract event GradeUnder3Delegate GradeUnder3;
        public abstract void ChangeOfStudentName(string newName);
        public abstract void AddGrade(double grade);
        public abstract void AddGrade(string grade);
        public abstract Statistics GetStatistics();
    }
}