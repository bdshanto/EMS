using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
   public class Organization
    {
        public long Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public List<SelectListItem> SelectListItemsOraganization { get; set; }
    }
}
