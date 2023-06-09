using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wsei.Matches.Core.ContributorAggregate;

namespace Wsei.Matches.Infrastructure.Data.Config;
public class ContributorConfiguration : IEntityTypeConfiguration<Contributor>
{
  public void Configure(EntityTypeBuilder<Contributor> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();
  }
}
