using System.ComponentModel.DataAnnotations;

namespace ForumIT.Models.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "First name can't be empty")]
    
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name can't be empty")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "User name can't be empty")]
      //  [ValidName(ErrorMessage = "Name Not Exit")]
       // [StringLength(10, ErrorMessage = "Vui lòng không nhập giá trị quá 10 ký tự")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Email can't be empty")]
      //  [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password can't be empty")]
        // [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase,1 lowercase, 1 special character and 1 digit")]
        //[RegularExpression(@"^(?=.*\d).{8,}$", ErrorMessage = "Your Pas must start with 8 digits and containt 1 number.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Confirm can't be empty")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password does not match")]
        public string ConfirmPassword { get; set; }

        public string? Role { get; set; }
    }
}
