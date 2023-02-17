using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS3.Models
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
        
        // later this string value will be converted in to a integer for purpose of calculating GPA 
        public string CreditValue { get; set; }

        // store each student's module grade as A, A-, B+.... 
        // later using Dictionary<string,double> this gradePoint converted in to calculable numerical value to calculate GPA
        public string GradePoint { get; set; }
    }
}
