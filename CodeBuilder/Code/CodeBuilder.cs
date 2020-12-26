using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeBuilder.Code
{
    public class CodeBuilder
    {
        private  List<ClassGenerate> _code = new List<ClassGenerate>();
        private static string _globalNamespaceName = "X.System";

        public static string GlobalNamespaceName => _globalNamespaceName;

        public static CodeBuilder CreateBuilder(string @namespace)
        {
            if (!string.IsNullOrWhiteSpace(@namespace))
            {
                _globalNamespaceName = @namespace;
            }
            return new CodeBuilder();
        }

        /// <summary>
        /// 创建一个代码模板
        /// </summary>
        /// <returns></returns>
        public ClassGenerate Load()
        {
            ClassGenerate codeGenerate = new ClassGenerate();
            codeGenerate.SetNamespace(_globalNamespaceName);
            _code.Add(codeGenerate);
            return codeGenerate;
        }

        public void Save(string path=".")
        {
            //开始输出模板
            for (int i = 0; i < _code.Count; i++)
            {
                var file = _code[i].Generate();
                using (FileStream fileStream=new FileStream($"{path}/{file.Name}",FileMode.Create,FileAccess.ReadWrite))
                {
                    var bytes= Encoding.UTF8.GetBytes(file.Content);
                    fileStream.Write(bytes,0, bytes.Length);
                    fileStream.Close();
                }
            }
        }
    }
}