using GameService.Domain.EntityModels.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Domain.EntityModels.Media {

  public class Image : BaseEntity<Guid> {

    /// <summary>
    /// Name of an image
    /// </summary>
    [StringLength(30)]
    public string Name { get; set; }

    /// <summary>
    /// Source of image in form of byte array
    /// </summary>
    [Column(TypeName = "image")]
    public byte[] Source { get; set; }

    /// <summary>
    /// Foreign key to a game
    /// </summary>
    public Guid? GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public virtual Game Game { get; set; }
  }
}