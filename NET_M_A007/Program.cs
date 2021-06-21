using System;
using System.Globalization;

namespace NET_M_A007
{
    public static class Program
    {

        private static void Main()
        {
            do
            {
                try
                {
                    DateTime enterDate;
                    Console.Write("Please insert your date in the following format dd/mm/yyyy\n");
                    Console.WriteLine("For example: 08/01/2019");

                    DateTime.TryParseExact(Console.ReadLine()
                                            , "dd/mm/yyyy"
                                            , CultureInfo.InvariantCulture
                                            , DateTimeStyles.None
                                            , out enterDate);
                    //
                    Remind(enterDate);

                    //Expand Problems
                    ExpandRemind(enterDate);

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (true);
        }

        /// <summary>
        /// The Remind
        /// </summary>
        /// <param name="enterDate">The enterDate<see cref="DateTime"/>.</param>
        private static void Remind(DateTime enterDate)
        {
            DateTime firstReminder = enterDate.AddDays(7);
            DateTime secondReminder = firstReminder.AddDays(2);
            DateTime thirdReminder = secondReminder.AddDays(1);
            DateTime fourthReminder = thirdReminder.AddDays(1);
            DateTime fifthReminder = fourthReminder.AddDays(1);

            Console.WriteLine("\n1st Reminder: " + firstReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
            Console.WriteLine("2nd Reminder: " + secondReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
            Console.WriteLine("3rd Reminder: " + thirdReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
            Console.WriteLine("4th Reminder: " + fourthReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
            Console.WriteLine("5th Reminder: " + fifthReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
        }

        /// <summary>
        /// The ExpandRemind.
        /// </summary>
        /// <param name="enterDate">The enterDate<see cref="DateTime"/>.</param>
        private static void ExpandRemind(DateTime enterDate)
        {
            DateTime firstReminder = AddWorkingDays(enterDate, 7);
            DateTime secondReminder = AddWorkingDays(firstReminder, 2);
            DateTime thirdReminder = AddWorkingDays(secondReminder, 1);
            DateTime fourthReminder = AddWorkingDays(thirdReminder, 1);
            DateTime fifthReminder = AddWorkingDays(fourthReminder, 1);

            Console.WriteLine("\nExpand Problems");
            Console.WriteLine("1st Reminder: " + firstReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
            Console.WriteLine("2nd Reminder: " + secondReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
            Console.WriteLine("3rd Reminder: " + thirdReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
            Console.WriteLine("4th Reminder: " + fourthReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
            Console.WriteLine("5th Reminder: " + fifthReminder.ToString("d", CultureInfo.GetCultureInfo("vi-VN")));
        }

        /// <summary>
        /// The AddWorkingDays.
        /// </summary>
        /// <param name="date">The date<see cref="DateTime"/>.</param>
        /// <param name="daysToAdd">The daysToAdd<see cref="int"/>.</param>
        /// <returns>The <see cref="DateTime"/>.</returns>
        public static DateTime AddWorkingDays(this DateTime date, int daysToAdd)
        {
            while (daysToAdd > 0)
            {
                date = date.AddDays(1);

                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    daysToAdd -= 1;
                }

            }

            return date;
        }
    }
}
