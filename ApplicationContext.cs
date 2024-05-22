using Microsoft.EntityFrameworkCore;
using spa_project_management.Models;
using Task = spa_project_management.Models.Task;

namespace spa_project_management;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemType> ItemTypes { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectItem> ProjectItems { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Добавление ролей
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, RoleName = "Client" },
            new Role { RoleId = 2, RoleName = "Employee" }
        );

        // Добавление тестовых пользователей
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890",
                RoleId = 1, // Client
                Description = "Prefers morning appointments"
            },
            new User
            {
                UserId = 2,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Phone = "0987654321",
                RoleId = 2, // Employee
                Description = "Massage Therapist"
            },
            new User
            {
                UserId = 3,
                Name = "Mike Johnson",
                Email = "mike.johnson@example.com",
                Phone = "1122334455",
                RoleId = 2, // Employee
                Description = "Spa Manager"
            }
        );
    }
}