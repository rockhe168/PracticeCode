using System.Collections.Generic;
using Domain.Entity;

namespace IInteraction
{
    /// <summary>
    ///  产品系统交互层接口。
    /// 实现接口和具体实现的分离。降低系统耦合度
    /// </summary>
    public interface IProductSI 
    {
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();
    }
}
