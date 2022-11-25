using System.ComponentModel.DataAnnotations;

namespace CelleGames.ProductApi.Model;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }
}
