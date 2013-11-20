using System.Collections.Generic;
using System.ServiceModel;
using DTO;

namespace IFacade.IProducts
{
    /// <summary>
    /// 产品远程外观接口
    /// 这里定义了远程调用服务的契约，实现契约和实现分离。
    /// </summary>
    [ServiceContract]
    public interface IProductFacade
    {
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<ProductDTO> GetAllProducts();
    }
}
