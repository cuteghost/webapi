using System.Reflection;
using Services.PropertyService;

namespace Validations.Common.Validations;
public class ValidationsService : IValidationsService
{
    private readonly IPropertyService _propertyService;
    public ValidationsService(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }
    public ValidationModel GetValidationModel(string message, int statusCode, bool resultOfValidations)
    {
        return new ValidationModel
        {
            ValidationMessage = message,
            StatusCode = statusCode,
            ResultOfValidations = resultOfValidations
        };
    }
    public bool ValidateMinFieldLength(string field, int minLength)
    {
        if (field.Length < minLength)
        {
            return false;
        }
        return true;
    }
    public bool ValidateMaxFieldLength(string field, int maxLength)
    {
        if (field.Length > maxLength)
        {
            return false;
        }
        return true;
    }
    public (string,string) SetValidationFieldsLengthMessage((string minMess,string maxMess) customFieldLengthMessages, PropertyInfo propertyInfo){
        if (customFieldLengthMessages.minMess == "")
            customFieldLengthMessages.minMess = $"Minimum length of the field {_propertyService.GetPropertyName(propertyInfo)} is {_propertyService.GetMaxLengthOfTheFieldBasedOnAttributte(propertyInfo)}";
        if (customFieldLengthMessages.maxMess == "")
            customFieldLengthMessages.maxMess = $"Minimum length of the field {_propertyService.GetPropertyName(propertyInfo)} is {_propertyService.GetMinLengthOfTheFieldBasedOnAttributte(propertyInfo)}";
        return customFieldLengthMessages;
    }
    public ValidationModel ValidateFieldsLength(object myObject, string[] exceptFields, (string maxMess, string minMess) customFieldLengthMessages)
    {
        foreach (var propertyInfo in myObject.GetType().GetProperties())
        {
            /* if the field type is not string for example: Id, then this for that field is jumped */
            if (exceptFields.Contains(propertyInfo.Name) == true) { continue; }
                if (propertyInfo.GetValue(myObject).ToString() != null)
                {
                    (string maxMess, string minMess) fieldLengthMessage = SetValidationFieldsLengthMessage(customFieldLengthMessages,propertyInfo);
                    if (!ValidateMinFieldLength(_propertyService.GetPropertyValue(propertyInfo,myObject), _propertyService.GetMinLengthOfTheFieldBasedOnAttributte(propertyInfo)))
                    {
                        return GetValidationModel(fieldLengthMessage.minMess, 400, false);
                    }
                    if (!ValidateMaxFieldLength(_propertyService.GetPropertyValue(propertyInfo,myObject), _propertyService.GetMaxLengthOfTheFieldBasedOnAttributte(propertyInfo)))
                    {
                        return GetValidationModel( fieldLengthMessage.maxMess, 400, false);
                    }
                }
        }
        return new ValidationModel
        {
            StatusCode = 200,
            ResultOfValidations = true,
            ValidationMessage = "OK"
        };
    }
}
