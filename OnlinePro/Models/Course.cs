using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
   public class Course : IEnumerable
   {
        //public Course()
        //{
        //    SelectListItemsCourse=new List<SelectListItem>();
        //}
        public int Id { get; set; }
        [Required]
        public int OrganizationId  { get; set; }
        public Organization Organization { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(10,MinimumLength = 2,ErrorMessage = "you should input length max 10 and minimum 2 ")]
        public string Code { get; set; }
        public string Duration { get; set; }
        public double Credit { get; set; }
        public string Outline { get; set; }
        public string Tags { get; set; }
        public bool IsDelete { get; set; }
        public IEnumerable<SelectListItem> SelectListItemsOraganization { get; set; }

       public IEnumerator GetEnumerator()
       {
           throw new NotImplementedException();
       }
   }
}
