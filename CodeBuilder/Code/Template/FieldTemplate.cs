using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 字段模板
    /// </summary>
    public class FieldTemplate: DbModelTemplate
    {
        /// <summary>
        /// 是否是属性
        /// </summary>
        public bool IsAttribute { get; set; } = true;
        /// <summary>
        /// 备注
        /// </summary>
        public CommentTemplate Comment { get; set; }
        /// <summary>
        /// 字段类型名称
        /// </summary>
        public string FieldTypeName { get; set; } = "string";
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 可空类型
        /// </summary>
        public bool CanNull { get; set; } = false;
        /// <summary>
        /// 访问限制
        /// </summary>
        public string FiledLimit { get;private set; } = VisitLimit.Public.GetDescription();

        public void SetFiledLimit(VisitLimit visitLimit)
        {
            FiledLimit = visitLimit.GetDescription();
        }
    }
}
