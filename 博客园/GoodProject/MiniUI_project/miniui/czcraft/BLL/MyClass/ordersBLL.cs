using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.IO;
using Newtonsoft.Json;
namespace czcraft.BLL
{
    public partial class ordersBLL
    {
        #region 获取订单号
        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <returns></returns>
        public static string GetOrderId()
        {
            return new ordersDAL().GetOrderId();
        }
        #endregion
        #region 保存订单
        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="order">订单</param>
        /// <param name="ReturnProductNames">返回产品名称列表</param>
        /// <returns></returns>
        public bool SaveOrder(ref orders order, out string ReturnProductNames)
        {
            ReturnProductNames = "";
            //查询条件(购物车视图中查询)
            string Condition = " MemberId=" + order.UserId;
            //(需要读取购物车,然后,插入订单商品表和订单表)
            //订单产品信息列表
            List<orderproduct> listOrder = new List<orderproduct>();
            IEnumerable<VCartProductInfo> CartProducts = new VCartProductInfoDAL().ListAll(Condition);
            order.TotalPrice = 0.0;
            order.FactPrice = 0.0;
            foreach (VCartProductInfo CartProduct in CartProducts)
            {
                orderproduct OrderProduct = new orderproduct();
                OrderProduct.AddTime = DateTime.Now;
                OrderProduct.OrderId = order.OrderId;
                OrderProduct.ProId = CartProduct.ProductId.Value.ToString();
                OrderProduct.ProImg = CartProduct.Picturepath;
                OrderProduct.ProName = CartProduct.ProductName;
                ReturnProductNames += OrderProduct.ProName + ",";
                OrderProduct.ProNum = CartProduct.Quantity;
                OrderProduct.ProPrice = CartProduct.Price;
                OrderProduct.BelongType = CartProduct.BelongType;
                OrderProduct.SupperlierId = CartProduct.SupperlierId;
                OrderProduct.SupperlierName = CartProduct.SupperlierName;
                OrderProduct.ProOtherPara = "";
                OrderProduct.Remark = "";
                OrderProduct.Specification = "";
                //加入到产品订单信息列表中
                listOrder.Add(OrderProduct);
                //总价计算
                order.TotalPrice += OrderProduct.ProPrice.Value * OrderProduct.ProNum.Value;
                //实际总价
                order.FactPrice += OrderProduct.ProPrice.Value * OrderProduct.ProNum.Value;
            }
            //支付状态为等待付款
            order.PaymentStatus = orders.ePaymentStatus.WaitPay.GetHashCode().ToString();
            //订单状态为未支付
            order.OrderStatus = orders.eOrderStatus.NotPay.GetHashCode().ToString();

            //订单状态
            order.IsOrderNormal = 0;
            order.Remark = "";
            order.ShopDate = DateTime.Now;
            order.OrderDate = DateTime.Now;
            //返回订单执行状态
            bool Status = new ordersDAL().AddOrders(order, listOrder);
            if (Status)
            {
                //给客户发邮件
                SMTP smtp = new SMTP(order.ConsigneeEmail);
                smtp.SendMail("潮州工艺平台", SendToCustomContentHtml(order, listOrder));

            }
            return Status;

        }
        #endregion
  
