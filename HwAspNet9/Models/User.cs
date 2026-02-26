using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HwAspNet9.Models
{
    public class User(string firstName, string lastName, string userName, int age, string password, string email, string phoneNumber, string creditCardNumber, string website, string termsOfService, long id = 0)
    {
        public long Id { get; set; } = id;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string UserName { get; set; } = userName;
        public int Age { get; set; } = age;
        public string Password { get; set; } = password;
        public string Email { get; set; } = email;
        public string PhoneNumber { get; set; } = phoneNumber;
        public string CreditCardNumber { get; set; } = creditCardNumber;
        public string Website { get; set; } = website;
        public string TermsOfService { get; set; } = termsOfService;
    }
}
