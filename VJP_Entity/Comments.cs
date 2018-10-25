using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class Comments : Entity
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Type something to post comment."), Display(Name = "Comment")]
        //public string Comment { get; set; }


        //[Required(ErrorMessage = "User is required.")]
        //[ForeignKey("User"), Display(Name = "User")]
        //public int UserId { get; set; }

        //public virtual User User { get; set; }

        //[Required(ErrorMessage = "Project is required.")]
        //[ForeignKey("Project"), Display(Name = "Project")]
        //public int ProjectId { get; set; }

        //public virtual Project Project { get; set; }
    }
}
