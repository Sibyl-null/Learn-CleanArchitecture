using System.Reflection;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistence;

public class GymManagerDbContext : DbContext, IUnitOfWork
{
    public DbSet<Subscription> Subscriptions { get; set; } = null!;

    public GymManagerDbContext(DbContextOptions options) : base(options)
    {
    }

    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}