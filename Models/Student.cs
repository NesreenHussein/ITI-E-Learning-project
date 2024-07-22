using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Learning___Summer_Courses_.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to provide a valid name.")]
        [MinLength(2, ErrorMessage = "Name mustn't be less than 2 characters.")]
        [MaxLength(20, ErrorMessage = "Name mustn't exceed 20 characters.")]
        public required string FullName { get; set; }
        public string StudentDepartment { get; set; }
        public string StudentAccount { get; set; }

        [MinLength(11, ErrorMessage = "Please enter vaild Phone Number")]
        public string StudentPhoneNumber { get; set; }
        public int StudentLevel { get; set; }


        [DisplayName("Subject")]
        public int SubjectId { get; set; }

        [ValidateNever]
        public Subject Subject { get; set; }//opject =>navigation Property
    }

    
}
 
 