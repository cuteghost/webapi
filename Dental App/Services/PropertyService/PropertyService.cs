using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Services.PropertyService;

public class PropertyService : IPropertyService
{
    public PropertyService()
    {
        
    }
    public string GetPropertyName(PropertyInfo propertyInfo)
    {
        if(propertyInfo.Name != null) return propertyInfo.Name.ToString();
        return "";
    }
    public string GetPropertyValue(PropertyInfo propertyInfo,object myObject)
    {
        if (propertyInfo.GetValue(myObject) != null) return  propertyInfo.GetValue(myObject).ToString();
        return "";
    }
    public int GetMaxLengthOfTheFieldBasedOnAttributte(PropertyInfo propertyInfo)
    {
        if (propertyInfo.GetCustomAttributes(typeof(MaxLengthAttribute), false).FirstOrDefault() != null)
        {
                return propertyInfo.GetCustomAttributes(typeof(MaxLengthAttribute), false).Length;
        }
        return 0;
    }
    public int GetMinLengthOfTheFieldBasedOnAttributte(PropertyInfo propertyInfo)
    {
        if (propertyInfo.GetCustomAttributes(typeof(MinLengthAttribute), false).FirstOrDefault() != null)
        {
            return propertyInfo.GetCustomAttributes(typeof(MinLengthAttribute), false).Length;
        }
        return 0;
    }
}