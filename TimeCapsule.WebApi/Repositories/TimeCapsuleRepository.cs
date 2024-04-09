using Microsoft.EntityFrameworkCore;
using TimeCapsule.Data;

namespace TimeCapsule.WebApi.Repositories;

public class TimeCapsuleRepository(TimeCapsuleDb db)
{
    public async Task<Data.Models.TimeCapsule> CreateTimeCapsule(Data.Models.TimeCapsule timeCapsule)
    {
        db.TimeCapsules.Add(timeCapsule);
        await db.SaveChangesAsync();

        return timeCapsule;
    }

    public async Task<Data.Models.TimeCapsule?> GetTimeCapsule(int id)
    {
        return await db.TimeCapsules.FindAsync(id);
    }

    public async Task<List<Data.Models.TimeCapsule>> GetTimeCapsules()
    {
        return await db.TimeCapsules.ToListAsync();
    }

    public async Task<Data.Models.TimeCapsule> UpdateTimeCapsule(Data.Models.TimeCapsule timeCapsule)
    {
        db.TimeCapsules.Update(timeCapsule);
        await db.SaveChangesAsync();

        return timeCapsule;
    }

    public async Task<bool> DeleteTimeCapsule(int id)
    {
        var timeCapsule = await db.TimeCapsules.FindAsync(id);

        if (timeCapsule == null)
        {
            return false;
        }

        db.TimeCapsules.Remove(timeCapsule);
        await db.SaveChangesAsync();

        return true;
    }
}
