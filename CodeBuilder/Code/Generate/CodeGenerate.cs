using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuilder.Code.Template;

namespace CodeBuilder.Code.Generate
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public class CodeGenerate
    {
        private readonly List<string> _importNamespace;
        private readonly List<NamespaceTemplate> _namespaceCode;
        public CodeGenerate()
        {
            _namespaceCode = new List<NamespaceTemplate>();
            _importNamespace = new List<string>
            {
                "System",
                "System.Linq",
                "System.Text",
                "System.Threading.Tasks",
                "System.Collections.Generic",
                "System.ComponentModel.DataAnnotations"
            };
        }

        /// <summary>
        /// 导入命名空间
        /// </summary>
        /// <param name="namespace"></param>
        /// <returns></returns>
        public CodeGenerate ImportNamespace(string @namespace)
        {
            _importNamespace.AddIfNotContains(@namespace);
            return this;
        }
        /// <summary>
        /// 添加命名空间
        /// </summary>
        /// <param name="namespaceTemplate"></param>
        /// <returns></returns>
        public CodeGenerate AddNamespace(NamespaceTemplate namespaceTemplate)
        {
            _namespaceCode.Add(namespaceTemplate);
            return this;
        }
    }
}
