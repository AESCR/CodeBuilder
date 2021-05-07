using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 类模板
    /// </summary>
    public class ClassTemplate
    {
        private readonly List<MethodTemplate> _methodsCode;
        private readonly List<FieldTemplate> _fieldsCode;
        /// <summary> 
        /// 添加方法模板
        /// </summary>
        /// <param name="classTemplate"></param>
        /// <returns></returns>
        public void AddMethod(MethodTemplate classTemplate)
        {
            _methodsCode.Add(classTemplate);
        }
        /// <summary>
        /// 添加字段模板
        /// </summary>
        /// <param name="classTemplate"></param>
        /// <returns></returns>
        public void AddField(FieldTemplate classTemplate)
        {
            _fieldsCode.Add(classTemplate);
        }
        public ClassTemplate()
        {
            _methodsCode = new List<MethodTemplate>();
            _fieldsCode = new List<FieldTemplate>();
        }
        /// <summary>
        /// 设置类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 基类
        /// </summary>
        public ClassTemplate BaseClass { get; set; }
        /// <summary>
        /// 真实名称 例如：[Table("blogs")]
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 访问限制
        /// </summary>
        public string LimitType => _accessType.GetCustomAttributeDescription()?? "public";
        /// <summary>
        /// 设置访问限制
        /// </summary>
        /// <param name="classLimit"></param>
        public void SetAccess(VisitLimit classLimit)
        {
            _accessType = classLimit;
        }
        /// <summary>
        /// 注释
        /// </summary>
        public CommentTemplate Comment { get; set; }
        private VisitLimit _accessType { get; set; } = VisitLimit.Public;
        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                //设置类名注释
                if (string.IsNullOrWhiteSpace(Comment?.CommentName) == false)
                {
                    stringWriter.WriteLine("/// <summary>");
                    stringWriter.WriteLine("/// "+Comment.CommentName);
                    stringWriter.WriteLine("/// </summary>");
#if NET5_0
                       stringWriter.WriteLine($"[Comment(\"{Comment.CommentName}\")]");
#endif
                }
                if (string.IsNullOrWhiteSpace(RealName) == false && ClassName != RealName)
                {
                    stringWriter.WriteLine($"[Table(\"{RealName}\")]");
                }
                //设置类名
                {
                    stringWriter.Write($"public class {ClassName}");
                    string baseStr = ":";
                    //基类
                    if (BaseClass != null)
                    {
                        baseStr = baseStr + BaseClass.ClassName;
                    }
                    if (baseStr!=":")
                    {
                        stringWriter.Write(baseStr);
                    }
                    stringWriter.WriteLine();
                    stringWriter.WriteLine("{");
                    //设置字段属性
                    {
                        foreach (var f in _fieldsCode)
                        {
                            var filed=f.Generate();
                            using (StringReader stringReader=new StringReader(filed))
                            {
                                while (stringReader.Peek()!=-1)
                                {
                                    stringWriter.WriteLine("\t" + stringReader.ReadLine());
                                }
                            }
                        }
                    }
                    //设置方法
                    {
                        foreach (var m in _methodsCode)
                        {
                            var filed = m.Generate();
                            using (StringReader stringReader = new StringReader(filed))
                            {
                                while (stringReader.Peek() != -1)
                                {
                                    stringWriter.WriteLine("\t" + stringReader.ReadLine());
                                }
                            }
                        }
                    }
                    stringWriter.WriteLine("}");
                }
                return stringWriter.ToString();
            }
        }

        public List<FieldTemplate> GetField()
        {
            return _fieldsCode;
        }
    }
}
