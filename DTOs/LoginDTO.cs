using System.ComponentModel.DataAnnotations;

namespace TMKStore.DTOs
{
    public class LoginDTO
    {
        [Required (ErrorMessage = "Введите действующую почту"), DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required (ErrorMessage = "Введите пароль"), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
