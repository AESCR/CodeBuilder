using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.CSharpCode
{
    public  class CodeBuilder
    {
        private List<CodeTemplate> _code=new List<CodeTemplate>();
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
            return codeGenerate;
        }

        public void Write(ClassGenerate code)
        {
            _code.Add(code.Generate()); ;
        }

        public void Save()
        {

        }

    }
}
