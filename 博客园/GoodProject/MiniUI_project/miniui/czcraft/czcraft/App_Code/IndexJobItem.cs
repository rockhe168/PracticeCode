using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///任务类型
/// </summary>
public class IndexJobItem
{
    //任务类型
   public enum JobType
    {
        Delete, Add
    }

    public JobType ItemType { get; set; }
    public long ThreadId { get; set; }
    public int Id { get; set; }
   
    public override bool Equals(object obj)
    {
        IndexJobItem item = obj as IndexJobItem;
        if (item == null)
        {
            return false;
        }
        return this.ItemType == item.ItemType && this.ThreadId == item.ThreadId;
        //return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public override string ToString()
    {
        return ItemType + ":" + ThreadId;
    }
    public IndexJobItem()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
}
