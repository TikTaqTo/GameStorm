using GameService.Domain.EntityModels.Media;
using GameService.Domain.EntityModels.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameService.Domain.EntityModels.Dictionaries {

  public class Developer : BaseEntity<int> {

    public Developer() {
      CreatedGames = new List<Game>();
    }

    [Required]
    [StringLength(200)]
    public string SeoTitle { get; set; }

    [Required]
    [StringLength(250)]
    public string NormalizedSeoTitle { get; set; }

    public virtual ICollection<Game> CreatedGames { get; set; }

    public int GamesCount { get; set; }
  }
}