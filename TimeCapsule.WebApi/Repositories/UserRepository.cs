using Microsoft.EntityFrameworkCore;
using TimeCapsule.Data;

namespace TimeCapsule.WebApi.Repositories;

public class UserRepository(TimeCapsuleDb db)
{
    public async Task<Data.Models.User> CreateUser(Data.Models.User user)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();

        return user;
    }

    public async Task<Data.Models.User?> GetUser(int id)
    {
        return await db.Users.FindAsync(id);
    }

    public async Task<Data.Models.User?> GetUserByEmail(string email)
    {
        return await db.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<Data.Models.User>> GetUsers()
    {
        return await db.Users.ToListAsync();
    }

    public async Task<Data.Models.User> UpdateUser(Data.Models.User user)
    {
        db.Users.Update(user);
        await db.SaveChangesAsync();

        return user;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await db.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        db.Users.Remove(user);
        await db.SaveChangesAsync();

        return true;
    }

}
