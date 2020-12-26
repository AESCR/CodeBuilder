using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CodeBuilder.Code
{
    public class CodeFile
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
    public class CodeTemplate
    {
        /// <summary>
        /// 备注
        /// </summary>
        public CommentTemplate Comment { get; set; }

        public bool IsClass { get; } = true;
        public bool IsStruct { get; } = false;
        public bool IsInterface { get; } = false;

        /// <summary>
        /// 使用的命名空间
        /// </summary>
        public List<string> ImportNamespace { get; set; } = new List<string>();

        /// <summary>
        /// 设置命名空间
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// 设置类名 接口名 结构名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public List<MethodTemplate> Methods { get; set; } = new List<MethodTemplate>();
        /// <summary>
        /// 字段
        /// </summary>
        public List<FieldTemplate> Fields { get; set; }=new List<FieldTemplate>();
        /// <summary>
        /// 父类
        /// </summary>
        public List<CodeTemplate> BaseTemplate { get; set; } = new List<CodeTemplate>();
    }

    public class FieldTemplate
    {
        public CommentTemplate Comment { get; set; }
        public bool IsProperty { get; set; } = true;
        public string ReturnType { get; set; } = "string";
        public string Name { get; set; }
        public string FiledLimit { get; set; }= VisitLimit.EveryOne.GetDescription();
    }
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
        /// 返回类型
        /// </summary>
        public string ReturnType { get; set; } = "void";

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
        public bool IsInterface { get; } = false;
        /// <summary>
        /// 方法访问限制
        /// </summary>
        public string MethodLimit { get; set; } = VisitLimit.EveryOne.GetDescription();
    }

    /// <summary>
    /// 参数模板
    /// </summary>
    public class ParameterTemplate
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParameterName { get; set; } = "val";

        public string ParameterType { get; set; } = "string";
    }

    /// <summary>
    /// 访问限制
    /// </summary>
    public enum VisitLimit
    {
        [Description("public")] EveryOne,
        [Description("protected")] Family,
        [Description("private")] Oneself
    }

    /// <summary>
    ///
    /// </summary>
    public class CommentTemplate
    {
        public string CommentName { get; set; }
        public string ReturnComment { get; set; } = "string";
        public List<string> ParameterComment { get; set; } = new List<string>();
    }

    public static class EnumExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DescriptionAttribute>()?
                .Description;
        }
    }
}