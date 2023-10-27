using AdessoCoddingChallenge.Data;
using AdessoCoddingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace AdessoCoddingChallenge
{
    public class AppStart
    {
        //Bu class programın ilk başlangıcında ülkeleri ve takımları database e eklemek için kullanılıyor.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDBContext>>()))
            {

                if (context.Teams.Any() || context.Countries.Any())
                {
                    return;
                }

                var countries = new List<Country>
            {
                new Country
                {
                    Name = "Türkiye",
                    Teams = new List<Team>
                    {
                        new Team { Name = "Adesso İstanbul"},
                        new Team { Name = "Adesso Ankara"},
                        new Team { Name = "Adesso İzmir"},
                        new Team { Name = "Adesso Antalya"},
                    }
                },
               new Country
                {
                    Name = "Almanya",
                    Teams = new List<Team>
                    {
                        new Team { Name = "Adesso Berlin"},
                        new Team { Name = "Adesso Frankfurt"},
                        new Team { Name = "Adesso Münih"},
                        new Team { Name = "Adesso Dortmund"},
                    }
                },
                new Country
                {
                    Name = "Fransa",
                    Teams = new List<Team>
                    {
                        new Team { Name = "Adesso Paris"},
                        new Team { Name = "Adesso Marsilya"},
                        new Team { Name = "Adesso Nice"},
                        new Team { Name = "Adesso Lyon"},
                    }
                }, new Country
                {
                    Name = "Hollanda",
                    Teams = new List<Team>
                    {
                        new Team { Name = "Adesso Amsterdam"},
                        new Team { Name = "Adesso Rotterdam"},
                        new Team { Name = "Adesso Lahey"},
                        new Team { Name = "Adesso Eindhoven"},
                    }
                }, new Country
                {
                    Name = "Portekiz",
                    Teams = new List<Team>
                    {
                        new Team { Name = "Adesso Lisbon"},
                        new Team { Name = "Adesso Porto"},
                        new Team { Name = "Adesso Braga"},
                        new Team { Name = "Adesso Coimbra"},
                    }
                }, new Country
                {
                    Name = "Belçika",
                    Teams = new List<Team>
                    {
                        new Team { Name = "Adesso Brüksel"},
                        new Team { Name = "Adesso Brugge"},
                        new Team { Name = "Adesso Gent"},
                        new Team { Name = "Adesso Anvers"},
                    }
                }, new Country
                {
                    Name = "İtalya",
                    Teams = new List<Team>
                    {
                        new Team { Name = "Adesso Roma"},
                        new Team { Name = "Adesso Milano"},
                        new Team { Name = "Adesso Venedik"},
                        new Team { Name = "Adesso Napoli"},
                    }
                }, new Country
                {
                    Name = "İspanya",
                    Teams = new List<Team>
                    {
                        new Team { Name = "Adesso Sevilla"},
                        new Team { Name = "Adesso Madrid"},
                        new Team { Name = "Adesso Barselona"},
                        new Team { Name = "Adesso Granada"},
                    }
                },
            };

                context.Countries.AddRange(countries);

                context.SaveChanges();
            }
        }
    }
}
