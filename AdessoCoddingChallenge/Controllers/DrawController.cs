using AdessoCoddingChallenge.Data;
using AdessoCoddingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdessoCoddingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DrawController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost("draw")]
        public async Task<IActionResult> Draw(int groupCount, string organizerName)
        {
            if (groupCount != 4 && groupCount != 8)
            {
                return BadRequest("Grup sayısı 4 veya 8 olmalıdır.");
            }

            if (string.IsNullOrWhiteSpace(organizerName))
            {
                return BadRequest("Kurayı Çeken kişinin bilgileri zorunludur.");
            }

            if (_context.Groups.Any())
            {
                return BadRequest("Daha Önce Kura çekilişi yapılmış.");
            }

            var groups = new List<Group>();
            for (var i = 0; i < groupCount; i++)//Grup isimlendirmesini bu noktada yapıyoruz
            {
                char groupName = (char)('A' + i);
                var group = new Group { Name = $"Group {groupName}" };
                group.Teams = new List<Team>();
                groups.Add(group);
            }

            var teams = _context.Teams.OrderBy(x => Guid.NewGuid()).ToList();

            var countryGroups = teams.GroupBy(t => t.CountryId).ToList();
            int groupIndex = 0;
            //Öncesinde grupları ülke kodlarına göre ayırıyoruz. Bu bize her gruba aynı ülkeden sadece bir takım koymamızda yardımcı olacak.
            foreach (var countryGroup in countryGroups)
            {
                
                foreach (var team in countryGroup)
                {
                    if (groupIndex >= 0 && groupIndex < groups.Count)
                    {
                        groups[groupIndex].Teams.Add(team);
                        groupIndex = (groupIndex + 1) % groupCount;
                    }
                    else
                    {
                        return StatusCode(500, "Takım dağılımları yapılırken hata oluştu.");
                    }
                }
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Groups.AddRange(groups);
                    _context.DrawResults.Add(new DrawResult { DrawnBy = organizerName });
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    return StatusCode(500, "Kura sonuçlarını kaydederken hata oluştu");
                }
            }

            return Ok(groups);
        }
    }
}
