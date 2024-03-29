﻿using Repository.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using server.Database;
using Models.Domain;

namespace Repository.Classes.Users;
public class UsersRead : IUsersRead
{
    private readonly DentalDBContext _dbContext;
    public UsersRead(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<long> GetUserByJMBG(string jmbg)
    {
        try
        {
            var userID = await _dbContext.Users.AsNoTracking().Where(s => s.JMBG == jmbg).Select(s => s.Id).FirstOrDefaultAsync();
            return userID; 
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<long> GetUserByEmail(string email)
    {
        try
        {
            var userID = await _dbContext.Users.AsNoTracking().Where(s => s.Email == email).Select(s => s.Id).FirstOrDefaultAsync();
            return userID;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<User> GetUserById(long id)
    {
        try
        {
            var user = await _dbContext.Users.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();
            return user;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
