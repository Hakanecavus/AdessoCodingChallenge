using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdessoCoddingChallenge.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Team> Teams { get; set; }
        public int? DrawResultId { get; set; }
        public DrawResult DrawResult { get; set; }
    }
}
