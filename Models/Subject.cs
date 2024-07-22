using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Learning___Summer_Courses_.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage = "You have to provide a valid name.")]
        [MinLength(2, ErrorMessage = "Name mustn't be less than 2 characters.")]
        [MaxLength(20, ErrorMessage = "Name mustn't exceed 20 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You have to provide a valid Description.")]
        [MinLength(10, ErrorMessage = "Name Description be less than 10 characters.")]
        [MaxLength(50, ErrorMessage = "Name Description exceed 50 characters.")]
        public string Description { get; set; }
        public decimal RegistrationAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CreditHours { get; set; }
        public bool IsActive { get; set; }

        internal Subject FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
        [ValidateNever]
        public List<Student> Students { get; set; }

    }
}