        #region 生成给客户发的HTML内容(亚马逊布局)
        /// <summary>
        /// 生成给客户发的HTML内容(亚马逊)
        /// </summary>
        /// <param name="order"></param>
        /// <param name="ProductsList"></param>
        /// <returns></returns>
        public string SendToCustomContentHtml(orders order, IEnumerable<orderproduct> ProductsList)
        {
            //获取当前http上下文
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            //主页
            string Default = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/Default.aspx");
            //会员订单网址
            string webpath = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/Member/MemberOrders.aspx");
            //文件流读取
            StringBuilder sb = new StringBuilder();
            sb.Append(File.ReadAllText(context.Server.MapPath("~/Other/SendToCustomContent.html"), Encoding.UTF8));
            sb.Replace("$ConsigneeRealName", order.ConsigneeRealName);
            sb.Replace("$ConsigneeEmail", order.ConsigneeEmail);
            sb.Replace("$ConsigneeRealName", order.ConsigneeRealName);
            sb.Replace("$ConsigneeAddress", order.ConsigneeAddress);
            sb.Replace("$ConsigneeProvince", order.ConsigneeProvince);
            sb.Replace("$ConsigneeZip", order.ConsigneeZip);
            sb.Replace("$TotalPrice", order.TotalPrice.Value.ToString());
            sb.Replace("$webpath", webpath);
            sb.Replace("$OrderId", order.OrderId);
            sb.Replace("$TotalPrice", order.TotalPrice.Value.ToString());
            sb.Replace("$Carriage", order.Carriage.ToString());//
            sb.Replace("$TotalPrice", order.TotalPrice.Value.ToString());
            sb.Replace("$FactPrice", order.FactPrice.Value.ToString());
            sb.Replace("$DateTime", DateTime.Now.AddDays(3).ToShortDateString());

            //商品内容生成
            int num = 0;
            StringBuilder TempData = new StringBuilder();
            foreach (orderproduct Product in ProductsList)
            {
                string temp3 = @"<table><tbody>
<tr valign='top'><td></td><td><font size='-1' face='verdana,arial,helvetica'><b>" + (++num) + @"</b></font></td><td><font size='-1' face='verdana,arial,helvetica'><b>" + Product.ProName + @"</b><br>
<span class='price'>￥ " + Product.ProPrice + @"</span><br>现在有货<br>&nbsp; 卖家： <a href='" + Default + @"' target='_blank'>潮州工艺品集团</a> </font></td></tr></tbody></table>";
                TempData.Append(temp3);


            }
            //商品主体信息替换
            sb.Replace("$Body", TempData.ToString());
            //sb.Replace("$Carriage", order.Carriage);



            return sb.ToString();

        }
        #region HTML内容生成
        //copy内容(网址比较复杂)
        /*  #region HTML内容生成
          StringBuilder sb = new StringBuilder();
          string temp1 = @"<table border='0' cellspacing='0' cellpadding='1' width='90%' bgcolor='#006699' align='center'> <tbody><tr><td><table border='0' cellspacing='0' cellpadding='5' width='100%' align='center'><tbody><tr valign='top'><td bgcolor='#ffffff'><font size='-1' face='verdana,arial,helvetica'><p><b>感谢您的订购, " + order.ConsigneeRealName + @"!</b></p><p><b>如何查看或修改您的订单？</b><br> 如果您要查看或修改您的订单，请登录潮州工艺品网站的“登录”。<br></p></font>";
          sb.AppendFormat(temp1);
          string temp2 = @" <table border='0' cellspacing='0' cellpadding='4' width='100%'><tbody><tr><td bgcolor='#006699' colspan='2'><font color='#ffffff' size='-1' face='verdana,arial,helvetica'><b>购物信息：</b></font></td> </tr><tr><td colspan='2'><font size='-1' face='verdana,arial,helvetica'><b>邮箱地址：</b>&nbsp; <a href='mailto:" + order.ConsigneeEmail + @"'  target='_blank'>" + order.ConsigneeEmail + @"</a> </font></td></tr><tr><td colspan='2'><table cellspacing='0' cellpadding='0' width='100%'><tbody><tr><td style='padding-right: 1em' valign='top' width='50%'></td><td valign='top' width='50%'><font size='-1' face='verdana,arial,helvetica'><b>送货地址：</b><br>" + order.ConsigneeRealName + @"<br>" + order.ConsigneeAddress + @"<br>" + order.ConsigneeProvince + @"<br>" + order.ConsigneeZip + @"<br><br></font></td></tr> </tbody></table></td></tr><tr><td colspan='2'><font size='-1' face='verdana,arial,helvetica'><b>订单总计： ￥ " + order.TotalPrice + @"</b> </font></td> </tr><tr><td bgcolor='#006699' colspan='2'><font color='#ffffff' size='-1' face='verdana,arial,helvetica'><b>订单汇总：</b></font></td></tr><tr><td bgcolor='#eeeeee'><font color='#cc6600' size='-1' face='verdana,arial,helvetica'><b>配送说明 : 您所订购的商品将一次性送达</b></font></td></tr><tr><td><table border='0' cellspacing='0' cellpadding='1' width='100%'><tbody><tr><td nowrap='nowrap'>
<font size='-1' face='verdana,arial,helvetica'><b>订单号：</b> </font></td>
<td width='98%'><font size='-1' face='verdana,arial,helvetica'><a href='" + webpath + @"'target='_blank'>" + order.OrderId + @"</a> </font></td></tr><tr><td nowrap='nowrap'><font size='-1' face='verdana,arial,helvetica'><b>送货方式：</b> </font></td><td width='98%'><font size='-1' face='verdana,arial,helvetica'>快递送货上门</font></td></tr><tr><td nowrap='nowrap'><font size='-1' face='verdana,arial,helvetica'><b>货物拆分：</b></font></td><td width='98%'><font size='-1' face='verdana,arial,helvetica'>等待所有商品到货一起发货</font></td></tr><tr><td nowrap='nowrap'><span class='small'><font size='-1' face='verdana,arial,helvetica'>小计： &nbsp; </font> </span></td><td><span class='small'><font size='-1' face='verdana,arial,helvetica'>￥ " + order.TotalPrice + @" </font></span></td></tr><tr><td nowrap='nowrap'><span class='small'><font size='-1' face='verdana,arial,helvetica'>促销优惠: &nbsp; </font></span></td><td><span class='small'><font size='-1' face='verdana,arial,helvetica'>-￥ 0.00 </font> </span> </td> </tr><tr> <td>&nbsp; </td><td> ------</td></tr><tr> <td nowrap='nowrap'>
<span class='small'><font size='-1' face='verdana,arial,helvetica'><b>订单总计： &nbsp; </b></font></span></td><td><span class='small'><font size='-1' face='verdana,arial,helvetica'><b>￥ " + order.FactPrice + @" </b></font> </span></td></tr><tr>
<td colspan='2'><font size='-1' face='verdana,arial,helvetica'><br>&nbsp;<br><b>预计送达日期： </b>" + DateTime.Now.AddDays(3).ToShortDateString() + @" </font>";

          sb.Append(temp2);
          int num = 0;
          foreach (orderproduct Product in ProductsList)
          {
              string temp3 = @"<table><tbody><tr valign='top'><td></td><td><font size='-1' face='verdana,arial,helvetica'><b>" + (++num) + @"</b></font></td><td><font size='-1' face='verdana,arial,helvetica'><b>" + Product.ProName + @"</b><br><span class='price'>￥ " + Product.ProPrice + @"</span><br>现在有货<br>&nbsp; 卖家： <a href='" + Default + @"' target='_blank'>潮州工艺品集团</a> </font></td></tr></tbody></table>";
              sb.Append(temp3);

          }

          string temp4 = @"</td></tr></tbody></table></td></tr><tr><td><hr size='1' noshade='noshade'><p><font size='-1' face='verdana,arial,helvetica'><b>此订单确认信仅确认我们已收到了您的订单，只有当我们向您发出送货确认的电子邮件通知您我们已将产品发出时，我们和您之间的订购合同才成立。</b></font></p><p><font size='-1' face='verdana,arial,helvetica'><br>了解更多信息，请访问“帮助中心”。<br></font></p><p><font size='-1' face='verdana,arial,helvetica'>请注意: 此邮件发送地址仅用于发送订单信息， ，请不要直接回复。</font></p><p><font size='-1' face='verdana,arial,helvetica'>欢迎您再次到潮州工艺品购物，祝您购物愉快！ </font></p><p><font size='-1' face='verdana,arial,helvetica'><b><a href='" + Default + @"' >潮州工艺品网站</a></b></font></p> </td></tr> </tbody></table></td></tr></tbody></table>";
          sb.Append(temp4);
          #endregion  */
        #endregion
        /// <summary>
        /// 生成给客户发的HTML内容
        /// </summary>
        /// <param name="order"></param>
        /// <param name="ProductsList"></param>
        /// <returns></returns>
        public string SendToCustomContent(orders order, IEnumerable<orderproduct> ProductsList)
        {
            StringBuilder sb = new StringBuilder();
            string tmp = "<font size='+3'>潮州工艺网</font><br /><br />";
            sb.AppendFormat(tmp);
            string tmp2 = "<font size='+2'>订单号:" + order.OrderId + "</font>";
            sb.AppendFormat(tmp2);

            string tmp4 = "<table><tr><td>商品编号</td><td>商品名称</td><td>商品单价</td><td>商品数量</td></tr>";

            sb.AppendFormat(tmp4);

            foreach (orderproduct Product in ProductsList)
            {

                sb.AppendFormat("<tr><td>" + Product.ProId + "</td><td>" + Product.ProName + "</td><td>Y" + Product.ProPrice + "</td><td>" + Product.ProNum + "</td></tr>");
            }

            sb.AppendFormat("</table>");
            sb.AppendFormat("<br /><font size='+3' color='#0033CC'>收货人信息:</font><br />");
            sb.AppendFormat("<ul>");

            sb.AppendFormat("<li>收货人手机：" + order.ConsigneePhone + "</li>");
            sb.AppendFormat("<li>收货人：" + order.ConsigneeRealName + "</li>");

            sb.AppendFormat("<li>收货人地址：" + order.ConsigneeAddress + "</li>");

            sb.AppendFormat("<li>邮政编码：" + order.ConsigneeZip + "</li>");

            sb.AppendFormat("<li>总费用：" + order.TotalPrice + "</li>");

            sb.AppendFormat("<li><font color='#FF0000' size='+2'>实际费用：" + order.FactPrice + "</font></li>");

            sb.AppendFormat("</ul>");

            return sb.ToString();
        }
        #endregion
        /// <summary>
        /// 通过订单号获取订单信息
        /// </summary>
        /// <param name="OrderId">订单号</param>
        /// <returns></returns>
        public orders GetOrdersByOrderId(string OrderId)
        { 
         return new ordersDAL().GetOrdersMemberInfo(OrderId);
        }
        #region 根据订单号获取订单收货人信息
        /// <summary>
        /// 根据订单号获取订单收货人信息 
        /// </summary>
        /// <param name="OrderId">订单号</param>
        /// <returns></returns>
        public string GetOrdersMemberInfo(string OrderId)
        {
            orders Info = new ordersDAL().GetOrdersMemberInfo(OrderId);
            bool Status = false;
            if (Info.Id.HasValue)
                Status = true;
            StringBuilder Json = new StringBuilder();
            StringWriter sw = new StringWriter(Json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");
                jsonWriter.WriteStartArray();

                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("ConsigneeAddress");
                jsonWriter.WriteValue(Info.ConsigneeProvince+ Info.ConsigneeAddress);
                jsonWriter.WritePropertyName("ConsigneeRealName");
                jsonWriter.WriteValue(Info.ConsigneeRealName);
                jsonWriter.WritePropertyName("ConsigneeTel");
                jsonWriter.WriteValue(Info.ConsigneeTel);
                jsonWriter.WritePropertyName("ConsigneeEmail");
                jsonWriter.WriteValue(Info.ConsigneeEmail);
                jsonWriter.WritePropertyName("ConsigneePhone");
                jsonWriter.WriteValue(Info.ConsigneePhone);
                jsonWriter.WritePropertyName("ConsigneeZip");
                jsonWriter.WriteValue(Info.ConsigneeZip);
                jsonWriter.WriteEndObject();

                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
            }
            return Json.ToString();
        } 
       
        #endregion
        #region 取消订单
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="OrderStatus">订单状态</param>
        /// <returns></returns>
        public bool CancelOrdersStatus(string Id, orders.ePaymentStatus PayStatus, orders.eOrderStatus OrderStatus)
        {
            return new ordersDAL().CancelOrdersStatus(Id, PayStatus.GetHashCode().ToString(), OrderStatus.GetHashCode().ToString());
        } 
        #endregion
        #region 订单状态修改
        /// <summary>
        /// 订单状态修改
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="PayStatus">支付状态</param>
        /// <param name="OgisticsStatus">送货状态</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <returns></returns>
        public bool UpdateOrdersStatus(string Id, orders.ePaymentStatus PayStatus, orders.eOgisticsStatus OgisticsStatus,orders.eOrderStatus OrderStatus)
        {
            return new ordersDAL().UpdateOrdersStatus(Id, PayStatus.GetHashCode().ToString(),OrderStatus.GetHashCode().ToString (),OgisticsStatus.GetHashCode().ToString());
        }
        #endregion
    }

}
