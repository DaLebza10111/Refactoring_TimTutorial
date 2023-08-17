using Brownfieldlibrary.Models;
using System;
using System.Collections.Generic;

namespace Brownfieldlibrary
{
	//adding statics makes it not store data
	public static class ProcessTimeSheet
	{
		public static double GetHoursworked(List<TimeSheetEntry> timesheet, string companyname)
		{
			double output = 0;

			for (int i = 0; i < timesheet.Count; i++)
			{
				if (timesheet[i].WorkDone.ToLower().Contains(companyname.ToLower()))
				{
					output += timesheet[i].HoursWorked;
				}
			}

			return output;
		}

		public static decimal GetEmployeeRate(List<TimeSheetEntry> timeSheets, EmployeeModel employee)
		{
			decimal output = 0;
			double totalHours = 0;
			for (int i = 0; i < timeSheets.Count; i++)
			{
				totalHours += timeSheets[i].HoursWorked;
			}

			if (totalHours > 40)
			{
				output = (decimal)(((decimal)totalHours - 40) * (employee.hourlyRate * 1.5M)) + (40M * employee.hourlyRate);
			}
			else
			{
				output = (decimal)totalHours * employee.hourlyRate;
			}

			return output;
		}
	}
}
