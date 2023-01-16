using System;
using App;
using Xunit;


namespace myapp.Test
{
    public class TypeTest
    {
        [Fact]
        public void GetStudentReturnsDiffrentObject()
        {
            var emp1 = GetStudent("Adam", "Kowalski", 27);
            var emp2 = GetStudent("Paweł", "Wiśniewski", 29);
            var emp3 = GetStudent("Wiktoria", "Nowak", 36);
            var emp4 = emp2;

            Assert.Equal("Adam", emp1.Name);
            Assert.Equal("Paweł", emp2.Name);
            Assert.Equal("Wiktoria", emp3.Name);
            Assert.Same(emp2,emp4);
            Assert.NotSame(emp1,emp3);
            Assert.True(Object.ReferenceEquals (emp2,emp4));
            Assert.False(Object.ReferenceEquals (emp1,emp3));
            Assert.True(SavedStudent.Equals(emp2,emp4));
            Assert.False(SavedStudent.Equals(emp2,emp3));
        }
        private SavedStudent GetStudent(string name, string surname, int age)
        {
            return new SavedStudent(name, surname, age);
        }
    }
}