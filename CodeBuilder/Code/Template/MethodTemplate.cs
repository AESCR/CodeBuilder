using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 方法模板
    /// </summary>
    public class MethodTemplate
    {
        /// <summary>
        /// 方法标识
        /// </summary>
        public int Code {
            get
            {
                var txt = string.Empty;
                foreach (var parameter in Parameters)
                {
                    txt += parameter.ParameterTypeName;
                }
                txt += MethodName;
                return txt.GetHashCode();
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string ReturnName { get; set; } = "void";

        /// <summary>
        /// 参数
        /// </summary>
        public List<ParameterTemplate> Parameters { get; set; } = new List<ParameterTemplate>();

        /// <summary>
        /// 是否是虚方法
        /// </summary>
        public bool IsVirtual { get; set; } = false;

        /// <summary>
        /// 是否是抽象类方法
        /// </summary>
        public bool IsAbstract { get; set; } = false;
        /// <summary>
        /// 是否是接口
        /// </summary>
        public bool IsInterface { get; set; } = false;
        /// <summary>
        /// 是属性方法
        /// </summary>
        public bool IsAttribute { get; set; }

        /// <summary>
        /// 是否重写
        /// </summary>
        public bool Overwrite { get; set; } = false;
       
        private string Limit=> MethodLimit.GetCustomAttributeDescription();
        /// <summary>
        /// 方法访问限制
        /// </summary>
        public VisitLimit MethodLimit { get; set; } = VisitLimit.Public;
        /// <summary>
        /// 一行代码
        /// </summary>
        public List<string> CodeLine=new List<string>();

        public ParameterTemplate CreateParameter()
        {
            ParameterTemplate parameter=new ParameterTemplate();
            Parameters.Add(parameter);
            return parameter;
        }
        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
             
                stringWriter.WriteLine("/// <summary>");
                //设置属性注释
                if (string.IsNullOrWhiteSpace(Remark) == false)
                {
                    stringWriter.WriteLine("/// " + Remark);
                }
                var parameters = string.Empty;
                int index = 0;
                foreach (ParameterTemplate parameter in Parameters)
                {
                    parameters = parameters + $"{parameter.ParameterTypeName} {parameter.ParameterName}";
                    index++;
                    if (index!= Parameters.Count)
                    {
                        parameters += ",";
                    }
                    stringWriter.WriteLine("/// <param name="+ parameter.ParameterName+ ">"+parameter.Remark+"</param>");
                }
                stringWriter.WriteLine("/// </summary>");
                if (IsInterface==false)
                {
                    stringWriter.Write(Limit+" ");
                }
                if (Overwrite)
                {
                    stringWriter.WriteLine($"override ");
                }
                stringWriter.Write($"{ReturnName} {MethodName}({parameters})");
                if (IsInterface==false)
                {
                    stringWriter.WriteLine();
                    stringWriter.WriteLine("{");
                    if (CodeLine.Count == 0 && ReturnName != "void" && IsInterface == false)
                    {
                        stringWriter.WriteLine("\tthrow null;");
                    }
                    foreach (var code in CodeLine)
                    {
                        stringWriter.WriteLine("\t" + code);
                    }
                    stringWriter.WriteLine("}");
                }
                else
                {
                    stringWriter.WriteLine(";");
                }
              
                return stringWriter.ToString();
            }


        }
    }
}
