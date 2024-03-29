﻿using Models.Domain;
namespace Models.DTO.UserDTO.Patient;
public class PatientPATCH : UserPatch
{
    public long PatientId { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
}
