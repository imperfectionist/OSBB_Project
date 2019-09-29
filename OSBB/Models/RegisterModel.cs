using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OSBB.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Адреса ел.пошти")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле має бути заповнено")]
        [StringLength(100, ErrorMessage = "Довжина паролю має бути від {2} символів", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(@"[a-z]+[0-9]+", ErrorMessage = "Пароль має містити латинські літери та цифри")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле має бути заповнено")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження пароля")]
        [Compare("Password", ErrorMessage = "Паролі не збігаються")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Поле має бути заповнено")]
        [Display(Name = "Номер квартири")]
        public int ApartmnentNumber { get; set; }

        [Required(ErrorMessage = "Поле має бути заповнено")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(13, ErrorMessage = "Некоректний формат вводу телефону. Будь-ласка, введіть телефон у форматі +380ХХХХХХХХХ", MinimumLength = 13)]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }
    }
}