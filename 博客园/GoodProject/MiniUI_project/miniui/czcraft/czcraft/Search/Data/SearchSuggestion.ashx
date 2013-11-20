<%@ WebHandler Language="C#" Class="SearchSuggestion" %>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using czcraft.BLL;
using czcraft.Model;
    /// <summary>
    /// SearchSuggestion 的摘要说明
    /// </summary>
    public class SearchSuggestion : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string kw = context.Request["term"];
            SearchInfoBLL bll = new SearchInfoBLL();
            var result = bll.GetSuggestion(kw,SearchSum.searchType.Knowledge);
            List<string> list = new List<string>();
            foreach (var item in result)
            {
                list.Add(item.KeyWord);
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(list);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
