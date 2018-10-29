using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class Project : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required."), Display(Name = "Title")]
        public string Title { get; set; }

        public string Description { get; set; }

        [ScaffoldColumn(false), Column(TypeName = "DateTime2"), Display(Name = "Posting Date")]
        public DateTime PostingDate { get; set; }

        public string Path { get; set; }

        [Required(ErrorMessage = "Event is required.")]
        [ForeignKey("Event"), Display(Name = "Event")]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        [ForeignKey("Student"), Display(Name = "Posted by")]
        public int PostedBy { get; set; }

        [Display(Name ="Rating"), DefaultValue("ture")]
        public double TotalRatings { get; set; }

        ////[Required(ErrorMessage = "Event Category is required.")]
        ////[ForeignKey("EventCategory"), Display(Name = "Event Category")]
        ////public int EventCategoryId { get; set; }

        //public virtual EventCategory EventCategory { get; set; }


        [Required(ErrorMessage = "Category is required.")]
        [ForeignKey("ProjectCategory"), Display(Name = "Category")]
        public int ProjectCategoryId { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual Student Student { get; set; }



        //To get the list of group member of a project
        public List<ProjectGroup> GroupMember { get; set; }

        public List<Comments> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
