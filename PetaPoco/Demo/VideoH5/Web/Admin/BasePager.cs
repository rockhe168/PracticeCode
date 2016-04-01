using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videoContext;
namespace Web.Admin
{
    using System.Text;

    using PetaPoco;

    public class BasePager<T> : System.Web.UI.Page
    {

        //页面初始化，赋值
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //检查会话是否过期
            //CheckUserUserSession();

            //当前页
            if (Request["pageNum"] != null)
                DefaultListPagination.CurrentPageNo = int.Parse(Request["pageNum"] ?? "1");

            //页大小
            if (Request["numPerPage"] != null)
                DefaultListPagination.PageSize = int.Parse(Request["numPerPage"] ?? "1");

            ////排序
            //if (!String.IsNullOrEmpty(Request["orderField"]))
            //{
            //    OrderbyStr = Request["orderField"];

            //    var direction = Request["orderDirection"];

            //    if (!String.IsNullOrEmpty(direction) && direction.ToLower() == "asc")
            //    {
            //        OrderByDirection = Direction.Asc;
            //    }
            //    else if (!String.IsNullOrEmpty(direction) && direction.ToLower() == "desc")
            //    {
            //        OrderByDirection = Direction.Desc;
            //    }

            //}
        }

        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);

            if(UserInfo ==null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        /// <summary>
        /// 默认列表分页对象
        /// </summary>
        public List<T> DefaultList {
            get
            {

                if (PageData == null || PageData.Items == null)
                {
                    return new List<T>();
                }
                else
                {
                    return PageData.Items;
                }
   
            }
        }

        private T _defaultObject = default(T);

        /// <summary>
        /// 默页面认对象
        /// </summary>
        public T DefaultObject
        {
            get
            {
                if (_defaultObject == null)
                {
                    _defaultObject =(T)System.Reflection.Assembly.GetAssembly(typeof(T)).CreateInstance(typeof(T).ToString());
                }
                return _defaultObject;
            }
            set { _defaultObject = value; }
        }

        public Page<T> PageData { get; set; }


        private Sql _sql =null;
        /// <summary>
        /// 查询字符串
        /// </summary>
        public Sql sql
        {
            get
            {
                if (_sql==null)
                {
                    _sql = new Sql();
                    return _sql;
                }
                else
                {
                    return _sql;
                }
            }
            set { _sql = value; }
        }      

        public userinfo UserInfo
        {
            get
            {
                userinfo userinfo = (userinfo)Session[SystemConstant.CurrentUserInfo];
                return userinfo;
            }
        }

        private Pagination _pagination;
        /// <summary>
        /// 当前页面分页对象
        /// </summary>
        public Pagination DefaultListPagination
        {
            get
            {
                if (_pagination == null)
                {
                    _pagination = new Pagination();
                    return _pagination;
                }
                else
                {
                    if (PageData != null )
                    {
                        _pagination.TotalCount = PageData.TotalItems;
                    }
                    return _pagination;
                }

            }
            set { _pagination = value; }
        }

        #region DWZ HTML Helper

        /// <summary>
        /// 分页导航(默认为当前页页面列表、针对页码只有一个列表页)
        /// </summary>
        /// <returns></returns>
        public string OutPutPagerNavigation()
        {
            var pager = new StringBuilder();
            pager.Append("<div class=\"panelBar\">");
            pager.Append("<div class=\"pages\">");
            pager.Append("<span>显示</span>");
            pager.Append("<select name=\"numPerPage\" onchange=\"navTabPageBreak({numPerPage:this.value})\">");
            switch (DefaultListPagination.PageSize)
            {
                case 20:
                    pager.Append("<option value=\"20\" selected=\"selected\">20</option>");
                    pager.Append("<option value=\"50\">50</option>");
                    pager.Append("<option value=\"100\">100</option>");
                    break;
                case 50:
                    pager.Append("<option value=\"20\">20</option>");
                    pager.Append("<option value=\"50\" selected=\"selected\">50</option>");
                    pager.Append("<option value=\"100\">100</option>");
                    break;
                case 100:
                    pager.Append("<option value=\"20\">20</option>");
                    pager.Append("<option value=\"50\">50</option>");
                    pager.Append("<option value=\"100\" selected=\"selected\">100</option>");
                    break;
            }
            pager.Append("</select>");
            pager.Append("<span>条，总共" + DefaultListPagination.TotalCount + "条，每页" + DefaultListPagination.PageSize + "条，当前第" + DefaultListPagination.CurrentPageNo + "页</span>");
            pager.Append("</div>");
            pager.Append("<div class=\"pagination\" targetType=\"navTab\" totalCount=\"" + DefaultListPagination.TotalCount + "\" numPerPage=\"" + DefaultListPagination.PageSize + "\" pageNumShown=\"10\" currentPage=\"" + DefaultListPagination.CurrentPageNo + "\"></div>");
            pager.Append("</div>");
            return pager.ToString();
        }

        /// <summary>
        /// 分页导航（针对页码有多个列表页）
        /// </summary>
        /// <param name="page">列表分页对象</param>
        /// <returns></returns>
        public static string OutPutPagerNavigation(Pagination page)
        {
            var pager = new StringBuilder();
            pager.Append("<div class=\"panelBar\">");
            pager.Append("<div class=\"pages\">");
            pager.Append("<span>显示</span>");
            pager.Append("<select name=\"numPerPage\" onchange=\"navTabPageBreak({numPerPage:this.value})\">");
            switch (page.PageSize)
            {
                case 20:
                    pager.Append("<option value=\"20\" selected=\"selected\">20</option>");
                    pager.Append("<option value=\"50\">50</option>");
                    pager.Append("<option value=\"100\">100</option>");
                    break;
                case 50:
                    pager.Append("<option value=\"20\">20</option>");
                    pager.Append("<option value=\"50\" selected=\"selected\">50</option>");
                    pager.Append("<option value=\"100\">100</option>");
                    break;
                case 100:
                    pager.Append("<option value=\"20\">20</option>");
                    pager.Append("<option value=\"50\">50</option>");
                    pager.Append("<option value=\"100\" selected=\"selected\">100</option>");
                    break;
            }
            pager.Append("</select>");
            pager.Append("<span>条，总共" + page.TotalCount + "条，每页" + page.PageSize + "条，当前第" + page.CurrentPageNo + "页</span>");
            pager.Append("</div>");
            pager.Append("<div class=\"pagination\" targetType=\"navTab\" totalCount=\"" + page.TotalCount + "\" numPerPage=\"" + page.PageSize + "\" pageNumShown=\"10\" currentPage=\"" + page.CurrentPageNo + "\"></div>");
            pager.Append("</div>");
            return pager.ToString();
        }


        /// <summary>
        /// 输出CheckBox是否选中
        /// </summary>
        /// <param name="checkedstate">是否选中</param>
        /// <returns>输出是否选中html字符串</returns>
        public static string OutPutCheckBoxChecked(bool checkedstate)
        {
            if (checkedstate)
                return "checked='checked'";
            else
                return string.Empty;
        }

        /// <summary>
        /// 输出下拉框是否选中
        /// </summary>
        /// <param name="checkedstate">是否选中</param>
        /// <returns>输出是否选中html字符串</returns>
        public static string OutPutSelectChecked(bool selectstate)
        {
            if (selectstate)
                return "selected";
            else
                return "";
        }

        public static string OutPutSelectChecked(string selectstate)
        {
            bool result;
            Boolean.TryParse(selectstate, out result);


            return OutPutSelectChecked(result);
        }

        /// <summary>
        /// 输出Display='none'
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string OutPutDisabled(bool state)
        {
            if (state)
                return "disabled='disabled'";
            else
                return string.Empty;
        }

        public static string OutPutDisplayNone(bool state)
        {
            if (state)
                return "style='display: none'";
            else
                return string.Empty;
        }

        #endregion DWZ HTML Helper

    }
}