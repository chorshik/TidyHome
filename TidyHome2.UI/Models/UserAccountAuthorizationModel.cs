using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TidyHome2.UI.Models
{
    public class UserAccountAuthorizationModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Поле является обязательным")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Некорректный адрес")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле является обязательным")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}