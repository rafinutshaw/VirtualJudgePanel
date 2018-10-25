using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class Organization : Entity
    {
        [Key, ForeignKey("User")]
        public int OrganizationId { get; set; }

        public virtual User User { get; set; }

        //[Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Display(Name = "Web Url")]
        public string WebUrl { get; set; }

        public string Description { get; set; }

        public List<JobPost> JobPost { get; set; }
    }
}
