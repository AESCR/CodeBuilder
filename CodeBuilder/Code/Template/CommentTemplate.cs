using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 代码模板
    /// </summary>
    public class CommentTemplate
    {
        /// <summary>
        /// 注释介绍
        /// </summary>
        public string CommentName { get; set; }
    }
}
