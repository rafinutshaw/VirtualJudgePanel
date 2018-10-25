using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class Student : Entity
    {
        [Key, ForeignKey("User")]
        public int StudentId { get; set; }

        public virtual User User { get; set; }

        //[Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        public string About { get; set; }

        //[ForeignKey("EducationDetails")]
        //public int EducationDetailsId { get; set; }

        //[ForeignKey("ExperienceDetails")]
        //public int ExperienceDetailsId { get; set; }
        public List<EducationDetails> EducationDetails { get; set; }

        public List<ExperienceDetails> ExperienceDetails { get; set; }

        //public List<JobApplyActivity> JobApplyActivities { get; set; }
    }
}
