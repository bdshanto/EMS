using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
   public class Course
    {
        //public Course()
        //{
        //    SelectListItemsCourse=new List<SelectListItem>();
        //}
        public int Id { get; set; }
        [Required]
        [Display(Name = "Organization")]
        public int OrganizationId  { get; set; }
        public Organization Organization { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(10,MinimumLength = 2)]
        public string Code { get; set; }
        public string Duration { get; set; }
        public double Credit { get; set; }
        public string Outline { get; set; }
        public string Tags { get; set; }
        public bool IsDelete { get; set; }
        public IEnumerable<SelectListItem> SelectListItemsOraganization { get; set; }
    }
}
