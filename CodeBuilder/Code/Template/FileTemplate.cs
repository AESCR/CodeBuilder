using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using CodeBuilder.Code.Generate;

namespace CodeBuilder.Code.Template
{
    [Serializable]
    public class FileTemplate
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName
        {
            get
            {
                if (!string.IsNullOrEmpty(_fileName)) return _fileName;
                var code= PreviewCode();
                Regex regex = new Regex(@"(interface|class)[\s]+(?<name>[\w|\d]+)\s*");
                var mt = regex.Match(code);
                var className = mt.Groups["name"].Value;
                if (string.IsNullOrEmpty(className)==false)
                {
                    _fileName= className;
                }
                return _fileName;
            }
            set => _fileName = value;
        }

        public string Extension { get; set; } = ".cs";
        public string FileFullName => FileName + Extension;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string DownloadPath
        {
            get;
            set;
        }

        private string _fileName;
        private readonly List<string> _importNamespace;
        private readonly List<NamespaceTemplate> _namespaceCode;
        public FileTemplate()
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
        public FileTemplate ImportNamespace(string @namespace)
        {
            _importNamespace.AddIfNotContains(@namespace);
            return this;
        }
        /// <summary>
        /// 添加命名空间
        /// </summary>
        /// <param name="namespaceTemplate"></param>
        /// <returns></returns>
        public FileTemplate AddNamespace(NamespaceTemplate namespaceTemplate)
        {
            _namespaceCode.Add(namespaceTemplate);
            return this;
        }
        public NamespaceTemplate CreateNamespace()
        {
            NamespaceTemplate namespaceTemplate = new NamespaceTemplate();
            _namespaceCode.Add(namespaceTemplate);
            return namespaceTemplate;
        }
        /// <summary>
        /// 显示模板
        /// </summary>
        public string PreviewCode()
        {
            StringBuilder sb=new StringBuilder();
            using (StringWriter stringWriter = new StringWriter())
            {
                //写入using命名空间
                foreach (var t in _importNamespace)
                {
                    stringWriter.WriteLine($"using {t};");
                }
                foreach (var namespaceTemplate in _namespaceCode)
                {
                    stringWriter.WriteLine();
                    var naGenerate = namespaceTemplate.Generate();
                    stringWriter.Write(naGenerate);
                    var t = stringWriter.ToString();
                    sb.AppendLine(t);
                }
            }
            return sb.ToString();
        }
        /*/// <summary>
        /// 保存模板
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<> Save()
        {
            var code = Preview();
            var directoryPath = Path.GetFullPath(DownloadPath);
            if (string.IsNullOrEmpty(directoryPath) == false)
            {
                if (Directory.Exists(directoryPath) == false)
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            var filePath = Path.Combine(directoryPath ?? string.Empty, FileName + Extension);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                var bytes = Encoding.UTF8.GetBytes(code);
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Close();
            }
            return true;
        }*/
    }
}