using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// Db实体模板
    /// </summary>
    public class DbModelTemplate
    {
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsKey { get; set; }
        /// <summary>
        /// 最小长度
        /// </summary>
        public int MinLength { get; set; } = 0;
        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength { get; set; } = 0;
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get; set; }
    }
}
