using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcessLayer.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserNameFrom { get; set; }
        public string Text { get; set;}
        [Required,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
