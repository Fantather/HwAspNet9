using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HwAspNet9.InputModels
{
    public class UserInputModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Укажите имя длинной от 2 до 100 символов")]
        public string FirstName { get; init; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [MinLength(2, ErrorMessage = "Слишком короткая фамилия")]
        public string LastName { get; init; }

        [RegularExpression(@"^[a-zA-Z0-9_]+$", 
            ErrorMessage = "Игровое имя может содержать только Латинские Буквы, Цифры и подчёркивания")]
        [StringLength(20, ErrorMessage = "Длинна игрового имени не должна превышать 20 символов")]
        [Remote(action:"IsUserNameInUse", controller: "Account", ErrorMessage = "Игровое имя уже используется")]
        public string UserName { get; init; }


        [Range(minimum: 18, maximum: 100, ErrorMessage = "Допускается возраст от 18 до 100 лет")]
        public int Age { get; init; }


        [CreditCard(ErrorMessage = "Не верный формат номера банковской карты")]
        public string CreditCardNumber { get; init; }

        [Required(ErrorMessage = "Укажите электронную почту")]
        [EmailAddress(ErrorMessage = "Не верный формат электронной почты")]
        public string Email { get; init; }


        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, ErrorMessage = "Длинна пароля не может превышать 100 символов")]
        public string Password { get; init; }
        
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [StringLength(100, ErrorMessage = "Длинна пароля не может превышать 100 символов")]
        public string ConfirmPassword { get; init; }


        [RegularExpression(@"^((\+)?\b(8|38)?(0[\d]{2}))([\d-]{5,8})([\d]{2})$", ErrorMessage = "Не корректный номер телефона")]
        public string PhoneNumber { get; init; }

        [Url(ErrorMessage = "Не подходящий формат Url-адреса")]
        public string Website { get; init; }

        [ValidateNever]
        public string TermsOfService { get; init; }
    }
}
