﻿namespace Dental_App.Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsDelete
{
    public Task<long> DeletePatientAsync(long adminId, long userId);
}