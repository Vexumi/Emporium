using Emporium.Infrastructure;

namespace Emporium.Models.Dto
{
    public class OrderDetailDto
    {
        [ColumnName("Наименование товара")]
        public string Name { get; set; } = null!;

        [ColumnName("Категория")]
        public string? Category { get; set; }

        [ColumnName("Цена")]
        public decimal Price { get; set; } = 0;

        [ColumnName("Количество")]
        public int? Quantity { get; set; }

        [ColumnName("Адрес ПВЗ")]
        public string? Address { get; set; }

        [ColumnName("Номер ПВЗ")]
        public string? Phone { get; set; }
    }
}
