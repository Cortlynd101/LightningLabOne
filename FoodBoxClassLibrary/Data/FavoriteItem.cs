namespace FoodBoxClassLibrary.Data;

public partial class FavoriteItem
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
