using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
   public class Organization
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public string Code { get; set; }
        //public string Address { get; set; }
        //public string Contact { get; set; }
        //public string About { get; set; }
        //public string Logo{ get; set; }

        [NotMapped]
        public List<SelectListItem> SelectListItemsOraganization { get; set; }
    }
}
