using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.DAL;
using czcraft.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
namespace czcraft.DAL
{
    public partial class productDAL
    {
        #region  增加product
        /// <summary>
        /// 增加product
        /// </summary>
        /// <param name="model">tableName实体</param>
        /// <returns>执行状态</returns>
        public long AddNew(product model)
        {
            string MasterId = model.Masterid.HasValue ? model.Masterid.ToString() : "NULL";
            string CompanyId = model.Companyid.HasValue ? model.Companyid.ToString() : "NULL";
            string sql = "insert into product(Name,Simplename,Explain,Picturepath,Flashpath,Material,Weight,Volume,Specification,Model,Issell,Isexcellent,Nongenetic,Isrecomment,Isshow,Typeid,Belongstype,Masterid,Companyid,Num,Soldnum,Lsprice,Pfprice,Vipprice,MarketPrice,Price1,Price2,Price3,Price4,hit,rank) output inserted.Id values(@Name,@Simplename,@Explain,@Picturepath,@Flashpath,@Material,@Weight,@Volume,@Specification,@Model,@Issell,@Isexcellent,@Nongenetic,@Isrecomment,@Isshow,@Typeid,@Belongstype," + MasterId + "," + CompanyId + "," +
                //@Masterid,@Companyid,
            "@Num,@Soldnum,@Lsprice,@Pfprice,@Vipprice,@MarketPrice,@Price1,@Price2,@Price3,@Price4,@hit,@rank)";
            long id = (long)SqlHelper.ExecuteScalar(sql
                        , (DbParameter)new SqlParameter("Name", model.Name)
                        , (DbParameter)new SqlParameter("Simplename", model.Simplename)
                        , (DbParameter)new SqlParameter("Explain", model.Explain)
                        , (DbParameter)new SqlParameter("Picturepath", model.Picturepath)
                        , (DbParameter)new SqlParameter("Flashpath", model.Flashpath)
                        , (DbParameter)new SqlParameter("Material", model.Material)
                        , (DbParameter)new SqlParameter("Weight", model.Weight)
                        , (DbParameter)new SqlParameter("Volume", model.Volume)
                        , (DbParameter)new SqlParameter("Specification", model.Specification)
                        , (DbParameter)new SqlParameter("Model", model.Model)
                        , (DbParameter)new SqlParameter("Issell", model.Issell)
                        , (DbParameter)new SqlParameter("Isexcellent", model.Isexcellent)
                        , (DbParameter)new SqlParameter("Nongenetic", model.Nongenetic)
                        , (DbParameter)new SqlParameter("Isrecomment", model.Isrecomment)
                        , (DbParameter)new SqlParameter("Isshow", model.Isshow)
                        , (DbParameter)new SqlParameter("Typeid", model.Typeid)
                        , (DbParameter)new SqlParameter("Belongstype", model.Belongstype)
                //, (DbParameter)new SqlParameter("Masterid", model.Masterid.HasValue ? model.Masterid.ToString() : "NULL")
                //, (DbParameter)new SqlParameter("Companyid", model.Companyid.HasValue ? model.Companyid.ToString() : "NULL")
                        , (DbParameter)new SqlParameter("Num", model.Num)
                        , (DbParameter)new SqlParameter("Soldnum", model.Soldnum)
                        , (DbParameter)new SqlParameter("Lsprice", model.Lsprice)
                        , (DbParameter)new SqlParameter("Pfprice", model.Pfprice)
                        , (DbParameter)new SqlParameter("Vipprice", model.Vipprice)
                        , (DbParameter)new SqlParameter("MarketPrice", model.MarketPrice)
                        , (DbParameter)new SqlParameter("Price1", model.Price1)
                        , (DbParameter)new SqlParameter("Price2", model.Price2)
                        , (DbParameter)new SqlParameter("Price3", model.Price3)
                        , (DbParameter)new SqlParameter("Price4", model.Price4)
                        , (DbParameter)new SqlParameter("hit", model.hit)
                        , (DbParameter)new SqlParameter("rank", model.rank)
            );
            return id;
        } 
        #endregion
        #region 更新product实体
        /// <summary>
        /// 更新product实体
        /// </summary>
        /// <param name="model">tableName实体</param>
        /// <returns>执行状态</returns>
        public bool Update(product model)
        {
            string MasterId = model.Masterid.HasValue ? model.Masterid.ToString() : "NULL";
            string CompanyId = model.Companyid.HasValue ? model.Companyid.ToString() : "NULL";
            string sql = "update product set Name=@Name,Simplename=@Simplename,Explain=@Explain,Picturepath=@Picturepath,Flashpath=@Flashpath,Material=@Material,Weight=@Weight,Volume=@Volume,Specification=@Specification,Model=@Model,Issell=@Issell,Isexcellent=@Isexcellent,Nongenetic=@Nongenetic,Isrecomment=@Isrecomment,Isshow=@Isshow,Typeid=@Typeid,Belongstype=@Belongstype,MasterId=" + MasterId + ",CompanyId=" + CompanyId + "," + //Masterid=@Masterid,Companyid=@Companyid,//
        "Num=@Num,Soldnum=@Soldnum,Lsprice=@Lsprice,Pfprice=@Pfprice,Vipprice=@Vipprice,MarketPrice=@MarketPrice,Price1=@Price1,Price2=@Price2,Price3=@Price3,Price4=@Price4 where id=@id";
            return SqlHelper.ExecuteNonQuery(sql
                            , (DbParameter)new SqlParameter("Id", model.Id)
                            , (DbParameter)new SqlParameter("Name", model.Name)
                            , (DbParameter)new SqlParameter("Simplename", model.Simplename)
                            , (DbParameter)new SqlParameter("Explain", model.Explain)
                            , (DbParameter)new SqlParameter("Picturepath", model.Picturepath)
                            , (DbParameter)new SqlParameter("Flashpath", model.Flashpath)
                            , (DbParameter)new SqlParameter("Material", model.Material)
                            , (DbParameter)new SqlParameter("Weight", model.Weight)
                            , (DbParameter)new SqlParameter("Volume", model.Volume)
                            , (DbParameter)new SqlParameter("Specification", model.Specification)
                            , (DbParameter)new SqlParameter("Model", model.Model)
                            , (DbParameter)new SqlParameter("Issell", model.Issell)
                            , (DbParameter)new SqlParameter("Isexcellent", model.Isexcellent)
                            , (DbParameter)new SqlParameter("Nongenetic", model.Nongenetic)
                            , (DbParameter)new SqlParameter("Isrecomment", model.Isrecomment)
                            , (DbParameter)new SqlParameter("Isshow", model.Isshow)
                            , (DbParameter)new SqlParameter("Typeid", model.Typeid)
                            , (DbParameter)new SqlParameter("Belongstype", model.Belongstype)
                //, (DbParameter)new SqlParameter("Masterid", model.Masterid.HasValue ? model.Masterid.ToString() : "NULL")
                //, (DbParameter)new SqlParameter("Companyid", model.Companyid.HasValue ? model.Companyid.ToString() : "NULL")
                            , (DbParameter)new SqlParameter("Num", model.Num)
                            , (DbParameter)new SqlParameter("Soldnum", model.Soldnum)
                            , (DbParameter)new SqlParameter("Lsprice", model.Lsprice)
                            , (DbParameter)new SqlParameter("Pfprice", model.Pfprice)
                            , (DbParameter)new SqlParameter("Vipprice", model.Vipprice)
                            , (DbParameter)new SqlParameter("MarketPrice", model.MarketPrice)
                            , (DbParameter)new SqlParameter("Price1", model.Price1)
                            , (DbParameter)new SqlParameter("Price2", model.Price2)
                            , (DbParameter)new SqlParameter("Price3", model.Price3)
                            , (DbParameter)new SqlParameter("Price4", model.Price4)
                //  , (DbParameter)new SqlParameter("hit", model.hit)
                //  , (DbParameter)new SqlParameter("rank", model.rank)
                );
        } 
        #endregion
        #region 更新大师排名信息
        /// <summary>
        /// 更新大师排名信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateproductRank(product model)
        {

            string sql = "update product set rank=@rank where Id=@Id";
            return SqlHelper.ExecuteNonQuery(sql
                            , (DbParameter)new SqlParameter("Id", model.Id)
                            , (DbParameter)new SqlParameter("rank", model.rank)
                );

        } 
        #endregion
        #region 根据排名查询首页显示的前n个商品
        /// <summary>
        /// 根据排名查询首页显示的前n个商品
        /// </summary>
        /// <param name="TopNum">排名</param>
        /// <returns></returns>
        public IEnumerable<product> GetTopProductForMain(int TopNum)
        {
            string sql = "select top (" + TopNum + ")  * from product where Isshow='1' order by rank desc";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<product> list = new List<product>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;
        } 
        #endregion
        #region 根据排名寻找产品
        /// <summary>
        /// 根据排名寻找产品
        /// </summary>
        /// <param name="TopNum">排名</param>
        /// <returns></returns>
        public IEnumerable<product> GetTopProductByRank(int TopNum)
        {
            string sql = "select top (" + TopNum + ")  * from product order by rank desc";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<product> list = new List<product>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;
        } 
        #endregion
        #region 删除产品

