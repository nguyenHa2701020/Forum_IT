using System.ComponentModel.DataAnnotations;

namespace ForumIT.Models
{
    public class CustomValidation
    {
    }

    public sealed class ValidBithDate: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime sDOB = Convert.ToDateTime(value);
            DateTime minD=Convert.ToDateTime("01-1-1975");
            DateTime maxD = Convert.ToDateTime("31-12-2005");
            if (sDOB > minD && sDOB < maxD)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }

    public sealed class ValidName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string name = (string)value;
            ForumITContext db=new ForumITContext();
            List<AspNetUser> users = db.AspNetUsers.ToList();
            AspNetUser user=users.Where(x=>x.UserName.Equals(name)).FirstOrDefault();
            if (user==null)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}
