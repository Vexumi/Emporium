using Emporium.Infrastructure;

namespace Emporium.Models.Dto;

public class ProductDto
{
    [ColumnName("Артикул")]
    public int ProductId { get; set; }

    [ColumnName("Название")]
    public string Name { get; set; } = null!;

    [ColumnName("Продавец")]
    public string? Seller { get; set; }

    [ColumnName("Цена")]
    public decimal Price { get; set; }

    [ColumnName("Категоия")]
    public string? Category { get; set; }

    [ColumnName("Оценка товара")]
    public int? Rating { get; set; }
}
