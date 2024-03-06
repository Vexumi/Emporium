using Emporium.Infrastructure;

namespace Emporium.Models.Dto
{
    public class EmployeeDto
    {
        [ColumnName("Личный номер")]
        public int EmployeeId { get; set; }

        [ColumnName("ФИО")]
        public string FullName { get; set; } = null!;

        [ColumnName("Должность")]
        public string Position { get; set; } = null!;

        [ColumnName("Зарплата")]
        public decimal? Salary { get; set; }

        [ColumnName("Пункт выдачи")]
        public string? PickupPoint { get; set; }
    }
}
