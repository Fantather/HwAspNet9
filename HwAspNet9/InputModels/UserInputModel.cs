using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HwAspNet9.InputModels
{
    public record class UserInputModel(string firstName, string lastName, string userName, string creditCardNumber, int age, string password, string confirmPassword, string email, string phoneNumber, string website, string termsOfService)
    {
        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Укажите имя длинной от 2 до 100 символов")]
        public string FirstName { get; init; } = firstName;

        [Required(ErrorMessage = "Укажите фамилию")]
        [MinLength(2, ErrorMessage = "Слишком короткая фамилия")]
        public string LastName { get; init; } = lastName;

        [RegularExpression(@"^[a-zA-Z0-9_]+$", 
            ErrorMessage = "Игровое имя может содержать только Латинские Буквы, Цифры и подчёркивания")]
        [StringLength(20, ErrorMessage = "Длинна игрового имени не должна превышать 20 символов")]
        [Remote(action:"IsUserNameInUse", controller: "Account", ErrorMessage = "Игровое имя уже используется")]
        public string UserName { get; init; } = userName;


        [Range(minimum: 18, maximum: 100, ErrorMessage = "Допускается возраст от 18 до 100 лет")]
        public int Age { get; init; } = age;


        [CreditCard(ErrorMessage = "Не верный формат номера банковской карты")]
        public string CreditCardNumber { get; init; } = creditCardNumber;

        [Required(ErrorMessage = "Укажите электронную почту")]
        [EmailAddress(ErrorMessage = "Не верный формат электронной почты")]
        public string Email { get; init; } = email;


        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, ErrorMessage = "Длинна пароля не может превышать 100 символов")]
        public string Password { get; init; } = password;
        
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [StringLength(100, ErrorMessage = "Длинна пароля не может превышать 100 символов")]
        public string ConfirmPassword { get; init; } = confirmPassword;


        [RegularExpression(@"^((\+)?\b(8|38)?(0[\d]{2}))([\d-]{5,8})([\d]{2}", ErrorMessage = "Не корректный номер телефона")]
        public string PhoneNumber { get; init; } = phoneNumber;

        [Url(ErrorMessage = "Не подходящий формат Url-адреса")]
        public string Website { get; init; } = website;

        [ValidateNever]
        public string TermsOfService { get; init; } = termsOfService;
    }
}
