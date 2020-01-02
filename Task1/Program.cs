using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Task1
{
    //Завдання 1.
    //Дано текстовий файл.
    //o Виправити всі речення у файлі, замінюючи першу літеру речення на велику.
    //o Видалити зайві пропуски між словами, залишаючи по одному.
    class Program
    {
        static void Task1(string filename = "../../test.txt")
        {
            string text = File.ReadAllText(filename);
            string result = "";

            text = Regex.Replace(text, @"\s{2,}", " ");
            
            MatchCollection matchCollection = Regex.Matches(text, "[\\w\\s\'\";:,]+[?!.]*\\s*");
            if (matchCollection.Count > 0)
            {
                foreach (Match el in matchCollection)
                    result += Regex.Replace(el.Value, @"^.", x => x.ToString().ToUpper());
                    
                File.WriteAllText(filename, result);
            }
        }
        static void Main(string[] args)
        {
            Task1();
        }
    }
}
