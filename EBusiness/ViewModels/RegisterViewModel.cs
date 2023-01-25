using System.ComponentModel.DataAnnotations;

namespace EBusiness.ViewModels
{
    public class RegisterViewModel
    {

        [Required,StringLength(maximumLength:50)]
        public string Fullname { get; set; }
        [Required,StringLength(maximumLength:100)]
        public string Email { get; set; }
        [Required,StringLength(maximumLength:50)]
        public string Username { get; set; }
        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }  
        [Required, MinLength(8), DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfrimPassword { get; set; }
    }
}
