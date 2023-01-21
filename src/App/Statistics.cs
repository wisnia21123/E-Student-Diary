namespace App
{
    public class Statistics
    {
        public double High;
        public double Low;
        public double Sum;
        public int Count;
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public Statistics()
        {
            Sum = 0;
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void Add(double grades)
        {
            Sum += grades;
            Count += 1;
            Low = Math.Min(grades, Low);
            High = Math.Max(grades, High);
        }
    }
}