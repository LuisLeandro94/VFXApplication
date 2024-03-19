using System.ComponentModel.DataAnnotations;

namespace VFXFinancial.Models
{
    public class AccountModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Client ID is required")]
        public string ClientID {  get; set; }
        [Required(ErrorMessage = "User ID is required")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
