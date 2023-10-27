using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdessoCoddingChallenge.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
