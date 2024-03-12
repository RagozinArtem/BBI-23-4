﻿//4.Результаты соревнований по прыжкам в высоту определяются по лучшей из двух
//попыток. Вывести список участников в порядке занятых мест
// 4 zadanie(1) 
struct sorevnovania// создаём структуру 
{
    private string _Surname; // поля структуры
    private int _besttry;
    private int _firsttry;
    private int _secondtry;
    public int Besttry { get { return _besttry; } } // свойство
    public sorevnovania(int firsttry, int secondtry, string surname)// конструктор
    {
        _firsttry = firsttry;
        _secondtry = secondtry;
        _besttry = 0;
        _Surname = surname;

        if (firsttry > secondtry)
        {
            _besttry = firsttry;

        }
        else if (secondtry >= firsttry) { _besttry = secondtry; }
    }


    public void Print() => Console.WriteLine($"{_besttry}, {_Surname}"); // метод вывода


}

class Program
{

    static void Main()// мэйн

    {
        sorevnovania[] everything = new sorevnovania[5];// присваиваем тип sorevnovania для переменной everything 
        everything[0] = new sorevnovania(155, 176, "Ivanov");
        everything[1] = new sorevnovania(180, 187, "Petrov");
        everything[2] = new sorevnovania(181, 191, "Sidorov");
        everything[3] = new sorevnovania(165, 186, "Ivanov");
        everything[4] = new sorevnovania(175, 171, "Ivanov");
        sort(everything);
        for (int i = 0; i < everything.Length; i++)
        {
            everything[i].Print();
        }
    }
    static void sort(sorevnovania[] everything)
    {
        int d = everything.Length / 2;
        while (d >= 1)
        {
            for (int i = d; i < everything.Length; i ++)
            {
                sorevnovania l = everything[i];
                int k = everything[i].Besttry;
                int j = i - d;

                while (j >= 0 && everything[j].Besttry < k)
                {
                    everything[j + d] = everything[j];
                    j -= d;
                }

                everything[j + d] = l;
            }

            d = d / 2;
        }
    }

}

