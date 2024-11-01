using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Group = TravelingManagementSystem.Domain.Entities.Group;

namespace TravelingManagementSystem.Domain.Configurations;

public class GroupConfiguration:IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.Property(x => x.MemberCount).HasMaxLength(15);
    }
}