using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.EntityModels.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameService.Domain.EntityModels.VideoGame {

  public class Game : BaseEntity<Guid> {

    public Game() {
      Developers = new List<Developer>();
      Publishers = new List<Publisher>();
      Platforms = new List<Platform>();
      Screenshots = new List<Image>();
      Tags = new List<Tag>();
      Genres = new List<Genre>();
    }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    [StringLength(200)]
    public string NormalizedTitle { get; set; }

    [DataType(DataType.Url)]
    public string Website { get; set; }

    [Required]
    public Image Poster { get; set; }

    [Required]
    public virtual ICollection<Developer> Developers { get; set; }

    [Required]
    public virtual ICollection<Publisher> Publishers { get; set; }

    [Required]
    public virtual ICollection<Genre> Genres { get; set; }

    [Required]
    public virtual ICollection<Platform> Platforms { get; set; }

    [Required]
    public virtual ICollection<Image> Screenshots { get; set; }

    public virtual ICollection<Tag> Tags { get; set; }

    [Required]
    public string Status { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Release Date")]
    public DateTimeOffset ReleaseDate { get; set; }

    /// <summary>
    ///     The purchase currency of the game is calculated in dollars,
    ///     there are no functions for determining the price by country.
    ///     I did not give the opportunity to add a discount to the price
    ///     due to the fact that I provide the game and its base price,
    ///     the store itself must determine what the discount will be
    /// </summary>

    [Required]
    public string Description { get; set; }

    public string AgeRating { get; set; }

    public bool TBA { get; set; }

    /// <summary>
    ///     I still think whether it is worth using the system requirements,
    ///     it can be expensive to store 2 classes for each game: Recommended
    ///     and Minimum system requirements that will be individual for each game
    /// </summary>
    //public string SystemRequirements { get; set; }

    //public trailer GameVideoTrailer {get; set;}

    /// <summary>
    /// Perhaps it is worth creating a separate class in which there will be fields:
    /// Id (Guid), Slug (Enum), Name (Enum)
    /// it will have fields with age restrictions esrb
    /// </summary>
  }
}