namespace MovieDb.Data.ViewModels
{
	public class PaginatedListViewModel<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int Count { get; private set; }
        public List<T> Items { get; private set; }

        public PaginatedListViewModel(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Count = count;
            Items = items;
        }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 1); }
        }

        public bool HasNextPage
        {
            get { return (PageIndex < TotalPages); }
        }
    }
}
