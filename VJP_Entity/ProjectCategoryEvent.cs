using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class ProjectCategoryEvent : Entity
    {
        //public int Id { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("ProjectCategory")]
        public int ProjectCategoryId { get; set; }

        public virtual Event Event { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }
    }
}
