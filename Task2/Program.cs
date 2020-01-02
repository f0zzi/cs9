using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Task2(string filename = "../../test.txt")
        {
            string text = File.ReadAllText(filename);
            text = Regex.Replace(text, @"(interface[\s]+)([^I\d]{1}[\w]*)", x => x.Groups[1].Value + "I" + x.Groups[2].Value);
            text = Regex.Replace(text, @"(class[\s]+)(\b[\D]{1}[\w]+[\s]?)([\s]*:[\s]*)(\b[^I\d]{1}[\w]*)", x => x.Groups[1].Value + x.Groups[2].Value + x.Groups[3].Value + "I" + x.Groups[4].Value);
            File.WriteAllText(filename, text);
        }
        static void Main(string[] args)
        {
            Task2();
        }
    }
}
