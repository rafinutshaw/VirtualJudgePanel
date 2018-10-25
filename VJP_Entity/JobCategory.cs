using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class JobCategory : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }

        public List<JobPost> JobPost { get; set; }
    }
}
