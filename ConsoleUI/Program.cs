using Brownfieldlibrary;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            int i;
            double totalHours, t;

            List<TimeSheetEntry> timesheet = LoadTimesheets();

            totalHours = ProcessTimeSheet.GetHoursworked(timesheet, "acme");
            Console.WriteLine("Simulating Sending email to Acme");
            Console.WriteLine("Your bill is $" + totalHours * 150 + " for the hours worked.");

            totalHours = 0;
            for (i = 0; i < timesheet.Count; i++)
            {
                if (timesheet[i].WorkDone.ToLower().Contains("abc"))
                {
                    totalHours += timesheet[i].HoursWorked;
                }
            }
            Console.WriteLine("Simulating Sending email to ABC");
            Console.WriteLine("Your bill is $" + totalHours * 125 + " for the hours worked.");

            totalHours = 0;
            for (i = 0; i < timesheet.Count; i++)
            {
                totalHours += timesheet[i].HoursWorked;
            }
            if (totalHours > 40)
            {
                Console.WriteLine("You will get paid $" + (((totalHours - 40) * 15) + (40 * 10)) + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + totalHours * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static void BillCustomer(List<TimeSheetEntry> timesheet, string companyName, decimal hourlyrate)
        {
			double totalHours = ProcessTimeSheet.GetHoursworked(timesheet, companyName);
			Console.WriteLine($"Simulating Sending email to {companyName}");
			Console.WriteLine("Your bill is $" + totalHours * hourlyrate + " for the hours worked.");
		}

        private static List<TimeSheetEntry> LoadTimesheets()
        {
			List <TimeSheetEntry> output = new List<TimeSheetEntry> ();
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

}
