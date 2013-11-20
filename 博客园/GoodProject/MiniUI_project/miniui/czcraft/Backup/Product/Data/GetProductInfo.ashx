<%@ WebHandler Language="C#" Class="GetProductInfo" %>

using System;
using System.Web;
using czcraft.BLL;
using czcraft.Model;
using Common;
using System.Web.SessionState;
public class GetProductInfo : IHttpHandler,IRequiresSessionState {

    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
            case "GetProduct":
                GetProduct(context);
                break;
            case "GetProductShow":
                GetProductShow(context);
                break;
            case "GetProductAllPic":
                GetProductAllPic(context);
                break;
            case "GetTopProductForMain":
                GetTopProductForMain(context);
                break;
            case "GetTopByRank":
                GetTopByRank(context);
                break;
            case "GetTopCraftTypeInfo":
                GetTopCraftTypeInfo(context);
                break;
            case "AddShoppingCart":
                AddShoppingCart(context);
                break;
            case "AddCollection":
                AddCollection(context);
                break;
            default:
                return;


        }
    }
    /// <summary>
    /// 加入购物车
    /// </summary>
    /// <param name="context"></param>
    public void AddShoppingCart(HttpContext context)
    {
       
        object SessionUserId =context.Session["UserId"];
        
        if (Tools.IsNullOrEmpty(SessionUserId))
        {
           context.Response.Write(Tools.WriteJsonForReturn(false, "未登录,无法加入购物车!"));
            return;
        }   
        //产品id
        string ProductId = context.Request["Id"];
        //供应商名称
        string SupperlierName = context.Request["SupperlierName"];
        //校验信息
        if (!Tools.IsValidInput(ref ProductId, true) && !Tools.IsValidInput(ref SupperlierName, true))
        {
            context.Response.Write(Tools.WriteJsonForReturn(false, "信息有误!"));
            return;
        }
        ShoppingCart Cart = new ShoppingCart();
        Cart.Quantity = 1;
        Cart.SupperlierName = SupperlierName;
        Cart.ProductId =Convert.ToInt64(ProductId);
        Cart.MemberId = Convert.ToInt32(SessionUserId);
        //加入购物车(假如之前,必须检验是否已经加入购物车了)
        Boolean Status=false;
        string Msg = "";
        ShoppingCartBLL bll = new ShoppingCartBLL();
        
        //如果购物车不存在该类产品
        if (bll.CheckCartExist(Cart.ProductId.Value))
        {
            Status = new ShoppingCartBLL().AddNewCart(Cart);
        }
        else
            Msg = "已添加商品,您可以继续在购物车中修改商品数量!";
        if (Status)
        {  //如果添加商品成功!则需要计算购物车中的总价,和购物车中产品数量(并返回json格式)
            context.Response.Write(bll.GetCartInfo(SessionUserId.ToString ()));
        }
        else
            context.Response.Write(Tools.WriteJsonForReturn(false, Msg));
    }
    /// <summary>
    /// 加入收藏
    /// </summary>
    /// <param name="context"></param>
    protected void AddCollection(HttpContext context)
    {
        object UserId = context.Session["UserId"];

        if (Tools.IsNullOrEmpty(UserId))
        {
            context.Response.Write(Tools.WriteJsonForReturn(false, "未登录,无法加入收藏!"));
            return;
        }
        //产品id
        string ProductId = context.Request["Id"];
        //供应商名称
        string SupperlierName = context.Request["SupperlierName"];
        //校验信息
        if (!Tools.IsValidInput(ref ProductId, true) && !Tools.IsValidInput(ref SupperlierName, true))
        {
            context.Response.Write(Tools.WriteJsonForReturn(false, "信息有误!"));
            return;
        }
        MemberCollection collection = new MemberCollection();
        collection.AddTime = DateTime.Now;
        collection.SupperName = SupperlierName;
        collection.ProductId = Convert.ToInt64(ProductId);
        collection.MemberId = Convert.ToInt32(UserId);
        //加入收藏(假如之前,必须检验是否已经加入收藏了)
        Boolean Status = false;
        string Msg = "";
        MemberCollectionBLL bll = new MemberCollectionBLL();

        //如果收藏不存在该类产品
        if (!bll.CheckCartExist(ProductId, UserId.ToString ()))
        {
            //未购买
            collection.IsBuy = "0";
            Status = bll.AddNewCollection(collection);
        }
        else
        {
            Status = bll.UpdateCollection(collection);
        }
        context.Response.Write(Tools.WriteJsonForReturn(Status, Msg));
    }
    /// <summary>
    /// 获取排名信息
    /// </summary>
    /// <param name="context"></param>
    public void GetTopByRank(HttpContext context)
    {
        //创建缓存工厂
        CacheStorage.ICacheStorage Cache = CacheStorage.CacheFactory.CreateCacheFactory();
        string cache = Convert.ToString(Cache.Get("TopRankInfo"));
        string JsonData = "";//返回的json数据
        if (string.IsNullOrEmpty(cache))
        {
            JsonData = new productBLL().GetTopByRankByJson();
            //插入缓存(时间从配置文件中读取)
            Cache.Insert("TopRankInfo", JsonData, CacheManage.GetTimeConfig("TopRankInfo"));
        }
        else
        {
            JsonData = cache;
        }
        context.Response.Write(JsonData);
    }

    /// <summary>
    /// 为首页生成产品图片的列表数据
    /// </summary>
    /// <param name="context"></param>
    public void GetTopProductForMain(HttpContext context)
    { 
        //创建缓存工厂
        CacheStorage.ICacheStorage Cache = CacheStorage.CacheFactory.CreateCacheFactory();
        string cache = Convert.ToString(Cache.Get("TopProduct"));
        string JsonData = "";//返回的json数据
        if (string.IsNullOrEmpty(cache))//如果缓存为空
        {
       
            //读取排名20的产品信息并转化为json格式

            JsonData = productBLL.GetTopProductForMain(10);


            //插入缓存(时间从配置文件中读取)
            Cache.Insert("TopProduct", JsonData, CacheManage.GetTimeConfig("DefaultContent"));
        }
        else
        {
            JsonData = cache;
        }


        context.Response.Write(JsonData);

    }
    /// <summary>
    /// 获取所有图片信息
    /// </summary>
    /// <param name="context"></param>
    public void GetProductAllPic(HttpContext context)
    {
        try
        {
            string ProductId = context.Request["ProductId"];
            if (Tools.IsValidInput(ref ProductId, true))
            {
                product_picturepathBLL bll = new product_picturepathBLL();
                context.Response.Write(bll.GetProductPicForJson(ProductId));
            }
            else
            {
                context.Response.Write(Tools.WriteJsonForReturn(false, "输入的信息有误!"));
            }
        }
        catch (Exception ex)
        {
            logger.Error("出错!", ex);
        }
    }
    /// <summary>
    /// 获取产品
    /// </summary>
    /// <param name="context"></param>
    public void GetProduct(HttpContext context)
    {
        try
        {
            string ProductId = context.Request["ProductId"];
            if (Tools.IsValidInput(ref ProductId, true))
            {
                productBLL bll = new productBLL();
                long Id = Convert.ToInt64(ProductId);
                context.Response.Write(bll.GetProductJson(Id));
            }
            else
            {
                context.Response.Write(Tools.WriteJsonForReturn(false, "输入的信息有误!"));
            }
        }
        catch (Exception ex)
        {
            logger.Error("出错!", ex);
        }
        
    }
  
    /// <summary>
    /// 产品展览信息
    /// </summary>
    /// <param name="context"></param>
    public void GetProductShow(HttpContext context)
    {
        
        context.Response.Write(new VProductCraftTypeBLL().ListTopProductIsRecommentAndIsexcellent());
    }
    /// <summary>
    /// 获取产品类别的顶级菜单
    /// </summary>
    /// <param name="context"></param>
    public void GetTopCraftTypeInfo(HttpContext context)
    {
        //创建缓存工厂
        CacheStorage.ICacheStorage Cache = CacheStorage.CacheFactory.CreateCacheFactory();
        string cache = Convert.ToString(Cache.Get("ProductType"));
   
        string JsonData = "";//返回的json数据
        if (string.IsNullOrEmpty(cache))
        {  
          
            JsonData = new crafttypeBLL().GetTopTreeToJson();
            //插入缓存(时间从配置文件中读取)
            Cache.Insert("ProductType", JsonData, CacheManage.GetTimeConfig("ProductType"));
        }
        else
        {
            JsonData = cache;
        }
        context.Response.Write(JsonData);
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}