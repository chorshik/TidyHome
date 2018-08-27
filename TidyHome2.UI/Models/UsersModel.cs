using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TidyHome2.DAL.Entities.Entities;

namespace TidyHome2.UI.Models
{
    public class UsersModel
    {
        public long IdUsers { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string Patronymic { get; set; }
        public string Email { get; set; }

        

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        [Phone(ErrorMessage = "Несуществующий телефон")]
        public string Phone { get; set; }

        [Display(Name = "Скидка")]
        public Nullable<int> Discount { get; set; }

        [Display(Name = "Категория")]
        public Nullable<long> IdType { get; set; }

        //public virtual TypeServiceModel TypeService { get; set; }

        public static explicit operator Users(UsersModel model)
        {
            if (model != null)
            {
                return new Users()
                {
                    IdUsers = model.IdUsers,
                    Surname = model.Surname,
                    Name = model.Name,
                    Patronymic = model.Patronymic,
                    Email = model.Email,                  
                    Address = model.Address,
                    Phone = model.Phone,
                    Discount = model.Discount,
                    IdType = model.IdType,
                };
            }
            return null;
        }

        public static explicit operator UsersModel(Users model)
        {
            if (model != null)
            {
                return new UsersModel()
                {
                    IdUsers = model.IdUsers,
                    Surname = model.Surname,
                    Name = model.Name,
                    Patronymic = model.Patronymic,
                    Email = model.Email,                  
                    Address = model.Address,
                    Phone = model.Phone,
                    Discount = model.Discount,
                    IdType = model.IdType,
                    //TypeService = (TypeServiceModel)model.TypeService
                };
            }
            return null;
        }
    }
}