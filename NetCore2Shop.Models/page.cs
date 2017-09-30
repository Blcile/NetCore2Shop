using System.Collections.Generic;

namespace NetCore2Shop.Models
{
    public class Page<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public Page(IEnumerable<T> data,int index, int total, int size)
        {
            this.Data = data;
            this.PageIndex = index;
            this.TotalCount = total;
            this.PageSize = PageSize;
            this.TotalPage = total / size + 1;
        }
    }
}