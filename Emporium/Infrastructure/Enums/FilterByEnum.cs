using System.ComponentModel;

namespace Emporium.Infrastructure.Enums
{
    public enum FilterBy
    {
        [Description("Без фильтра")]
        Unknown = 0,
        [Description("Название содержит")]
        NameContains,
        [Description("Название не содержит")]
        NameDoesNotContain,
        [Description("Категория содержит")]
        CategoryContains,
        [Description("Категория не содержит")]
        CategoryDoesNotContain,
        [Description("ФИО содержит")]
        FullnameContains,
        [Description("ФИО не содержит")]
        FullnameDoesNotContain,
    }
}
