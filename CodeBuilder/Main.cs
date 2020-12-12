using CCWin;
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
using CodeBuilder.Code;
using Newtonsoft.Json;

namespace CodeBuilder
{
    public partial class Main : Skin_VS
    {
        private SqlConnection _sqlCon;

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
            };
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
            string sqlConStr =
                $"Data Source = {skinTextBoxAddress.Text.Trim()} ; Initial Catalog = master ; User ID ={skinTextBoxAccount.Text.Trim()} ; Password = {skinTextBoxPassword.Text}";
            _sqlCon = new SqlConnection(sqlConStr);
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

        private void skinBtnBuilder_Click(object sender, EventArgs e)
        {
            var dataRow = skinComboBoxDatabase.SelectedItem as DataRowView;
            if (dataRow == null)
            {
                return;
            }

            var database = dataRow.Row[0];
            if ((_sqlCon.State & ConnectionState.Open) != 0)
            {
                SqlCommand command = new SqlCommand($"use {database};", _sqlCon);
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
                SqlDataAdapter sda = new SqlDataAdapter(sqlStr, _sqlCon);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ReadDatSet(ds.Tables[0]);
            }
        }

        private void ReadDatSet(DataTable dt)
        {
            //创建文件夹
            Directory.CreateDirectory(Path.Combine(_modelConfig.SavePath, "DBModel"));
            Directory.CreateDirectory(Path.Combine(_modelConfig.SavePath, "InPutModel"));
            Directory.CreateDirectory(Path.Combine(_modelConfig.SavePath, "OutPutModel"));
            for (int index = 0; index < dt.Rows.Count;)
            {
                DataRow dataRow = dt.Rows[index];
                var tableName = dataRow["表名"].ToString();
                if (!string.IsNullOrWhiteSpace(tableName))
                {
                    CSharpTemplate dbTemplate = new CSharpTemplate();
                    dbTemplate.ImportNamespace();
                    dbTemplate.SetNamespace(_modelConfig.Namespace);
                    dbTemplate.SetClass(tableName, dataRow["表说明"].ToString(),false);
                    dbTemplate.SetProperty(DbToCsharpType(dataRow["类型"].ToString(), dataRow["允许空"].ToString() == "√"), dataRow["字段名"].ToString(), dataRow["字段说明"].ToString());
                    while (true)
                    {
                         index++;
                        if (index < dt.Rows.Count)
                        {
                            DataRow tempDataRow = dt.Rows[index];
                            var hasTableName = string.IsNullOrWhiteSpace(tempDataRow["表名"].ToString());
                            if (hasTableName == false)
                            {
                                break;
                            }
                            dbTemplate.SetProperty(DbToCsharpType(tempDataRow["类型"].ToString(), tempDataRow["允许空"].ToString() == "√"), tempDataRow["字段名"].ToString(), tempDataRow["字段说明"].ToString());
                        }
                        else
                        {
                            break; ;
                        }
                    }
                    dbTemplate.Save(Path.Combine(_modelConfig.SavePath, "DBModel/", tableName));
                }
            }
            //
            var folders= FindFolder("DBModel");
            foreach (string folder in folders)
            {
                var name = Path.GetFileNameWithoutExtension(folder);
                Directory.CreateDirectory(Path.Combine(_modelConfig.SavePath, $"InPutModel/{name}"));
                new CSharpTemplate().SetClass(_modelConfig.Namespace,$"Add{name}").Save(Path.Combine(_modelConfig.SavePath, $"InPutModel/{name}/Add{name}"));
                new CSharpTemplate().SetClass(_modelConfig.Namespace, $"Edit{name}").Save(Path.Combine(_modelConfig.SavePath, $"InPutModel/{name}/Edit{name}"));
                new CSharpTemplate().SetClass(_modelConfig.Namespace, $"Search{name}").Save(Path.Combine(_modelConfig.SavePath, $"InPutModel/{name}/Search{name}"));
                Directory.CreateDirectory(Path.Combine(_modelConfig.SavePath, $"OutPutModel/{Path.GetFileNameWithoutExtension(folder)}"));
                new CSharpTemplate().SetClass(_modelConfig.Namespace, $"{name}View").Save(Path.Combine(_modelConfig.SavePath, $"OutPutModel/{name}/{name}View"));
            }
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
