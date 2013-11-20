using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Data;

namespace czcraft.BLL
{
   public partial class crafttypeBLL
    {
        #region 获取自己的Fid
        /// <summary>
        /// 获取自己的Fid
        /// </summary>
        /// <param name="Belongsid"></param>
        /// <returns></returns>
        public string GetFId(int Belongsid)
        {
            string MaxBortherFId = new crafttypeDAL().GetFatherMaxChildFId(Belongsid);//获取兄弟最大Fid的属性(格式F0101)
            //前缀F01
            string FirstStr = MaxBortherFId.Substring(0, MaxBortherFId.Length - 2);
            //后缀01
            string LastStr = MaxBortherFId.Substring(MaxBortherFId.Length - 2, 2);
            int LastNum = Convert.ToInt32(LastStr) + 1;
            //拼接自己的FId
            string FId = FirstStr + string.Format("{0:D2}", LastNum);//拼接字符串F0102
            return FId;
        } 
        #endregion
        #region 增加crafttype
        /// <summary>
        /// 增加crafttype
        /// </summary>
        /// <param name="model">tableName实体</param>
        /// <returns>执行状态</returns>
        public bool AddNewAndUpdateLeaf(crafttype model)
        {
            model.FId = GetFId((int)model.Belongsid);
            return new crafttypeDAL().AddNewAndUpdateLeaf(model);
        } 
        #endregion
       #region 获取顶级的产品类别信息
       /// <summary>
       /// 获取顶级的产品类别信息
       /// </summary>
       /// <returns></returns>
       public IEnumerable<crafttype> GetTopTypeInfo()
       {
           return new crafttypeDAL().GetTopTypeInfo(-1);//顶级的产品belongsid为1
       } 
       #endregion
       #region 获取顶级产品类别信息的json格式
       /// <summary>
       /// 获取顶级产品类别信息的json格式
       /// </summary>
       /// <returns></returns>
       public string GetTopTreeToJson()
       {
           StringBuilder sb = new StringBuilder("[");
           IEnumerable<crafttype> craftTypeList = GetTopTypeInfo();

           foreach (crafttype root in craftTypeList)
           {
               sb.Append("{\"TypeId\":\"" + root.ID + "\",\"TypeName\":\"" + root.Name + "\"");
               sb.Append(",\"FId\":\"" + root.FId + "\"");
               sb.Append("},");

           }
           sb.Remove(sb.Length - 1, 1);   //去除掉最后一个多余的,
           sb.Append("]");
           return sb.ToString();

       } 
       #endregion
       #region 为产品类别多选生成json数据
       /// <summary>
       /// 为产品类别多选生成json数据(json格式[{id: "base", text: "Base", expanded: false},{}]等)
       /// </summary>
       /// <returns></returns>
       public string MultiProductTypeForJson()
       {
           StringBuilder sb = new StringBuilder("[");
           IEnumerable<crafttype> craftTypeList = GetTopTypeInfo();

           foreach (crafttype root in craftTypeList)
           {
               sb.Append("{\"id\":\"" + root.ID + "\",\"text\":\"" + root.Name + "\"");
               sb.Append(",\"expanded\":false");
               sb.Append("},");

           }
           sb.Remove(sb.Length - 1, 1);   //去除掉最后一个多余的,
           sb.Append("]");
           return sb.ToString();

       } 
       #endregion
       #region 工艺品类别树转化为json格式
       /// <summary>
       /// 工艺品类别树转化为json格式
       /// </summary>
       /// <returns></returns>
       public string craftTypeTreeToJson()
       {
           //传递的json格式

           IEnumerable<crafttype> craftTypeList = new crafttypeDAL().ListAll();
           StringBuilder sb = new StringBuilder("[");

           foreach (crafttype root in craftTypeList)
           {
               if (root.Belongsid == -1)
               {
                   sb.Append("{id:\"" + root.ID + "\",text:\"" + root.Name + "\"");
                   sb.Append(",pid:\"-1\"");//添加父节点
                   sb.Append(",expanded:\"false\"");
                   if (root.IsLeaf == "0")//如果是不是叶子节点,那么,就要递归添加children:[{xxx},内容
                   {
                       sb.Append(",children:");
                       GetLeafTree(ref sb, (int)root.ID, craftTypeList);//递归追加叶子
                   }
                   sb.Append("},");
               }

           }
           sb.Remove(sb.Length - 1, 1);   //去除掉最后一个多余的,
           sb.Append("]");
           return Common.FormatToJson.MiniUiToJsonForTree(sb.ToString(), "工艺品类别");

       } 
       #endregion
       #region 递归获得父级ID下的所有类别json数据
       /// <summary>
       /// 递归获得父级ID下的所有类别json数据
       /// </summary>
       /// <param name="sb">json字符串</param>
       /// <param name="parentID">父级id</param>
       /// <param name="craftTypeList">类别信息集合</param>
       public void GetLeafTree(ref StringBuilder sb, int parentID, IEnumerable<crafttype> craftTypeList)
       {
           sb.Append("[");
           foreach (crafttype leaf in craftTypeList)
           {
               if (leaf.Belongsid == parentID) //根据双亲节点查找叶子
               {
                   sb.Append("{id:\"" + leaf.ID + "\",text:\"" + leaf.Name + "\"");
                   sb.Append(",pid:\"" + parentID + "\"");//添加父节点
                   sb.Append(",expanded:\"false\"");
                   if (leaf.IsLeaf == "0")//如果是不是叶子节点,那么,就要递归添加children:[{xxx},内容
                   {
                       sb.Append(",children:");
                       GetLeafTree(ref sb, (int)leaf.ID, craftTypeList);//递归追加叶子

                   }
                   sb.Append("},");
               }
           }
           sb.Remove(sb.Length - 1, 1);   //去除掉最后一个多余的,
           sb.Append("]");




       } 
       #endregion
       #region 删除
       #region 删除crafttype
       /// <summary>
       /// 删除crafttype
       /// </summary>
       /// <param name="id">id</param>
       /// <returns>执行状态</returns>
       public bool Delete(int id)
       {
           #region 大师图片信息保存
           //获取大师主Id信息
           DataTable dtMasterIds = new masterDAL().GetAllMasterByCraftType(id.ToString());
           StringBuilder MasterIds = new StringBuilder();
           foreach (DataRow dr in dtMasterIds.Rows)
           {
               MasterIds.Append(dr["Masterid"].ToString());
           }
           MasterIds.Remove(MasterIds.Length - 1, 1);
           //大师多个id
           string strMasterIds = MasterIds.ToString();
           //获取大师主图片
           DataTable dtMasterPath = new masterDAL().GetMasterMainPic(strMasterIds);
           //获取大师荣誉图片
           DataTable dtMasterCert = new master_certDAL().GetMoreMasterCertPath(strMasterIds);
           //获取大师产品图片
           DataTable dtMasterProducts = new productDAL().GetProductsPicByMoreMasterIds(strMasterIds);
           //获取大师其他产品图片
           StringBuilder ProductIds = new StringBuilder();
           foreach (DataRow dr in dtMasterProducts.Rows)
           {
               ProductIds.Append(dr["Id"].ToString());
           }
           ProductIds.Remove(ProductIds.Length - 1, 1);
           DataTable dtProductOtherProducts = new product_picturepathDAL().GetMoreOtherProductPicPath(ProductIds.ToString());
           #endregion
           #region 企业图片信息保存
           //获取企业主Id信息
           DataTable dtCompanyIds = new companyDAL().GetAllCompanyByCraftType(id.ToString());
           StringBuilder CompanyIds = new StringBuilder();
           foreach (DataRow dr in dtCompanyIds.Rows)
           {
               CompanyIds.Append(dr["Masterid"].ToString());
           }
           CompanyIds.Remove(CompanyIds.Length - 1, 1);
           //企业多个id
           string strCompanyIds = CompanyIds.ToString();
           //获取企业主图片
           DataTable dtCompanyPath = new companyDAL().GetCompanyMainPic(strCompanyIds);
           //获取企业美景图
           DataTable dtCompanyPic = new company_picDAL().GetCompanyPicByMoreCompanyIds(strCompanyIds);
           //获取企业荣誉图片
           DataTable dtCompanyCert = new company_certDAL().GetMoreCompanyCertPath(strCompanyIds);
           //获取企业产品图片
           DataTable dtCompanyProducts = new productDAL().GetProductsPicByMoreCompanyIds(strCompanyIds);
           //获取企业其他产品图片
           StringBuilder CompanyProductIds = new StringBuilder();
           foreach (DataRow dr in dtCompanyProducts.Rows)
           {
               CompanyProductIds.Append(dr["Id"].ToString());
           }
           CompanyProductIds.Remove(CompanyProductIds.Length - 1, 1);
           DataTable dtCompanyOtherProducts = new product_picturepathDAL().GetMoreOtherProductPicPath(ProductIds.ToString());
           #endregion
           //删除
           crafttypeDAL dal = new crafttypeDAL();
           bool Status = dal.Delete(id);
           //如果执行成功,则删除图片
           masterBLL bll = new masterBLL();
           companyBLL companyBll = new companyBLL();
           if (Status)
           {
               #region 大师图片删除
               //删除大师主图片
               bll.DeleteMainMasterPath(dtMasterPath);

               //删除大师荣誉证书

               bll.DeleteMasterCertPic(dtMasterCert);
               //删除所有产品图片

               bll.DeleteProdoctsByMasterId(dtMasterProducts);
               //删除产品其他图片
               new product_picturepathBLL().DeleteMoreOtherProductPic(dtProductOtherProducts);
               #endregion
               #region 企业图片删除
               //删除企业主图片
               companyBll.DeleteMainCompanyPath(dtCompanyPath);
               //删除企业美景图
               companyBll.DeleteCompanyPic(dtCompanyPic);

               //删除多个企业荣誉图片

               companyBll.DeleteCompanyCertPic(dtCompanyCert);
               //删除所有产品图片

               companyBll.DeleteProdoctsByCompanyId(dtCompanyProducts);
               //删除产品其他图片
               new product_picturepathBLL().DeleteMoreOtherProductPic(dtCompanyOtherProducts);
               #endregion

           }
           return Status;

       } 
       #endregion
       #region 删除crafttype
       /// <summary>
       /// 删除crafttype
       /// </summary>
       /// <param name="strID">strID,记得多个用,隔开</param>
       /// <returns>执行状态</returns>
       public bool DeleteMoreID(string strID)
       {
           #region 大师图片信息保存
           //获取大师主Id信息
           DataTable dtMasterIds = new masterDAL().GetAllMasterByCraftType(strID);
           StringBuilder MasterIds = new StringBuilder();
           foreach (DataRow dr in dtMasterIds.Rows)
           {
               MasterIds.Append(dr["Masterid"].ToString());
           }
           MasterIds.Remove(MasterIds.Length - 1, 1);
           //大师多个id
           string strMasterIds = MasterIds.ToString();
           //获取大师主图片
           DataTable dtMasterPath = new masterDAL().GetMasterMainPic(strMasterIds);
           //获取大师荣誉图片
           DataTable dtMasterCert = new master_certDAL().GetMoreMasterCertPath(strMasterIds);
           //获取大师产品图片
           DataTable dtMasterProducts = new productDAL().GetProductsPicByMoreMasterIds(strMasterIds);
           //获取大师其他产品图片
           StringBuilder ProductIds = new StringBuilder();
           foreach (DataRow dr in dtMasterProducts.Rows)
           {
               ProductIds.Append(dr["Id"].ToString());
           }
           ProductIds.Remove(ProductIds.Length - 1, 1);
           DataTable dtProductOtherProducts = new product_picturepathDAL().GetMoreOtherProductPicPath(ProductIds.ToString());
           #endregion
           #region 企业图片信息保存
           //获取企业主Id信息
           DataTable dtCompanyIds = new companyDAL().GetAllCompanyByCraftType(strID);
           StringBuilder CompanyIds = new StringBuilder();
           foreach (DataRow dr in dtCompanyIds.Rows)
           {
               CompanyIds.Append(dr["Masterid"].ToString());
           }
           CompanyIds.Remove(CompanyIds.Length - 1, 1);
           //企业多个id
           string strCompanyIds = CompanyIds.ToString();
           //获取企业主图片
           DataTable dtCompanyPath = new companyDAL().GetCompanyMainPic(strCompanyIds);
           //获取企业美景图
           DataTable dtCompanyPic = new company_picDAL().GetCompanyPicByMoreCompanyIds(strCompanyIds);
           //获取企业荣誉图片
           DataTable dtCompanyCert = new company_certDAL().GetMoreCompanyCertPath(strCompanyIds);
           //获取企业产品图片
           DataTable dtCompanyProducts = new productDAL().GetProductsPicByMoreCompanyIds(strCompanyIds);
           //获取企业其他产品图片
           StringBuilder CompanyProductIds = new StringBuilder();
           foreach (DataRow dr in dtCompanyProducts.Rows)
           {
               CompanyProductIds.Append(dr["Id"].ToString());
           }
           CompanyProductIds.Remove(CompanyProductIds.Length - 1, 1);
           DataTable dtCompanyOtherProducts = new product_picturepathDAL().GetMoreOtherProductPicPath(ProductIds.ToString());
           #endregion
           //删除
           crafttypeDAL dal = new crafttypeDAL();
           bool Status = dal.DeleteMoreID(strID);
           //如果执行成功,则删除图片
           masterBLL bll = new masterBLL();
           companyBLL companyBll = new companyBLL();
           if (Status)
           {
               #region 大师图片删除
               //删除大师主图片
               bll.DeleteMainMasterPath(dtMasterPath);

               //删除大师荣誉证书

               bll.DeleteMasterCertPic(dtMasterCert);
               //删除所有产品图片

               bll.DeleteProdoctsByMasterId(dtMasterProducts);
               //删除产品其他图片
               new product_picturepathBLL().DeleteMoreOtherProductPic(dtProductOtherProducts);
               #endregion
               #region 企业图片删除
               //删除企业主图片
               companyBll.DeleteMainCompanyPath(dtCompanyPath);
               //删除企业美景图
               companyBll.DeleteCompanyPic(dtCompanyPic);

               //删除多个企业荣誉图片

               companyBll.DeleteCompanyCertPic(dtCompanyCert);
               //删除所有产品图片

               companyBll.DeleteProdoctsByCompanyId(dtCompanyProducts);
               //删除产品其他图片
               new product_picturepathBLL().DeleteMoreOtherProductPic(dtCompanyOtherProducts);
               #endregion

           }
           return Status;
       } 
       #endregion
        #endregion
    }
}
