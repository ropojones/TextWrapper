/*
    Developer:  Oluropo Akinbolade-JOnes
    Company:    Telesoftas
    Role:       Senior Fullstack Developer
    Date:       April, 2022

*/

using System.Text;

namespace TextWrapper
{
    public class Program
    {

        public static void Main(string[] args)
        {
            string? option = string.Empty;
            string? choice = string.Empty;


            //Lets do something interesting here by making things dynamic. 
            //Allow users to create the input as opposed to have an already made static file

            do
            {
                Console.Clear();
                Console.WriteLine("TextWrapper by Jones (Telesoftas)");
                Console.WriteLine("=================================");
                Console.WriteLine("");

                //Prompt users to select an option, the task they wish to carry out
                Console.Beep();
                Console.WriteLine("Select an option [A, B, C]: ");
                Console.WriteLine("");
                Console.WriteLine("A. Dynamically create input file ");
                Console.WriteLine("B. Read input file, wrap text and generate output file");
                Console.WriteLine("C. Exit TextWrapper App");
                Console.WriteLine("");

                Console.Beep();
                Console.Write("Option: ");
                choice = Console.ReadLine();
                Console.WriteLine("");

                switch (choice.ToLower())
                {
                    case "a":
                        //Generate input file with text to wrap
                        Console.WriteLine("Creating input file. Include \\n to add a newline into your input file.");
                        Console.WriteLine("");

                        Console.Write("Enter content of files: ");
                        var content = Console.ReadLine();

                        //Create input text file using the Wrapper Class CreateTextFile method
                        bool result = Wrapper.CreateTextFile(content);
                        if (result)
                        {
                            Console.WriteLine("Dynamic file successfully created!");
                        }
                        else
                        {
                            Console.WriteLine("There was an error creating dynamic file!");
                        }

                        Console.WriteLine("");
                        Console.Write("Do you want to continue using TextWrapper (Yes [Y] or No [N]): ");
                        option = Console.ReadLine();

                        break;

                    case "b":

                        //Wrap text and write output to file
                        Console.WriteLine("Wrapping input file. An output.txt file will be generated with wrapped text");
                        Console.WriteLine("");
                        
                        //Dynamically get the maximum number of characters in one line.
                        Console.Write("Enter the maximum length of each line: ");
                        int maxLength = int.Parse(Console.ReadLine());

                        string text = string.Empty;
                        string inputFileName = "input.txt";
                        string outputFileName = "output.txt";
                        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        string inputFilePath = path + @"\" + inputFileName;
                        string outputFilePath = path + @"\" + outputFileName;

                        //Read input file created in option A
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
                        
                        Console.WriteLine("");

                        //Wrap text using the Wrapper Class WrapTextFile method
                        List<string> list = Wrapper.WrapTextFile(text, maxLength);
                        FileStream stream = null;

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

                        Console.WriteLine("Wrapped text output");
                        Console.WriteLine("===================");
                        
                        foreach (string txt in list)
                        {
                            Console.WriteLine(txt);
                        }

                        Console.WriteLine("");
                        Console.Write("Do you want to continue using TextWrapper (Yes [Y] or No [N]): ");
                        option = Console.ReadLine();
                        break;

                    case "c":
                        //Close Application                  
                        Console.WriteLine("Closing TestWrapper...... ");
                        Console.Write("Do you want to continue using TextWrapper (Yes [Y] or No [N]): ");

                        option = Console.ReadLine();

                        break;
                }


            }
            while (option.ToLower() == "yes" || option.ToLower() == "y" || string.IsNullOrEmpty(option) || string.IsNullOrWhiteSpace(option));

            Console.Clear();
            Console.Beep();
            Console.WriteLine("Thank you for using TextWrapper by Jones (Telesoftas)");
            Console.WriteLine("====================================================");
            Console.WriteLine("");


        }
    }
}



