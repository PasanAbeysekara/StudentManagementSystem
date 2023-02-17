using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS3
{
	public class Module
	{
		public Module(string id, string name, string creditValue)
		{
			Id = id;
			Name = name;
			CreditValue = creditValue;
			GradePoint = "";
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public string CreditValue { get; set; }
		public string GradePoint { get; set; }
	}
}
