﻿using CCWin;
using CodeBuilder.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinClass;
using CodeBuilder.Code;
using Newtonsoft.Json;

namespace CodeBuilder
{
    public partial class Main : Skin_VS
    {
       private  string SqlConStr =>
            $"Data Source = {skinTextBoxAddress.Text.Trim()} ; Initial Catalog = master ; User ID ={skinTextBoxAccount.Text.Trim()} ; Password = {skinTextBoxPassword.Text}";

        public Main()
        {
            InitializeComponent();
            Init();
        }

        private ModelConfig _modelConfig;

        private void Init()
        {
            if (!File.Exists("appconfig.bin"))
            {
                _modelConfig = new ModelConfig();
                skinTextBoxAccount.Text = _modelConfig.DataAccount;
                skinTextBoxPassword.Text = _modelConfig.DataPassword;
                skinTextBoxAddress.Text = _modelConfig.DataAddress;
            }
            else
            {
                using (FileStream fileStream =
                    new FileStream("appconfig.bin", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    StreamReader sr = new StreamReader(fileStream, Encoding.UTF8);
                    var json = sr.ReadToEnd();
                    var modelConfig = JsonConvert.DeserializeObject<ModelConfig>(json);
                    _modelConfig = modelConfig;
                    skinTextBoxAccount.Text = modelConfig.DataAccount;
                    skinTextBoxPassword.Text = modelConfig.DataPassword;
                    skinTextBoxAddress.Text = modelConfig.DataAddress;
                }
            }
        }

        private void skinDataConfigBtn_Click(object sender, EventArgs e)
        {
            DataModelConfig dataModelConfig = new DataModelConfig();
            dataModelConfig.ShowDialog();
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinBtnConnect_Click(object sender, EventArgs e)
        {
           
            using (SqlConnection _sqlCon = new SqlConnection(SqlConStr))
            {
                _sqlCon.Open();
                Task.Run(() =>
                {
                    ModelConfig modelConfig = new ModelConfig();
                    modelConfig.DataAccount = skinTextBoxAccount.Text.Trim();
                    modelConfig.DataPassword = skinTextBoxPassword.Text.Trim();
                    modelConfig.DataAddress = skinTextBoxAddress.Text.Trim();
                    using (FileStream fileStream = new FileStream("appconfig.bin", FileMode.Create, FileAccess.Write,
                        FileShare.ReadWrite))
                    {
                        var strJson = JsonConvert.SerializeObject(modelConfig);
                        var by = Encoding.UTF8.GetBytes(strJson);
                        fileStream.Write(by, 0, by.Length);
                        fileStream.Close();
                    }
                });
                SqlDataAdapter sda = new SqlDataAdapter("select name from sysdatabases", _sqlCon);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                skinComboBoxDatabase.DataSource = ds.Tables[0];
                skinComboBoxDatabase.DisplayMember = "name";
            }
        }

        private void skinBtnBuilder_Click(object sender, EventArgs e)
        {
            var dataRow = skinComboBoxDatabase.SelectedItem as DataRowView;
            if (dataRow == null)
            {
                return;
            }
            var database = dataRow.Row[0];
            using (SqlConnection sqlCon = new SqlConnection(SqlConStr))
            {
                sqlCon.Open();
                SqlCommand command = new SqlCommand($"use {database};", sqlCon);
                command.ExecuteNonQuery();
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
                SqlDataAdapter sda = new SqlDataAdapter(sqlStr, sqlCon);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ReadModelDatSet(ds.Tables[0]);
            }

        }

        private void ReadModelDatSet(DataTable dt)
        {
            Code.CodeBuilder codeBuilder = new Code.CodeBuilder();
            var nameText = skinTextNamespace.Text ?? _modelConfig.Namespace;
            for (int index = 0; index < dt.Rows.Count;)
            {
                DataRow dataRow = dt.Rows[index];
                var dbTemplate = codeBuilder.Load();
                dbTemplate.SetNamespace(nameText);
                var tableName = dataRow["表名"].ToString();
                dbTemplate.SetClassName(tableName, dataRow["表说明"].ToString());
                do
                {
                    DataRow tempRow = dt.Rows[index];
                    var field = new FieldTemplate();
                    var comment = new CommentTemplate();
                    field.Name = tempRow["字段名"].ToString();
                    comment.CommentName = tempRow["字段说明"].ToString();
                    field.DbType = tempRow["类型"].ToString();
                    field.MaxLength = tempRow["长度"].ToString().ToInt32();
                    field.Comment = comment;
                    field.Name = tempRow["字段名"].ToString();
                    field.CanNull = tempRow["允许空"].ToString() == "√";
                    field.ReturnType = DbToCsharpType(tempRow["类型"].ToString());
                    dbTemplate.SetProperty(field, comment);
                    /*dbTemplate.SetProperty(name: tempRow["字段名"].ToString(),
                        type: DbToCsharpType(tempRow["类型"].ToString(), tempRow["允许空"].ToString() == "√"),
                        comment: tempRow["字段说明"].ToString(), dbType:tempRow["类型"].ToString());*/
                    index++;
                    if (index== dt.Rows.Count)
                    {
                        break;
                    }
                } while (string.IsNullOrWhiteSpace(dt.Rows[index]["表名"].ToString()));
            }
            codeBuilder.Save("Model");
        }

        /// <summary>
        /// 数据库中与c#中的数据类型对照
        /// </summary>
        /// <param name="type">数据库类型</param>
        /// <param name="isNull">可空类型</param>
        /// <returns>C#类型</returns>
        public static string DbToCsharpType(string type,bool isNull=false)
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
                if (ravel!="string"&& ravel!= "object" && ravel != "byte[]")
                {
                    ravel += "?";
                }
            }
            return ravel;
        }

        public static List<string> FindFolder(string path,bool depth=false)
        {
            List<string> resultList=new List<string>();
            DirectoryInfo theFolder = new DirectoryInfo(path);
            if (depth)
            {
                //遍历文件夹
                foreach (DirectoryInfo nextFolder in theFolder.GetDirectories())
                {
                    resultList.AddRange(FindFolder(nextFolder.FullName));
                }
            }
            //遍历文件
            foreach (FileInfo nextFile in theFolder.GetFiles())
            {
                resultList.Add(nextFile.FullName);
            }

            return resultList;
        }
    }
}