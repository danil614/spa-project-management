using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="Project"/> model.
/// </summary>
/// <param name="repository">Project repository to use</param>
[Route("api/[controller]")]
public class ProjectsController(IProjectRepository repository)
    : BaseController<Project, IProjectRepository>(repository)
{
    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Admin)]
    public override async Task<ActionResult<IEnumerable<Project>>> GetAllAsync(CancellationToken ct)
    {
        return await base.GetAllAsync(ct);
    }

    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Admin)]
    [HttpGet("excel")]
    public async Task<ActionResult> GetAllAtExcelAsync(CancellationToken ct)
    {
        var projects = await Repository.GetAllAsync(ct);
        var stream = new MemoryStream();

        using (var package = new ExcelPackage(stream))
        {
            var worksheet = package.Workbook.Worksheets.Add("Projects");
            worksheet.Cells[1, 1].Value = "Номер";
            worksheet.Cells[1, 2].Value = "Название";
            worksheet.Cells[1, 3].Value = "Клиент";
            worksheet.Cells[1, 4].Value = "Начало";
            worksheet.Cells[1, 5].Value = "Конец";
            worksheet.Cells[1, 6].Value = "Описание";

            var row = 2;
            foreach (var project in projects)
            {
                worksheet.Cells[row, 1].Value = project.Id;
                worksheet.Cells[row, 2].Value = project.Name;
                worksheet.Cells[row, 3].Value = project.Client?.Name;
                worksheet.Cells[row, 4].Value = project.StartDate.ToString("dd MMMM yyyy", new CultureInfo("ru-RU"));
                worksheet.Cells[row, 5].Value = project.EndDate?.ToString("dd MMMM yyyy", new CultureInfo("ru-RU"));
                worksheet.Cells[row, 6].Value = project.Description;
                row++;
            }

            worksheet.Cells["A1:C1"].Style.Font.Bold = true;
            worksheet.Cells.AutoFitColumns();

            await package.SaveAsync(ct);
        }

        stream.Position = 0;
        var excelName = $"Projects-{DateTime.Now:yyyyMMddHHmmssfff}.xlsx";

        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
    }

    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Client + Constants.Comma + RoleEnum.Admin)]
    public override async Task<ActionResult<Project>> GetByIdAsync(int id, CancellationToken ct)
    {
        return await base.GetByIdAsync(id, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Admin)]
    public override async Task<ActionResult> CreateAsync(Project entity, CancellationToken ct)
    {
        return await base.CreateAsync(entity, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Admin)]
    public override async Task<ActionResult> UpdateAsync(Project entity, CancellationToken ct)
    {
        return await base.UpdateAsync(entity, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Admin)]
    public override Task<ActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        return base.DeleteAsync(id, ct);
    }
}