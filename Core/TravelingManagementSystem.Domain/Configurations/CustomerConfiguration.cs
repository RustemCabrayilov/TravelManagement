using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Domain.Configurations;

public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(x=>x.Name).HasMaxLength(200);
        builder.Property(x=>x.Surname).HasMaxLength(250);
        builder.Property(x=>x.Email).HasMaxLength(100);
        builder.Property(x => x.Phone).HasMaxLength(50);
        builder.Property(x => x.Nationality).HasMaxLength(40);
    }
}