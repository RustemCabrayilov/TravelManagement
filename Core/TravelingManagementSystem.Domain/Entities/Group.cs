using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Domain.Configurations;

namespace TravelingManagementSystem.Domain.Entities;
[EntityTypeConfiguration(typeof(GroupConfiguration))]
public class Group:BaseEntity
{
    public short MemberCount { get; set; }
    public Guid GuideId { get; set; }
    public Guide Guide { get; set; }
    public ICollection<Customer> Customers { get; set; }
}