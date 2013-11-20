using System;

namespace Domain.common
{

    /// <summary>
    /// 运算符
    /// </summary>
    public enum OperatorWhere
    {
        And,
        Or
    }
    /// <summary>
    /// 比较运算符
    /// </summary>
    public enum ComparisonWhere
    {
        BetweenAnd,//在两者之间
        Equals,//等于
        GreaterOrEquals,//大于等于
        GreaterThan,//大于
        IsNull,//空
        IsNotNull,//非空
        LessOrEquals,//小于等于
        LessThan,//小于
        Like,//模糊查询
        NotEquals//不等于

    }

    /// <summary>
    /// 残友条件类
    /// create by wgc on 2011-10-24
    /// </summary>
    public class CanYouWhere
    {
        /// <summary>
        /// 条件中对应的列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 列所对应的值
        /// </summary>
        public object ParamStartValue { get; set; }
        /// <summary>
        /// 运算符：And/Or
        /// </summary>
        public OperatorWhere OperatorWhere { get; set; }
        /// <summary>
        /// 比较运算符：等于 大于 小于等
        /// </summary>
        public ComparisonWhere ComparisonWhere { get; set; }

        /// <summary>
        /// 用与Between ParamStartValue and ParamEndValue，
        /// 如果没有使用Between 该参数可以不赋值
        /// </summary>
        public object ParamEndValue { get; set; }
        /// <summary>
        /// create by laq on 2011-10-24
        /// 设置分页的条件
        /// </summary>
        /// <param name="pColumnName">列名</param>
        /// <param name="pParamStartValue">对应的列的值</param>
        /// <param name="pOperatorWhere">and 或则 or</param>
        /// <param name="pComparisonWhere">比较运算符</param>
        /// <param name="pParamEndValue">用与Between ParamStartValue and ParamEndValue，如果没有使用Between 该参数可以不赋值</param>
        public CanYouWhere(string pColumnName, Object pParamStartValue, OperatorWhere pOperatorWhere, ComparisonWhere pComparisonWhere, object pParamEndValue)
        {
            ColumnName = pColumnName;
            ParamStartValue = pParamStartValue;
            OperatorWhere = pOperatorWhere;
            ComparisonWhere = pComparisonWhere;
            ParamEndValue = pParamEndValue;
        }
        /// <summary>
        /// 构造函数，指定ColumnName和Value，其他默认为And和Equals
        /// </summary>
        public CanYouWhere(string pColumnName, Object pValue)
        {
            ColumnName = pColumnName;
            ParamStartValue = pValue;
            OperatorWhere = OperatorWhere.And;
            ComparisonWhere = ComparisonWhere.Equals;
            //ParamEndValue = null;
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CanYouWhere()
        {
 
        }
    }
}
