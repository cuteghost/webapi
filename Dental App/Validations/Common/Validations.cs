using server.Database;
namespace Dental_App.Validations.Common;
public class Validations
{ 
    public Validation validation { get; set; }

    public Validations()
    {
        validation = new Validation();
    }
    public bool ValidateLength(string field, int minLength = 3, int maxLength = 4000)
    {
        if (field.Length > maxLength)
        {
            validation.statusCode = 400;
            validation.validationMessage = string.Format("'{0}' is too long (max length = {1})!",field,maxLength);
            return false;
        }
        if (field.Length < minLength)
        {
            validation.statusCode = 400;
            validation.validationMessage = string.Format("'{0}' is too short (min length = {1})!", field, minLength);
            return false;
        }
        validation.statusCode = 200;
        return true;
    }
    public Validation GetValidation()
    {
        return validation;
    }
}
