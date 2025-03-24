using System.ComponentModel.DataAnnotations;

namespace TMKStore.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required (ErrorMessage = "Необходимо ввести имя")]
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        [Required (ErrorMessage = "Введённые пароли не совпадают"), Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
