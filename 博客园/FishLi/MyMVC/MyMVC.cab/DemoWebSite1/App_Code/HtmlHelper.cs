﻿using System;
using System.Collections.Generic;
using System.Text;
using MyMVC;
using WebSiteCommonLib;
using WebSiteModel;


/// <summary>
/// 网站相关的一些HTML扩展方法
/// </summary>
public static class HtmlHelper
{
	/// <summary>
	/// 生成“商品分类”下拉框中的 option 列表
	/// </summary>
	public static string ToHtmlOptions(this List<Category> list, int currentCategoryId,
		string categoryUrlkey, bool addEmptyItem, params string[] deleteUrlKeys)
	{
		if( list == null )
			throw new ArgumentNullException("list");
		if( string.IsNullOrEmpty(categoryUrlkey) )
			throw new ArgumentNullException("categoryUrlkey");


		StringBuilder sb = new StringBuilder();

		MyUrlGenerator generate = new MyUrlGenerator(HttpContextHelper.RequestRawUrl);
		generate.Remove(categoryUrlkey).Remove(deleteUrlKeys);

		if( addEmptyItem )
			sb.Append("---请选择---".ToHtmlOptionUrl(generate.ToString()));

		foreach( WebSiteModel.Category category in list ) {
			string href = generate.GetNewUrl(categoryUrlkey, category.CategoryID.ToString());

			sb.Append(category.CategoryName.ToHtmlOptionUrl(href, (category.CategoryID == currentCategoryId)));
		}

		return sb.ToString();
	}

	private static readonly string[] UnitArray = new string[] { "个", "件", "只", "双" };

	/// <summary>
	/// 生成“商品单位”下拉框中的 option 列表
	/// </summary>
	public static string GetUnitHtmlOptions(string unit)
	{
		int exist = 0;
		StringBuilder sb = new StringBuilder();

		foreach( string str in UnitArray ) {
			if( str == unit ) {
				exist++;
				sb.Append(str.ToHtmlOption(true));
			}
			else
				sb.Append(str.ToHtmlOption());
		}

		if( exist == 0 && string.IsNullOrEmpty(unit) == false )
			sb.Append(unit.ToHtmlOption(true));

		return sb.ToString();
	}



}