/*
    Developer:  Oluropo Akinbolade-JOnes
    Company:    Telesoftas
    Role:       Senior Fullstack Developer
    Date:       April, 2022
*/

using System.Text;
using System.Text.RegularExpressions;

namespace TextWrapper
{
    public class Wrapper
    {
        public static bool CreateTextFile(string input)
        {
            // File name  
            string name = "input.txt";
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string filePath = path + @"\" + name;
            FileStream stream = null;
            try
            {
                // Create a FileStream with mode CreateNew  
                stream = new FileStream(filePath, FileMode.OpenOrCreate);
                // Create a StreamWriter from FileStream  
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    string[] text = input.Split("\\n");
                    foreach (string txt in text)
                    {
                        writer.WriteLine(txt);
                    }
                }
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
            return false;
        }


        public static List<string> WrapTextFile(int maxLineLength)
        {
            // File name  
            string text = string.Empty;
            string inputFileName = "input.txt";
            string outputFileName = "output.txt";
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string inputFilePath = path + @"\" + inputFileName;
            string outputFilePath = path + @"\" + outputFileName;

            //Read input file generated
            using (StreamReader sr = File.OpenText(inputFilePath))
            {
                string s;
                StringBuilder str = new StringBuilder();

                while ((s = sr.ReadLine()) != null)
                {
                    str.AppendLine(s);
                }
                text = str.ToString();
            }

            FileStream stream = null;
            var list = new List<string>();
            int currentIndex;
            var lastWrap = 0;
            var whitespace = new[] { ' ', '\r', '\n', '\t' };
            do
            {
                currentIndex = lastWrap + maxLineLength > text.Length ? text.Length : (text.LastIndexOfAny(new[] { ' ', ',', '.', '?', '!', ':', ';', '-', '\n', '\r', '\t' }, Math.Min(text.Length - 1, lastWrap + maxLineLength)) + 1);
                if (currentIndex <= lastWrap)
                    currentIndex = Math.Min(lastWrap + maxLineLength, text.Length);
                list.Add(text.Substring(lastWrap, currentIndex - lastWrap).Trim(whitespace));
                lastWrap = currentIndex;
            } while (currentIndex < text.Length);

            try
            {
                // Create a FileStream with mode CreateNew  
                stream = new FileStream(outputFilePath, FileMode.OpenOrCreate);
                // Create a StreamWriter from FileStream  
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    foreach (string txt in list)
                    {
                        writer.WriteLine(txt);
                    }
                }
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }

            return list;
        }


    }

}