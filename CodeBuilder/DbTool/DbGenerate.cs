#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 单位 运管家
// 版权所有。 
//
// 文件名：DbModelGenerate
// 文件功能描述：
//
// 
// 创建者：名字 AESCR
// 时间：2021/5/8 9:45:15
//
// 修改人：
// 时间：
// 修改说明：
//
// 修改人：
// 时间：
// 修改说明：
//
// 版本：V1.0.0
//----------------------------------------------------------------*/
#endregion

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using CodeBuilder.Code.Generate;
using CodeBuilder.Code.Template;
using MySql.Data.MySqlClient;

namespace CodeBuilder.DbTool
{
    /// <summary>
    /// DB生成器
    /// </summary>
    public class DbGenerate: CodeGenerate
    {
        private readonly DbConnect _connect;
        public DataBaseType DbType => _connect.DbType;
        public string Namespace { get; set; }
        /// <summary>
        /// 移除_
        /// </summary>
        public bool RemoveLine { get; set; } = false;
        /// <summary>
        /// 是否生成上下文
        /// </summary>
        public bool DbContext { get; set; } = true;
        public DbGenerate(DbConnect dbConnect)
        {
            _connect = dbConnect;
        }

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableFlat()
        {
            var sqlConStr = _connect.GetConnection();
            switch (_connect.DbType)
            {
              
                case DataBaseType.MySQL:
                {
                    using (var sqlCon = new MySqlConnection(sqlConStr))
                    {
                        sqlCon.Open();
                        var command = new MySqlCommand($"use {_connect.Database};", sqlCon);
                        command.ExecuteNonQuery();

                        #region SQL查询语句

                        string sqlStr = @"SELECT
CASE
		WHEN B.ordinal_position =1 THEN
		A.table_name ELSE ''
	END 表名,
CASE
		WHEN B.ordinal_position =1 THEN
		A.table_comment ELSE ''
	END 表说明,
	B.ordinal_position AS 字段序号,
	B.column_name AS 字段名,
	B.column_comment AS 字段说明,
	B.column_key AS 标识,
CASE
		B.column_key 
		WHEN 'PRI' THEN
		'√' ELSE '' 
	END AS 主键,
	B.data_type AS 类型,
CASE 
	WHEN B.character_maximum_length is not NULL  THEN
		B.character_maximum_length	
	WHEN  	B.numeric_precision	 is not null THEN 
		B.numeric_precision	
		when B.datetime_precision is not null THEN 
		B.datetime_precision
	ELSE
		 B.character_maximum_length
END AS 长度,
	B.numeric_scale AS 小数位数,
CASE
		B.is_nullable 
		WHEN 'YES' THEN
		'√' ELSE '' 
	END AS 允许空,
	B.column_default AS 默认值 
FROM
	information_schema.TABLES A
	LEFT JOIN information_schema.COLUMNS B ON B.table_name = A.table_name 
WHERE
	A.table_schema = DATABASE () 
ORDER BY
	A.table_name,
	B.ordinal_position
	
";

                        #endregion

                        var sda = new MySqlDataAdapter(sqlStr, sqlCon);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds.Tables[0];
                    }
                }
                case DataBaseType.MsSQL:
                default:
                {
                        using (SqlConnection sqlCon = new SqlConnection(sqlConStr))
                        {
                            sqlCon.Open();
                            SqlCommand command = new SqlCommand($"use {_connect.Database};", sqlCon);
                            command.ExecuteNonQuery();

                            #region SQL查询语句

                            string sqlStr = @"SELECT
	表名 =
CASE

		WHEN A.colorder= 1 THEN
		D.name ELSE ''
	END,
	表说明 =
CASE

	WHEN A.colorder= 1 THEN
	isnull( F.value, '' ) ELSE ''
	END,
	字段序号 = A.colorder,
	字段名 = A.name,
	字段说明 = isnull( G.[value], '' ),
	标识 =
CASE

		WHEN COLUMNPROPERTY( A.id, A.name, 'IsIdentity' ) = 1 THEN
		'√' ELSE ''
	END,
	主键 =
CASE

	WHEN EXISTS (
	SELECT
		1
	FROM
		sysobjects
	WHERE
		xtype = 'PK'
		AND parent_obj = A.id
		AND name IN ( SELECT name FROM sysindexes WHERE indid IN ( SELECT indid FROM sysindexkeys WHERE id = A.id AND colid = A.colid ) )
		) THEN
		'√' ELSE ''
	END,
	类型 = B.name,
--占用字节数 = A.Length,
	长度
	= COLUMNPROPERTY( A.id, A.name, 'PRECISION' ),
	小数位数 = isnull( COLUMNPROPERTY( A.id, A.name, 'Scale' ), 0 ),
	允许空 =
CASE

		WHEN A.isnullable= 1 THEN
		'√' ELSE ''
	END,
	默认值 = isnull( E.Text, '' )
FROM
	syscolumns A
	LEFT JOIN systypes B ON A.xusertype= B.xusertype
	INNER JOIN sysobjects D ON A.id= D.id
	AND D.xtype= 'U'
	AND D.name<> 'dtproperties'
	LEFT JOIN syscomments E ON A.cdefault= E.id
	LEFT JOIN sys.extended_properties G ON A.id= G.major_id
	AND A.colid= G.minor_id
	LEFT JOIN sys.extended_properties F ON D.id= F.major_id
	AND F.minor_id= 0 --where d.name='OrderInfo' --如果只查询指定表,加上此条件

ORDER BY
	A.id,
	A.colorder";

                            #endregion

                            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, sqlCon);
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
            }
        }

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetDataBase()
        {
            List<string> rList = new List<string>();
            var sqlConStr = _connect.GetConnection();
            switch (_connect.DbType)
            {
                case DataBaseType.MsSQL:
                {
                    using (SqlConnection sqlCon = new SqlConnection(sqlConStr))
                    {
                        sqlCon.Open();
                        using (SqlCommand cmd = new SqlCommand("select name from sysdatabases", sqlCon))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var n = reader["name"].ToString();
                                    rList.Add(n);
                                }
                                reader.Close();
                            }
                        }
                        return rList;
                    }
                }
                case DataBaseType.MySQL:
                {
                    using (MySqlConnection sqlCon=new MySqlConnection(sqlConStr))
                    {
                        sqlCon.Open();
                        using (MySqlCommand cmd = new MySqlCommand("show databases", sqlCon))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    var n = reader[0].ToString();
                                    rList.Add(n);
                                }
                                reader.Close();
                            }
                        }
                        return rList;
                    }
                }

            }
            return rList;
        }

        private void GenerateDbModel()
        {
            var dt = GetTableFlat();
            var nameText = Namespace ?? "Aescr.Model";
            for (int index = 0; index < dt.Rows.Count;)
            {
                DataRow dataRow = dt.Rows[index];
                var ft= CreateFile();
                ft.DownloadPath = DownloadPath + "/DbModel";
                var namespaceTemplate= ft.CreateNamespace();
                namespaceTemplate.NamespaceName = nameText;
                ClassTemplate classTemplate = new ClassTemplate();
                namespaceTemplate.AddClass(classTemplate);
                if (RemoveLine)
                {
                    classTemplate.ClassName = dataRow["表名"].ToString();
                    classTemplate.ClassName = classTemplate.ClassName.Replace("_", "");
                }
                else
                {
                    classTemplate.ClassName = dataRow["表名"].ToString();
                }
                classTemplate.RealName = dataRow["表名"].ToString();
                classTemplate.Comment = new Code.Template.CommentTemplate();
                classTemplate.Comment.CommentName = dataRow["表说明"].ToString();
                do
                {
                    DataRow tempRow = dt.Rows[index];
                    var field = new Code.Template.FieldTemplate();
                    var comment = new Code.Template.CommentTemplate();
                    field.FieldName = tempRow["字段名"].ToString();
                    comment.CommentName = tempRow["字段说明"].ToString();
                    field.DbType = tempRow["类型"].ToString();
                    field.MaxLength = tempRow["长度"].ToString().ToInt64();
                    field.MinLength = 0;
                    field.Comment = comment;
                    field.IsProperty = true;
                    field.IsKey = tempRow["主键"].ToString() == "√";
                    field.CanNull = tempRow["允许空"].ToString() == "√";
                    if (_connect.DbType == DataBaseType.MsSQL)
                    {
                        field.FieldTypeName = DbToCsharpType.MsSqlToCsharpType(tempRow["类型"].ToString());
                    }
                    else if(_connect.DbType == DataBaseType.MySQL)
                    {
                        field.FieldTypeName = DbToCsharpType.MySqlToCsharpType(tempRow["类型"].ToString());
                    }
                    classTemplate.AddField(field);
                    index++;
                    if (index == dt.Rows.Count)
                    {
                        break;
                    }
                } while (string.IsNullOrWhiteSpace(dt.Rows[index]["表名"].ToString()));
            }
        }

        private void GenerateDbContext()
        {
            var ft = CreateFile();
            ft.DownloadPath = DownloadPath + "/DbContext";
            var namespaceTemplate = ft.CreateNamespace();
            namespaceTemplate.NamespaceName = "Microsoft.EntityFrameworkCore";
            var classTemplate = new ClassTemplate();
            namespaceTemplate.AddClass(classTemplate);
            classTemplate.ClassName = _connect.Database.Trim() + "DbContext";
            classTemplate.BaseClass = new ClassTemplate()
            {
                ClassName = "DbContext"
            };
            var method = new MethodTemplate();
            classTemplate.AddMethod(method);
            method.Overwrite = true;
            method.MethodName = "OnModelCreating";
            method.Parameters.Add(new ParameterTemplate()
            {
                ParameterTypeName = "ModelBuilder",
                ParameterName = "modelBuilder"
            });
            var dt = GetTableFlat();
            for (int index = 0; index < dt.Rows.Count;)
            {
                DataRow dataRow = dt.Rows[index];
                ClassTemplate tableTemplate = new ClassTemplate();
                if (RemoveLine)
                {
                    tableTemplate.ClassName = dataRow["表名"].ToString();
                    tableTemplate.ClassName = classTemplate.ClassName.Replace("_", "");
                }
                else
                {
                    tableTemplate.ClassName = dataRow["表名"].ToString();
                }

                tableTemplate.RealName = dataRow["表名"].ToString();
                tableTemplate.Comment = new Code.Template.CommentTemplate();
                tableTemplate.Comment.CommentName = dataRow["表说明"].ToString();
                method.CodeLine.Add($"modelBuilder.Entity<{ tableTemplate.ClassName}>().HasComment(\"{tableTemplate.Comment.CommentName  }\");");
                var field = new Code.Template.FieldTemplate();
                field.IsGenerateAttribute = false;
                field.FieldName = tableTemplate.ClassName;
                field.FieldTypeName = $"DbSet<{tableTemplate.ClassName}>";
                field.IsProperty = true;
                classTemplate.AddField(field);
                do
                {
                    DataRow tempRow = dt.Rows[index];
                    method.CodeLine.Add($"modelBuilder.Entity<{  tableTemplate.ClassName }>().Property(b => b.{ tempRow["字段名"].ToString()}).HasComment(\"{  tempRow["字段说明"].ToString()}\");");
                    index++;
                    if (index == dt.Rows.Count)
                    {
                        break;
                    }
                } while (string.IsNullOrWhiteSpace(dt.Rows[index]["表名"].ToString()));
            }
        }

        public new void Save()
        {
            GenerateDbModel();
            if (DbContext)
            {
                GenerateDbContext();
            }
            base.Save();
        }
    }
}
