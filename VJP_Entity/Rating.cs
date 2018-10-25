using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class Rating : Entity
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Rating is required"), Display(Name = "Rating")]
        //public double Ratings { get; set; }


        //[Required(ErrorMessage = "Judge is required.")]
        //[ForeignKey("Judge"), Display(Name = "Judge")]
        //public int JudgeId { get; set; }

        //public virtual Judge Judge { get; set; }

        //[Required(ErrorMessage = "Project is required.")]
        //[ForeignKey("Project"), Display(Name = "Project")]
        //public int ProjectId { get; set; }

        //public virtual Project Project { get; set; }
    }
}
