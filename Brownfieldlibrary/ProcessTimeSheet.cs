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
	}
}
