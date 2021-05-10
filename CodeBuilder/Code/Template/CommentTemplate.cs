using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 注释模板
    /// </summary>
    public class CommentTemplate
    {
        /// <summary>
        /// 注释介绍
        /// </summary>
        public string CommentName { get; set; }

        public string Generate()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                //设置属性注释
                if (string.IsNullOrWhiteSpace(CommentName) == false)
                {
                    stringWriter.WriteLine("/// <summary>");
                    stringWriter.WriteLine("/// " + CommentName);
                    stringWriter.WriteLine("/// </summary>");
                }
                return CommentName.ToString();
            }
        }
    }
}
