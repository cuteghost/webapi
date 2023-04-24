using System.Reflection;

namespace Dental_App.Validations.Common.Validations;
public interface IValidationsService
{
    public ValidationModel GetValidationModel(string message, int statusCode, bool resultOfValidations);    
    public bool ValidateMinFieldLength(string field, int minLength);
    public bool ValidateMaxFieldLength(string field, int maxLength);
    public (string,string) SetValidationFieldsLengthMessage((string minMess,string maxMess) customFieldLengthMessages, PropertyInfo propertyInfo);
    public ValidationModel ValidateFieldsLength(object myObject, string[] exceptFields, (string maxMess, string minMess) customFieldLengthMessages);
}
