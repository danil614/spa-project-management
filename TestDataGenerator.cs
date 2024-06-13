using SpaProjectManagement.Models;

namespace SpaProjectManagement;

/// <summary>
/// Generates test data for the project.
/// </summary>
public static class TestDataGenerator
{
    public static Invoice[] GenerateInvoices()
    {
        return
        [
            new Invoice
            {
                Id = 1,
                ProjectId = 1,
                ClientId = 1,
                Amount = 30589.00m,
                IssueDate = DateTime.UtcNow,
                PaymentDate = null,
                StatusId = 3
            },
            new Invoice
            {
                Id = 2,
                ProjectId = 2,
                ClientId = 4,
                Amount = 1253.00m,
                IssueDate = DateTime.UtcNow,
                PaymentDate = DateTime.UtcNow.AddDays(1),
                StatusId = 2
            },
            new Invoice
            {
                Id = 3,
                ProjectId = 2,
                ClientId = 4,
                Amount = 256390.00m,
                IssueDate = DateTime.UtcNow,
                PaymentDate = null,
                StatusId = 1
            },
            new Invoice
            {
                Id = 4,
                ProjectId = 1,
                ClientId = 1,
                Amount = 3000.00m,
                IssueDate = DateTime.UtcNow,
                PaymentDate = null,
                StatusId = 1
            }
        ];
    }

    public static InvoiceStatus[] GenerateInvoiceStatuses()
    {
        return
        [
            new InvoiceStatus { Id = 1, Name = "Не оплачен" },
            new InvoiceStatus { Id = 2, Name = "Оплачен" },
            new InvoiceStatus { Id = 3, Name = "Просрочен" }
        ];
    }

    public static Role[] GenerateRoles()
    {
        return
        [
            new Role { Id = 1, Name = "Клиент", SystemName = "Client" },
            new Role { Id = 2, Name = "Менеджер", SystemName = "Manager" },
            new Role { Id = 3, Name = "Администратор", SystemName = "Admin" }
        ];
    }

    public static User[] GenerateUsers()
    {
        return
        [
            new User
            {
                Id = 1,
                Login = "john.doe",
                Password = "123456",
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890",
                Description = "Morning Client. Prefers morning appointments"
            },
            new User
            {
                Id = 2,
                Login = "jane.smith",
                Password = "123456",
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Phone = "0987654321",
                Description = "Expensive Project Manager"
            },
            new User
            {
                Id = 3,
                Login = "mike.johnson",
                Password = "123456",
                Name = "Mike Johnson",
                Email = "mike.johnson@example.com",
                Phone = "1122334455",
                Description = "Genius Architect"
            },
            new User
            {
                Id = 4,
                Login = "alice.brown",
                Password = "123456",
                Name = "Alice Brown",
                Email = "alice.brown@example.com",
                Phone = "5544332211",
                Description = "New User"
            }
        ];
    }

    public static UserRole[] GenerateUserRoles()
    {
        return
        [
            new UserRole { UserId = 1, RoleId = 1 }, // John Doe -> Client
            new UserRole { UserId = 2, RoleId = 2 }, // Jane Smith -> Manager
            new UserRole { UserId = 3, RoleId = 3 }, // Mike Johnson -> Admin
            new UserRole { UserId = 4, RoleId = 1 } // Alice Brown -> Client
        ];
    }

    public static Project[] GenerateProjects()
    {
        return
        [
            new Project
            {
                Id = 1,
                ClientId = 1,
                ResponsibleEmployeeId = 2,
                Name = "Relaxation Oasis",
                StartDate = DateTime.UtcNow,
                EndDate = null,
                Budget = 50000.00m,
                StatusId = 1,
                Description = "Creating a luxury spa complex with state-of-the-art facilities."
            },
            new Project
            {
                Id = 2,
                ClientId = 4,
                ResponsibleEmployeeId = 3,
                Name = "Serenity Springs",
                StartDate = DateTime.UtcNow.AddDays(-30),
                EndDate = DateTime.UtcNow.AddDays(180),
                Budget = 75000.00m,
                StatusId = 2,
                Description = "Renovation and expansion of an existing spa resort."
            }
        ];
    }

    public static ProjectStatus[] GenerateProjectStatuses()
    {
        return
        [
            new ProjectStatus { Id = 1, Name = "На согласовании" },
            new ProjectStatus { Id = 2, Name = "В процессе" },
            new ProjectStatus { Id = 3, Name = "Выполнен" },
            new ProjectStatus { Id = 4, Name = "Отменен" }
        ];
    }

    public static Service[] GenerateServices()
    {
        return
        [
            new Service
            {
                Id = 1,
                TypeId = 1,
                Name = "Строительство Роскошного СПА",
                Description = "Профессиональное строительство роскошного спа-комплекса"
            },
            new Service
            {
                Id = 2,
                TypeId = 2,
                Name = "Установка Устройств в СПА",
                Description = "Установка современного оборудования в спа-центре"
            },
            new Service
            {
                Id = 3,
                TypeId = 3,
                Name = "Дизайн и Оформление СПА",
                Description = "Индивидуальный дизайн и оформление вашего спа-комплекса"
            }
        ];
    }

    public static ServiceType[] GenerateServiceTypes()
    {
        return
        [
            new ServiceType { Id = 1, Name = "Роскошное строительство" },
            new ServiceType { Id = 2, Name = "Установка оборудования" },
            new ServiceType { Id = 3, Name = "Дизайн и оформление" }
        ];
    }
}