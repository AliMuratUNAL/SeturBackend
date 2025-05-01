using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReportService.Models.Entities
{
    [Table("Reports")]
    public class Report
    {
        [Key]
        [Column("UUID")]
        public Guid? UUID { get; set; } = Guid.NewGuid();

        [Column("Location")]
        public string? Location { get; set; }

        [Column("PersonCount")]
        public int PersonCount { get; set; }

        [Column("PhoneNumberCount")]
        public int PhoneNumberCount { get; set; }

        [Column("RequestDate")]
        public DateTime? RequestDate { get; set; } = DateTime.UtcNow;

        [Column("Status")]
        public ReportStatus Status { get; set; } = ReportStatus.Preparing;

    }

    public enum ReportStatus
    {
        Preparing = 0,
        Completed = 1
    }
}