using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelleGames.ProductApi.Model;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }
}
