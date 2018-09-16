using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class CourseSearchCriteria
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Duration { get; set; }
        public double Credit { get; set; }
        public string Outline { get; set; }
        public string Tags { get; set; }

        public List<Course> Courses { get; set; } 
    }
}
