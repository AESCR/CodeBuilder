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
        private readonly List<FileTemplate> _fileTemplate;
        public CodeGenerate()
        {
            _fileTemplate=new List<FileTemplate>();
        }

        public FileTemplate CreateFile()
        {
            FileTemplate fileTemplate=new FileTemplate();
            _fileTemplate.Add(fileTemplate);
            return fileTemplate;
        }

        public List<FileTemplate> Preview()
        {
            return _fileTemplate;
        }
        /// <summary>
        /// 保存模板
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            foreach (FileTemplate fileTemplate in _fileTemplate)
            {
                var code= fileTemplate.PreviewCode();
                if (string.IsNullOrEmpty(fileTemplate.DownloadPath))
                {
                    fileTemplate.DownloadPath = DownloadPath;
                }
                var directoryPath = Path.GetFullPath(fileTemplate.DownloadPath);
                if (string.IsNullOrEmpty(directoryPath) == false)
                {
                    if (Directory.Exists(directoryPath) == false)
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                }
                var filePath = Path.Combine(directoryPath ?? string.Empty, fileTemplate.FileFullName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    var bytes = Encoding.UTF8.GetBytes(code);
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Close();
                }
            }
            return true;
        }
    }
}
