class Program
{
    class chelovek// структура
    {
        protected string _name;
        protected double[] _1ekz = new double[4];
        protected double _AVG;
        public double AVG { get { return _AVG; } }// свойство
        public chelovek(string name, double[] ekz)
        {
            _name = name;
            _1ekz = ekz;

            _AVG = 0;
            double sum = 0;
            for (int i = 0; i < _1ekz.Length; i++)
            {
                sum += _1ekz[i];
                if ((sum) / 4 >= 4)
                {
                    _AVG = sum / 4;
                }
            }

        }
        public virtual void Print()
        {
            if (_AVG >= 4)
            {
                Console.WriteLine("{0,20},{1,20}", _name, _AVG);
            }
        }

    }
    class student : chelovek
    {
        protected static int _studentnumberall;
        protected int _studentnumber;

        public student(string name, double[] ekz) : base(name, ekz)
        {
            _studentnumberall++;
            _studentnumber = _studentnumberall;

        }
        public override void Print()
        {
            if (_AVG >= 4)
            {
                Console.WriteLine("{0,20},{1,20},{2,20}", _name, _AVG, _studentnumber);
            }
        }

    }
    static void Main()
    {
        chelovek[] results = new chelovek[5];
        results[0] = new chelovek("Sidorov", new double[] { 3, 4, 5, 2 });
        results[1] = new chelovek("Petrov", new double[] { 2, 3, 4, 4 });
        results[2] = new chelovek("Ivanov", new double[] { 5, 5, 4, 5 });
        results[3] = new chelovek("Kostin", new double[] { 4, 4, 3, 5 });
        results[4] = new chelovek("Smislov", new double[] { 4, 4, 4, 4 });
        sort(results);
        student[] end = new student[5];
        end[0] = new student("Sidorov", new double[] { 3, 4, 5, 2 });
        end[1] = new student("Petrov", new double[] { 2, 3, 4, 4 });
        end[2] = new student("Ivanov", new double[] { 5, 5, 4, 5 });
        end[3] = new student("Kostin", new double[] { 4, 4, 3, 5 });
        end[4] = new student("Smislov", new double[] { 4, 4, 4, 4 });


        Console.WriteLine("{0,20},{1,20},{2,20}", "Фамилия", "Средний бал", "Номер студентческого билета");
        for (int i = 0; i < results.Length; i++)

        { end[i].Print(); }
    }
    static void sort(chelovek[] results)
    {
        for (int i = 0; i < results.Length - 1; i++)
        {

            for (int j = i; j < results.Length; j++)
            {
                if (results[i].AVG < results[j].AVG)
                {
                    chelovek all = results[j];
                    results[j] = results[i];
                    results[i] = all;
                }
            }
        }

    }
}