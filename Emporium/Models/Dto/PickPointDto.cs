using Emporium.Infrastructure;

namespace Emporium.Models.Dto
{
    public class PickPointDto
    {
        [ColumnName("Название")]
        public string Name { get; set; } = null!;

        [ColumnName("Адрес")]
        public string? Address { get; set; }

        [ColumnName("Номер телефона")]
        public string? Phone { get; set; }

        [ColumnName("Рабочие часы")]
        public string? WorkingHours { get; set; }

        [ColumnName("Рейтинг")]
        public decimal? Rating { get; set; }

        [ColumnName("Количество сотрудников")]
        public int? EmployeesCount { get; set; }
    }
}
