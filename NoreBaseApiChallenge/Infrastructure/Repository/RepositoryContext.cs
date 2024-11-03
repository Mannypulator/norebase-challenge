using System;
using Microsoft.EntityFrameworkCore;
using NoreBaseApiChallenge.Domain.entity;
using NoreBaseApiChallenge.Infrastructure.Repository.Configuration;

namespace NoreBaseApiChallenge.Infrastructure.Repository;

public class RepositoryContext: DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options) { }

    public DbSet<Like> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfiguration(new LikeConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is Like &&(
                            e.State == EntityState.Added ||
                            e.State == EntityState.Modified
                        ));

        foreach(var entry in entries)
        {
            entry.Property("RowVersion").CurrentValue = DateTime.UtcNow.ToString("O");
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
