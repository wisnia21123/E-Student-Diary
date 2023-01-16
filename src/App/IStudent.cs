namespace App
{
    public interface IStudent
    {
        void AddGrade(double grade);
        void AddGrade(string grade);
        Statistics GetStatistics();
        string Name { get; }
        string Surname { get; }
        int Age { get;}
        event GradeUnder3Delegate GradeUnder3;
    }
}