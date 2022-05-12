namespace Hw_7
{
    struct Base
    {
        private Worker[] Workers;

        private string path;

        int index;

        public Base(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.Workers = new Worker[2];
        }

        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.Workers, this.Workers.Length *2);
            }
        }

        public void AddWorker(Worker worker)
        {
            this.Resize(index >= this.Workers.Length);
            this.Workers[index] = worker;
            this.index++;
        }

        public void Load()
        {
            using (StreamReader stream = new StreamReader(this.path))
            {
               while (!stream.EndOfStream)
                {
                    string[] args = stream.ReadLine().Split('#');

                    AddWorker(new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToDateTime(args[5]), args[6]));
                }
            }
        }

        public void WriteData()
        {
            using (StreamWriter add = new StreamWriter($@"{this.path}", true))
            {
                for (int i = 0; i < this.Workers.Length; i++)
                {
                    string worker = this.Workers[i].CreateWorker();
                    add.WriteLine(worker.Replace("; ", "#"));
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < this.Workers.Length; i++)
            {
                string worker = this.Workers[i].CreateWorker();
                Console.WriteLine(worker.Replace("#", "; "));
            }
        }

        public void Sort()
        {
            var sortedWorkers = from worker in this.Workers
                                orderby worker.Birth
                                select worker;

            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine($"{worker.Name} {worker.Birth}");
            }


        }
    }
}
