using App;

namespace myapp.Test
{
    public class StudentTest
    {
        [Fact]
        public void GetStatisticsTest()
        {
            var emp1 = new SavedStudent("Adam", "Kowalski", 27);

            emp1.AddGrade(5);
            emp1.AddGrade(4.5);
            emp1.AddGrade(3);
            emp1.AddGrade(2.5);

            var result = emp1.GetStatistics();

            Assert.Equal(3.75, result.Average, 2);
            Assert.Equal(5, result.High, 2);
            Assert.Equal(2.5, result.Low, 2);
        }
    }
}