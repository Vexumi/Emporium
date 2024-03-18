using Emporium.Infrastructure;
using System;

namespace Emporium.Models.Dto
{
    public class OrderDto
    {
        [ColumnName("Номер заказа")]
        public int Id { get; set; }

        [ColumnName("Покупатель")]
        public string Customer { get; set; } = null!;

        [ColumnName("Сотрудник")]
        public string? Employee { get; set; } = null!;

        [ColumnName("Дата заказа")]
        public DateTime? OrderDate { get; set; }

        [ColumnName("Количество товаров")]
        public int? TotalProductsCount { get; set; }

        [ColumnName("Итоговая сумма")]
        public decimal? TotalAmount { get; set; }
    }
}
