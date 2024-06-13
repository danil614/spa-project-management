using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

/// <summary>
/// Repository for <see cref="Price"/> model.
/// </summary>
/// <param name="context">Application database context</param>
public class PriceRepository(ApplicationContext context)
    : BaseRepository<Price, ApplicationContext>(context), IPriceRepository;