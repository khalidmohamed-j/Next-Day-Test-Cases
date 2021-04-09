using System;

namespace ExampleNextDate
{
    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Date NextDate()
        {
            Date tomorrow = new Date { Day = this.Day, Month = this.Month, Year = this.Year };


            if (this.Day < 1 || this.Day > 31 || this.Month < 1 || this.Month > 12 || this.Year < 1818 || this.Year > 2021)
                throw new InvalidDateException();

            switch (Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                    if (Day < 31)
                    {
                        tomorrow.Day = Day + 1;
                    }
                    else
                    {
                        tomorrow.Day = 1;
                        tomorrow.Month = Month + 1;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (Day < 30)
                    {
                        tomorrow.Day = Day + 1;
                    }
                    else if (Day == 30)
                    {
                        tomorrow.Day = 1;
                        tomorrow.Month = Month + 1;
                    }
                    else throw new InvalidDateException();
                    break;
                case 12:
                    if (Day < 31)
                    {
                        tomorrow.Day = Day + 1;
                    }
                    else
                    {
                        tomorrow.Day = 1;
                        tomorrow.Month = 1;
                        tomorrow.Year = Year + 1;
                    }
                    break;
                case 2:
                    if (Day < 28)
                    {
                        tomorrow.Day = Day + 1;
                    }
                    else if (Day == 28)
                    {
                        if (IsLeapYear(Year))
                        {
                            tomorrow.Day = 29;
                        }
                        else
                        {
                            tomorrow.Day = 1;
                            tomorrow.Month = 3;
                        }
                    }
                    else if (Day == 29)
                    {
                        if (IsLeapYear(Year))
                        {
                            tomorrow.Day = 1;
                            tomorrow.Month = 3;
                        }
                        else throw new InvalidDateException();
                    }
                    else throw new InvalidDateException();
                    break;
            }

            tomorrow.Day = tomorrow.Day;
            tomorrow.Month = tomorrow.Month;
            tomorrow.Year = tomorrow.Year;

            return tomorrow;

        }

        public static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        //    public static bool IsLeapYear(int year)
        //    {
        //        if (year % 4 == 0)
        //        {
        //            if (year % 100 == 0 && year % 400 != 0)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
    }


    public class InvalidDateException : Exception
    {
        public InvalidDateException()
        {
        }
        public InvalidDateException(string message)
            : base(message)
        {
        }

        public InvalidDateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
