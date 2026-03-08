using System.ComponentModel.DataAnnotations;

namespace MyFirstMVC.Models
{
    public class Cards
    {
        [Key]
        public int Id { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
    }
}
