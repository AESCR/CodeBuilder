using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 类模板
    /// </summary>
    public class ClassTemplate
    {
        private readonly List<MethodTemplate> _methodsCode;
        private readonly List<FieldTemplate> _fieldsCode;
        /// <summary> 
        /// 添加方法模板
        /// </summary>
        /// <param name="classTemplate"></param>
        /// <returns></returns>
        public void AddMethod(MethodTemplate classTemplate)
        {
            _methodsCode.Add(classTemplate);
        }
        /// <summary>
        /// 添加字段模板
        /// </summary>
        /// <param name="classTemplate"></param>
        /// <returns></returns>
        public void AddField(FieldTemplate classTemplate)
        {
            _fieldsCode.Add(classTemplate);
        }
        public ClassTemplate()
        {
            _methodsCode = new List<MethodTemplate>();
            _fieldsCode = new List<FieldTemplate>();
        }
        /// <summary>
        /// 设置类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 访问限制
        /// </summary>
        public string LimitType => _accessType.GetDescription()?? "public";
        /// <summary>
        /// 设置访问限制
        /// </summary>
        /// <param name="classLimit"></param>
        public void SetAccess(VisitLimit classLimit)
        {
            _accessType = classLimit;
        }
        private VisitLimit _accessType { get; set; } = VisitLimit.Public;
    }
}
