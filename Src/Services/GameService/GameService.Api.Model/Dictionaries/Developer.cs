using GameService.Api.Model.Media;
using GameService.Api.Model.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameService.Api.Model.Dictionaries {

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

    public Image BackgroundImage { get; set; }

    public virtual ICollection<Game> CreatedGames { get; set; }

    public int GamesCount { get; set; }
  }
}