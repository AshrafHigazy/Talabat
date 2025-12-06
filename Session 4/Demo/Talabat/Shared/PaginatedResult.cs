

namespace Shared
{
    public class PaginatedResult<Dto>
    {
        public PaginatedResult(int pageIndex, int pageSize, int totalCount, IEnumerable<Dto> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Dto> Data { get; set; }
    }
}
