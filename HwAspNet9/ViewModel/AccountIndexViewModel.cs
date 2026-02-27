namespace HwAspNet9.ViewModel
{
    public record class AccountIndexViewModel(long Id, string FirstName, string LastName, string UserName, int Age, string Password, string Email, string PhoneNumber, string CreditCardNumber, string Website, string TermsOfService)
    {
    }
}
