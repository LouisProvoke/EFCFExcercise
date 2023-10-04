using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCFExcercise.Models
{
    public class Title
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TitleId { get; set; }
        public string TitleDescription { get; set; }
    }
}
