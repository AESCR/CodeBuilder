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
        /// 是否生成属性
        /// </summary>
    
        public bool IsGenerateAttribute { get; set; } = true;
        /// <summary>
        /// 主键
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
        /// <summary>
        /// 是手机号
        /// </summary>
        public bool IsPhone { get; set; }
        /// <summary>
        /// 是邮箱
        /// </summary>
        public bool IsEMail { get; set; }
        /// <summary>
        /// [Table("blogs")] 表名
        /// </summary>
        public string TableName { get; set; }
    }
}
