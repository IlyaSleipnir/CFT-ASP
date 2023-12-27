using System.ComponentModel.DataAnnotations;

namespace TaskCFT.Models.Entities
{
    public class WorkRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; } = "";
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Application Application { get; set; }
        public int ApplicationId { get; set; }

    }
}
