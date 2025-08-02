namespace GazTestTask.Domain.DTOs.Common
{
    public class SearchResultDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
} 