﻿using GameService.Domain.EntityModels.Media;
using GameService.Domain.EntityModels.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameService.Domain.EntityModels.Dictionaries {

  public class Tag : BaseEntity<int> {

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Required]
    [StringLength(250)]
    public string NormalizedName { get; set; }

    public int GamesCount { get; set; }

    public Image BackgroundImage { get; set; }

    public virtual ICollection<Game> Games { get; set; }

    public string Description { get; set; }
  }
}