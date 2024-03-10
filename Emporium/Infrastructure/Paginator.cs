using Emporium.Infrastructure.Enums;

namespace Emporium.Infrastructure
{
    public class Paginator
    {
        protected int _totalElements;
        public int Offset { get; protected set; } = 0;
        public int TakeCount { get; protected set; }
        public SortBy SortSettings { get; set; } = SortBy.Unknown;
        public FilterBy FilterSettings { get; set; } = FilterBy.Unknown;
        public string FilterOption { get; set; }

        public Paginator(int TotalElements, int TakeCount = 20)
        {
            _totalElements = TotalElements;
            this.TakeCount = TakeCount;
        }

        public void NextPage()
        {
            if (Offset + TakeCount < _totalElements)
            {
                Offset += TakeCount;
            }
        }

        public void PrevPage()
        {
            if (Offset - TakeCount > 0)
            {
                Offset -= TakeCount;
            }
            else
            {
                Offset = 0;
            }
        }
    }
}
