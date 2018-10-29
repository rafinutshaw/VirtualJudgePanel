using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{ 
    public class EventSubscribe : Entity
    {
        public int Id { get; set; }

        [ForeignKey("Student"), Required(ErrorMessage = "Student Id is required."), Display(Name = "Title")]
        public int StudentId { get; set; }
        
        
        [ForeignKey("Event"), Required(ErrorMessage = "Event Id required."), Display(Name = "Title")]
        public int EventId { get; set; }


        //[ForeignKey("EventCategory"), Display(Name = "Category Type")]
        //public int EventCategory_Id { get; set; }

        public virtual Event Event { get; set; }
        public virtual Student Student { get; set; }

    }
}
