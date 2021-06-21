using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NET_M_A007_Ex3
{
    internal class Program
    {
        private static void Main()
        {
            List<string> lines = new List<string>();
            string lineTemp = "";
            ConsoleKeyInfo keyInfo;
            Console.WriteLine("Press Ctrl+Enter to print output");
            Console.WriteLine("\nInput");
            do
            {
                keyInfo = Console.ReadKey(true);
                Console.Write(keyInfo.KeyChar);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    lines.Add(lineTemp);
                    lineTemp = "";
                    Console.WriteLine();
                }
                else
                {
                    lineTemp += keyInfo.KeyChar;
                }

                if ((keyInfo.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                {
                    break;
                }
            }
            while (true);

            List<Information> listInformation = CreateListInformation(lines);
            listInformation = SortListInformation(listInformation);

            ////Print the output
            Console.WriteLine("Output");
            foreach (var item in listInformation)
            {
                Console.WriteLine(item.Label);
            }
        }

        /// <summary>
        /// Formatting input date.
        /// </summary>
        /// <param name="stringDate">.</param>
        /// <param name="date">.</param>
        /// <returns>.</returns>
        public static bool FormatDay(string stringDate, out DateTime date)
        {
            date = new DateTime();
            string[] formats = { "dd/MM/yyyy", "dd/MM/yyyy hh:mm:ss tt", "dd/MMM/yyyy" };
            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(stringDate
                                            , format
                                            , new CultureInfo("en-US")
                                            , DateTimeStyles.AllowTrailingWhite | DateTimeStyles.AllowLeadingWhite
                                            , out date))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Create list of informations.
        /// </summary>
        /// <param name="lines">.</param>
        /// <returns>.</returns>
        public static List<Information> CreateListInformation(List<string> lines)
        {
            ////Extract the date from each line
            List<Information> listInformation = new List<Information>();
            foreach (var line in lines)
            {
                Regex regex = new Regex(@"(\d{2}[/]\d{2}[/]\d{4} \d{2}[:]\d{2}[:]\d{2} (PM|AM))|(\d{2}[/]\d{2}[/]\d{4})");
                Match match = regex.Match(line);

                DateTime updateTimeTemp;
                if (FormatDay(match.Value, out updateTimeTemp))
                {
                    Information info = new Information()
                    {
                        Label = line,
                        UpdateTime = updateTimeTemp
                    };
                    listInformation.Add(info);
                }
            }
            return listInformation;
        }

        /// <summary>
        /// Sorting the output list by date.
        /// </summary>
        /// <param name="inputList">.</param>
        /// <returns>.</returns>
        public static List<Information> SortListInformation(List<Information> inputList)
        {
            for (int i = 0; i < inputList.Count - 1; i++)
            {
                if (inputList[i].UpdateTime.CompareTo(inputList[i + 1].UpdateTime) > 0)
                {
                    Information temp = inputList[i];
                    inputList[i] = inputList[i + 1];
                    inputList[i + 1] = temp;
                }
            }
            return inputList;
        }
    }
}