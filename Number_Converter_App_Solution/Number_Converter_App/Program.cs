using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Number_Converter_App
{
    internal class Program
    {
        // Checks if the language is set to English, if true ternary operator will use English text inline if false it will assign Serbian language
        static bool isEnglish;
        // Consol box width 
        static int consoleLineWidth = 100;

        // App and developer info
        static string appName = "Number Converter App";
        static string developerName = "Drazen Drinic";
        static string appGitHubLink = "https://github.com/Drazen-TheGRC/Number_Converter_App";
        static string developerLinkedin = "https://www.linkedin.com/in/drazendrinic/";

        static void Main(string[] args)
        {
            welcomeMessage();
            delaySeconds(3);
            goodbyeMessage();
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




        


















    }
}
