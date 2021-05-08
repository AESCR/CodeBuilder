using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 属性模板
    /// </summary>
    public class AttributeTemplate
    {
        /// <summary>
        /// 是否是数据库实体
        /// </summary>
        public bool IsDbModel { get; set; } =true;
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsKey { get; set; } = false;
        /// <summary>
        /// 最小长度
        /// </summary>
        public int MinLength { get; set; } = 0;
        /// <summary>
        /// 最大长度
        /// </summary>
        public long MaxLength { get; set; } = 0;
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int? DecimalDigits { get; set; }
    }
}
