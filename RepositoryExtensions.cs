using System.Reflection;
using SpaProjectManagement.Interfaces;

namespace SpaProjectManagement;

/// <summary>
/// Class with extension methods for IServiceCollection.
/// </summary>
public static class RepositoryExtensions
{
    /// <summary>
    /// Registers all repositories in the assembly.
    /// </summary>
    /// <param name="services">IServiceCollection instance</param>
    /// <param name="assembly">Assembly to scan for repositories</param>
    public static void AddRepositories(this IServiceCollection services, Assembly assembly)
    {
        var repositoryInterfaceType = typeof(IBaseRepository<>);

        // Получаем все классы, которые реализуют интерфейс базового репозитория и не являются абстрактными
        var repositoryTypes = assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } &&
                        t.GetInterfaces().Any(i => i.IsGenericType &&
                                                   i.GetGenericTypeDefinition() == repositoryInterfaceType));

        // Регистрируем эти классы с соответствующим интерфейсом
        foreach (var repositoryType in repositoryTypes)
        {
            var interfaceType = repositoryType.GetInterfaces()
                .First(i => !i.IsGenericType &&
                            i.GetInterfaces().Any(t => t.IsGenericType &&
                                                       t.GetGenericTypeDefinition() == repositoryInterfaceType));
            services.AddScoped(interfaceType, repositoryType);
        }
    }
}