using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc_for_angular.frontend.client_app.src.app.ViewModels
{
    public class Registration
    {

        [Required(ErrorMessage ="Login field is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Email  field is required")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password field is required")]
        [StringLength(5,ErrorMessage ="Password must be more 5 symbols",MinimumLength =5)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password must be identical")]
        public string ConfirmPassword {  get; set; }


    }
}
