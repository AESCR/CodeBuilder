using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 命名空间模板
    /// </summary>
    public class NamespaceTemplate
    {
        private readonly List<string> _importNamespace;
        private readonly List<ClassTemplate> _classTemplate;
        public NamespaceTemplate()
        {
            _classTemplate = new List<ClassTemplate>();
            _importNamespace = new List<string>();
        }
        /// <summary>
        /// 导入命名空间
        /// </summary>
        /// <param name="namespace"></param>
        /// <returns></returns>
        public void ImportNamespace(string @namespace)
        {
            _importNamespace.AddIfNotContains(@namespace);
        }
        /// <summary>
        /// 添加类模板
        /// </summary>
        /// <param name="classTemplate"></param>
        /// <returns></returns>
        public void AddClass(ClassTemplate classTemplate)
        {
            _classTemplate.Add(classTemplate);
        }
    }
}
