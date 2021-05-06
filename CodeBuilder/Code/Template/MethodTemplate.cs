using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 方法模板
    /// </summary>
    public class MethodTemplate
    {
        /// <summary>
        /// 备注
        /// </summary>
        public CommentTemplate Comment { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string ReturnName { get; set; } = "void";

        /// <summary>
        /// 参数
        /// </summary>
        public List<ParameterTemplate> Parameters { get; set; } = new List<ParameterTemplate>();

        /// <summary>
        /// 是否是虚方法
        /// </summary>
        public bool IsVirtual { get; set; } = false;

        /// <summary>
        /// 是否是抽象类方法
        /// </summary>
        public bool IsAbstract { get; set; } = false;
        /// <summary>
        /// 是否是接口
        /// </summary>
        public bool IsInterface { get; set; } = false;
        /// <summary>
        /// 是属性方法
        /// </summary>
        public bool IsAttribute { get; set; }
        /// <summary>
        /// 方法访问限制
        /// </summary>
        public string MethodLimit { get; private set; } = VisitLimit.Public.GetDescription();
        /// <summary>
        /// 设置访问权限
        /// </summary>
        /// <param name="visitLimit"></param>
        public void SetMethodLimit(VisitLimit visitLimit)
        {
            MethodLimit = visitLimit.GetDescription();
        }
    }
}
