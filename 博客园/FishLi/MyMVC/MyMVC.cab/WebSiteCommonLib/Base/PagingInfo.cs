using System;

namespace WebSiteCommonLib
{
	/// <summary>
	/// 分页信息
	/// </summary>
	public class PagingInfo
	{
		/// <summary>
		/// 分页序号，从0开始计数
		/// </summary>
		public int PageIndex;
		/// <summary>
		/// 分页大小
		/// </summary>
		public int PageSize;
		/// <summary>
		/// 从相关查询中获取到的符合条件的总记录数
		/// </summary>
		public int RecCount;

	}
}