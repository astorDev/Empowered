using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Empowered.ApplicationConfiguration.Ninjecting.EFCore
{
	public class TestTable
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime SomeDate { get; set; }
	}
}
