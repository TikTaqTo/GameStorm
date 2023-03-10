using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using GameService.Domain.Requests;
using GameService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.VideoGame {

  public class GamesService : IGameService {
    private readonly GameServiceContext _context;

    public GamesService(GameServiceContext context) {
        _context = context;

        List<Game> games = new()
        {
            new Game() {
                Id = Guid.NewGuid(),
                Title = "Grand Theft Auto V",
                NormalizedTitle = "grand theft auto v",
                Website = "http://www.rockstargames.com/V/",
                AgeRating = "17+",
                ReleaseDate = new DateTime(2020, 2, 10),
                TBA = true,
                Description = "Хорошая игра",
                Status = "Вышел"
            },
            new Game() {
                Id = Guid.NewGuid(),
                Title = "Dying Light 2 Stay Human",
                NormalizedTitle = "dying light 2 stay human",
                Website = "https://dyinglightgame.com/",
                AgeRating = "Без рейтинга",
                TBA = true,
                ReleaseDate = new DateTime(2022, 2, 4),
                Description = "Очень хорошая игра",
                Status = "Вышел"
            },
            new Game() {
                Id = Guid.NewGuid(),
                Title = "Ведьмак 3: Дикая охота",
                NormalizedTitle = "ведьмак 3: дикая охота",
                Website = "https://thewitcher.com/en/witcher3",
                AgeRating = "17+",
                TBA = true,
                ReleaseDate = new DateTime(2022, 2, 4),
                Description = "Очень хорошая игра",
                Status = "Вышел"
            },
            new Game() {
                Id = Guid.NewGuid(),
                Title = "Portal 2",
                NormalizedTitle = "portal 2",
                Website = "http://www.thinkwithportals.com/",
                AgeRating = "10+",
                TBA = true,
                ReleaseDate = new DateTime(2022, 2, 4),
                Description = "Хорошая игра",
                Status = "Вышел"
            },
            new Game() {
                Id = Guid.NewGuid(),
                Title = "God of War",
                NormalizedTitle = "god of war",
                Website = "https://godofwar.playstation.com/",
                AgeRating = "17+",
                TBA = true,
                ReleaseDate = new DateTime(2022, 9, 13),
                Description = "Очень хорошая игра",
                Status = "Вышел"
            },
            new Game() {
                Id = Guid.NewGuid(),
                Title = "Darksiders III",
                NormalizedTitle = "darksiders iii",
                Website = "http://www.darksiders.com",
                AgeRating = "17+",
                TBA = true,
                ReleaseDate = new DateTime(2022, 2, 4),
                Description = "В Darksiders III вам предстоит вернуться на Землю в роли ЯРОСТИ, которая намерена найти и уничтожить Семь смертных грехов. Darksiders III — долгожданная третья глава популярной серии Darksiders.",
                Status = "Вышел"
            },
            new Game() {
                Id = Guid.NewGuid(),
                Title = "Одни из нас",
                NormalizedTitle = "одни из нас",
                Website = "http://www.thelastofus.playstation.com/",
                AgeRating = "17+",
                TBA = true,
                ReleaseDate = new DateTime(2022, 2, 4),
                Description = "О грибе-паразите кордицепсе я давным-давно то ли вычитал в какой-то энциклопедии с картинками, то ли увидел в какой-то познавательной телепередаче, и больше к теме по понятным причинам не возвращался. Это жуть несусветная: гриб селится в насекомое, захватывает его нервную систему и заставляет взобраться на высокое растение. Дальше эта дрянь прорастает сквозь тело жертвы и взрывается, распространяя споры в воздухе. Те «засевают» других насекомых, и вот вам самый настоящий зомби-апокалипсис, который, возможно, прямо сейчас действительно происходит с какой-нибудь муравьиной цивилизацией в далеких лесах Амазонки. В реальности кордицепс не опасен для человека, но по сюжету The Last of Us он мутировал и таки устроил веселую жизнь людям. Жутко? Не то слово. От одной лишь мысли о том, что паразит реален, становится физически дискомфортно.",
                Status = "Вышел"
            },
            new Game() {
                Id = Guid.NewGuid(),
                Title = "Red Dead Redemption 2",
                NormalizedTitle = "red dead redemption 2",
                Website = "http://www.rockstargames.com/V/",
                AgeRating = "17+",
                TBA = true,
                ReleaseDate = new DateTime(2021, 2, 4),
                Description = "Артур Морган и другие подручные Датча ван дер Линде вынуждены пуститься в бега. Их банде предстоит участвовать в кражах, грабежах и перестрелках в самом сердце Америки. За ними по пятам идут федеральные агенты и лучшие в стране охотники за головами, а саму банду разрывают внутренние противоречия. Артуру предстоит выбрать, что для него важнее: его собственные идеалы или же верность людям, которые его взрастили.В комплекте новый контент для сюжетного режима, полноценный фоторежим и доступ к совместной игре в мире Red Dead Online, позволяющие игрокам найти свое место на Диком Западе. Вы можете выслеживать опасных преступников в роли охотника за головами, развивать собственное дело в роли торговца, разыскивать уникальные сокровища в роли коллекционера и открыть подпольное производство алкоголя в роли самогонщика, а также многое другое.Red Dead Redemption 2 для PC задействует всю мощь современных компьютеров, чтобы максимально правдоподобно представить каждый уголок этого огромного, насыщенного деталями мира. В числе графических и технических усовершенствований – увеличенная дальность прорисовки; улучшения в системе глобального освещения и рассеянного затенения, обеспечивающие более реалистичную смену времени суток; улучшенные отражения и тени более высокого разрешения на всех расстояниях; тесселяция текстур древесной коры и более качественные текстуры травы и меха, за счет чего животные и растения смотрятся еще натуралистичнее.Кроме того, Red Dead Redemption 2 для PC поддерживает режим HDR, разрешение 4K и выше, конфигурации с несколькими мониторами, широкоэкранные мониторы, более высокую частоту кадров и не только.",
                Status = "Вышел"
            },
            new Game() {
                Id = Guid.NewGuid(),
                Title = "Uncharted 4: Путь Вора",
                NormalizedTitle = "uncharted 4: путь вора",
                Website = "https://www.unchartedthegame.com/en-us/games/uncharted-4/",
                AgeRating = "17+",
                TBA = true,
                ReleaseDate = new DateTime(2022, 2, 4),
                Description = "Uncharted 4: Путь Вора — это игра в жанрах экшены и приключения, разработанная Naughty Dog. Она была выпущена в 2016. Её издателем выступила компания Sony Computer Entertainment. Рейтинг Uncharted 4: Путь Вора на Metacritic составляет 93. Он расчитывается на основе профессиональных рецензий в СМИ. Согласно нашим пользователям, самая популярная оценка игры — Шедевр.Uncharted 4: Путь Вора можно поиграть на PlayStation 4 и PlayStation 5. Можно купить игру в PlayStation Store.Bruce Straley и Neil Druckmann срежиссировали игру. Музыка в игре была написана Henry Jackman.",
                Status = "Вышел"
            },
            new Game() {
                Id = Guid.NewGuid(),
                Title = "Elden Ring",
                NormalizedTitle = "elden ring",
                Website = "https://en.bandainamcoent.eu/elden-ring/elden-ring",
                AgeRating = "17+",
                TBA = true,
                ReleaseDate = new DateTime(2022, 2, 4),
                Description = "НОВЫЙ ФЭНТЕЗИЙНЫЙ РОЛЕВОЙ БОЕВИК.Восстань, погасшая душа! Междуземье ждёт своего повелителя. Пусть благодать приведёт тебя к Кольцу Элден.• Огромный захватывающий мирОгромный мир с открытыми полями, множеством ситуаций и гигантскими подземельями, где сложные трёхмерные конструкции сочетаются воедино. Путешествуйте, преодолевайте смертельные опасности и радуйтесь успехам.• Создайте своего персонажаВы можете не только изменить внешность персонажа, но также комбинировать оружие, броню и предметы. Развивайте персонажа по своему вкусу. Наращивайте мышцы или постигайте таинства магии.• Эпическая драма, выросшая из мифаМногослойная история, разбитая на фрагменты. Эпическая драма, в которой мысли персонажей пересекаются в Междуземье.• Уникальный сетевой режим, приближающий вас к другим игрокамПомимо многопользовательского режима, в котором вы напрямую подключаетесь к другим игрокам и путешествуете вместе, есть асинхронный сетевой режим, позволяющий ощутить присутствие других игроков.",
                Status = "Вышел"
            }
        };

        _context.AddRange(games);
        _context.SaveChanges();
    }

    public async Task<GameReply> CreateGame(Game game) {
      await _context.Games.AddAsync(game);
      await _context.SaveChangesAsync();
      return new GameReply() {
        Game = game
      };
    }

    public async Task<GameReply> DeleteGameById(Guid id) {
      var game = _context.Games.Find(id);
      game.DeletedAt = DateTimeOffset.Now;
      game.DeletedBy = "admin";
      game.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new GameReply {
        Game = game
      };
    }

    public async Task<GamesReply> RetrieveGames() {
      var allGames = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags);

      var gamesReply = new GamesReply() {
        Games = allGames
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GameReply> UpdateGame(Game game) {
      //Проверить как он копирует IEnumerable<Genre> и т.д
      _context.Games.Update(game);
      await _context.SaveChangesAsync();
      return new GameReply() {
        Game = game
      };
    }

    public async Task<GameReply> RetrieveGameById(Guid gameId) {
      var game = _context.Games.Where(x => x.Id == gameId)
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .First();

      var gameReply = new GameReply() {
        Game = game
      };

      return await Task.FromResult(gameReply);
    }

    public async Task<GameReply> RetrieveGameByName(string gameTitle) {
      var game = _context.Games.Where(x => x.Title == gameTitle)
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .First();

      var gameReply = new GameReply() {
        Game = game
      };

      return await Task.FromResult(gameReply);
    }

    public async Task<GamesReply> RetrieveGamesByName(string gameTitle) {
      var games = _context.Games.Where(x => x.Title.Contains(gameTitle))
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags);

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByTag(string tag) {
      string normalizedTag = tag.ToLower();

      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.Tags.Any(t => t.NormalizedName == normalizedTag));

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByGenre(string genre) {
      string normalizedGenre = genre.ToLower();

      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.Genres.Any(t => t.NormalizedName == normalizedGenre));

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByPlatform(string platform) {
      string normalizedPlatform = platform.ToLower();

      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.Platforms.Any(t => t.NormalizedName == normalizedPlatform));

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByPublisher(string publisher) {
      string normalizedPublisher = publisher.ToLower();

      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.Publishers.Any(t => t.NormalizedName == normalizedPublisher));

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByDeveloper(string developer) {
      string normalizedDeveloper = developer.ToLower();

      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Developers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.Developers.Any(d => d.NormalizedSeoTitle == normalizedDeveloper));

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesAtCreatedYear(DateTimeOffset date) {
      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Developers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.CreatedAt.Year == date.Year);

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesAtReleaseYear(DateTimeOffset date) {
      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Developers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.ReleaseDate.Year == date.Year);

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesQueryPagination(int page, int pageSize) {
      var games = _context.Games
        .Skip(page * pageSize)
        .Take(pageSize)
        .Include(x => x.Developers)
        .Include(x => x.Genres)
        .Include(x => x.Platforms)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .ToList();

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByAllQuery(string genre, string gameSortOrder, string platform, DateTimeOffset? dateReleaseStart, DateTimeOffset? dateReleaseEnd, int page = 1, int pageSize = 20) {
      IQueryable<Game> games = _context.Games
        .Include(x => x.Developers)
        .Include(x => x.Genres)
        .Include(x => x.Platforms)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags);

      //Чекнуть разницу при использований в начале include и в конце

      if (!String.IsNullOrWhiteSpace(genre)) {
        string normalizedGenre = genre.ToLower();
        games = games.Where(x => x.Genres.Any(g => g.NormalizedName == normalizedGenre));
      }

      if (!String.IsNullOrWhiteSpace(platform)) {
        string normalizedPlatform = platform.ToLower();
        games = games.Where(x => x.Platforms.Any(p => p.NormalizedName == normalizedPlatform));
      }

      if (dateReleaseEnd != null && dateReleaseStart != null) {
        games = games.Where(x => x.ReleaseDate >= dateReleaseStart && x.ReleaseDate <= dateReleaseEnd);
      }

      switch (gameSortOrder) {
        case "Name":
          games = games.OrderBy(x => x.NormalizedTitle);
          break;

        case "Name_Desc":
          games = games.OrderByDescending(x => x.NormalizedTitle);
          break;

        case "Release_Date":
          games = games.OrderBy(x => x.ReleaseDate);
          break;

        case "Release_Date_Desc":
          games = games.OrderByDescending(x => x.ReleaseDate);
          break;

        case "Created_Date":
          games = games.OrderBy(x => x.CreatedAt);
          break;

        case "Created_Date_Desc":
          games = games.OrderByDescending(x => x.CreatedAt);
          break;

        default:
          games = games.OrderBy(x => x.NormalizedTitle);
          break;
      }

      var searchedGames =
        games.Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Include(x => x.Developers)
        .Include(x => x.Genres)
        .Include(x => x.Platforms)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .ToList();

      var gamesReply = new GamesReply() {
        Games = searchedGames
      };

      return await Task.FromResult(gamesReply);
    }

    #region Binding

    public async Task<GameReply> AddGenreToGame(AddGenreToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var genre = await _context.Genres.FindAsync(request.GenreId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find movie by id: {request.GameId}");
      } else if (game is null) {
        throw new ArgumentNullException($"Could not find genre by id: {request.GenreId}");
      }

      game.Genres.Add(genre);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddTagToGame(AddTagToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var tag = await _context.Tags.FindAsync(request.TagId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (tag is null) {
        throw new ArgumentNullException($"Could not find tag by id: {request.TagId}");
      }

      game.Tags.Add(tag);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddDeveloperToGame(AddDeveloperToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var developer = await _context.Developers.FindAsync(request.DeveloperId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (developer is null) {
        throw new ArgumentNullException($"Could not find developer by id: {request.DeveloperId}");
      }

      game.Developers.Add(developer);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddPlatformToGame(AddPlatformToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var platform = await _context.Platforms.FindAsync(request.PlatformId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (platform is null) {
        throw new ArgumentNullException($"Could not find platform by id: {request.PlatformId}");
      }

      game.Platforms.Add(platform);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddPublisherToGame(AddPublisherToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var publisher = await _context.Publishers.FindAsync(request.PublisherId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (publisher is null) {
        throw new ArgumentNullException($"Could not find publisher by id: {request.PublisherId}");
      }

      game.Publishers.Add(publisher);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddScreenshotToGame(AddScreenshotToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var screenshot = await _context.Images.FindAsync(request.ImageId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (screenshot is null) {
        throw new ArgumentNullException($"Could not find screenshot by id: {request.ImageId}");
      }

      game.Screenshots.Add(screenshot);
      await _context.SaveChangesAsync();

      return new GameReply() {
        Game = game
      };
    }

    #endregion Binding
  }
}