using Brownfieldlibrary;
using Brownfieldlibrary.Models;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{

			List<TimeSheetEntry> timesheet = LoadTimesheets();
			List<CustomerModel> customers = DataAccessSimulator.GetCustomers();
			EmployeeModel employee = DataAccessSimulator.GetCurrentEmployee();

			customers.ForEach(x => BillCustomer(timesheet, x));

			PayEmployee(timesheet, employee);

			Console.WriteLine();
			Console.Write("Press any key to exit application...");
			Console.ReadKey();
		}

		private static void PayEmployee(List<TimeSheetEntry> timeSheets, EmployeeModel employee)
		{
			decimal totalPay = ProcessTimeSheet.GetEmployeeRate(timeSheets, employee);
			Console.WriteLine($"You will get paid ${totalPay} for your time.");

		}

		private static void BillCustomer(List<TimeSheetEntry> timesheet, CustomerModel customer)
		{
			double totalHours = ProcessTimeSheet.GetHoursworked(timesheet, customer.CustomerName);
			Console.WriteLine($"Simulating Sending email to {customer.CustomerName}");
			Console.WriteLine("Your bill is $" + (decimal)totalHours * customer.hourlyRate + " for the hours worked.");
		}

		private static List<TimeSheetEntry> LoadTimesheets()
		{
			List<TimeSheetEntry> output = new List<TimeSheetEntry>();
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


			} while (enterMoreTimesheet.ToLower() == "yes");

            Console.WriteLine();

            return output;
		}

	}

}
