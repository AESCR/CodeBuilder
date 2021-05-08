using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CodeBuilder.Code.Generate
{
    public class DbToCsharpType
    {
        #region sql server数据类型

        // SqlDbType转换为C#数据类型
        private static Type SqlTypeToCsharpType(SqlDbType sqlType)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt:
                    return typeof(Int64);
                case SqlDbType.Binary:
                    return typeof(Object);
                case SqlDbType.Bit:
                    return typeof(Boolean);
                case SqlDbType.Char:
                    return typeof(String);
                case SqlDbType.DateTime:
                    return typeof(DateTime);
                case SqlDbType.Decimal:
                    return typeof(Decimal);
                case SqlDbType.Float:
                    return typeof(Double);
                case SqlDbType.Image:
                    return typeof(Object);
                case SqlDbType.Int:
                    return typeof(Int32);
                case SqlDbType.Money:
                    return typeof(Decimal);
                case SqlDbType.NChar:
                    return typeof(String);
                case SqlDbType.NText:
                    return typeof(String);
                case SqlDbType.NVarChar:
                    return typeof(String);
                case SqlDbType.Real:
                    return typeof(Single);
                case SqlDbType.SmallDateTime:
                    return typeof(DateTime);
                case SqlDbType.SmallInt:
                    return typeof(Int16);
                case SqlDbType.SmallMoney:
                    return typeof(Decimal);
                case SqlDbType.Text:
                    return typeof(String);
                case SqlDbType.Timestamp:
                    return typeof(Object);
                case SqlDbType.Time:
                    return typeof(TimeSpan);
                case SqlDbType.TinyInt:
                    return typeof(Byte);
                case SqlDbType.Udt://自定义的数据类型
                    return typeof(Object);
                case SqlDbType.UniqueIdentifier:
                    return typeof(Object);
                case SqlDbType.VarBinary:
                    return typeof(Object);
                case SqlDbType.VarChar:
                    return typeof(String);
                case SqlDbType.Variant:
                    return typeof(Object);
                case SqlDbType.Xml:
                    return typeof(Object);
                default:
                    return null;
            }
        }
        // sql server数据类型（如：varchar）转换为SqlDbType类型
        private static SqlDbType SqlTypeToSqlDbType(string sqlTypeString)
        {
            SqlDbType dbType = SqlDbType.Variant;//默认为Object

            switch (sqlTypeString.ToLower())
            {
                case "int":
                    dbType = SqlDbType.Int;
                    break;
                case "varchar":
                    dbType = SqlDbType.VarChar;
                    break;
                case "bit":
                    dbType = SqlDbType.Bit;
                    break;
                case "datetime":
                    dbType = SqlDbType.DateTime;
                    break;
                case "time":
                    dbType = SqlDbType.Time;
                    break;
                case "datetime2":
                    dbType = SqlDbType.DateTime2;
                    break;
                case "decimal":
                    dbType = SqlDbType.Decimal;
                    break;
                case "float":
                    dbType = SqlDbType.Float;
                    break;
                case "image":
                    dbType = SqlDbType.Image;
                    break;
                case "money":
                    dbType = SqlDbType.Money;
                    break;
                case "ntext":
                    dbType = SqlDbType.NText;
                    break;
                case "nvarchar":
                    dbType = SqlDbType.NVarChar;
                    break;
                case "smalldatetime":
                    dbType = SqlDbType.SmallDateTime;
                    break;
                case "smallint":
                    dbType = SqlDbType.SmallInt;
                    break;
                case "text":
                    dbType = SqlDbType.Text;
                    break;
                case "bigint":
                    dbType = SqlDbType.BigInt;
                    break;
                case "binary":
                    dbType = SqlDbType.Binary;
                    break;
                case "char":
                    dbType = SqlDbType.Char;
                    break;
                case "nchar":
                    dbType = SqlDbType.NChar;
                    break;
                case "numeric":
                    dbType = SqlDbType.Decimal;
                    break;
                case "real":
                    dbType = SqlDbType.Real;
                    break;
                case "smallmoney":
                    dbType = SqlDbType.SmallMoney;
                    break;
                case "sql_variant":
                    dbType = SqlDbType.Variant;
                    break;
                case "timestamp":
                    dbType = SqlDbType.Timestamp;
                    break;
                case "tinyint":
                    dbType = SqlDbType.TinyInt;
                    break;
                case "uniqueidentifier":
                    dbType = SqlDbType.UniqueIdentifier;
                    break;
                case "varbinary":
                    dbType = SqlDbType.VarBinary;
                    break;
                case "xml":
                    dbType = SqlDbType.Xml;
                    break;
            }
            return dbType;
        }

        #endregion

        #region Mysql
        private static Type MySqlTypeToCsharpType(MySqlDbType sqlType)
        {
            switch (sqlType)
            {
                case MySqlDbType.Int16:
                    return typeof(Int16);
                case MySqlDbType.Binary:
                    return typeof(Object);
                case MySqlDbType.Bit:
                    return typeof(Boolean);
                case MySqlDbType.VarString:
                case MySqlDbType.TinyText:
                case MySqlDbType.Text:
                case MySqlDbType.MediumText:
                case MySqlDbType.MediumBlob:
                case MySqlDbType.LongText:
                case MySqlDbType.LongBlob:
                    return typeof(String);
                case MySqlDbType.VarChar:
                    return typeof(Char);
                default:
                    return typeof(Object);
            }
        }
        private static MySqlDbType MySqlTypeToSqlDbType(string sqlTypeString)
        {
            MySqlDbType dbType = MySqlDbType.VarString;

            switch (sqlTypeString.ToLower())
            {
                case "char":
                    dbType = MySqlDbType.VarChar;
                    break;
                case "varchar":
                    dbType = MySqlDbType.VarString;
                    break;
                case "tinytext":
                    dbType = MySqlDbType.TinyText;
                    break;
                case "blob":
                    dbType = MySqlDbType.Blob;
                    break;
                case "text":
                    dbType = MySqlDbType.Text;
                    break;
                case "mediumblob":
                    dbType = MySqlDbType.MediumBlob;
                    break;
                case "mediumtext":
                    dbType = MySqlDbType.MediumText;
                    break;
                case "longblob":
                    dbType = MySqlDbType.LongBlob;
                    break;
                case "longtext":
                    dbType = MySqlDbType.LongText;
                    break;
                case "date":
                    dbType = MySqlDbType.Date;
                    break;
                case "time":
                    dbType = MySqlDbType.Time;
                    break;
                case "year":
                    dbType = MySqlDbType.Year;
                    break;
                case "dateTime":
                    dbType = MySqlDbType.DateTime;
                    break;
                case "timestamp":
                    dbType = MySqlDbType.Timestamp;
                    break;
                case "int":
                case "integer":
                    dbType = MySqlDbType.Int32;
                    break;
                case "bigint":
                    dbType = MySqlDbType.Int64;
                    break;
                case "float":
                    dbType = MySqlDbType.Float;
                    break;
                case "double":
                    dbType = MySqlDbType.Double;
                    break;
                case "decimal":
                    dbType = MySqlDbType.Decimal;
                    break;
                case "mediumint":
                    dbType = MySqlDbType.Int24;
                    break;
                case "smallint":
                    dbType = MySqlDbType.Int16;
                    break;
                case "bit":
                    dbType = MySqlDbType.Bit;
                    break;
                case "tinyint":
                    dbType = MySqlDbType.Bit;
                    break;
            }
            return dbType;
        }

        #endregion
        /// <summary>
        ///  SqlDbType转换为C#数据类型
        /// </summary>
        /// <param name="sqlTypeString"></param>
        /// <returns></returns>
        public static string MsSqlToCsharpType(string sqlTypeString)
        {
            var type= SqlTypeToCsharpType(SqlTypeToSqlDbType(sqlTypeString));
            return type.Name;
        }
        public static string MySqlToCsharpType(string sqlTypeString)
        {
            var type = MySqlTypeToCsharpType(MySqlTypeToSqlDbType(sqlTypeString));
            return type.Name;
        }
    }
}
