﻿using System.Collections.Generic;
using WebSiteCommonLib;

namespace WebSiteModel
{
	public class CustomersPageModel
	{
		public Customer Customer { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public List<Customer> List;

		public CustomersPageModel()
		{
			this.Customer = new Customer();
		}
	}
}