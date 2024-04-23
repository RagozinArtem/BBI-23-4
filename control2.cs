using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace Test2
{
    abstract class Task
    {
        protected string _text;
        public Task(string text)
        {
            _text = text;
        }
    }
    class Task1:Task
    {
        
        private string[] _words;
        private int _count;
        private int _uniqcount;
   
        

        //[JsonConstructor]
        public Task1(string text):base(text)
        {
            
                _words=_text.Split(' ');

        }
        public override string ToString()
        {   
            
            _count = 0;
            
            for (int i = 0; i < _words.Length; i++)
            {
                for (int j = 0; j < _words.Length; j++)
                {
                    if (_words[i] == _words[j] && j != i)
                    {

                        _count++;                       
                    }
                }
            }
         
            _uniqcount = _words.Length - _count;
            Console.WriteLine(_uniqcount);
            Console.ReadLine();
            return base.ToString();
        }
    }
    class Task2 : Task
    {
        private char[] _newtext;
        private char[] _pattern = new char[33] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
        private int[] _chisla = new int[33];
        private string _newtext1;
        //[JsonConstructor]
        public Task2(string text) : base(text)
        {
            _text=_text.ToUpper();
            _newtext = _text.ToCharArray();
            for (int i = 0; i < _text.Length; i++)
            {
                _newtext1 = _text[i].ToString();
            }
        }
        public override string ToString()
        {
            for (int i = 0; i < _text.Length; i++)
            {
                for (int j = 0; j < _pattern.Length; j++)
                    if (_newtext[i] == _pattern[j])
                {
                        _chisla[j]++;
                }
            }
            double max = 0;
            int imax = 0;
            for (int i = 0; i<33; i++ )                
            {
                if (_chisla[i] >= max)
                { max = _chisla[i];
                    imax = i;
                }              
            }
            Console.WriteLine();
           for (int i = 0;i<_newtext1.Length;i++)
            {
                if (_newtext[i] == _pattern[i])
                {
                    
                }
            }
            return base.ToString();

        }
    }
    class Task3: Task
    {
        public Task3(string text) : base(text)
        {

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1 task1 = new Task1("Привет это Артём, сейчас я расскажу как решить контрольную в c#, Привет");
            Task2 task2 = new Task2("Привет это Артём, сейчас я расскажу как решить контрольную в c#, привет");
            task1.ToString();
            task2.ToString();
        
        }
    }
    }

