using Microsoft.EntityFrameworkCore;
using SpaProjectManagement.Models;

namespace SpaProjectManagement;

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

        // Генерируем тестовые данные
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectStatus>().HasData(TestDataGenerator.GenerateProjectStatuses());
        modelBuilder.Entity<Project>().HasData(TestDataGenerator.GenerateProjects());
        modelBuilder.Entity<InvoiceStatus>().HasData(TestDataGenerator.GenerateInvoiceStatuses());
        modelBuilder.Entity<Invoice>().HasData(TestDataGenerator.GenerateInvoices());
        modelBuilder.Entity<Role>().HasData(TestDataGenerator.GenerateRoles());
        modelBuilder.Entity<User>().HasData(TestDataGenerator.GenerateUsers());
        modelBuilder.Entity<UserRole>().HasData(TestDataGenerator.GenerateUserRoles());
    }
}