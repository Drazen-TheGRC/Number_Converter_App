using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Number_Converter_App
{
    internal class Program
    {
        // Checks if the language is set to English, if true ternary operator will use English text inline if false it will assign Serbian language
        static bool isEnglish;
        // Checks if the consol app just started, it controles App Language selection
        static bool isFirstProgramRun = true;
        // Consol box width 
        static int consoleLineWidth = 100;

        // App and developer info
        static string appName = "Number Converter App";
        static string developerName = "Drazen Drinic";
        static string appGitHubLink = "https://github.com/Drazen-TheGRC/Number_Converter_App";
        static string developerLinkedin = "https://www.linkedin.com/in/drazendrinic/";

        static void Main(string[] args)
        {
            
            selectLanguageMenu();
            delaySeconds(3);

            welcomeMessage();
            delaySeconds(3);

            mainMenu();
            delaySeconds(3);


        }


        // Delay method
        private static void delaySeconds(int numberOfSeconds)
        {
            int countdown = numberOfSeconds - 1;
            for (int i = 0; i < numberOfSeconds; i++)
            {
                Console.WriteLine((isEnglish ? "Starts in: " : "Pocinje za: ") + countdown.ToString());
                Thread.Sleep(1000);
                countdown--;
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.SetCursorPosition(0, Console.CursorTop - 1);

            Console.WriteLine();
        }
        // Welcome 
        private static void welcomeMessage()
        {
            string header = isEnglish ? "[ Welcome ]" : "[ Dobrodosli ]";
            string footer = isEnglish ? "[ Next steps are below ]" : "[ Sledeći koraci su u nastavku ]";

            List<string> consoleBoxMainTextContentList = new List<string>();
            consoleBoxMainTextContentList.Add((isEnglish ? "Developer Name: " : "Ime Programera: ") + developerName);
            consoleBoxMainTextContentList.Add((isEnglish ? "Aplication Name: " : "Naziv Aplikacije: ") + appName);
            consoleBoxMainTextContentList.Add((isEnglish ? "GitHub Repository: " : "GitHub Repository: ") + appGitHubLink);
            consoleBoxMainTextContentList.Add((isEnglish ? "Developer LinkedIn: " : "LinkedIn Programera: ") + developerLinkedin);

            consoleBoxBuilder(consoleLineWidth, header, consoleBoxMainTextContentList, footer, false);
        }
        // Goodbye
        private static void goodbyeMessage()
        {
            string header = isEnglish ? "[ Goodbye ]" : "[ Dovidjenja ]";
            string footer = isEnglish ? "***" : "***";
            List<string> consoleBoxMainTextContentList = new List<string>();
            consoleBoxMainTextContentList.Add((isEnglish ? "Thanks for trying my app!!!" : "Hvala sto ste isprobali moju aplikaciju!!!"));
            consoleBoxMainTextContentList.Add((isEnglish ? "See you next time!!!" : "Vidimo se sledeci put!!!"));

            consoleBoxBuilder(consoleLineWidth, header, consoleBoxMainTextContentList, footer, true);
        }

        


        // Console builder methods
        private static void consoleBoxHeaderBuilder(string headerLine)
        {
            // Empty line above the console box
            Console.WriteLine();
            // Header line
            Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, headerLine, '+', '-', true));
            // Empty line inside the consol box
            Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, "", '|', ' ', true));
        }
        private static void consoleBoxFooterBuilder(string footerLine)
        {
            // Empty line inside the consol box
            Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, "", '|', ' ', true));
            // Footer line
            Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, footerLine, '+', '-', true));
            // Empty line below the console box
            Console.WriteLine();
        }
        private static string consoleBoxLineBuilder(int consoleLineWidth, string mainTextString, char headerAndFooterPlaceholder, char mainTextPlaceholder, bool isCentered)
        {
            string consoleLine = "";
            StringBuilder preTextPlaceholder = new StringBuilder();
            StringBuilder postTextPlaceholder = new StringBuilder();

            int preTextPlaceholderLength;
            int postTextPlaceholderLength;

            // Making a decision about the preTextPlaceholderLength and postTextPlaceholderLength length depending if the text isCentered
            if (isCentered)
            {
                preTextPlaceholderLength = (consoleLineWidth - mainTextString.Length) / 2;
                postTextPlaceholderLength = (consoleLineWidth - mainTextString.Length) - preTextPlaceholderLength;
            }
            else
            {
                preTextPlaceholderLength = 1;
                postTextPlaceholderLength = consoleLineWidth - mainTextString.Length - preTextPlaceholderLength;

            }

            // Building the preTextPlaceholder
            for (int i = 0; i < preTextPlaceholderLength; i++)
            {
                preTextPlaceholder.Append(mainTextPlaceholder);

            }
            preTextPlaceholder.Insert(0, headerAndFooterPlaceholder);

            // Building the postTextPlaceholder
            for (int i = 0; i < postTextPlaceholderLength; i++)
            {
                postTextPlaceholder.Append(mainTextPlaceholder);

            }
            postTextPlaceholder.Append(headerAndFooterPlaceholder);

            // Assembling a single consoleLine
            consoleLine = preTextPlaceholder + mainTextString + postTextPlaceholder;

            return consoleLine;
        }
        private static void consoleBoxBuilder(int consoleLineWidth, string headerLine, List<string> consoleBoxMainTextContentList, string footerLine, bool isCentered)
        {
            // Adding header line
            consoleBoxHeaderBuilder(headerLine);

            // Adding main console box content
            for (int i = 0; i < consoleBoxMainTextContentList.Count; i++)
            {
                Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, consoleBoxMainTextContentList[i], '|', ' ', isCentered));
            }

            // Adding footer line
            consoleBoxFooterBuilder(footerLine);
        }




        // Select language methods
        private static void selectLanguageMenuMessage()
        {
            string header = "[ Language selection / Izbor Jezika ]";
            string userInputInstructions = "Enter your choice here / Upišite vas izbor ovdje: ";
            string footer = "[ Please Enter Your Choice Below / Molim Unesite Vas Izbor Ispod ]";

            List<string> consoleBoxMainTextContentList = new List<string>();
            consoleBoxMainTextContentList.Add("[1] English / Englenski");
            consoleBoxMainTextContentList.Add("[2] Srpski / Serbian");

            consoleBoxBuilder(consoleLineWidth, header, consoleBoxMainTextContentList, footer, false);

            Console.Write(userInputInstructions);
        }
        private static void selectLanguageMenu()
        {
            // Add menu min choice option (most likely it will be always one)
            int min = 1;
            // Add menu max choice option
            int max = 2;

            // Display a message in the console for user prior asking for input
            selectLanguageMenuMessage();

            // waiting for the user to enter a valid selection and repeating it until the user enters a valid option
            // The userInputForMenu will take care of invalid inputs
            int selection = 0;
            while (selection==0)
            {
                selection = userInputForMenu(min, max);
            }

            // Decision making related to the user choice
            switch (selection)
            {
                case 1:
                    isEnglish = true;
                    Console.WriteLine();
                    goodInputMessage(selection.ToString());
                    Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   App language is set to English   <<<", '-', '-', true));
                    Console.WriteLine();
                    break;
                case 2:
                    isEnglish = false;
                    Console.WriteLine();
                    goodInputMessage(selection.ToString());
                    Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Jezik aplikacije je podešen na Srpski   <<<", '-', '-', true));
                    Console.WriteLine();
                    break;
            }
        }

        // User input for menu options selection only
        private static int userInputForMenu(int min, int max)
        {
            int userInput = 0;
            string userInputString = Console.ReadLine();

            Regex regex = new Regex($"^[{min}-{max}]$");
            if (regex.IsMatch(userInputString))
            {
                userInput = Int32.Parse(userInputString);

                if (isFirstProgramRun)
                {
                    isFirstProgramRun = false;
                }
            }
            else
            {
                if (isFirstProgramRun)
                {
                    Console.WriteLine();
                    Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   You entered: >   " + userInputString + "   < which is NOT a valid option   <<<", '-', '-', true));
                    Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Unijeli ste: >   " + userInputString + "   < sto NIJE valjana opcija   <<<", '-', '-', true));
                    Console.WriteLine();
                    Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Please try again   <<<", '-', '-', true));
                    Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Molim pokusajte ponovo   <<<", '-', '-', true));
                    Console.WriteLine();
                    Console.Write("Enter your choice here / Upišite vas izbor ovdje: ");
                }
                else
                {
                    Console.WriteLine();
                    badInputMessage(userInputString);
                    Console.WriteLine();
                    Console.Write(isEnglish ? "Enter your choice here: " : "Upišite vas izbor ovdje: ");
                }
            }

            return userInput;
        }
        // Good input 
        private static void goodInputMessage(string userInputString)
        {
            if (isEnglish)
            {
                Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   You entered: >   " + userInputString + "   < which is a valid option   <<<", '-', '-', true));
                Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Thanks For Your Input   <<<", '-', '-', true));
            }
            else
            {
                Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Unijeli ste: >   " + userInputString + "   < sto je valjana opcija   <<<", '-', '-', true));
                Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Hvala na unosu   <<<", '-', '-', true));
            }
        }
        // Bad input
        private static void badInputMessage(string userInputString)
        {
            if (isEnglish)
            {
                Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   You entered: >   " + userInputString + "   < which is NOT a valid option   <<<", '-', '-', true));
                Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Please try again   <<<", '-', '-', true));
            }
            else
            {
                Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Unijeli ste: >   " + userInputString + "   < sto NIJE valjana opcija   <<<", '-', '-', true));
                Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, ">>>   Molim pokusajte ponovo   <<<", '-', '-', true));
            }
        }




        private static void mainMenuMessage()
        {
            string header = isEnglish ? "[ Main Menu ]" : "[ Glavni Meni ]";
            string userInputInstructions = isEnglish ? "Enter your choice here: " : "Upišite vas izbor ovdje: ";
            string footer = isEnglish ? "[ Please Enter Your Choice Below ]" : "[ Molim Unesite Vas Izbor Ispod ]";

            List<string> consoleBoxMainTextContentList = new List<string>();
            consoleBoxMainTextContentList.Add(isEnglish ? "[1] Reset App" : "[1] Pokreni iz pocetka");
            consoleBoxMainTextContentList.Add("");
            consoleBoxMainTextContentList.Add(isEnglish ? "[2] Binary Converter" : "[2] Binarni Konverter");
            consoleBoxMainTextContentList.Add(isEnglish ? "[3] Octal Converter" : "[3] Oktalni Konverter");
            consoleBoxMainTextContentList.Add(isEnglish ? "[4] Decimal Converter" : "[4] Decimalni Konverter");
            consoleBoxMainTextContentList.Add(isEnglish ? "[5] Hexadecimal Converter" : "[5] Hexadecimalni Konverter");
            consoleBoxMainTextContentList.Add("");
            consoleBoxMainTextContentList.Add(isEnglish ? "[6] Exit App" : "[6] Ugasi Aplikaciju");


            consoleBoxBuilder(consoleLineWidth, header, consoleBoxMainTextContentList, footer, false);

            Console.Write(userInputInstructions);
        }
        private static void mainMenu()
        {
            int min = 1;
            int max = 6;
            mainMenuMessage();
            int selection = 0;
            while (selection == 0)
            {
                selection = userInputForMenu(min, max);
            }

            switch (selection)
            {
                case 1:
                    // restart app
                    // startApp();
                    break;

                case 2:
                    // binaryConverterMenu();
                    break;
                case 3:
                    // octalConverterMenu();
                    break;
                case 4:
                    // decimalConverterMenu();
                    break;
                case 5:
                    // hexadecimalConverterMenu();
                    break;


                case 6:
                    // stopApp();
                    break;

            }

        }












    }
}