        #region 删除product
        /// <summary>
        /// 删除product
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(long id)
        {
            bool status = false;
            SqlHelper.Open();
            SqlHelper.BeginTrans();

            status = SqlHelper.ExecuteNonQuery("delete from MemberCollection where ProductId=@id;delete from ShoppingCart where ProductId=@id;delete from comment where Productid=@id;delete from product_picturepath where Productid=@id; delete from product where id=@id",
                            (DbParameter)new SqlParameter("id", id));
            if (status)
            {
                SqlHelper.CommitTrans();
                return true;
            }
            else
            {
                SqlHelper.RollbackTrans();
                return false;
            }
        } 
        #endregion
        #region 获取删除产品的前置sql语句
        /// <summary>
        /// 获取删除产品的前置sql语句
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        internal string GetDeleteProductSqlString(string ProductId)
        {
            string sql = string.Format("delete from MemberCollection where ProductId={0};delete from ShoppingCart where ProductId={0};delete from comment where Productid={0};delete from product_picturepath where Productid={0}; delete from product where id={0};", ProductId);
            return sql;
        } 
        #endregion
        #region 删除product
        /// <summary>
        /// 删除product
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            bool status = false;
            string[] IDs = strID.Split(',');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < IDs.Length; i++)
            {
                sb.Append("delete from MemberCollection where ProductId=" + IDs[i] + ";");
                sb.Append("delete from ShoppingCart where ProductId=" + IDs[i] + ";");
                sb.Append("delete from comment where Productid=" + IDs[i] + ";");
                sb.Append("delete from product_picturepath where Productid=" + IDs[i] + ";");

            }
            sb.Append("delete from product where id in (" + strID + ")");
            SqlHelper.Open();
            SqlHelper.BeginTrans();
            if (SqlHelper.ExecuteNonQuery(sb.ToString()))
            {
                status = true;
                SqlHelper.CommitTrans();
            }
            else
            {
                status = false;
                SqlHelper.RollbackTrans();
            }

