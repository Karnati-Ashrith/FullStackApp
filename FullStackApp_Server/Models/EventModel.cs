using System.ComponentModel.DataAnnotations;

namespace FullStackApp_Server.Models
{
    public class EventModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
