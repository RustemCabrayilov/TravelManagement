namespace TravelingManagementSystem.Domain.Entities;

public abstract class Person:BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DOB { get; set; }
}