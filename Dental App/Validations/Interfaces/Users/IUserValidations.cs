using Dental_App.Models.Domain;
using Dental_App.Validations.Common;

namespace Dental_App.Validations.Interfaces.Users;
public interface IUserValidations
{
    //public readonly Common.Validations validations {get;set;}
    public bool ValidateBasics(string firstName, string lastName, string password, string jmbg);
    public Task<bool> ValidateJMBGUnique(string jmbg, long UserId = 0);
    public Task<bool> ValidateEmailUnique(string email, long UserId = 0);
    public Validation GetValidation();

    //TODO: Validacija sifre, regexom provjerit jel sifra kompleksna 
}
