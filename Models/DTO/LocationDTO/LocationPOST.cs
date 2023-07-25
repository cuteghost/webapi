﻿using System.ComponentModel.DataAnnotations;

namespace Models.DTO.LocationDTO;
public class LocationPost
{
    public long Id { get; set; }
    
    [MaxLength(50)]
    [MinLength(5)]
    public string Country { get; set; } = string.Empty;
    [MaxLength(50)]
    [MinLength(5)]
    public string City { get; set; } = string.Empty;
    [MaxLength(50)]
    [MinLength(5)]
    public string Address { get; set; } = string.Empty;

}
