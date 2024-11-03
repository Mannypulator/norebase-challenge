using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoreBaseApiChallenge.Domain.entity;

namespace NoreBaseApiChallenge.Infrastructure.Repository.Configuration;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(l => l.ArticleId);

        builder.Property(l => l.LikeCount).IsRequired();

        builder.Property(l => l.RowVersion).IsRowVersion()
                                            .IsConcurrencyToken()
                                            .HasDefaultValue("DATETIME('now')")
                                            .ValueGeneratedOnAddOrUpdate();
    }
}
