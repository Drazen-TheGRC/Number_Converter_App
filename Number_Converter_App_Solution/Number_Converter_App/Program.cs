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
            startApp();
        }

        // StartApp function will make sure it goes well all the way untill we reach out the main menu
        // Main menu will take over from there
        private static void startApp()
        {
            isFirstProgramRun = true;

            selectLanguageMenu();
            //delaySeconds(3);

            //welcomeMessage();
            //delaySeconds(5);

            mainMenu();
        }
        // StopApp function will display the goodbye message give it a nice delay and than clear then console and end the app 
        private static void stopApp()
        {
            goodbyeMessage();
            delaySeconds(10);
            Console.Clear();
            Environment.Exit(0);
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

            Console.WriteLine();
            Console.WriteLine();
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

        // User User input for menus functions
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



        // Main menu functions
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
                    delaySeconds(3);
                    startApp();
                    break;

                case 2:
                    // binaryConverterMenu();
                    break;
                case 3:
                    // octalConverterMenu();
                    break;
                case 4:
                    decimalConverterMenu();
                    break;
                case 5:
                    // hexadecimalConverterMenu();
                    break;


                case 6:
                    // stop the app
                    stopApp();
                    break;

            }

        }


        // Decimal number conversion methods
        // 

        private static void decimalConverterMenuMessage()
        {
            string header = isEnglish ? "[ Decimal Converter Menu ]" : "[ Decimalni Konverter Meni ]";
            string userInputInstructions = isEnglish ? "Enter your choice here: " : "Upišite vas izbor ovdje: ";
            string footer = isEnglish ? "[ Please Enter Your Choice Below ]" : "[ Molim Unesite Vas Izbor Ispod ]";

            List<string> consoleBoxMainTextContentList = new List<string>();
            consoleBoxMainTextContentList.Add(isEnglish ? "[1] Main Menu" : "[1] Glavni Meni");
            consoleBoxMainTextContentList.Add(isEnglish ? "[2] Convert Decimal Number" : "[2] Konvertuj Decimalni Broj");

            consoleBoxBuilder(consoleLineWidth, header, consoleBoxMainTextContentList, footer, false);

            Console.Write(userInputInstructions);
        }
        private static void decimalConverterMenu()
        {
            int min = 1;
            int max = 2;
            decimalConverterMenuMessage();
            int selection = 0;
            while (selection == 0)
            {
                selection = userInputForMenu(min, max);
            }

            switch (selection)
            {
                case 1:
                    
                    mainMenu();
                    break;
                case 2:
                    
                    decimalConverter();
                    break;
            }

        }

        private static decimal inputDecimal()
        {
            decimal userInput = 0;

            Console.WriteLine();
            // I added a limit so as not to cause issues on two ends, firstly I don't want the number of digits to mess up my presentation in the console,
            //Secondly I want to make sure the number fits into the int32. Why 16777215 because it is 8 digits long and it is the largest number in hexadecimal equivalent FFFFFF
            Console.Write(isEnglish ? "Please enter a decimal number less than 16777215: " : "Molim vas upišite decimalni broj manji od 16777215: ");

            string userInputString = Console.ReadLine();

            string regexPattern = @"^([0-9]{0,8})(\.[0-9]{1,5})?$";
            Regex regex = new Regex(regexPattern);
            if (regex.IsMatch(userInputString))
            {
                try
                {
                    userInput = decimal.Parse(userInputString);
                    if (userInput > 16777215 && userInput <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, isEnglish ? ">>>   There was an error, App will start from the previus menu   <<<" : ">>>   Dogodila se greška, applikacija će se nastaviti od predgodnog menija   <<<", '-', '-', true));
                        Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, isEnglish ? ">>>   Please try again   <<<" : ">>>   Molim pokusajte ponovo   <<<", '-', '-', true));
                        Console.WriteLine();
                        decimalConverterMenu();

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, isEnglish ? ">>>   There was an error, App will start from the previus menu   <<<" : ">>>   Dogodila se greška, applikacija će se nastaviti od predgodnog menija   <<<", '-', '-', true));
                    Console.WriteLine(consoleBoxLineBuilder(consoleLineWidth, isEnglish ? ">>>   Please try again   <<<" : ">>>   Molim pokusajte ponovo   <<<", '-', '-', true));
                    Console.WriteLine();
                    decimalConverterMenu();
                }

                Console.WriteLine();
                goodInputMessage(userInputString);
                Console.WriteLine();
            }
            else
            {

                // We need to say there was an error the app will go back for one menu
                Console.WriteLine();
                badInputMessage(userInputString);
                Console.WriteLine();
                inputDecimal();

                
            }

            return userInput;
        }



        private static void decimalNumberConversionExplanation()
        {
            string header = isEnglish ? "[ Decimal Converter ]" : "[ Decimalni Konverter ]";
            string footer = isEnglish ? "[ Enter a decimal number below ]" : "[ Upišite decimalni broj u nastavku ]";

            List<string> consoleBoxMainTextContentList = new List<string>();
            consoleBoxMainTextContentList.Add(isEnglish ? "explain decimal conversions " : "objasniti konverzije decimalnog broja");
            consoleBoxMainTextContentList.Add(isEnglish ? "" : "");
            consoleBoxMainTextContentList.Add(isEnglish ? "" : "");
            consoleBoxMainTextContentList.Add(isEnglish ? "" : "");

            consoleBoxBuilder(consoleLineWidth, header, consoleBoxMainTextContentList, footer, false);
        }
        private static void decimalConverter()
        {
            decimalNumberConversionExplanation();

            decimal decimalNumber = inputDecimal();

            {
                string header = isEnglish ? "[ Conversion of a Decimal to a Binary number ]" : "[ Konverzija Decimalnog u Binarni broj ]";
                string footer = isEnglish ? "[ ***** ]" : "[ ***** ]";


                consoleBoxBuilder(consoleLineWidth, header, decimalToBinary(decimalNumber), footer, false);
            }
            //{
            //    string header = isEnglish ? "[ Conversion of a Decimal to an Octal number ]" : "[ Konverzija Decimalnog u Oktalni broj ]";
            //    string footer = isEnglish ? "[ ***** ]" : "[ ***** ]";
            //    consoleBoxBuilder(consoleLineWidth, header, decimalToOctal(decimalNumber), footer, false);
            //}
            //{
            //    string header = isEnglish ? "[ Conversion of a Decimal to a Hexadecimal number ]" : "[ Konverzija Decimalnog u Heksadecimalni broj ]";
            //    string footer = isEnglish ? "[ ***** ]" : "[ ***** ]";
            //    consoleBoxBuilder(consoleLineWidth, header, decimalToHexadecimal(decimalNumber), footer, false);
            //}

            decimalConverterMenu();


        }




        private static List<string> decimalToBinary(decimal decimalNumberInput)
        {
            decimal decimalNumber = decimalNumberInput;

            int integralPart = (int)decimalNumber;
            decimal fractionalPart = decimalNumber - integralPart;


            // used for calculations of the integralPart
            int resultForIntegralPart;
            int reminderForIntegralPart;

            // used for the calculations of the fractionalPart
            decimal resultForFractionalPart;
            int reminderForFractionalPart;


            int tempIntegralPart = integralPart;
            decimal tempFractionalPart = fractionalPart;

            string conversionResult = "";
            string endText;



            List<string> consoleBoxMainTextContentList = new List<string>();

            consoleBoxMainTextContentList.Add("Calculating the Integral Part of the number: ");
            consoleBoxMainTextContentList.Add("");

            // Adding all integralPart calculations
            while (tempIntegralPart > 0)
            {
                reminderForIntegralPart = tempIntegralPart % 2;
                resultForIntegralPart = tempIntegralPart / 2;

                conversionResult = conversionResult.Insert(0, reminderForIntegralPart.ToString());

                if (tempIntegralPart == integralPart)
                {
                    endText = "^ LSB";
                }
                else if (resultForIntegralPart > 0)
                {
                    endText = "|";
                }
                else
                {
                    endText = "| MSB";
                }


                string conversionLine = tempIntegralPart.ToString();

                conversionLine += new string(' ', 8 - conversionLine.Length);
                conversionLine += "÷";

                conversionLine += new string(' ', 16 - conversionLine.Length);
                conversionLine += "2";

                conversionLine += new string(' ', 24 - conversionLine.Length);
                conversionLine += "=";

                conversionLine += new string(' ', 32 - conversionLine.Length);
                conversionLine += resultForIntegralPart.ToString();

                conversionLine += new string(' ', 40 - conversionLine.Length);
                conversionLine += "R = " + reminderForIntegralPart.ToString();

                conversionLine += new string(' ', 48 - conversionLine.Length);
                conversionLine += endText;

                tempIntegralPart = resultForIntegralPart;

                consoleBoxMainTextContentList.Add(conversionLine);
            }

            // Adding all fractional part calculations
            conversionResult += ".";
            consoleBoxMainTextContentList.Add("");
            consoleBoxMainTextContentList.Add("Calculating the Fractional Part of the number: ");
            consoleBoxMainTextContentList.Add("");

            int repetitions = 0;

            for(int i = 5; i > 0; i--)
            {
                resultForFractionalPart = (tempFractionalPart * 2);

                if (resultForFractionalPart >= 1)
                {
                    reminderForFractionalPart = 1;
                }
                else
                {
                    reminderForFractionalPart = 0;
                }



                conversionResult += reminderForFractionalPart;

                //if (tempIntegralPart == decimalNumber)
                //{
                //    endText = "^ LSB";
                //}
                //else if (resultForIntegralPart > 0)
                //{
                //    endText = "|";
                //}
                //else
                //{
                //    endText = "| MSB";
                //}


                string conversionLine = tempFractionalPart.ToString();

                conversionLine += new string(' ', 8 - conversionLine.Length);
                conversionLine += "*";

                conversionLine += new string(' ', 16 - conversionLine.Length);
                conversionLine += "2";

                conversionLine += new string(' ', 24 - conversionLine.Length);
                conversionLine += "=";

                conversionLine += new string(' ', 32 - conversionLine.Length);
                conversionLine += resultForFractionalPart.ToString();

                conversionLine += new string(' ', 40 - conversionLine.Length);
                conversionLine += "R = " + reminderForFractionalPart.ToString();

                conversionLine += new string(' ', 48 - conversionLine.Length);
                //conversionLine += endText;


                if (resultForFractionalPart > 1)
                {
                    tempFractionalPart = resultForFractionalPart-1;
                    
                }
                else if (resultForFractionalPart < 1)
                {
                    tempFractionalPart = resultForFractionalPart;
                }
                else
                {
                    tempFractionalPart = 0;
                }

                

                consoleBoxMainTextContentList.Add(conversionLine);

                // Breaks the loop in case tempFractionalPart == 0, that means there is no need to keep calculating
                if (tempFractionalPart == 0)
                {
                    break;
                }



            }







            consoleBoxMainTextContentList.Add("");
            string decString = isEnglish ? "Decimal number : " : "Decimalni broj : ";
            consoleBoxMainTextContentList.Add(decString + new string(' ', 20 - decString.Length) + decimalNumber.ToString());
            string binaryString = isEnglish ? "Binary number : " : "Binarni broj : ";
            consoleBoxMainTextContentList.Add(binaryString + new string(' ', 20 - binaryString.Length) + conversionResult);

            return consoleBoxMainTextContentList;
        }
        private static List<string> decimalToOctal(int decimalNumberInput)
        {
            int decimalNumber = decimalNumberInput;
            int result;
            int reminder;
            int newDecimal = decimalNumber;

            string conversionResult = "";
            string endText;



            List<string> consoleBoxMainTextContentList = new List<string>();

            while (newDecimal > 0)
            {
                reminder = newDecimal % 8;
                result = newDecimal / 8;

                conversionResult = conversionResult.Insert(0, reminder.ToString());

                if (newDecimal == decimalNumber)
                {
                    endText = "^ LSB";
                }
                else if (result > 0)
                {
                    endText = "|";
                }
                else
                {
                    endText = "| MSB";
                }


                string conversionLine = newDecimal.ToString();

                conversionLine += new string(' ', 8 - conversionLine.Length);
                conversionLine += "÷";

                conversionLine += new string(' ', 16 - conversionLine.Length);
                conversionLine += "8";

                conversionLine += new string(' ', 24 - conversionLine.Length);
                conversionLine += "=";

                conversionLine += new string(' ', 32 - conversionLine.Length);
                conversionLine += result.ToString();

                conversionLine += new string(' ', 40 - conversionLine.Length);
                conversionLine += "R = " + reminder.ToString();

                conversionLine += new string(' ', 48 - conversionLine.Length);
                conversionLine += endText;

                newDecimal = result;

                consoleBoxMainTextContentList.Add(conversionLine);
            }

            consoleBoxMainTextContentList.Add("");
            string decString = isEnglish ? "Decimal number : " : "Decimalni broj : ";
            consoleBoxMainTextContentList.Add(decString + new string(' ', 20 - decString.Length) + decimalNumber.ToString());
            string octaString = isEnglish ? "Octal number : " : "Oktalni broj : ";
            consoleBoxMainTextContentList.Add(octaString + new string(' ', 20 - octaString.Length) + conversionResult);

            return consoleBoxMainTextContentList;
        }
        private static List<string> decimalToHexadecimal(int decimalNumberInput)
        {
            int decimalNumber = decimalNumberInput;
            int result;
            int reminder;

            string reminderString;

            int newDecimal = decimalNumber;

            string conversionResult = "";
            string endText;



            List<string> consoleBoxMainTextContentList = new List<string>();

            while (newDecimal > 0)
            {
                reminder = newDecimal % 16;
                result = newDecimal / 16;

                if (reminder == 15)
                {
                    reminderString = "F";
                }
                else if (reminder == 14)
                {
                    reminderString = "E";
                }
                else if (reminder == 13)
                {

                    reminderString = "D";
                }
                else if (reminder == 12)
                {
                    reminderString = "C";
                }
                else if (reminder == 11)
                {
                    reminderString = "B";
                }
                else if (reminder == 10)
                {
                    reminderString = "A";
                }
                else
                {
                    reminderString = reminder.ToString();
                }

                conversionResult = conversionResult.Insert(0, reminderString);

                if (newDecimal == decimalNumber)
                {
                    endText = "^ LSB";
                }
                else if (result > 0)
                {
                    endText = "|";
                }
                else
                {
                    endText = "| MSB";
                }


                string conversionLine = newDecimal.ToString();

                conversionLine += new string(' ', 8 - conversionLine.Length);
                conversionLine += "÷";

                conversionLine += new string(' ', 16 - conversionLine.Length);
                conversionLine += "16";

                conversionLine += new string(' ', 24 - conversionLine.Length);
                conversionLine += "=";

                conversionLine += new string(' ', 32 - conversionLine.Length);
                conversionLine += result.ToString();

                conversionLine += new string(' ', 40 - conversionLine.Length);
                conversionLine += "R = " + reminder.ToString() + (reminder > 9 ? " -> " + reminderString : "  -> " + reminder.ToString());

                conversionLine += new string(' ', 54 - conversionLine.Length);
                conversionLine += endText;

                newDecimal = result;

                consoleBoxMainTextContentList.Add(conversionLine);
            }

            consoleBoxMainTextContentList.Add("");
            string decString = isEnglish ? "Decimal number : " : "Decimalni broj : ";
            consoleBoxMainTextContentList.Add(decString + new string(' ', 24 - decString.Length) + decimalNumber.ToString());
            string hexaString = isEnglish ? "Hexadecimal number : " : "Heksadecimalni broj : ";
            consoleBoxMainTextContentList.Add(hexaString + new string(' ', 24 - hexaString.Length) + conversionResult);

            return consoleBoxMainTextContentList;
        }





    }
}
