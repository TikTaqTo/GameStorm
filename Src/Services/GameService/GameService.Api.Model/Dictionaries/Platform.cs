using GameService.Api.Model.Media;
using GameService.Api.Model.VideoGame;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameService.Api.Model.Dictionaries {

  public class Platform : BaseEntity<int> {

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Required]
    [StringLength(250)]
    public string NormalizedName { get; set; }

    public Image BackgroundImage { get; set; }

    public ICollection<Game> Games { get; set; }

    public Platform() {
      Games = new List<Game>();
    }
  }
}