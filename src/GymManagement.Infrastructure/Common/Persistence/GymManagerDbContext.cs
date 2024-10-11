using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistence;

public class GymManagerDbContext : DbContext
{
    public DbSet<Subscription> Subscriptions { get; set; } = null!;

    public GymManagerDbContext(DbContextOptions options) : base(options)
    {
    }
}