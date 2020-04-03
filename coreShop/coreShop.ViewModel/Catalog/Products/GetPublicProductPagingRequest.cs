﻿using coreShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace coreShop.ViewModel.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
        public string LanguageId { get; set; }
    }
}
