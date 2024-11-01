using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Domain.Configurations;

public class GuideConfiguration:IEntityTypeConfiguration<Guide>
{
    public void Configure(EntityTypeBuilder<Guide> builder)
    {
        builder.Property(c => c.GuideType).HasConversion<string>();
        builder.Property(c => c.ShiftType).HasConversion<string>();
    }
}