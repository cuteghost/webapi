using Dental_App.Models.DTO.UserDTO.Patient;
using Dental_App.Validations.Interfaces.Users;

namespace Dental_App.Validations.Classes.Users;
public class PatientValidations : IPatientValidations
{
    public Common.Validations validations { get; set; }
    public readonly IUserValidations userValidations;
    public PatientValidations(IUserValidations userValidations)
    {
        this.userValidations = userValidations;
        this.validations = new Common.Validations();
    }
    public async Task<bool> ValidatePOST(PatientPOST newPatient)
    {
        if (userValidations.ValidateBasics(newPatient.FirstName, newPatient.LastName, newPatient.Password, newPatient.JMBG) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }
        if (await userValidations.ValidateJMBGUnique(jmbg: newPatient.JMBG) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }

        if (await userValidations.ValidateEmailUnique(email: newPatient.Email) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }
        return true;
    }
    public async Task<bool> ValidatePATCH(PatientPATCH patient)
    {
        if (userValidations.ValidateBasics(patient.FirstName, patient.LastName, patient.Password, patient.JMBG) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }
        if (await userValidations.ValidateJMBGUnique(jmbg: patient.JMBG) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }

        if (await userValidations.ValidateEmailUnique(email: patient.Email) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }
        return true;
    }
    public async Task<bool> ValidateDELETE(long adminId, long userId)
    {
        if (await userValidations.ValidateDeleteUser(adminId, userId) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }
        return true;
    }
}
