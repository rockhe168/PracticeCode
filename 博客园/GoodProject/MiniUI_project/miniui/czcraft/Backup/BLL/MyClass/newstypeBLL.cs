using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using czcraft.DAL;
using czcraft.Model;
namespace czcraft.BLL
{
   public partial class newstypeBLL
    {
        #region 获得newstype tree的json数据
        /// <summary>
        /// 获得newstype tree的json数据
        /// </summary>
        /// <returns></returns>
        public string GetNewsTypeInfoByJson()
        {
            IEnumerable<newstype> NewsTypeList = new newstypeDAL().ListAll();
            StringBuilder sb = new StringBuilder("[");
            foreach (newstype type in NewsTypeList)
            {
                sb.Append("{\"id\":\"" + type.Id + "\",\"text\":\"" + type.Name + "\"}");
                if (type != NewsTypeList.Last())
                {
                    sb.Append(",");

                }
            }
            sb.Append("]");
            return FormatToJson.MiniUiToJsonForTree(sb.ToString(), "总类别");
        } 
        #endregion
        #region 为新闻模块下拉框生成类别选择的数据
        /// <summary>
        /// 为新闻模块下拉框生成类别选择的数据
        /// </summary>
        /// <returns></returns>
        public string GetNewsTypeInfoForNewsByJson()
        {
            IEnumerable<newstype> NewsTypeList = new newstypeDAL().ListAll();
            StringBuilder sb = new StringBuilder("[");
            foreach (newstype type in NewsTypeList)
            {
                sb.Append("{\"TypeId\":\"" + type.Id + "\",\"TypeName\":\"" + type.Name + "\"}");
                if (type != NewsTypeList.Last())
                {
                    sb.Append(",");

                }
            }
            sb.Append("]");
            return sb.ToString();
        } 
        #endregion
       
    }
}
