﻿using Brownfieldlibrary.Models;
using System.Collections.Generic;

namespace Brownfieldlibrary
{
	public static class DataAccessSimulator
	{
		public static List<CustomerModel> GetCustomers()
		{
			List<CustomerModel> output = new List<CustomerModel>();

			output.Add(new CustomerModel() { CustomerName = "Acme", hourlyRate = 150 });
			output.Add(new CustomerModel() { CustomerName = "AbC", hourlyRate = 125 });

			return output;
		}

		public static EmployeeModel GetCurrentEmployee()
		{
			EmployeeModel output = new EmployeeModel
			{
				FirstName = "Jhon",
				LastName = "Smith",
				hourlyRate = 15
			};

			return output;
		}
	}

}