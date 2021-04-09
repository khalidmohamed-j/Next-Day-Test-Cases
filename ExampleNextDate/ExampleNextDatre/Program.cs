using System;
using static System.Console;
using ExampleNextDate;


namespace NextDateDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            int day, month, year;
            Date today;
            Date tomorrow;

            do
            {
                WriteLine("Enter a date between 1/1/1818 and 12/31/2021 and I'll tell you the date of the next day.\n");

                do
                {
                    Write("Enter the month: ");
                } while (!int.TryParse(ReadLine(), out month));

                do
                {
                    Write("Now the day: ");
                } while (!int.TryParse(ReadLine(), out day));

                do
                {
                    Write("And finally, the year: ");
                } while (!int.TryParse(ReadLine(), out year));

                today = new Date { Month = month, Day = day, Year = year };
                try
                {
                    tomorrow = today.NextDate();
                    WriteLine($"The day after {month}/{day}/{year} is {tomorrow.Month}/{tomorrow.Day}/{tomorrow.Year}.");
                }
                catch (InvalidDateException)
                {
                    WriteLine($"Hey!  What are you tryin' to pull? {month}/{day}/{year} ain't no valid date!  Scram!");
                }


                Write("\nAgain? ");
            } while (ReadLine().ToUpper() == "Y");

            WriteLine("\nThat's all, folks!");
            ReadKey();

        }
    }
}
