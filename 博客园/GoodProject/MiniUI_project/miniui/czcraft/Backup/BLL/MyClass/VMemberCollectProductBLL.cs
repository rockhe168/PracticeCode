using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
{
   public partial class VMemberCollectProductBLL
    {
        #region 获得收藏数据
        /// <summary>
        /// 获得收藏数据
        /// </summary>
        /// <param name="IsToday">是否是今天的收藏数据</param>
        /// <param name="MemberId">会员id</param>
        /// <returns></returns>
        public IEnumerable<Collection> GetCollectProductsByToday(bool IsToday, string MemberId)
        {
            //收藏夹容器
            List<Collection> listCollection = new List<Collection>();
            //收藏的数据读取
            IEnumerable<VMemberCollectProduct> ListProduct = new VMemberCollectProductDAL().GetCollectProductsByToday(IsToday, MemberId);
            foreach (VMemberCollectProduct Info in ListProduct)
            {
                Collection Collect = new Collection();
                Collect.Name = Info.Name;
                Collect.ProductId = Info.ProductId;
                Collect.MemberId = Info.MemberId;
                Collect.Material = Info.Material;
                Collect.LsPrice = Info.Lsprice;
                Collect.PicturePath = Info.Picturepath;
                //企业
                if (Info.Belongstype == 1)
                {
                    company com = new companyDAL().Get(Info.Companyid.Value);
                    //所属id 
                    Collect.BelongId = com.Id.ToString();
                    //卖家
                    Collect.BelongSell = com.Name;

                }
                //大师
                else if (Info.Belongstype == 0)
                {
                    master mat = new masterDAL().Get(Info.Masterid.Value);
                    //所属id 
                    Collect.BelongId = mat.Id.ToString();
                    //卖家
                    Collect.BelongSell = mat.Name;
                }
                //工艺集团官方
                else
                {
                    master mat = new masterDAL().Get(Info.Masterid.Value);
                    //所属id 
                    Collect.BelongId = mat.Id.ToString();
                    //卖家
                    Collect.BelongSell = mat.Name;
                }
                //所属类型
                Collect.BelongType = Info.Belongstype.ToString();
                Collect.AddTime = Info.AddTime;

                listCollection.Add(Collect);

            }
            return listCollection;
        } 
        #endregion


    }
}
