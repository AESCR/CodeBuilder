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
    [Serializable]
    public class ClassTemplate
    {
        private readonly List<MethodTemplate> _methodsCode;
        private readonly List<FieldTemplate> _fieldsCode;
        private readonly List<AttributeTemplate> _attributeTemplates;
        private readonly List<InterfaceTemplate> _interfaceTemplates;
        public ClassTemplate()
        {
            _interfaceTemplates = new List<InterfaceTemplate>();
            _methodsCode = new List<MethodTemplate>();
            _fieldsCode = new List<FieldTemplate>();
            _attributeTemplates = new List<AttributeTemplate>();
        }

        public InterfaceTemplate CreateInterface()
        {
            var t = new InterfaceTemplate();
            _interfaceTemplates.Add(t);
            return t;
        }
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
        /// 创建一个方法
        /// </summary>
        /// <returns></returns>
        public MethodTemplate CreateMethod()
        {
            MethodTemplate classTemplate = new MethodTemplate();
            _methodsCode.Add(classTemplate);
            return classTemplate;
        }

        /// <summary>
        /// 创建一个字段
        /// </summary>
        /// <returns></returns>
        public FieldTemplate CreateField()
        {
            FieldTemplate field = new FieldTemplate();
            _fieldsCode.Add(field);
            return field;
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

        private string LimitType => AccessType.GetCustomAttributeDescription() ?? "public";

        /// <summary>
        /// 注释
        /// </summary>
        public CommentTemplate Comment { get; set; }

        /// <summary>
        /// 访问限制
        /// </summary>
        public VisitLimit AccessType { get; set; } = VisitLimit.Public;

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
                    stringWriter.WriteLine("/// " + Comment.CommentName);
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

                    if (baseStr != ":")
                    {
                        stringWriter.Write(baseStr);
                    }

                    foreach (var @interface in _interfaceTemplates)
                    {
                        stringWriter.Write($",{@interface.InterfaceName}");
                    }

                    stringWriter.WriteLine();
                    stringWriter.WriteLine("{");
                    //设置字段属性
                    {
                        foreach (var f in _fieldsCode)
                        {
                            var filed = f.Generate();
                            using (StringReader stringReader = new StringReader(filed))
                            {
                                while (stringReader.Peek() != -1)
                                {
                                    stringWriter.WriteLine("\t" + stringReader.ReadLine());
                                }
                            }
                        }
                    }
                    //设置方法
                    {
                        //自定义方法
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
                        //实现接口方法
                        foreach (var @interface in _interfaceTemplates)
                        {
                            var tempMethods = @interface.GetAllMethods();
                            foreach (var m in tempMethods)
                            {
                                //判断自定义方法是否实现接口方法
                                if (_methodsCode.Exists(x => x.Code != m.Code))
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

                        }
                    }
                    stringWriter.WriteLine("}");
                }
                return stringWriter.ToString();
            }
        }
    }
}
