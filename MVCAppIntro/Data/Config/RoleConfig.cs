using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCAppIntro.Data.Config
{
  public class RoleConfig : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.HasKey(x => x.Id);
      builder.HasIndex(x => x.Name);
    }
  }
}
