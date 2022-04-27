namespace Hw_7
{
    struct Worker
    {
        public int Id;
        public DateTime Date;
        public string Name;
        public int Age;
        public int Height;
        public DateOnly Birth;
        public string Place;

        public Worker(int Id, DateTime Date, string Name, int Age, int Height, DateOnly Birth, string Place)
        {
            this.Id = Id;
            this.Date = Date;
            this.Name = Name;
            this.Age = Age;
            this.Height = Height;
            this.Birth = Birth;
            this.Place = Place;
        }

        public Worker(int Id, string Name, int Age, int Height, DateOnly Birth, string Place) :
            this(Id, DateTime.Now, Name, Age, Height, new DateOnly(), Place)
        {

        }

        public void ShowInfo(int Id)
        {
            Console.WriteLine($"{Id}, {Date}, {Name}, {Age}, {Height}, {Birth}, {Place}");
        }
    }
}
