class Group
{
    protected int _math;
    protected int _physika;
    protected int _science;
    protected string _name;
    protected double _avg;
    public Group(string name, int math, int physika, int science)
    {
        _name = name;
        _math = math;
        _physika = physika;
        _science = science;
        Avg();
    }
    public virtual void Avg()
    {
        _avg = (_math + _physika + _science) / 3;
    }
    public virtual void Print()
    {
        Console.WriteLine("{0,10}, {1,10}", _name, _avg);
    }
}
class Group1 : Group
{
    protected int _inf;
    protected int _OBJ;

    public Group1(string name, int math, int physika, int science, int inf, int OBJ) : base(name, math, physika, science)
    {
        _OBJ = OBJ;
        _inf = inf;
        Avg();
    }

    public override void Avg()
    {
        double sum = (_math + _physika + _science + _OBJ + _inf);
        _avg = sum / 5;


    }
    public override void Print()
    {
        Console.WriteLine("{0,10}, {1,10}", _name, _avg);
    }
}
class Group2 : Group
{
    protected int _RUS;
    protected int _ENG;
    public Group2(string name, int math, int physika, int science, int rus, int ENG) : base(name, math, physika, science)
    {
        _RUS = rus;
        _ENG = ENG;
        Avg();
    }
    public override void Avg()
    {
        _avg = (_math + _physika + _science + _RUS + _ENG) / 5;

    }
    public override void Print()
    {
        Console.WriteLine("{0,10}, {1,10}", _name, _avg);
    }
}
class Group3 : Group
{
    protected int _Italian;
    protected int _PHISRA;
    public Group3(string name, int math, int physika, int science, int italian, int phisra) : base(name, math, physika, science)
    {
        _Italian = italian;
        _PHISRA = phisra;
        Avg();
    }
    public override void Avg()
    {
        _avg = (_math + _physika + _science + _Italian + _PHISRA) / 5;

    }
    public override void Print()
    {
        Console.WriteLine("{0,10}, {1,10}", _name, _avg);
    }
}
class Program
{
    static void Main()
    {
        Group1[] results1 = new Group1[5];
        results1[0] = new Group1("Sidorov", 3, 4, 2, 5, 2);
        results1[1] = new Group1("Ivanov", 4, 3, 3, 3, 4);
        results1[2] = new Group1("Fudun", 3, 5, 3, 5, 4);
        results1[3] = new Group1("Kozlov", 3, 3, 3, 3, 5);
        results1[4] = new Group1("Clinton", 4, 2, 4, 3, 4);
        Group[] results2 = new Group2[5];
        results2[0] = new Group2("Trump", 3, 4, 2, 5, 2);
        results2[1] = new Group2("Oblyakov", 4, 3, 3, 3, 4);
        results2[2] = new Group2("Serzjov", 3, 5, 3, 5, 4);
        results2[3] = new Group2("Lubov", 3, 3, 3, 3, 5);
        results2[4] = new Group2("Krapivin", 4, 2, 4, 3, 4);
        Group[] results3 = new Group3[5];
        results3[0] = new Group3("Joe", 3, 4, 2, 5, 2);
        results3[1] = new Group3("Kotov", 4, 3, 3, 3, 4);
        results3[2] = new Group3("Molokov", 3, 5, 3, 5, 4);
        results3[3] = new Group3("Nepomnishii", 3, 3, 3, 3, 5);
        results3[4] = new Group3("Testov", 4, 2, 4, 3, 4);
        Console.Write("{0,10}, {1,10}", "Фамилия", "Средний бал");
        Console.WriteLine();
        for (int i = 0; i < results1.Length; i++)
        {
            results1[i].Print();
            results2[i].Print();
            results3[i].Print();
        }
    }
}
