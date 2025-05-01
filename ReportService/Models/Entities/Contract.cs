using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReportService.Models.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        [Column("UUID")]
        public Guid? UUID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Warning : Required Request")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Warning : Part numbers must be between 3 and 20 character in length.")]
        [Column("FirstName")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Required Request")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Warning : Part numbers must be between 3 and 20 character in length.")]
        [Column("LastName")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Required Request")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Warning : Part numbers must be between 2 and 20 character in length.")]
        [Column("Company")]
        public string? Company { get; set; }

        [StringLength(14, MinimumLength = 0, ErrorMessage = "Warning : Part numbers must be between 0 and 14 character in length.")]
        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [StringLength(40, MinimumLength = 0, ErrorMessage = "Warning : Part numbers must be between 0 and 40 character in length.")]
        [Column("Email")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Warning : Part numbers must be between 5 and 100 character in length.")]
        [Required(ErrorMessage = "Warning : Required Request")]
        [Column("Location")]
        public string? Location { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = "Warning : Part numbers must be between 0 and 100 character in length.")]
        [Column("InformationContent")]
        public string? InformationContent { get; set; } = default!;
    }
}

