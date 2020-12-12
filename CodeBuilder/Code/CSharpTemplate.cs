using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeBuilder.Code
{
    public class CSharpTemplate : ICodeTemplate
    {
        private readonly StringBuilder _codeBuilder;

        public CSharpTemplate()
        {
            _codeBuilder = new StringBuilder();
        }


        public ICodeTemplate ImportNamespace(params string[] names)
        {
            var result = names.ToList();
            result.Add("System");
            result.Add("System.Linq");
            result.Add("System.Text");
            var dResult = result.Distinct().ToList();
            foreach (var name in dResult)
            {
                _codeBuilder.AppendLine($"using {name};");
            }

            return this;
        }

        public ICodeTemplate SetNamespace(string name)
        {
            _codeBuilder.AppendLine();
            _codeBuilder.AppendLine($"namespace {name}");
            _codeBuilder.Append("{");
            _codeBuilder.Append(Environment.NewLine);
            _codeBuilder.Append("}");
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        public ICodeTemplate SetProperty(string typeName, string propertyName, string comment = "")
        {
            var temp = AddComment(comment);
            temp += $"\t\tpublic {typeName} {propertyName.First().ToString().ToUpper() + propertyName.Substring(1)}" + "{get;set;} ";
            var tabIndex = _codeBuilder.ToString().LastIndexOf($" ", StringComparison.Ordinal);
            _codeBuilder.Insert(tabIndex + 1, temp);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="tabIndex"></param>
        /// <returns></returns>
        private string AddComment(string comment, int tabIndex = 2)
        {
            string temp = "";
            if (string.IsNullOrEmpty(comment)) return Environment.NewLine;
            string tab = "";
            for (int i = 0; i < tabIndex; i++)
            {
                tab = "\t" + tab;
            }
            temp += Environment.NewLine;
            temp += $"{tab}/// <summary>";
            temp += Environment.NewLine;
            temp += $"{tab}/// {comment}";
            temp += Environment.NewLine;
            temp += $"{tab}/// </summary>";
            temp += Environment.NewLine;
            return temp;
        }
        public ICodeTemplate SetInterfaceMethod(string methodName, string returnType, params string[] parameterTypes)
        {
            string temp = $"{Environment.NewLine}\t\tpublic {returnType} {methodName}";
            string inher = "(";
            for (var index = 0; index < parameterTypes.Length; index++)
            {
                string parameter = parameterTypes[index];
                if (index != 0)
                {
                    inher += ",";
                }
                inher = inher + $"{parameter} {parameter.First().ToString().ToLower() + parameter.Substring(1)}";
            }
            inher += ");";
            temp = temp + inher + " ";
            var tabIndex = _codeBuilder.ToString().LastIndexOf($" ", StringComparison.Ordinal);
            _codeBuilder.Insert(tabIndex + 1, temp);
            return this;
        }

        public ICodeTemplate SetClass(string nSpace, string className, string comment="", params string[] inheritors)
        {
            ImportNamespace();
            SetNamespace(nSpace);
            return SetClass(className, comment, false, inheritors);
        }

        public ICodeTemplate SetClass(string className, string comment, bool isInterface, params string[] inheritors)
        {
            string temp = AddComment(comment, 1);
            if (isInterface)
            {
                temp += $"\tpublic interface {className}";
            }
            else
            {
                temp += $"\tpublic class {className}";
            }
            string inher = "";
            for (var index = 0; index < inheritors.Length; index++)
            {
                string inheritor = inheritors[index];
                if (index != 0)
                {
                    inher += ",";
                }
                inher += inheritor;
            }
            if (inheritors.Length > 0)
            {
                temp = temp + ":" + inher;
            }
            temp += Environment.NewLine;
            temp += $"\t{{ {Environment.NewLine}\t}}";
            var tabIndex = _codeBuilder.ToString().LastIndexOf(Environment.NewLine, StringComparison.Ordinal);
            _codeBuilder.Insert(tabIndex, temp);
            return this;
        }


        public void Save(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            var ext = Path.GetExtension(path);
            if (string.IsNullOrWhiteSpace(ext))
            {
                path += ".cs";
            }
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                var bytes = Encoding.UTF8.GetBytes(_codeBuilder.ToString());
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}