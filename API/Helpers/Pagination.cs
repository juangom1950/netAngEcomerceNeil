namespace API.Helpers
{
    // Where T is a type of class
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        // This is the most specific thing that we can return for our data.
        public IReadOnlyList<T> Data { get; set; }
    }
}