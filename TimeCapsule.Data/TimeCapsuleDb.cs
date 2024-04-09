using Microsoft.EntityFrameworkCore;

namespace TimeCapsule.Data;

public class TimeCapsuleDb(DbContextOptions<TimeCapsuleDb> options) : DbContext(options)
{
    public DbSet<Models.TimeCapsule> TimeCapsules => Set<Models.TimeCapsule>();


}
