using System.ComponentModel.DataAnnotations;

namespace StudioTemp.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        [MinLength(3,ErrorMessage ="Adiniz min 3simvoldan ibaret olmalidir")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "soyadiniz min 3simvoldan ibaret olmalidir")]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]     
        public string Email { get; set; }
        [MinLength(8)]
        [Required]
        [DataType(DataType.Password),Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
