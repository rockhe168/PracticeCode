<%@ WebHandler Language="C#" Class="GetProductInfo" %>

using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
using Common;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
public class GetProductInfo : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        
        String methodName = context.Request["method"];
        if (!string.IsNullOrEmpty(methodName))
            CallMethod(methodName, context);
    }
    /// <summary>
    /// 根据业务需求调用不同的方法
    /// </summary>
    /// <param name="Method">方法</param>
    /// <param name="context">上下文</param>
    public void CallMethod(string Method, HttpContext context)
    {
        switch (Method)
        {
            case "SaveProduct": 
                SaveProduct(context);
                break;
            case "SearchProduct":
                SearchProduct(context);
                break;
            case "GetProduct":
                GetProduct(context);
                break;
            case "UpdateProductRank":
                UpdateProductRank(context);
                break;
            case "RemoveProduct":
                RemoveProduct(context);
                break;
            case "GetProductType":
                GetProductType(context);
                break;
            case "AddProductType":
                AddProductType(context);
                break;
            case "RemoveProductType":
                RemoveProductType(context);
                break;
            case "SaveProductType":
                SaveProductType(context);
                break;
            default:
                return;


        }
    }
    /// <summary>
    /// 获取产品信息
    /// </summary>
    /// <param name="context"></param>
    public void GetProduct(HttpContext context)
    {
        string strid = context.Request["id"];
        int id = 0;
        if (!string.IsNullOrEmpty(strid) && int.TryParse(strid, out id))
        {
            product Info = new productBLL().Get(id);
            string json = productBLL.MiniUiForSingeAddProductToJson(Info);
            context.Response.Write(json);
        }
    }
    /// <summary>
    /// 保存产品信息(这个是官方后台添加产品,产品所属既不是大师也不是企业)
    /// </summary>
    /// <param name="context"></param>
    public void SaveProduct(HttpContext context)
    {
       
        //用户json数据读取
        product Info = new product();
        String ProductStr = context.Request["Product"];
       
        string id = context.Request["id"];
        string pic = context.Request["pic"];
        if (!Tools.IsValidInput(ref pic, true) || !Tools.IsValidInput(ref id, false))
        {
            return;
        }
        //图片保存
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(context.Server.MapPath("tzt.txt"), true);
        //sw.Write(ProductStr);
        //sw.Close();
        //使用Newtonsoft.Json.dll组件解析json对象

      
            JObject o = JObject.Parse(ProductStr);
            Info.Name = (string)o.SelectToken("Name");
            Info.Simplename = (string)o.SelectToken("Simplename");
            Info.Material = (string)o.SelectToken("Material");
            Info.Weight = (string)o.SelectToken("Weight");
            Info.Volume = (string)o.SelectToken("Volume");
            Info.Specification = (string)o.SelectToken("Specification");
            Info.Model = (string)o.SelectToken("Model");
            Info.Volume = (string)o.SelectToken("Volume");
            Info.Explain = (string)o.SelectToken("Explain");
            Info.Isrecomment = ((string)o.SelectToken("Isrecomment")) == "true" ? "1" : "0";
            Info.Isshow = ((string)o.SelectToken("Isshow")) == "true" ? "1" : "0";
            Info.Issell = ((string)o.SelectToken("Issell")) == "true" ? "1" : "0";
            Info.Isexcellent = ((string)o.SelectToken("Isexcellent")) == "true" ? "1" : "0";
            Info.Nongenetic = ((string)o.SelectToken("Nongenetic")) == "true" ? "1" : "0";
            string TypeID = (string)o.SelectToken("Typeid");
            Info.Typeid = Convert.ToInt32(TypeID);
            Info.Belongstype = -1;//这个是官方网站添加,所以所属为-1,为0代表大师产品,为1代表企业产品
            //官方提供,则默认1
            Info.Companyid = 1;
            Info.Masterid = 1;
            Info.Flashpath = "#";
            Info.Num = (long?)o.SelectToken("Num");
            Info.Soldnum = (long?)o.SelectToken("Soldnum");
            Info.Lsprice = Convert.ToDouble((string)o.SelectToken("Lsprice"));
            Info.Pfprice = Convert.ToDouble((string)o.SelectToken("Pfprice"));
            Info.Vipprice = Convert.ToDouble((string)o.SelectToken("Vipprice"));
            Info.MarketPrice = Convert.ToDouble((string)o.SelectToken("MarketPrice"));
            Info.Price1 = Convert.ToDouble((string)o.SelectToken("Price1"));
            Info.Price2 = Convert.ToDouble((string)o.SelectToken("Price2"));
            Info.Price3 = Convert.ToDouble((string)o.SelectToken("Price3"));
            Info.Price4 = Convert.ToDouble((string)o.SelectToken("Price4"));

            Info.Picturepath = pic;

            if (Tools.IsNumber(id))
                Info.Id = Convert.ToInt32(id);

            if (!Info.Id.HasValue)
            {
                Info.rank = 0;
                Info.hit = 0;
                //执行增加操作
                new productBLL().AddNew(Info);
            }
            else
            {
                new productBLL().Update(Info);
            }
        
       

    }
    /// <summary>
    /// 更新产品排名
    /// </summary>
    /// <param name="context"></param>
    public void UpdateProductRank(HttpContext context)
    {
       // System.IO.StreamWriter sw=new System.IO.StreamWriter (context.Server.MapPath("tzh.txt"),true);
            
        product Info = new product();
        String ProductStr = context.Request["Productdata"];
       // sw.Write(ProductStr);
       // sw.Close();
        JObject o = JObject.Parse(ProductStr);
        string id = (string)o.SelectToken("id");

        if (!Tools.IsValidInput(ref id, true))
            return;
        Info.Id = Convert.ToInt64(id);
        Info.rank = (long?)o.SelectToken("rank");
        context.Response.Write(new productBLL().UpdateProductRank(Info));
    }
    /// <summary>
    /// 查找产品信息
    /// </summary>
    /// <param name="context"></param>
    public void SearchProduct(HttpContext context)
    {
        //查询条件
        string key = context.Request["key"];
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        string strCondition = "";
        //对搜索内容进行验证
        if (!Common.Tools.IsValidInput(ref key, false))
        {
            return;
        }
        else
            strCondition = VFindProductInfoBLL.ConfirmCondition(key);//判断查询条件
        VFindProductInfoBLL bll = new VFindProductInfoBLL();
        //分页数据读取
        IEnumerable<VFindProductInfo> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = VFindProductInfoBLL.MiniUiListToJson(list, totalPage, "");


        context.Response.Write(json);
    }
    /// <summary>
    /// 保存工艺品类别信息
    /// </summary>
    /// <param name="context"></param>
    public void SaveProductType(HttpContext context)
    {

        bool result = false;
        string id = context.Request["id"];
        string text = context.Request["text"];
        string pid = context.Request["pid"];
        string IsLeaf = context.Request["IsLeaf"];
        if (Tools.IsValidInput(ref id, true) &&Tools.IsValidInput(ref text, true)&&Tools.IsValidInput(ref pid,true) &&Tools.IsValidInput(ref IsLeaf, true))
        {
            crafttype type = new crafttype();
            type.ID = Convert.ToInt32(id);
            type.Name = text;
            type.Belongsid = Convert.ToInt32(pid);
            type.IsLeaf = (IsLeaf == "true" ? "1" : "0");
            type.level=0; //level没用到,所以随便置0
            result = new crafttypeBLL().Update(type);

        }
        context.Response.Write(result);
    }
    /// <summary>
    /// 添加类别信息
    /// </summary>
    /// <param name="context"></param>
    public void AddProductType(HttpContext context)
    {
        crafttype type = new crafttype();
        string text = context.Request["text"];
        string pid = context.Request["pid"];
        string IsLeaf = context.Request["IsLeaf"];
        if(Tools.IsValidInput(ref text, true) &&Tools.IsValidInput(ref pid,true) &&Tools.IsValidInput(ref IsLeaf, true))
        {
            type.Name = text;
            type.Belongsid =Convert.ToInt32(pid);
            type.level = 0;//level基本没什么用,所以给0
            type.IsLeaf = "1";//初始化新添加的节点都是叶子//(IsLeaf=="true"?"1":"0");
            context.Response.Write(new crafttypeBLL().AddNewAndUpdateLeaf(type));
        }
        else context.Response.Write(false);
    }
    /// <summary>
    /// 加载类别信息
    /// </summary>
    /// <param name="context"></param>
    public void GetProductType(HttpContext context)
    {
        context.Response.Write(new crafttypeBLL().craftTypeTreeToJson());

    }
    /// <summary>
    /// 删除产品
    /// </summary>
    /// <param name="context"></param>
    public void RemoveProduct(HttpContext context)
    {

        string id = context.Request["id"];
        if (Tools.IsValidInput(ref id, true))
        {
            context.Response.Write(new productBLL().DeleteMoreID(id));
        }
    }
    /// <summary>
    /// 删除类别信息
    /// </summary>
    /// <param name="context"></param>
    public void RemoveProductType(HttpContext context)
    {
        string id = context.Request["id"];
        if (Tools.IsValidInput(ref id, true))
        {
            context.Response.Write(new crafttypeBLL().DeleteMoreID(id));
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}