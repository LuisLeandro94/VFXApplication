using System.ComponentModel.DataAnnotations;

namespace VFXFinancial.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "ClientID is required")]
        public string? ClientID {  get; set; }
        [Required(ErrorMessage = "UserID is required")]
        public string? UserID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
