using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class JobPost : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required."), Display(Name = "Title")]
        public string JobTitle { get; set; }

        [ForeignKey("JobCategory"), Display(Name = "Category")]
        public int JobCategoryId { get; set; }

        public virtual JobCategory JobCategory { get; set; }
        
        public bool FullTimeJob { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public string Address { get; set; }

        [Column(TypeName = "DateTime2"), Display(Name = "Posted on")]
        public DateTime PostingDate { get; set; }

        [Column(TypeName = "DateTime2"), Display(Name = "Deadline")]
        public DateTime LastDate { get; set; }

        [ForeignKey("Organization"), Display(Name = "Posted by")]
        public int PostedBy { get; set; }

        public virtual Organization Organization { get; set; }

        public List<JobApplyActivity> JobApplyActivities { get; set; }
    }
}
