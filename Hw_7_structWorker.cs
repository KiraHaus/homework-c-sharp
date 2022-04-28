namespace Hw_7
{
    public struct Worker
    {
        /// <summary>
        /// ID работника
        /// </summary>
        private int id;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Дата внесения в базу
        /// </summary>
        private DateTime date;

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = DateTime.UtcNow; }
        }
        
        /// <summary>
        /// ФИО работника
        /// </summary>
        private string name;
        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        private int age;

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        /// <summary>
        /// Рост
        /// </summary>
        private int height;

        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        
        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateOnly birth;

        public DateOnly Birth
        {
            get { return this.birth; }
            set { this.birth = value; }
        }
        
        /// <summary>
        /// Место рождения
        /// </summary>
        private string place;

        public string Place
        {
            get { return this.place; }
            set { this.place = value; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Date"></param>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="Birth"></param>
        /// <param name="Place"></param>
        public Worker(int Id, DateTime Date, string Name, int Age, int Height, DateOnly Birth, string Place)
        {
            this.id = Id;
            this.date = Date;
            this.name = Name;
            this.age = Age;
            this.height = Height;
            this.birth = Birth;
            this.place = Place;
        }

        public Worker(int Id, string Name, int Age, int Height, DateOnly Birth, string Place):
            this(Id, DateTime.UtcNow, Name, Age, Height, Birth, Place)
        {

        }

        /// <summary>
        /// Вывод инфы
        /// </summary>
        public string ShowInfo()
        {
            return $"{Id}, {Date}, {Name}, {Age}, {Height}, {Birth}, {Place}";
        }
    }
}
