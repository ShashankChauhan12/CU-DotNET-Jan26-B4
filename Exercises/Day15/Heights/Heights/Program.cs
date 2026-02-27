namespace Heights
{
    class Height
    {
        private int feet;

        public int Feet
        {
            get { return feet; }
            set { feet = value; }
        }

        private decimal inches;

        public decimal Inches
        {
            get { return inches; }
            set { inches = value; }
        }

        public Height()
        {
            feet = 0;
            inches = 0;
        }
        public Height(int f,decimal i)
        {
            feet = f;
            inches = i;
        }
        public Height(decimal inch)
        {
            feet = (int)(inch / 12);
            inches = inch % 12;
        }

        public Height AddHeights(Height h2)
        {
            int totalFeet = this.Feet + h2.Feet;
            decimal totalInches = this.Inches + h2.Inches;

            if (totalInches >= 12)
            {
                int extraFeet = (int)(totalInches / 12);
                totalFeet += extraFeet;
                totalInches = totalInches % 12;
            }
            return new Height(totalFeet, totalInches);
        }

        public override string ToString()
        {
            return $"Height- {feet} feet {inches} inches";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Height person1 = new Height(4, 5.8m);
            Height person2 = new Height(6,9.8m);
            Height person3 = new Height(75m);

            Console.WriteLine(person3);

            Height totalHeight = person1.AddHeights(person2);

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(totalHeight);
        }
    }
}
