using System.ComponentModel.DataAnnotations;

namespace EFCFExcercise.Models.Dto.Staff
{
    public class StaffDto
    {
        public int? TitleId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
