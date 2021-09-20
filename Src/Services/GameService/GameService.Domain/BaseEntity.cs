using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Domain {

  public class BaseEntity<TKey>
        where TKey : struct {

    /// <summary>
    ///     Primary key (Generic)
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }

    /// <summary>
    ///     Date of creation with offset
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    ///     Who created
    /// </summary>
    [StringLength(20)]
    public string CreatedBy { get; set; } = "admin";

    /// <summary>
    ///     Date of last modified with offset
    /// </summary>
    public DateTimeOffset? ModifiedAt { get; set; } = null;

    /// <summary>
    ///     Who modified
    /// </summary>
    [StringLength(20)]
    public string ModifiedBy { get; set; } = null;

    /// <summary>
    ///     Reason of modified
    /// </summary>
    [StringLength(50)]
    public string ModifiedReason { get; set; } = "UpdateInfo";

    /// <summary>
    ///     Date of deletion with offset
    /// </summary>
    public DateTimeOffset? DeletedAt { get; set; } = null;

    /// <summary>
    ///     Who deleted
    /// </summary>
    [StringLength(20)]
    public string DeletedBy { get; set; } = null;

    /// <summary>
    ///     Reason of deletion
    /// </summary>
    [StringLength(50)]
    public string DeletedReason { get; set; } = null;
  }
}