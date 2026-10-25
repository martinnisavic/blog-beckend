using DataAccess;
using Domain.Entities;

namespace BlogApi.Seed
{
    public static class DatabaseSeeder
    {
        public static void Seed(BlogDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new RoleEntity { Name = "User", CreatedAt = DateTime.UtcNow });
                context.Roles.Add(new RoleEntity { Name = "Admin", CreatedAt = DateTime.UtcNow });
                context.SaveChanges();
            }
            if (!context.UseCases.Any())
            {
                var names = new[]
                {
                    "get-categories",
                    "rate-post",
                    "create-post",
                    "get-posts",
                    "get-post",
                    "update-post",
                    "delete-post",
                    "get-comments",
                    "update-comment",
                    "delete-comment",
                    "create-comment",
                    "account-activate",
                    "get-users",
                    "delete-comment"
                };

                foreach (var name in names)
                {
                    context.UseCases.Add(new UseCaseEntity
                    {
                        Name = name,
                        CreatedAt = DateTime.UtcNow,
                    });
                }
                context.SaveChanges();
            }

            if(!context.Users.Any())
            {
                int userRoleId = context.Roles.First(r => r.Name == "User").Id;
                int adminRoleId = context.Roles.First(r => r.Name == "Admin").Id;

                context.Users.Add(new UserEntity
                {
                    Name = "Test",
                    Surname = "User",
                    Username = "user",
                    Email = "user@gmail.com",
                    Phone = "060000000",
                    Password = BCrypt.Net.BCrypt.HashPassword("Test1234"),
                    RoleId = userRoleId,
                    ActivatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                });

                context.Users.Add(new UserEntity
                {
                    Name = "Test",
                    Surname = "Admin",
                    Username = "admin",
                    Email = "admin@gmail.com",
                    Phone = "060000001",
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin1234"),
                    RoleId = adminRoleId,
                    ActivatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                });

                var extraUsers = new[]
                {
                    ("Marko", "Markovic", "marko", "marko@gmail.com", "060000002", "Marko1234"),
                    ("Ana", "Anic", "ana", "ana@gmail.com", "060000003", "Ana1234"),
                    ("Petar", "Petrovic", "petar", "petar@gmail.com", "060000004", "Petar1234"),
                };
                foreach (var (name, surname, username, email, phone, pass) in extraUsers)
                {
                    context.Users.Add(new UserEntity
                    {
                        Name = name,
                        Surname = surname,
                        Username = username,
                        Email = email,
                        Phone = phone,
                        Password = BCrypt.Net.BCrypt.HashPassword(pass),
                        RoleId = userRoleId,
                        ActivatedAt = DateTime.UtcNow,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                context.SaveChanges();
            }

            if(!context.RoleUseCases.Any())
            {
                int RoleId(string name) => context.Roles.First(r => r.Name == name).Id;
                int UcId(string name) => context.UseCases.First(c => c.Name == name).Id;

                var userUseCases = new[] { "get-posts", "get-post", "get-comments", "get-categories", "rate-post", "create-post", "update-post", "delete-post", "create-comment", "delete-comment" };

                var adminUseCases = new[] { "get-categories",
                    "rate-post",
                    "create-post",
                    "get-posts",
                    "get-post",
                    "update-post",
                    "delete-post",
                    "get-comments",
                    "update-comment",
                    "delete-comment",
                    "create-comment",
                    "account-activate",
                    "get-users",
                    "delete-comment"
                };

                if (!context.Categories.Any())
                {
                    var categoryNames = new[] { "Tehnologija", "Sport", "Muzika", "Film", "Putovanja", "Hrana","Restorani" };
                    foreach (var name in categoryNames)
                    {
                        context.Categories.Add(new CategoryEntity { Name = name, CreatedAt = DateTime.UtcNow });
                    }
                    context.SaveChanges();
                }

                foreach (var uc in userUseCases)
                    context.RoleUseCases.Add(new RoleUseCaseEntity { RoleId = RoleId("User"), UseCaseId = UcId(uc) });

                foreach (var uc in adminUseCases)
                    context.RoleUseCases.Add(new RoleUseCaseEntity { RoleId = RoleId("Admin"), UseCaseId = UcId(uc) });

                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                int U(string username) => context.Users.First(x => x.Username == username).Id;
                int C(string name) => context.Categories.First(x => x.Name == name).Id;

                PostEntity Post(string title, string desc, string user, string cat, string imgSeed, int daysAgo) => new PostEntity
                {
                    Title = title,
                    Description = desc,
                    UserId = U(user),
                    CategoryId = C(cat),
                    CreatedAt = DateTime.UtcNow.AddDays(-daysAgo),
                    Images = new List<ImageEntity>
                    {
                        new ImageEntity { Path = $"https://images.unsplash.com/photo-{imgSeed}?w=640&h=400&fit=crop", CreatedAt = DateTime.UtcNow }
                    }
                };

                var posts = new[]
                {
                    Post("Uvod u Angular signale",
                        "Signali su nova osnova reaktivnosti u Angular-u. U ovom tekstu objašnjavam po čemu se razlikuju od RxJS-a, kada ih koristiti za držanje stanja, i kako computed i effect menjaju način na koji pišemo komponente. Prolazimo kroz praktične primere iz stvarnog projekta i česte greške početnika.",
                        "user", "Tehnologija", "1461749280684-dccba630e2f6", 12),
                    Post("Finale lige šampiona",
                        "Finale ove sezone bilo je jedno od najuzbudljivijih u poslednjih nekoliko godina. Analiziramo ključne momente, taktičke poteze oba trenera i individualne partije koje su presudile ishod. Osvrćemo se i na to šta ovaj rezultat znači za narednu sezonu i transfere.",
                        "marko", "Sport", "1579952363873-27f3bade9f55", 11),
                    Post("Najbolji albumi 2026",
                        "Godina je donela mnoštvo sjajnih izdanja u svim žanrovima. Izdvajamo albume koji su obeležili scenu, od rok povrataka do svežih hip-hop i pop projekata. Za svaki album dajemo kratku recenziju i preporuku pesme za početak slušanja.",
                        "ana", "Muzika", "1511379938547-c1f69419868d", 10),
                    Post("Recenzija novog sci-fi filma",
                        "Najnoviji naučnofantastični spektakl stigao je uz velika očekivanja. U recenziji bez spojlera govorimo o režiji, vizuelnim efektima i scenariju, kao i o tome da li film opravdava hajp. Na kraju dajemo ocenu i kome ga preporučujemo.",
                        "petar", "Film", "1440404653325-ab127d49abc1", 9),
                    Post("Vodič za putovanje po Italiji",
                        "Italija je zemlja koja ima sve — istoriju, hranu, more i planine. U ovom vodiču delimo rutu kroz najlepše gradove, savete za budžet, prevoz i smeštaj, kao i skrivene destinacije koje turisti često preskoče. Idealno za planiranje prvog putovanja.",
                        "marko", "Putovanja", "1552832230-c0197dd311b5", 8),
                    Post("Recept: domaća pica",
                        "Savršena domaća pica nije teška ako znaš par trikova. Objašnjavam korak po korak pripremu testa, odabir sastojaka i pečenje da kora bude hrskava a sredina mekana. Dajem i varijacije za vegetarijance i ljubitelje ljute hrane.",
                        "ana", "Hrana", "1513104890138-7c749659a591", 7),
                    Post("Top 5 restorana u Beogradu",
                        "Beograd ima bogatu gastronomsku scenu, od tradicionalnih kafana do modernih bistroa. Izdvajamo pet mesta koja vredi posetiti, sa utiscima o hrani, ambijentu i ceni. Za svaki restoran dajemo preporuku šta obavezno naručiti.",
                        "petar", "Restorani", "1517248135467-4c7edcad34c4", 6),
                    Post(".NET 10 novine",
                        "Nova verzija .NET-a donosi niz poboljšanja u performansama i produktivnosti. Prolazimo kroz najvažnije novine u jeziku i runtime-u, promene u EF Core-u i alatima, i kako migrirati postojeće projekte. Uz primere koda za svaku ključnu funkciju.",
                        "user", "Tehnologija", "1498050108023-c5249f4df085", 5),
                    Post("Košarkaški kup — pregled",
                        "Ovogodišnji košarkaški kup doneo je iznenađenja i sjajne mečeve. Pravimo pregled rezultata, najboljih igrača i momenata koji su oduševili publiku. Analiziramo i forme ekipa pred nastavak sezone.",
                        "marko", "Sport", "1546519638-68e109498ffc", 3),
                    Post("Koncert godine",
                        "Koncert o kom se priča nedeljama zaista je opravdao sva očekivanja. Prenosimo utiske sa lica mesta, od produkcije i zvuka do energije publike. Uz set-listu i preporuku za one koji planiraju da odu na naredne nastupe.",
                        "ana", "Muzika", "1470229722913-7c0e2dbbafd3", 1),
                };
                context.Posts.AddRange(posts);
                context.SaveChanges();
            }

            if (!context.Comments.Any())
            {
                int U(string username) => context.Users.First(x => x.Username == username).Id;
                var allPosts = context.Posts.OrderBy(p => p.Id).ToList();
                var commenters = new[] { "user", "marko", "ana", "petar", "admin" };
                var texts = new[]
                {
                    "Odličan tekst, baš mi je koristio! Jedva čekam nastavak na ovu temu.",
                    "Slažem se sa svime što si napisao, vrlo jasno i detaljno objašnjeno.",
                    "Hvala na preporukama, probaću svakako i javiću utiske.",
                    "Zanimljivo, nisam ovako gledao na ovu temu do sada.",
                    "Super napisano, nastavi tako! Pratim tvoje objave redovno.",
                };
                int i = 0;
                foreach (var p in allPosts)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        context.Comments.Add(new CommentEntity
                        {
                            Text = texts[(i + k) % texts.Length],
                            AuthorId = U(commenters[(i + k + 1) % commenters.Length]),
                            PostId = p.Id,
                            CreatedAt = DateTime.UtcNow.AddDays(-1)
                        });
                    }
                    i++;
                }
                context.SaveChanges();
            }

            if (!context.Ratings.Any())
            {
                int U(string username) => context.Users.First(x => x.Username == username).Id;
                var allPosts = context.Posts.OrderBy(p => p.Id).ToList();
                var raters = new[] { "user", "marko", "ana", "petar" };
                var values = new[] { 5, 4, 5, 3, 4 };
                int i = 0;
                foreach (var p in allPosts)
                {
                    for (int k = 0; k < 3; k++)   // 3 ocene od različitih korisnika (unique UserId+PostId)
                    {
                        context.Ratings.Add(new RatingEntity
                        {
                            UserId = U(raters[(i + k) % raters.Length]),
                            PostId = p.Id,
                            Value = values[(i + k) % values.Length],
                            CreatedAt = DateTime.UtcNow.AddDays(-1)
                        });
                    }
                    i++;
                }
                context.SaveChanges();
            }
        }
    }
}
