using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CodeBuilder.Code.Template;
namespace CodeBuilder.Code.Generate
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public class CodeGenerate
    {
        public string DownloadPath = "./Code";
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
                "System.ComponentModel.DataAnnotations",
                "System.ComponentModel.DataAnnotations.Schema"
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

        /// <summary>
        /// 显示模板
        /// </summary>
        public Dictionary<string,string> Show()
        {
            Dictionary<string, string> codeDic=new Dictionary<string, string>();
            foreach (var namespaceTemplate in _namespaceCode)
            {
                using (StringWriter stringWriter = new StringWriter())
                {
                    //写入using命名空间
                    for (int i = 0; i < _importNamespace.Count; i++)
                    {
                        stringWriter.WriteLine($"using {_importNamespace[i]};");
                    }
                    stringWriter.WriteLine();
                    var naGenerate = namespaceTemplate.Generate();
                    stringWriter.Write(naGenerate);
                    var t = stringWriter.ToString();
                    Regex regex = new Regex(@"class[\s]+(?<name>[\w|\d]+)\s*");
                    var mt = regex.Match(t);
                    var className = mt.Groups["name"].Value;
                    codeDic.Add(className, t);
                }
            }
            return codeDic;
        }

        /// <summary>
        /// 保存模板
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            var codeDic = Show();
            //开始输出模板
            foreach (var keyValue in codeDic)
            {
                var directoryPath = Path.GetFullPath(DownloadPath);
                if (string.IsNullOrEmpty(directoryPath) == false)
                {
                    if (Directory.Exists(directoryPath) == false)
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                }
                var filePath = Path.Combine(directoryPath ?? string.Empty, keyValue.Key + ".cs");
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    var bytes = Encoding.UTF8.GetBytes(keyValue.Value);
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Close();
                }
            }
            return true;
        }
    }
}
