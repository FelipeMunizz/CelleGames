namespace CelleGames.ProductApi.DataVO.ValueObjects;

public class ProductVO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public float Inventory { get; set; }
    public int CategoyId { get; set; }
}
