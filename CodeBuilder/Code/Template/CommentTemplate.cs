using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 代码注释模板
    /// </summary>
    public class CommentTemplate
    {
        /// <summary>
        /// 注释介绍
        /// </summary>
        public string CommentName { get; set; }
        /// <summary>
        /// 响应备注
        /// </summary>
        public string ReturnComment { get; set; } = "string";
        /// <summary>
        /// 参数备注
        /// </summary>
        public List<MethodParameterTemplate> ParameterComment { get; set; } = new List<MethodParameterTemplate>();
    }
}
