using System;
using System.Collections.Generic;
using System.Text;

namespace coreShop.ViewModel.Common
{
    public class PageResult<T>
    {
        public List<T> Items { set; get; }
        public int TotalRecord { get; set; }
    }
}
