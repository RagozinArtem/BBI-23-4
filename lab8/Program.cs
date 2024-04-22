
//№ 1, 3, 6, 12, 13, 15


using System;
using System.CodeDom.Compiler;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.RegularExpressions;
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
    private string _procentstr;
    private double _procent;
    private double _countall;
    private double _count;
    public Thefirst(string text) : base(text)
    {

    }

    public override string ToString()
    {
        for (int i = 0; i < _text.Length; i++)
        {
            if (Char.IsLetter(_text[i]))
            { _countall++; }
            if (_text[i] == 'а')
            { _count++; };
        }
        _procent = _count / _countall;
        _procentstr = _procent.ToString("f4");
        Console.WriteLine(_procentstr);
        return _procentstr;
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
    private string _words;
    private string _pattern;

    public task6(string text) : base(text)
    {
        _words = "";
        _pattern = @"(?<=[аеиоуюяэыё])";
    }
    public override string ToString()
    {

        for (int i = 0; i < _text.Length; i++)
        {
            _words = _words + _text[i];
        }
        string[] syllables = Regex.Split(_words, _pattern);
        int oneSyllable = 0;
        int twoSyllables = 0;
        int threeSyllables = 0;
        int moreSyllables = 0;
        foreach (string word in syllables)
        {
            int syllableCount = CountSyllables(word);
            if (syllableCount == 1)
                oneSyllable++;
            else if (syllableCount == 2)
                twoSyllables++;
            else if (syllableCount == 3)
                threeSyllables++;
            else
                moreSyllables++;
        }
        static int CountSyllables(string word)
        {
            word = word.ToLower();
            word = Regex.Replace(word, @"[^аеёиоуыэюя]", "");
            return word.Length;
        }
        Console.WriteLine("Количество слов с одним слогом: " + oneSyllable);
        Console.WriteLine("Количество слов с двумя слогами: " + twoSyllables);
        Console.WriteLine("Количество слов с тремя слогами: " + threeSyllables);
        Console.WriteLine("Количество слов с более чем тремя слогами: " + moreSyllables);
        return oneSyllable.ToString("f3");



    }
}
class Task12 : Zadanie
{

    public Task12(string text) : base(text)
    {

    }
    public override string ToString()
    {
        Dictionary<string, string> wordCodes = new Dictionary<string, string>();
        string[] lines = _text.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            if (line.Contains(":"))
            {
                string[] parts = line.Split(":");
                wordCodes[parts[1].Trim()] = parts[0].Trim();
            }
            else
            {
                _text += line + " ";
            }
        }
        wordCodes["William"] = "#$@^";
        wordCodes["one"] = "*@!&";
        wordCodes["total"] = "!@#$%";
        wordCodes["along"] = "%^&*(";
        wordCodes["poems"] = "&*()!";
        foreach (var code in wordCodes)
        {
            _text = _text.Replace(code.Key, code.Value);
        }
        Console.WriteLine(_text);
        return _text.Trim();
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
            Console.WriteLine(_meet[i]);

        }

        return base.ToString();
    }

}
class task15 : Zadanie
{
    private string _chisla;
    private double _count;

    public task15(string text) : base(text)
    {
        _count = 0;
        _chisla = "";

    }

    public override string ToString()
    {
        for (int i = 0; i < _text.Length; i++)

        {
            if (Char.IsDigit(_text[i]))
            {
                _chisla = _text[i].ToString();
                _count += double.Parse(_chisla);

            }

        }
        Console.WriteLine(_count);
        return base.ToString();
    }
}


class Program
{
    static void Main()
    {
        Thefirst first = new Thefirst("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ");
        Thethird third = new Thethird("Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
        task6 sixth = new task6("1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.");
        Task12 twelve = new Task12("Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.");
        task13 thirtinth = new task13("William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.");

        sixth.ToString();
        first.ToString();
        third.ToString();
        thirtinth.ToString();
        task15 fifteen = new task15("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.");
        fifteen.ToString();
        twelve.ToString();
    }

}

