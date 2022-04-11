/*
    Developer:  Oluropo Akinbolade-JOnes
    Company:    Telesoftas
    Role:       Senior Fullstack Developer
    Date:       April, 2022

*/

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

                        Console.Write("Enter the maximum length of each line: ");
                        int maxLength = int.Parse(Console.ReadLine());

                        Console.WriteLine("");
                        List<string> output = Wrapper.WrapTextFile(maxLength);

                        Console.WriteLine("Wrapped text output");
                        Console.WriteLine("===================");
                         foreach (string txt in output)
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



