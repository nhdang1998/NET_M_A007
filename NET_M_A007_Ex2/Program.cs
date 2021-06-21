using System;
using System.Globalization;
using System.Text;

namespace NET_M_A007_Ex2
{
    internal static class Program
    {
        private static void Main()
        {
            do
            {
                try
                {
                    Console.Write("Start Date: \n");
                    DateTime.TryParseExact(Console.ReadLine()
                                                    , "dd/MM/yyyy"
                                                    , CultureInfo.InvariantCulture
                                                    , DateTimeStyles.None
                                                    , out DateTime startDate);

                    //Format the input of 3-letters name
                    StringBuilder departmentName = new StringBuilder();
                    string myDepartmentName = Format3LetterName(departmentName);

                    //Format the name to upper case
                    myDepartmentName = myDepartmentName.ToUpper();

                    Console.Write("\n\nInvoice number in 1 day: ");
                    int numberOfInvoicesPerDay = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nNumber of days to print the invoice: ");
                    int numberOfDayToPrintInvoice = Convert.ToInt32(Console.ReadLine());

                    Screen(startDate, myDepartmentName, numberOfInvoicesPerDay, numberOfDayToPrintInvoice);

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }

        /// <summary>
        /// Formatting output string
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="myDepartmentName"></param>
        /// <param name="numberOfInvoicesPerDay"></param>
        /// <param name="numberOfDayToPrintInvoice"></param>
        /// <returns></returns>
        private static void Screen(DateTime startDate, string myDepartmentName, int numberOfInvoicesPerDay, int numberOfDayToPrintInvoice)
        {
            int codeNumber = 1;
            startDate = startDate.AddDays(-1);
            for (int i = 0; i < numberOfDayToPrintInvoice; i++)
            {
                startDate = startDate.AddDays(1);
                int Year = (startDate.Month < 4) ? (startDate.Year - 1) : startDate.Year;

                ////Check financial year
                ////Restart after this day
                if (startDate.Day == 1 && startDate.Month == 4)
                {
                    codeNumber = 1;
                }
                string Statement = $"Invoice Date {startDate.ToString("d", CultureInfo.GetCultureInfo("vi-VN"))}: ";
                StringBuilder myCode = new StringBuilder("MyCode");
                for (int j = 0; j < numberOfInvoicesPerDay; j++)
                {
                    myCode.Append($",{myDepartmentName}FY{Year}{codeNumber:00000} ");
                    codeNumber++;
                }
                myCode = myCode.Replace("MyCode,", "");
                Console.WriteLine(Statement + myCode);
            }
        }

        /// <summary>
        /// Formatting name of the department
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        private static string Format3LetterName(StringBuilder departmentName)
        {
            bool loop = true;
            Console.WriteLine("\nDepartmentName: ");
            while (loop)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            loop = false;
                            break;
                        }
                    default:
                        {
                            if (departmentName.Length < 3)
                            {
                                departmentName.Append(keyInfo.KeyChar);
                                Console.Write(keyInfo.KeyChar);
                            }
                            break;
                        }
                }
            }
            return departmentName.ToString();
        }
    }
}