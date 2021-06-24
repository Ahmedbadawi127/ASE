using System.Collections.Generic;
using System.Linq;

namespace Shipping.Shared
{
    public class PagedDataResult<T>
    {
        public PagedDataResult()
        { }

        public PagedDataResult(List<T> Items)
        {
            this.Items = Items ?? new List<T>();
            this.Count = this.Items?.Count ?? 0;
        }

        public PagedDataResult(IEnumerable<T> Items)
        {
            this.Items = Items?.ToList() ?? new List<T>();
            this.Count = this.Items.Count;
        }

        public PagedDataResult(List<T> Items, int Count)
        {
            this.Items = Items ?? new List<T>();
            this.Count = Count;
        }

        public PagedDataResult(IEnumerable<T> Items, int Count)
        {
            this.Items = Items?.ToList() ?? new List<T>();
            this.Count = Count;
        }

        public int Count { get; set; }
        public List<T> Items { get; set; } = new List<T>();
        public T Item { get; set; }
    }
}