using System;
using System.Collections.Generic;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string w, rawTimeWorked;
            int i;
            double ttl, t;

            List<TimeSheetEntry> timesheet = LoadTimesheets();

			ttl = 0;
            for (i = 0; i < timesheet.Count; i++)
            {
                if (timesheet[i].WorkDone.ToLower().Contains("acme"))
                {
                    ttl += timesheet[i].HoursWorked;
                }
            }
            Console.WriteLine("Simulating Sending email to Acme");
            Console.WriteLine("Your bill is $" + ttl * 150 + " for the hours worked.");

            ttl = 0;
            for (i = 0; i < timesheet.Count; i++)
            {
                if (timesheet[i].WorkDone.ToLower().Contains("abc"))
                {
                    ttl += timesheet[i].HoursWorked;
                }
            }
            Console.WriteLine("Simulating Sending email to ABC");
            Console.WriteLine("Your bill is $" + ttl * 125 + " for the hours worked.");

            ttl = 0;
            for (i = 0; i < timesheet.Count; i++)
            {
                ttl += timesheet[i].HoursWorked;
            }
            if (ttl > 40)
            {
                Console.WriteLine("You will get paid $" + (((ttl - 40) * 15) + (40 * 10)) + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + ttl * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static List<TimeSheetEntry> LoadTimesheets()
        {
			List < TimeSheetEntry > output = new List<TimeSheetEntry> ();
			string enterMoreTimesheet = string.Empty;

			//do loop executes 1 or more time and a while loop executes 0 or more times.

			do
            {
				double hoursworked;
				Console.Write("Enter what you did: ");
                string workdone = Console.ReadLine();

                Console.Write("How long did you do it for: ");
                string rawTimeWorked = Console.ReadLine();

                while (double.TryParse(rawTimeWorked, out hoursworked) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid number given");
                    Console.Write("How long did you do it for: ");
                    rawTimeWorked = Console.ReadLine();
                }

                TimeSheetEntry timesheet = new TimeSheetEntry();
                timesheet.HoursWorked = hoursworked;
                timesheet.WorkDone = workdone;
                output.Add(timesheet);

                Console.Write("Do you want to enter more time (yes/no): ");
                enterMoreTimesheet = Console.ReadLine();
                

            } while(enterMoreTimesheet.ToLower() == "yes");

            return output;
		}

    }

    public class TimeSheetEntry
    {
        public string WorkDone;
        public double HoursWorked;
    }
}
