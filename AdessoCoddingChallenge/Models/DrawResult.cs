using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdessoCoddingChallenge.Models
{
    public class DrawResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string DrawnBy { get; set; }

        public List<Group> Groups { get; set; }
    }
}
