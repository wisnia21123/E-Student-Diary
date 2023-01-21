namespace App
{
    public delegate void GradeUnder3Delegate(object sender, EventArgs args);

    public class SavedStudent : StudentBase
    {
        public SavedStudent(string name, string surname, int age) : base(name, surname, age)
        {
        }

        public override event GradeUnder3Delegate GradeUnder3;

        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 6)
            {
                WriteAddgradeInFileWithEvent(grade);
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
                    WriteAddgradeInFile(gradePlus);
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
                    WriteAddgradeInFile(gradeDouble);
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
            using (var reader = File.OpenText($"{Name} {Surname} {Age} Grade.txt"))
            {
                var line = reader.ReadLine();
                while (!string.IsNullOrWhiteSpace(line))
                {
                    double grades = 0;
                    var isParsed = double.TryParse(line, out grades);
                    result.Add(grades);
                    line = reader.ReadLine();
                }
            }
            return result;
        }

        private void WriteAddgradeInFileWithEvent(double grade)
        {
            WriteAddgradeInFile(grade);
            if (GradeUnder3 is not null)
            {
                GradeUnder3(this, new EventArgs());
            }
        }

        private void WriteAddgradeInFile(double grade)
        {
            using (var writer = File.AppendText($"{Name} {Surname} {Age} Grade.txt"))
            {
                writer.WriteLine(grade);
            }
            using (var writer = File.AppendText($"{Name} {Surname} {Age} Audit.txt"))
            {
                writer.WriteLine($"{DateTime.UtcNow} {grade}");
            }
        }
    }
}