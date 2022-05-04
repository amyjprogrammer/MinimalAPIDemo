using DataAccess.DBAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    //this is a method
    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_Get", new { Id = id });
        return results.FirstOrDefault();
    }

    //created a new object, because not passing in the id created (SQL will add the ID)
    public Task InsertUser(UserModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName });

    //passed in the entire user(model), because we will use all the parts (id, first and last name)
    public Task UpdateUser(UserModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUser_Update", user);

    public Task DeleteUser(int id) =>
        _db.SaveData(storedProcedure: "dbo.spUser_Delete", new { Id = id });
}
