﻿using System.Collections.Generic;
using WebSiteCommonLib;

namespace WebSiteModel
{
	public class ProductsPageModel
	{
		public PagingInfo PagingInfo;
		public List<Category> Categories;
		public int CurrentCategoryId;
		public List<Product> Products;

		public ProductInfoModel ProductInfo { get; set; }
	}
}