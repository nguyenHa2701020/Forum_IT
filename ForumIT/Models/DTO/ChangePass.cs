using System.ComponentModel.DataAnnotations;

namespace ForumIT.Models.DTO
{
    public class ChangePass
    {
        [Required(ErrorMessage = "Pass Old can't be empty")]
        public string PasswordOld { get; set; }

        [Required(ErrorMessage = "Pass New can't be empty")]
    //    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase,1 lowercase, 1 special character and 1 digit")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Pass New can't be empty")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
