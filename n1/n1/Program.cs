using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace n1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Task1-#1";
            string _text = "";
            if (args.Length > 0)
            {
                if (File.Exists(args[1]))
                {
                    StreamReader fs = new StreamReader(@args[1]);
                    _text = ((fs.ReadLine()) != null)?fs.ReadLine():"0,0";
                }
                else
                {
                    Console.WriteLine("Файл не найден...");
                    
                }

            }
                else 
                {
                     Console.Write("Введите координаты X, Y = ");
                     _text = Console.ReadLine();
                }
            int ln = _text.Split(',').Length;
            string[] _pts =(ln>2||ln==0)?new string[2]{"0","0"}:_text.Split(',');
            Console.WriteLine("X:{0}; Y:{1};",_pts[0],_pts[1]);
            Console.WriteLine("\nНажмите любую клавишу для закрытия...");
            Console.ReadKey();
        }
    }

  
}
