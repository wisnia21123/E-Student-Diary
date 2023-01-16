namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new SavedStudent("Adam", "Kowalski", 27);
            
            EnterGrade(student);

            var stats = student.GetStatistics();

            Console.WriteLine($"The Average is:{stats.Average:N2}");
            Console.WriteLine($"The MaxValue is: {stats.High:N2}");
            Console.WriteLine($"The MinValue is: {stats.Low:N2}");
            Console.WriteLine($"The Sum is:{stats.Sum:N2}");
            Console.WriteLine($"The Count is:{stats.Count:N2}");
        }
        private static void ChangeOfStudentName(InMemoryStudent newName)
        {
            Console.WriteLine($"Press N to change of student name.");
        }
        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Hello! Enter grade for student.Only grades from 1 to 6 are allowed! {student.Name} {student.Surname}");
                Console.WriteLine($"Press q for exit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                student.AddGrade(input!);
            }
        }
        static void OnGradeUnder3(object sender, EventArgs args)
        {
            Console.WriteLine($"Oh no! Student got grade under 3. We should inform students parents about this fact!");
        }
    }
}