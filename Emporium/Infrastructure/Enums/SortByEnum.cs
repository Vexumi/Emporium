using System.ComponentModel;

namespace Emporium.Infrastructure.Enums
{
    public enum SortBy
    {
        [Description("Без сортировки")]
        Unknown = 0,
        [Description("Цена по возрастанию")]
        PriceAscending,
        [Description("Цена по убыванию")]
        PriceDescending,
        [Description("Название по алфавиту (а-я)")]
        NameAscending,
        [Description("Название против алфавита (я-а)")]
        NameDescending,
    }
}
