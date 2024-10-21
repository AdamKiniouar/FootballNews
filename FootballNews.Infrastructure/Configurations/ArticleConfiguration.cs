using Microsoft.EntityFrameworkCore;
using FootballNews.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballNews.Infrastructure.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired();

        builder.Property(t => t.Content)
            .IsRequired();

        builder.Property(t => t.Url)
            .IsRequired();

        builder.Property(t => t.Source)
            .IsRequired();

        builder.Property(t => t.PublishedDate).IsRequired();

        builder.Property(t => t.Published)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(t => t.FetchDate)
            .HasDefaultValueSql("GETDATE()");

        // Configure relationships
        builder.HasOne(a => a.Team)
            .WithMany(t => t.Articles)
            .HasForeignKey(a => a.TeamId);
    }
}