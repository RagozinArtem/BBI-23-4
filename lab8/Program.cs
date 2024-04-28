//№ 1, 3, 6, 12, 13, 15


using System;
using System.CodeDom.Compiler;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

abstract class Zadanie
{
    protected string _text;
    public Zadanie(string text)
    {
        _text = text;
    }


}
class Thefirst : Zadanie
{
    private string _newtext;

    private double[] _procent = new double[33];
    private double _countall;
    private double[] _count = new double[33];
    private char[] _pattern = new char[33] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
    public Thefirst(string text) : base(text)
    {

    }

    public override string ToString()
    {
        _newtext = _text.ToLower();
        for (int i = 0; i < _text.Length; i++)
        {
            if (Char.IsLetter(_text[i]))
            { _countall++; }
            for (int j = 0; j < 33; j++)
            {
                if (_newtext[i] == _pattern[j])
                { _count[j]++; };
            }
        }
        for (int i = 0; i < 33; i++)
        {
            _procent[i] = (_count[i] / _countall) * 100;
        }

        for (int i = 0; i < 33; i++)
        {
            Console.WriteLine(_pattern[i].ToString() + "= " + Math.Round(_procent[i], 2));

        }
        return base.ToString();
    }
}
class Thethird : Zadanie
{
    private int _max;
    private string[] _words;
    public Thethird(string text) : base(text)
    {
        _max = 50;
        _words = _text.Split(' ');

    }
    public override string ToString()
    {
        string current = "";
        foreach (string word in _words)
        {
            if ((current + word).Length > _max)
            {
                Console.WriteLine(current);
                current = "";
            }
            current += word + " ";
        }
        Console.WriteLine(current);
        return current;
    }
}
class task6 : Zadanie
{
    private int[] _symbols = new int[10];
    private int _symbolcount;
    private string[] _words;
    public task6(string text) : base(text)
    {
        _words = _text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _symbolcount = 0;
    }


    public override string ToString()
    {
        foreach (string word in _words)
        {
            _symbolcount = Countsymbols(word); // определяем количество слогов в слове           
            _symbols[_symbolcount]++; // увеличиваем счетчик слов с определенным количеством слогов

        }

        for (int i = 1; i < _symbols.Length; i++) // выводим результат
        {
            if (_symbols[i] > 0)
            {
                Console.WriteLine($"Количество слов с {i} слогами: {_symbols[i]}");
            }
        }





        return base.ToString();
    }

    private static int Countsymbols(string word)
    {
        int count = 0;
        bool glasnie = false;

        char[] glasnie_ = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };

        foreach (char letter in word)
        {
            if (Array.IndexOf(glasnie_, char.ToLower(letter)) >= 0)
            {
                if (!glasnie)
                {
                    glasnie = true;
                    count++;
                }
            }
            else
            {
                glasnie = false;
            }
        }

        return count;
    }
}
class task13 : Zadanie
{
    private string _newtext;
    private string[] _newtext1;
    private char[] _engl = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    private double[] _meet = new double[26];

    public task13(string text) : base(text)
    {
        _newtext = _text.ToLower();
        _newtext1 = _newtext.Split(' ');

    }
    public override string ToString()
    {

        foreach (string word in _newtext1)
        {

            for (int j = 0; j < _engl.Length; j++)
            {
                if (word[0] == _engl[j])
                {
                    _meet[j]++;
                }
            }
        }
        for (int j = 0; j < _meet.Length; j++)
        {
            _meet[j] = (_meet[j] / _newtext1.Length) * 100;
        }
        for (int i = 0; i < 26; i++)

        {
            Console.WriteLine(_engl[i].ToString() + " = " + Math.Round(_meet[i], 2));

        }

        return base.ToString();
    }

}
class task15 : Zadanie
{

    private string[] _words;
    private int _sum;

    public task15(string text) : base(text)
    {
        _sum = 0;
        _words = _text.Split(' ');
    }

    public override string ToString()
    {

        foreach (string word in _words)
        {
            // Преобразовать найденное число в int и добавить к сумме
            if (int.TryParse(word, out int number))
            {
                _sum += number;
            }
        }
        Console.WriteLine(_sum);
        return base.ToString();
    }
}
class Task_12 : Zadanie
{
    private List<string> _wordsAndPunctuation = new List<string>();
    private List<int> _wordCodes = new List<int>();


    public Task_12(string text) : base(text) { }

    public void ParseText(string text)
    {
        string[] wordsAndPunctuationArray = Regex.Split(text, @"(\b\S+\b|[^\w\s])");
        int code = 1;

        foreach (string item in wordsAndPunctuationArray)
        {
            if (Regex.IsMatch(item, @"\b\S+\b"))
            {
                _wordsAndPunctuation.Add(item);
                _wordCodes.Add(code);
                code++;
            }
            else
            {
                _wordsAndPunctuation.Add(item);
            }
        }
    }

    public override string ToString()
    {
        string result = "Decoded Text:\n";
        foreach (string symb in _wordsAndPunctuation)
        {
            if (symb.StartsWith("#"))
            {
                int code = int.Parse(symb.Substring(1));
                string word = GetDecodedWord(code);
                result += word + " ";
            }
            else
            {
                result += symb;
            }
        }
        Console.WriteLine(result);
        return result;
    }

    private string GetDecodedWord(int code)
    {
        int index = code - 1;
        if (index >= 0 && index < _wordsAndPunctuation.Count)
        {
            return _wordsAndPunctuation[index];
        }
        return "";
    }
}





class Program
{
    public static void Main()
    {
        Thefirst first = new Thefirst("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ");
        Thethird third = new Thethird("Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
        task6 sixth = new task6("1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.");
        task13 thirtinth = new task13("William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.");
        Task_12 task12 = new Task_12("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ");
        task15 fifteen = new task15("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.");

        sixth.ToString();
        first.ToString();
        third.ToString();
        thirtinth.ToString();
        fifteen.ToString();
        task12.ParseText("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ");
        task12.ToString();
    }
}



