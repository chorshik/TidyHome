using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using TidyHome2.DAL.Entities.Entities;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace TidyHome2.UI.Models
{
    public class UserAccountRegistrationModel
    {
        [Display(Name = "Фамилия*")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string Surname { get; set; }

        [Display(Name = "Имя*")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string Name { get; set; }

        [Display(Name = "Отчество*")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string Patronymic { get; set; }

        [Display(Name = "Email*")]
        [Required(ErrorMessage = "Поле является обязательным")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Некорректный адрес")]
        [Remote("CheckEmail", "Account", HttpMethod = "POST", ErrorMessage = "Пользователь с данным Email уже зарегистрирован")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Display(Name = "Пароль*")]
        [Required(ErrorMessage = "Поле является обязательным")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль*")]
        [Required(ErrorMessage = "Поле является обязательным")]
        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

        

        [Display(Name = "Адрес*")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string Address { get; set; }

        [Display(Name = "Телефон*")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string Phone { get; set; }
        public Nullable<int> Discount { get; set; }
        

        [Display(Name = "Регистрация сотрудника?")]
        public bool Employee { get; set; }

        [Display(Name = "Категория")]
        public long IdType { get; set; }

        public static explicit operator Users(UserAccountRegistrationModel model)
        {
            if (model != null)
            {
                ASCIIEncoding enc = new ASCIIEncoding();
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                return new Users()
                {
                    Surname = model.Surname,
                    Name = model.Name,
                    Patronymic = model.Patronymic,
                    Email = model.Email,
                    Password = Regex.Replace(BitConverter.ToString(sha1.ComputeHash(enc.GetBytes(model.Password))), "-",
                        "").ToLower(),                   
                    Address = model.Address,                
                    Phone = model.Phone,
                    Discount = model.Discount,
                    IdType = model.Employee ? model.IdType : default(long?)
                };
            }

            return null;
        }

        public string[] GetRoles()
        {
            var roles = new List<string>();

            if (Employee) roles.Add("Employee");
            else
            {
                roles.Add("Сlient");               
            }

            return roles.ToArray();
        }
    }
}