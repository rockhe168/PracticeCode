using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.CodeDom;

namespace MyMVC
{
	/// <summary>
	/// 一个基于“System.Web.UI.Page”的类
	/// </summary>
	[FileLevelControlBuilder(typeof(ViewPageControlBuilder))]
	public class MyBasePage : System.Web.UI.Page
	{
		/// <summary>
		/// 当前页面的请求地址。
		/// </summary>
		public string CurrentRequestRawUrl { get; private set; }

		/// <summary>
		/// OnPreInit
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreInit(EventArgs e)
		{
			base.OnPreInit(e);

			this.CurrentRequestRawUrl = Server.UrlEncode(HttpContextHelper.RequestRawUrl);
		}

		public virtual void SetModel(object model)
		{
		}
	}


	internal sealed class ViewPageControlBuilder : FileLevelPageControlBuilder
	{
		public string PageBaseType
		{
			get;
			set;
		}

		public override void ProcessGeneratedCode(
			CodeCompileUnit codeCompileUnit,
			CodeTypeDeclaration baseType,
			CodeTypeDeclaration derivedType,
			CodeMemberMethod buildMethod,
			CodeMemberMethod dataBindingMethod)
		{

			// 如果分析器找到一个有效的类型，就使用它。
			if( PageBaseType != null ) {
				derivedType.BaseTypes[0] = new CodeTypeReference(PageBaseType);
			}
		}
	}



	



}
