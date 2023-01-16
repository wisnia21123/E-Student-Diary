using System.Text;

namespace App
{
    public class InMemoryStudent : StudentBase
    {
        private List<double> grades;
        public InMemoryStudent(string name, string surname, int age) : base(name, surname, age)
        {
            grades = new List<double>();
        }
        public override event GradeUnder3Delegate GradeUnder3;
        public override void ChangeOfStudentName(string newName)
        {
            bool checkName = false;
            foreach (var l in newName)
            {
                if (char.IsDigit(l))
                {
                    checkName = true;
                }
            }
            if (checkName)
            {
                Console.WriteLine("Wrong new name");
            }
            else
            {
                Name = newName;
            }
        }
        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 6)
            {
                this.grades.Add(grade);
                Console.WriteLine($"{grade} was added!");
                if (grade < 3)
                {
                    GradeUnder3(this, new EventArgs());
                }
            }
            else
            {
                Console.WriteLine("Grade is out of range.");
            }
        }
        public override void AddGrade(string grade)
        {

            if (grade.Length == 2 && char.IsDigit(grade[0]) && grade[0] <= '6' && (grade[1] == '+'))
            {
                double convertedGradeToDouble = char.GetNumericValue(grade[0]);
                double gradePlus = convertedGradeToDouble + 0.50;
                if (gradePlus > 1 && gradePlus <= 6)
                {
                    this.grades.Add(gradePlus);
                    Console.WriteLine($"{gradePlus} was added!");
                    if (gradePlus < 3)
                    {
                        GradeUnder3(this, new EventArgs());
                    }
                }
                else
                {
                    Console.WriteLine("Grade is out of range.");
                }
            }

            else
            {
                double gradeDouble = 0;
                var isParsed = double.TryParse(grade, out gradeDouble);
                if (isParsed && gradeDouble > 0 && gradeDouble <= 6)
                {
                    this.grades.Add(gradeDouble);
                    Console.WriteLine($"{gradeDouble} was added!");

                    if (GradeUnder3 is not null && gradeDouble < 3)
                    {
                        GradeUnder3(this, new EventArgs());
                    }
                }

                else
                {
                    Console.WriteLine("Grade is out of range.");
                }

            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }
            return result;
        }
    }
}