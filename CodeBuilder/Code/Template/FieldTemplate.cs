using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code.Template
{
    /// <summary>
    /// 字段模板
    /// </summary>
    [Serializable]
    public class FieldTemplate : AttributeTemplate
    {
        /// <summary>
        /// 是否是属性
        /// </summary>
        public bool IsProperty { get; set; } = true;

        /// <summary>
        /// 备注
        /// </summary>
        public CommentTemplate Comment { get; set; }

        /// <summary>
        /// 字段类型名称
        /// </summary>
        public string FieldTypeName { get; set; } = "string";

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 可空类型
        /// </summary>
        public bool CanNull { get; set; } = false;

        /// <summary>
        /// 访问限制
        /// </summary>
        public string FiledLimit { get; private set; } = VisitLimit.Public.GetCustomAttributeDescription();

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                //设置属性注释
                if (string.IsNullOrWhiteSpace(Comment?.CommentName) == false)
                {
                    stringWriter.WriteLine("/// <summary>");
                    stringWriter.WriteLine("/// "+Comment.CommentName);
                    stringWriter.WriteLine("/// </summary>");
                }
                if (IsProperty)
                {
                    if (IsGenerateAttribute)
                    {
                        var commentName = Comment?.CommentName;
                        if (string.IsNullOrWhiteSpace(commentName))
                        {
                            if (IsKey)
                            {
                                stringWriter.WriteLine("[Required]");
                            }
                        }
                        else
                        {
                            if (IsKey)
                            {
                                stringWriter.WriteLine($"[Required(ErrorMessage = \"{commentName}\")]");
                            }
#if NET5_0
                        stringWriter.WriteLine($"[Comment(\"{Comment.CommentName}\")]");
#endif

                        }

                        if (MaxLength > 0)
                        {
                            stringWriter.WriteLine($"[MaxLength({MaxLength})]");
                        }
                        if (MinLength > 0)
                        {
                            stringWriter.WriteLine($"[MinLength({MinLength})]");
                        }
                        if (string.IsNullOrEmpty(DbType) == false)
                        {
                            var max = MaxLength.ToString();
                            if (MaxLength == -1)
                            {
                                max = "max";
                            }
                            if (DbType.Contains("(") == false)
                            {
                                if (DbType.Contains("varchar"))
                                {
                                    DbType = DbType + "(" + max + ")";
                                }
                                else if (DbType.Contains("varbinary"))
                                {
                                    DbType += $"({max})";
                                }
                                else if (DbType.Contains("decimal"))
                                {
                                    if (DecimalDigits == null)
                                    {
                                        DecimalDigits = 2;
                                    }
                                    DbType = DbType + $"({MaxLength},{DecimalDigits})";
                                }
                            }
                            stringWriter.WriteLine($"[Column(TypeName = \"{DbType}\")]");
                        }
                    }
                

                    stringWriter.WriteLine($"{FiledLimit} {FieldTypeName} {FieldName}" + "{get;set;}");
                }
                else
                {
                    stringWriter.WriteLine($"{FiledLimit} {FieldTypeName} {FieldName};");
                }
                return stringWriter.ToString();
            }

        
        }
    }
}