
namespace WebSiteController
{

	/// <summary>
	/// 创建BLL的一个简单的工厂。不想搞得太复杂，就这样算了。
	/// </summary>
	public static class BllFactory
	{
		public static CategoryBLL GetCategoryBLL()
		{
			return new CategoryBLL();
		}

		public static CustomerBLL GetCustomerBLL()
		{
			return new CustomerBLL();
		}

		public static ProductBLL GetProductBLL()
		{
			return new ProductBLL();
		}

		public static OrderBLL GetOrderBLL()
		{
			return new OrderBLL();
		}
	}
}
