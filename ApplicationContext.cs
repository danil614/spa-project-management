using Microsoft.EntityFrameworkCore;
using spa_project_management.Models;

namespace spa_project_management;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectService> ProjectServices { get; set; }
    public DbSet<ProjectStatus> ProjectStatus { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Установка уникального ограничения на сочетание ServiceId и EffectiveDate
        modelBuilder.Entity<Price>()
            .HasIndex(p => new { p.ServiceId, p.EffectiveDate })
            .IsUnique();

        // Настройка отношений для User и Project
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Client)
            .WithMany(u => u.ClientProjects)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.ResponsibleEmployee)
            .WithMany(u => u.ResponsibleProjects)
            .HasForeignKey(p => p.ResponsibleEmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        // Добавление ролей
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Client" },
            new Role { Id = 2, Name = "Manager" },
            new Role { Id = 3, Name = "Architect" }
        );

        // Добавление тестовых пользователей
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890",
                Description = "Morning Client. Prefers morning appointments"
            },
            new User
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Phone = "0987654321",
                Description = "Expensive Project Manager"
            },
            new User
            {
                Id = 3,
                Name = "Mike Johnson",
                Email = "mike.johnson@example.com",
                Phone = "1122334455",
                Description = "Genius Architect"
            }
        );

        // Добавление записей в UserRole
        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { UserId = 1, RoleId = 1 }, // John Doe -> Client
            new UserRole { UserId = 2, RoleId = 2 }, // Jane Smith -> Manager
            new UserRole { UserId = 3, RoleId = 3 } // Mike Johnson -> Architect
        );
    }
}