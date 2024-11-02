using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Domain.Configurations;

public class GuideConfiguration:IEntityTypeConfiguration<Guide>
{
    public void Configure(EntityTypeBuilder<Guide> builder)
    {
        builder.Property(x=>x.Name).HasMaxLength(200);
        builder.Property(x=>x.Surname).HasMaxLength(250);
        builder.Property(x=>x.Email).HasMaxLength(100);
        builder.Property(x => x.Phone).HasMaxLength(50);
        builder.Property(c => c.GuideType).HasConversion<string>();
        builder.Property(c => c.ShiftType).HasConversion<string>();
    }
}