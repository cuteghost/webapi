﻿using Dental_App.Models.Domain;
using Dental_App.Repository.Interfaces.Users.StaffInterfaces;
using server.Database;

namespace Dental_App.Repository.Classes.Users.StaffRepo;
public class StaffUpdate : IStaffUpdate
{
    private readonly DentalDBContext _dbContext;

	public StaffUpdate(DentalDBContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<long> UpdateStaffAsync(User user, Dental_App.Models.Domain.Staff staff)
	{
		try
		{
			_dbContext.Update(user);
			await _dbContext.SaveChangesAsync();

            _dbContext.Update(staff);
            await _dbContext.SaveChangesAsync();

			return user.Id;
        }
        catch (Exception)
		{

			throw;
		}
	}
}
