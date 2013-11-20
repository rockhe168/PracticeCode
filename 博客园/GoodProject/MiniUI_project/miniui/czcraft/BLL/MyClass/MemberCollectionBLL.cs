using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
{
   public partial class MemberCollectionBLL
    {
        #region 检验收藏夹是否已经加入该类产品
        /// <summary>
        /// 检验收藏夹是否已经加入该类产品,如果加入则不能再次加入
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public bool CheckCartExist(string ProductId,string MemberId)
        {
            int Count = new MemberCollectionDAL().GetCount(" ProductId=" + ProductId + " and MemberId=" + MemberId);
            return Count > 0;
        }
        #endregion
        #region 加入收藏夹
        /// <summary>
        /// 加入收藏夹
        /// </summary>
        /// <param name="model">ShoppingCart实体</param>
        /// <returns></returns>
        public bool AddNewCollection(MemberCollection model)
        {
            return new MemberCollectionDAL().AddNew(model) > 0;
        }

        #endregion
        #region 更新收藏夹信息
        /// <summary>
        /// 更新收藏夹信息
        /// </summary>
        /// <param name="model">收藏夹</param>
        /// <returns></returns>
        public bool UpdateCollection(MemberCollection model)
        {
            return new MemberCollectionDAL().UpdateCollection(model);

        }
        #endregion
    }
}
