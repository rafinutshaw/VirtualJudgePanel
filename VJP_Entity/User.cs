using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class User : Entity
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Email is required"), DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format"), StringLength(60)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public string Password { get; set; }

        [ScaffoldColumn(false), Column(TypeName = "DateTime2")]
        public DateTime CreateDate { get; set; }

        [ForeignKey("AccountType"), Display(Name = "Account Type")]
        public int AccountType_Id { get; set; }

        public virtual AccountType AccountType { get; set; }

        //To get the submitted project of a user
        public List<ProjectGroup> Projects { get; set; }

        public List<Comments> Comments { get; set; }

        //public int Id { get; set; }

        //[Required(ErrorMessage = "Username is required")]
        //public string Username { get; set; }

        //[Required(ErrorMessage = "Email is required"), DataType(DataType.EmailAddress)]
        //[RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        //public string Password { get; set; }

        ////[NotMapped, Display(Name = "Confirm Password")]
        ////[Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        ////[Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        ////public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Gender is required")]
        //public string Gender { get; set; }

        //[Display(Name = "Image")]
        //public string ImagePath { get; set; }

        //[ScaffoldColumn(false), Column(TypeName = "DateTime2")]
        //public DateTime? ModificationDate { get; set; }

        //[Display(Name = "Account Type"), Column("Account Type")]
    }
}
