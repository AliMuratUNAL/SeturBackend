using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportService.Models.Data;
using ReportService.Models.Entities;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public ReportController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateUpdateReport")]
        public async Task<IActionResult> GetReport()
        {
            var locationGroups = _dbContext.Contracts.Where(x => x.Location != null) // Location dolu olanlar
            .GroupBy(x => x.Location).Select(g => new
            {
                Location = g.Key,
                TotalCount = g.Count(), // Aynı Location'a sahip kişi sayısı
                PhoneNumberCount = g.Count(x => !string.IsNullOrEmpty(x.PhoneNumber))
            }).ToList();// Telefonu olanların sayısı

            // Check existing report
            foreach (var group in locationGroups)
            {
                var existingReport = _dbContext.Reports.FirstOrDefault(r => r.Location == group.Location);
                // Update
                if (existingReport != null)
                {
                    existingReport.PersonCount = group.TotalCount; existingReport.PhoneNumberCount = group.PhoneNumberCount;
                    existingReport.RequestDate = DateTime.UtcNow; existingReport.Status = ReportStatus.Completed;
                }
                // New Register 
                else
                {
                    var newReport = new Report
                    {
                        UUID = Guid.NewGuid(),
                        Location = group.Location,
                        PersonCount = group.TotalCount,
                        PhoneNumberCount = group.PhoneNumberCount,
                        RequestDate = DateTime.UtcNow,
                        Status = ReportStatus.Completed
                    };
                    await _dbContext.Reports.AddAsync(newReport);
                }
            }

            await _dbContext.SaveChangesAsync();
            return Ok("Report Created And Updated Successfully.");
        }

        [HttpGet("GetAll")]
        public async Task<List<Report>> GetAll()
        {
            return await _dbContext.Reports.ToListAsync();
        }

    }
}