            return status;
        } 
        #endregion
        #endregion
        #region 获得产品图片
        #region 获得企业的所有产品图片
        /// <summary>
        /// 获得所有的产品图片
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public DataTable GetProductsPicByCompanyId(string CompanyId)
        {
            string sql = "select Picturepath,Id from Product where Companyid=" + CompanyId;
            return SqlHelper.ExecuteDataTable(sql);
        }

        /// <summary>
        /// 获得所有的产品图片
        /// </summary>
        /// <param name="CompanyIds"></param>
        /// <returns></returns>
        public DataTable GetProductsPicByMoreCompanyIds(string CompanyIds)
        {
            string sql = "select Picturepath,Id from Product where Companyid  in(" + CompanyIds + ")";
            return SqlHelper.ExecuteDataTable(sql);
        }
        #endregion
        #region 获取产品多张图片信息
        /// <summary>
        /// 获取产品多张图片信息
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public DataTable GetMoreProductPic(string Ids)
        {
            string sql = "select Picturepath from product where id in (" + Ids + ")";
            return SqlHelper.ExecuteDataTable(sql);
        }
        #endregion

        #region 获得大师的所有产品图片
        /// <summary>
        /// 获得大师所有的产品图片
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public DataTable GetProductsPicByMasterId(string MasterId)
        {
            string sql = "select Picturepath,Id from Product where Masterid=" + MasterId;
            return SqlHelper.ExecuteDataTable(sql);
        }

        /// <summary>
        /// 获得大师所有的产品图片
        /// </summary>
        /// <param name="CompanyIds"></param>
        /// <returns></returns>
        public DataTable GetProductsPicByMoreMasterIds(string MasterIds)
        {
            string sql = "select Picturepath,Id from Product where Masterid  in(" + MasterIds + ")";
            return SqlHelper.ExecuteDataTable(sql);
        }
        #endregion
    
        #endregion
    }
}
