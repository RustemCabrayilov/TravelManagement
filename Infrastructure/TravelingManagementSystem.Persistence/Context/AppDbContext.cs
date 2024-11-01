﻿using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Persistence.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Guide> Guides { get; set; }
    public DbSet<Group> Groups { get; set; }
}