using AdessoCoddingChallenge.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdessoCoddingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly ApplicationDBContext _context;
        public GroupController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var groupData = await _context.Groups
        .Select(g => new
        {
            groupName = g.Name,
            teams = g.Teams.Select(t => new
            {
                name = t.Name
            })
        })
        .ToListAsync();

            var result = new { groups = groupData };

            return Ok(result);
        }
    }
}
