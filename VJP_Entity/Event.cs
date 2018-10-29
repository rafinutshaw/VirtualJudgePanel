using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class Event : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required."), Display(Name = "Title")]
        public string EventTitle { get; set; }
        
        public string Description { get; set; }

        [Column(TypeName = "DateTime2"), Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; }

        [Column(TypeName = "DateTime2"), Display(Name = "Closing Date")]
        public DateTime ClosingDate { get; set; }

        //[ForeignKey("EventCategory"), Display(Name = "Category Type")]
        //public int EventCategory_Id { get; set; }

        //public virtual EventCategory EventCategory { get; set; }

        public List<ProjectCategory> ProjectCategory { get; set; }
        public List<EventSubscribe> EventSubscribes { get; set; }
        public List<ProjectCategoryEvent> ProjectCategoryEvents { get; set; }

        //public string Imageath { get; set; }
    }
}
