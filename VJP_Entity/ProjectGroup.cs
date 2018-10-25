using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class ProjectGroup : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Minimum one group member is required.")]
        [ForeignKey("User"), Display(Name = "Member")]
        public int StudentId { get; set; }

        public virtual User User { get; set; }

        [Required(ErrorMessage = "Project is required.")]
        [ForeignKey("Project"), Display(Name = "Project")]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
