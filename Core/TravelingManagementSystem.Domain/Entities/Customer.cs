﻿using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Domain.Configurations;
namespace TravelingManagementSystem.Domain.Entities;
[EntityTypeConfiguration(typeof(CustomerConfiguration))]
public class Customer:Person
{
    public string Nationality { get; set; }
    public bool IsHealty { get; set; }
    public Guid GroupId { get; set; }
    public Group Group { get; set; }    
}