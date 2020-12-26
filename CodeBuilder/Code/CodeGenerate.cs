using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeBuilder.Code
{
    public class ClassGenerate
    {
        /// <summary>
        /// 
        /// </summary>
        public ClassGenerate()
        {
            _cSharp.ImportNamespace.Add("System");
            _cSharp.ImportNamespace.Add("System.Linq");
            _cSharp.ImportNamespace.Add("System.Text");
            _cSharp.ImportNamespace.Add("System.Threading.Tasks");
            _cSharp.ImportNamespace.Add("System.Collections.Generic");
        }
        private readonly CodeTemplate _cSharp = new CodeTemplate();

        public ClassGenerate SetNamespace(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            _cSharp.NamespaceName = name;
            return this;
        }

        public ClassGenerate UsingNamespace(params string[] names)
        {
            var r = names.ToList();
            _cSharp.ImportNamespace.AddRange(r);
            _cSharp.ImportNamespace = _cSharp.ImportNamespace.Distinct().ToList();
            return this;
        }


        public ClassGenerate SetBase(params CodeTemplate[] baseCode)
        {
            _cSharp.BaseTemplate.AddRange(baseCode);
            return this;
        }

        public ClassGenerate SetClassName(string name,string comment="")
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            _cSharp.ClassName = name;
            if (_cSharp.Comment==null)
            {
                _cSharp.Comment=new CommentTemplate();
            }
            _cSharp.Comment.CommentName = comment;
            return this;
        }
        /// <summary>
        /// 数据库中与c#中的数据类型对照
        /// </summary>
        /// <param name="type">数据库类型</param>
        /// <param name="isNull">可空类型</param>
        /// <returns>C#类型</returns>
        public static string DbToCsharpType(string type, bool isNull = false)
        {
            string ravel;
            switch (type)
            {
                case "int":
                    ravel = "int";
                    break;

                case "text":
                    ravel = "string";
                    break;

                case "bigint":
                    ravel = "long";
                    break;

                case "binary":
                    ravel = "byte[]";
                    break;

                case "bit":
                    ravel = "bool";
                    break;

                case "char":
                    ravel = "string";
                    break;

                case "datetime":
                    ravel = "DateTime";
                    break;

                case "decimal":
                    ravel = "decimal";
                    break;

                case "float":
                    ravel = "double";
                    break;

                case "image":
                    ravel = "byte[]";
                    break;

                case "money":
                    ravel = "decimal";
                    break;

                case "nchar":
                    ravel = "string";
                    break;

                case "ntext":
                    ravel = "string";
                    break;

                case "numeric":
                    ravel = "decimal";
                    break;

                case "nvarchar":
                    ravel = "string";
                    break;

                case "real":
                    ravel = "float";
                    break;

                case "smalldatetime":
                    ravel = "DateTime";
                    break;

                case "smallint":
                    ravel = "int";
                    break;

                case "smallmoney":
                    ravel = "decimal";
                    break;

                case "timestamp":
                    ravel = "DateTime";
                    break;

                case "tinyint":
                    ravel = "byte";
                    break;

                case "uniqueidentifier":
                    ravel = "string";
                    break;

                case "varbinary":
                    ravel = "byte[]";
                    break;

                case "varchar":
                    ravel = "string";
                    break;

                case "variant":
                    ravel = "object";
                    break;

                default:
                    ravel = "string";
                    break;
            }
            if (isNull)
            {
                if (ravel != "string" && ravel != "object" && ravel != "byte[]")
                {
                    ravel += "?";
                }
            }
            return ravel;
        }
        public ClassGenerate SetProperty(string name,string limit= "public", string type="string", string comment = "")
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            var field = new FieldTemplate();
            field.Comment=new CommentTemplate();
            field.Comment.CommentName = comment;
            field.Name = name;
            field.FiledLimit = limit;
            field.ReturnType = type;

            _cSharp.Fields.Add(field);
            return this;
        }
        public MethodGenerate CreateMethod()
        {
            var m = new MethodGenerate();
            return m;
        }

        public ClassGenerate AddMethods(MethodGenerate method)
        {
            _cSharp.Methods.Add(method.Generate());
            return this;
        }

        /// <summary>
        /// 生成一个代码模板
        /// </summary>
        public CodeFile Generate()
        {
            CodeFile codeFile=new CodeFile();
            codeFile.Name = _cSharp.ClassName+".cs";
            using (StringWriter stringWriter = new StringWriter())
            {
                //写入using命名空间
                for (int i = 0; i < _cSharp.ImportNamespace.Count; i++)
                {
                    stringWriter.WriteLine($"using {_cSharp.ImportNamespace[i]};");
                }
                stringWriter.Write(Environment.NewLine);
                //设置命名空间
                {
                    stringWriter.WriteLine($"namespace {_cSharp.NamespaceName}");
                    stringWriter.WriteLine("{");
                    string tabCoincide = "\t";
                    string tabProperty = "\t\t";
                    string tabMethod = "\t\t";
                    //设置类名注释
                    if (string.IsNullOrWhiteSpace(_cSharp.Comment?.CommentName)==false)
                    {
                        stringWriter.WriteLine(tabCoincide+ "/// <summary>");
                        stringWriter.WriteLine(tabCoincide + "/// "+ _cSharp.Comment.CommentName);
                        stringWriter.WriteLine(tabCoincide + "/// </summary>");
                    }
                    //设置类名
                    {
                        stringWriter.Write(tabCoincide);
                        if (_cSharp.IsClass)
                        {
                            stringWriter.Write("public class ");
                        }
                        else if (_cSharp.IsInterface)
                        {
                            stringWriter.Write("public interface ");
                        }
                        else if(_cSharp.IsStruct)
                        {
                            stringWriter.Write("public static ");
                        }
                        else
                        {
                            stringWriter.Write("public class ");
                        }
                        stringWriter.WriteLine(_cSharp.ClassName);
                        //判断是否有继承
                        if (_cSharp.BaseTemplate.Count>0)
                        {
                            stringWriter.Write(":");
                            for (int i = 0; i < _cSharp.BaseTemplate.Count; i++)
                            {
                                stringWriter.Write(_cSharp.BaseTemplate[i].ClassName);
                                if (i!= _cSharp.BaseTemplate.Count)
                                {
                                    stringWriter.Write(",");
                                }
                            }
                        }
                        stringWriter.WriteLine(tabCoincide+"{");
                        //设置属性
                        {
                            foreach (var f in _cSharp.Fields)
                            {
                                //设置属性注释
                                if (string.IsNullOrWhiteSpace(f.Comment?.CommentName) == false)
                                {
                                    stringWriter.WriteLine(tabProperty + "/// <summary>");
                                    stringWriter.WriteLine(tabProperty + "/// " + f.Comment.CommentName);
                                    stringWriter.WriteLine(tabProperty + "/// </summary>");
                                }
                                if (f.IsProperty)
                                {
                                    stringWriter.Write(tabProperty);
                                    stringWriter.Write($"{f.FiledLimit} {f.ReturnType} {f.Name}");
                                    stringWriter.WriteLine("{get;set;}");
                                }
                                else
                                {
                                    stringWriter.Write(tabProperty);
                                    stringWriter.Write($"{f.FiledLimit} {f.ReturnType} {f.Name};");
                                }
                            }
                        }
                        //设置方法
                        {
                            foreach (var m in _cSharp.Methods)
                            {
                                stringWriter.WriteLine(tabMethod + "/// <summary>");
                                stringWriter.WriteLine(tabMethod + "/// " + m.Comment.CommentName);
                                //参数备注
                                for (var index = 0; index < m.Parameters.Count; index++)
                                {
                                    var p = m.Parameters[index];

                                    if (index < m.Comment.ParameterComment.Count)
                                    {
                                        var c = m.Comment.ParameterComment[index];
                                        stringWriter.WriteLine($"{tabMethod}/// <param name=\"{p.ParameterName}\">{c}</param>");
                                    }
                                }
                                //返回类型备注
                                if (string.IsNullOrWhiteSpace(m.Comment.ReturnComment)==false)
                                {
                                    stringWriter.WriteLine(tabMethod + $"/// <returns>{m.Comment.ReturnComment}</returns>");
                                }
                                stringWriter.WriteLine(tabMethod + "/// </summary>");
                                stringWriter.Write(tabMethod);
                                if (m.IsVirtual)
                                {
                                    stringWriter.Write($"{m.MethodLimit} virtual {m.ReturnType} {m.MethodName}");
                                }
                                else if (m.IsAbstract)
                                {
                                    stringWriter.Write($"{m.MethodLimit} abstract {m.ReturnType} {m.MethodName}");
                                }
                                else if (m.IsInterface)
                                {
                                    stringWriter.Write($"{m.ReturnType} {m.MethodName}");
                                }
                                //参数
                                stringWriter.Write("(");
                                for (int i = 0; i < m.Parameters.Count; i++)
                                {
                                    var p = m.Parameters[i];
                                    stringWriter.Write("(");
                                    stringWriter.Write($"{p.ParameterType} {p.ParameterName}");
                                    if (i != m.Parameters.Count)
                                    {
                                        stringWriter.Write(",");
                                    }
                                }
                                stringWriter.Write(")");
                                //实现
                                if (m.IsInterface==false&&m.IsAbstract==false)
                                {
                                    stringWriter.WriteLine("\t\t\tthrow new NotImplementedException();");
                                }
                            }
                        }
                        stringWriter.WriteLine(tabCoincide+"}");
                    }
                    stringWriter.WriteLine("}");
                }
                codeFile.Content = stringWriter.ToString();
            }
            return codeFile;
        }
    }

    public class MethodGenerate
    {
        private MethodTemplate method = new MethodTemplate();

        public MethodTemplate Generate()
        {
            return method;
        }

        public MethodGenerate SetName(string name, string @return = "void")
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            method.MethodName = name;
            method.ReturnType = @return;
            return this;
        }

        public MethodGenerate SetComment(string @comment, string @return = "")
        {
            if (method.Comment == null)
            {
                this.method.Comment = new CommentTemplate();
            }
            method.Comment.CommentName = @comment;
            if (method.ReturnType != "void")
            {
                this.method.Comment.ReturnComment = @return;
            }
            else
            {
                method.Comment.ReturnComment = null;
            }
            return this;
        }

        public MethodGenerate SetParameterComment(List<string> parameters)
        {
            if (method.Comment == null)
            {
                this.method.Comment = new CommentTemplate();
            }
            method.Comment.ParameterComment.AddRange(parameters);
            return this;
        }
    }
}