using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Domain.Configurations;
using TravelingManagementSystem.Domain.Enums;

namespace TravelingManagementSystem.Domain.Entities;
[EntityTypeConfiguration(typeof(GuideConfiguration))]
public class Guide:Person
{
    public GuideType GuideType { get; set; }
    public ShiftType ShiftType { get; set; }
}