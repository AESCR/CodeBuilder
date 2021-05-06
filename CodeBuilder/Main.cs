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
using CCWin.SkinClass;
using CodeBuilder.Code.Generate;
using CodeBuilder.Code.Template;
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
                ReadDb();
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
             ReadDb();
        }

        private void skinBtnBuilder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CodeGenerate codeGenerate=new CodeGenerate();
                codeGenerate.SavePath= dialog.SelectedPath+"/Model";
                ReadModelTable(codeGenerate);
                CreateDbContext(codeGenerate);
                codeGenerate.Save();
                MessageBox.Show("实体生成成功！", "提 示", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// 读取数据库列表
        /// </summary>
        private bool ReadDb()
        {
            using (SqlConnection sqlCon = new SqlConnection(SqlConStr))
            {
                try
                {
                    sqlCon.Open();
                    ModelConfig modelConfig = new ModelConfig
                    {
                        DataAccount = skinTextBoxAccount.Text.Trim(),
                        DataPassword = skinTextBoxPassword.Text.Trim(),
                        DataAddress = skinTextBoxAddress.Text.Trim()
                    };
                    using (FileStream fileStream = new FileStream("appconfig.bin", FileMode.Create, FileAccess.Write,
                        FileShare.ReadWrite))
                    {
                        var strJson = JsonConvert.SerializeObject(modelConfig);
                        var by = Encoding.UTF8.GetBytes(strJson);
                        fileStream.Write(by, 0, by.Length);
                        fileStream.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
              
                SqlDataAdapter sda = new SqlDataAdapter("select name from sysdatabases", sqlCon);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                skinComboBoxDatabase.DataSource = ds.Tables[0];
                skinComboBoxDatabase.DisplayMember = "name";
                return true;
            }
        }
        /// <summary>
        /// 读取当前选中的表
        /// </summary>
        private DataTable ReadTable()
        {
            var dataRow = skinComboBoxDatabase.SelectedItem as DataRowView;
            if (dataRow == null)
            {
                MessageBox.Show("请先选择要使用的库", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            var database = dataRow.Row[0].ToString();
            using (SqlConnection sqlCon = new SqlConnection(SqlConStr))
            {
                sqlCon.Open();
                SqlCommand command = new SqlCommand($"use {database};", sqlCon);
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
        /// <summary>
        /// 生成实体
        /// </summary>
        /// <param name="codeGenerate"></param>
        private void ReadModelTable(CodeGenerate codeGenerate)
        {
            var dt = ReadTable();
            var nameText = skinTextNamespace.Text ?? _modelConfig.Namespace;
            for (int index = 0; index < dt.Rows.Count;)
            {
                DataRow dataRow = dt.Rows[index];
                NamespaceTemplate namespaceTemplate=new NamespaceTemplate();
                namespaceTemplate.NamespaceName = nameText;
                codeGenerate.AddNamespace(namespaceTemplate);
                ClassTemplate classTemplate=new ClassTemplate();
                namespaceTemplate.AddClass(classTemplate);
                if (skinRemoveBoxUnderline.Checked)
                {
                    classTemplate.ClassName = dataRow["表名"].ToString();
                    classTemplate.ClassName= classTemplate.ClassName.Replace("_","");
                }
                else
                {
                    classTemplate.ClassName = dataRow["表名"].ToString();
                }
                classTemplate.RealName = dataRow["表名"].ToString();
                classTemplate.Comment=new Code.Template.CommentTemplate();
                classTemplate.Comment.CommentName = dataRow["表说明"].ToString();
                do
                {
                    DataRow tempRow = dt.Rows[index];
                    var field = new Code.Template.FieldTemplate();
                    var comment = new Code.Template.CommentTemplate();
                    field.FieldName = tempRow["字段名"].ToString();
                    comment.CommentName = tempRow["字段说明"].ToString();
                    field.DbType = tempRow["类型"].ToString();
                    field.MaxLength = tempRow["长度"].ToString().ToInt32();
                    field.MinLength = 0;
                    field.Comment = comment;
                    field.IsProperty = true;
                    field.IsKey = tempRow["主键"].ToString() == "√";
                    field.CanNull = tempRow["允许空"].ToString() == "√";
                    field.FieldTypeName = DbToCsharpType.MsSqlToCsharpType(tempRow["类型"].ToString());
                    classTemplate.AddField(field);
                    index++;
                    if (index == dt.Rows.Count)
                    {
                        break;
                    }
                } while (string.IsNullOrWhiteSpace(dt.Rows[index]["表名"].ToString()));
            }
        }

        private void CreateDbContext(CodeGenerate code)
        {
            if (skinCheckBoxContext.Checked==false)
            {
                return;
            }
            var codeDic = code.Show();
            var codeGenerate = new CodeGenerate();
            codeGenerate.SavePath = Path.Combine(code.SavePath, "../");
            var namespaceTemplate = new NamespaceTemplate();
            codeGenerate.AddNamespace(namespaceTemplate);
            namespaceTemplate.NamespaceName = "Microsoft.EntityFrameworkCore";
            var classTemplate= new ClassTemplate();
            namespaceTemplate.AddClass(classTemplate);
            classTemplate.ClassName=skinComboBoxDatabase.Text.Trim()+ "DbContext";
            classTemplate.BaseClass =new ClassTemplate()
            {
                ClassName = "DbContext"
            };
           
            foreach (KeyValuePair<string, string> keyValuePair in codeDic)
            {
                var field = new FieldTemplate();
                field.FieldName = keyValuePair.Key;
                field.FieldTypeName = $"DbSet<{keyValuePair.Key}>";
                classTemplate.AddField(field);
            }
            codeGenerate.Save();
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