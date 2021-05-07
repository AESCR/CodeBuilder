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
        /// 备注
        /// </summary>
        public CommentTemplate Comment { get; set; }

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
        public List<MethodParameterTemplate> Parameters { get; set; } = new List<MethodParameterTemplate>();

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
        /// <summary>
        /// 方法访问限制
        /// </summary>
        public string MethodLimit { get; private set; } = VisitLimit.Public.GetCustomAttributeDescription();
        /// <summary>
        /// 设置访问权限
        /// </summary>
        /// <param name="visitLimit"></param>
        public void SetMethodLimit(VisitLimit visitLimit)
        {
            MethodLimit = visitLimit.GetCustomAttributeDescription();
        }
        public List<string> Codes=new List<string>();
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
                if (string.IsNullOrWhiteSpace(Comment?.CommentName) == false)
                {
                    stringWriter.WriteLine("/// " + Comment.CommentName);
                }
                var parameters = string.Empty;
                int index = 0;
                foreach (MethodParameterTemplate parameter in Parameters)
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

                if (Overwrite)
                {
                    stringWriter.WriteLine($"{MethodLimit} override {ReturnName} {MethodName}({parameters})");
                }
                else
                {
                    stringWriter.WriteLine($"{MethodLimit} {ReturnName} {MethodName}({parameters})");
                }
                stringWriter.WriteLine("{");
                if (Codes.Count==0)
                {
                    stringWriter.WriteLine("\tthrow null;");
                }
                foreach (var code in Codes)
                {
                    stringWriter.WriteLine("\t"+code);
                }
                stringWriter.WriteLine("}");
                return stringWriter.ToString();
            }


        }
    }
}
