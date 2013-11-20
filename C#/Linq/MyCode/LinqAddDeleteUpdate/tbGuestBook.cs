using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace LinqAddDeleteUpdate
{
    [Table(Name="tbGuestBook")]
    public class tbGuestBook
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column(IsPrimaryKey=true)]
        public Guid Id { get; set; }

        /// <summary>
        /// 留言用户名
        /// </summary>
        [Column(DbType = "varchar(50) NOT NULL", CanBeNull = false)]
        public string UserName { get; set; }

        /// <summary>
        /// 留言时间
        /// </summary>
        [Column(DbType = "datetime NOT NULL", CanBeNull = false)]
        public DateTime PostTime { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        [Column(DbType="varchar(400)")]
        public string Message { get; set; }

        /// <summary>
        /// 留言管理员是否回复
        /// </summary>
        [Column(DbType = "bit NOT NULL", CanBeNull = false)]
        public bool IsReplied { get; set; }


        /// <summary>
        /// 管理员回复内容
        /// </summary>
        [Column(DbType="varchar(400)")]
        public string Reply { get; set; }
    }
}