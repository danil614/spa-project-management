using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

/// <summary>
/// Repository for <see cref="ServiceType"/> model.
/// </summary>
/// <param name="context">Application database context</param>
public class ServiceTypeRepository(ApplicationContext context)
    : BaseRepository<ServiceType, ApplicationContext>(context), IServiceTypeRepository;