using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace n1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Task1-#1";
            Point tx = new Point();
            if ((args.Length > 0) && (args[0] == "--file"))
            {
                tx.FromFile(args[1]);
            }
            else
            {
                Console.Write("Введите координаты X, Y в формате {0.00},{0.00} = ");
                tx.text = Console.ReadLine();
            }

                if (tx.success)
 
                    Console.WriteLine("\nX:{0}; Y:{1}", tx.x, tx.y);
                else
                    Console.WriteLine(tx.error);
            Console.WriteLine("\nНажмите любую клавишу для закрытия...");
            Console.ReadKey();
        }
    }

    class Point
    {
        private string ptrn = @"(\w+\.\w+)\,(\w+\.\w+)";
        private string _text;
        public string x,y;
        public bool success;
        public string error = null;
        public void FromFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader fs = new StreamReader(path);
                this.text = fs.ReadLine();
            }
            else
            {
                this.error = "Ошибка!\nФайл не найден.";
            }
        }
        private void encodeIt()
        {
            Regex regexp = new Regex(this.ptrn);
            Match _matched = regexp.Match(this._text);
            if (_matched.Success)
            {
                this.x = _matched.Groups[1].Value;
                this.y = _matched.Groups[2].Value;
                this.success = true;
            }
            else
            {
                this.success = false;
                this.error = "Ошибка!\nДанные введены не верно.";
            }
        }
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
                this.encodeIt();
            }
        }

    }
}
