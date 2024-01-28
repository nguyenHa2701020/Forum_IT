﻿using System.ComponentModel.DataAnnotations;

namespace ForumIT.Models.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "User name can't be empty")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Pass word can't be empty")]
       // [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase,1 lowercase, 1 special character and 1 digit")]
        public string Password { get; set; }
    }
}
