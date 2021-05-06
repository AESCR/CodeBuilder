using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Code
{
    public class DbToCsharpType
    {
        /// <summary>
        /// 数据库中与c#中的数据类型对照
        /// </summary>
        /// <param name="type">数据库类型</param>
        /// <param name="isNull">可空类型</param>
        /// <returns>C#类型</returns>
        public static string ToCsharpType(string type, bool isNull = false)
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
    }
}
