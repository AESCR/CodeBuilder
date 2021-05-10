using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly List<InterfaceTemplate> _interfaceTemplate;
        public NamespaceTemplate()
        {
            _classTemplate = new List<ClassTemplate>();
            _importNamespace = new List<string>();
            _interfaceTemplate=new List<InterfaceTemplate>();
        }
        /// <summary>
        /// 命名空间名称
        /// </summary>
        public string NamespaceName { get; set; }

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
        /// <summary>
        /// 添加类模板
        /// </summary>
        /// <returns></returns>
        public ClassTemplate CreateClass()
        {
            ClassTemplate classTemplate=new ClassTemplate();
            _classTemplate.Add(classTemplate);
            return classTemplate;
        }
        /// <summary>
        /// 创建接口模板
        /// </summary>
        /// <returns></returns>
        public InterfaceTemplate CreateInterface()
        {
            InterfaceTemplate interfaceTemplate = new InterfaceTemplate();
            _interfaceTemplate.Add(interfaceTemplate);
            return interfaceTemplate;
        }
        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                //写入using命名空间
                for (int i = 0; i < _importNamespace.Count; i++)
                {
                    stringWriter.WriteLine($"using {_importNamespace[i]};");
                }
                stringWriter.WriteLine();
                {
                    stringWriter.WriteLine($"namespace {NamespaceName}");
                    stringWriter.WriteLine("{");
                    foreach (var classTemplate in _classTemplate)
                    {
                        var classStr = classTemplate.Generate();
                        using (StringReader stringReader = new StringReader(classStr))
                        {
                            while (stringReader.Peek() != -1)
                            {
                                stringWriter.WriteLine("\t" + stringReader.ReadLine());
                            }
                        }
                    }
                    foreach (var interfaceTemplate in _interfaceTemplate)
                    {
                        var classStr = interfaceTemplate.Generate();
                        using (StringReader stringReader = new StringReader(classStr))
                        {
                            while (stringReader.Peek() != -1)
                            {
                                stringWriter.WriteLine("\t" + stringReader.ReadLine());
                            }
                        }
                    }
                    stringWriter.WriteLine("}");
                }
                return stringWriter.ToString();
            }
        }

    }
}
