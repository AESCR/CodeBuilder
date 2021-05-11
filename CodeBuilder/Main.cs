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
using CodeBuilder.DbTool;
using CodeBuilder.RepositoryTool;
using Newtonsoft.Json;

namespace CodeBuilder
{
    
    public partial class Main : Skin_VS
    {

        public Main()
        {
            InitializeComponent();
            Init();
        }

        private DbConnect _dbConfig=new DbConnect();
        private void Init()
        {
            skinComboxDatabaseName.SelectedIndex = 0;
            if (File.Exists("appconfig.bin"))
            {
                using (FileStream fileStream =
                    new FileStream("appconfig.bin", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    StreamReader sr = new StreamReader(fileStream, Encoding.UTF8);
                    var json = sr.ReadToEnd();
                    var modelConfig = JsonConvert.DeserializeObject<DbConnect>(json);
                    if (modelConfig!=null)
                    {
                        _dbConfig = modelConfig;
                        skinTextBoxPort.Text = _dbConfig.Port.ToString();
                        skinTextBoxAccount.Text = _dbConfig.Account;
                        skinTextBoxPassword.Text = _dbConfig.Password;
                        skinTextBoxAddress.Text = _dbConfig.Ip;
                    }
                }
            }
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinBtnConnect_Click(object sender, EventArgs e)
        {
            _dbConfig.Port = skinTextBoxPort.Text.ToInt32();
            _dbConfig.Account = skinTextBoxAccount.Text;
            _dbConfig.Password= skinTextBoxPassword.Text;
            _dbConfig.Ip= skinTextBoxAddress.Text;
            _dbConfig.DbType = GetBaseType();
            DbGenerate dbModelGenerate=new DbGenerate(_dbConfig);
            var r= dbModelGenerate.GetDataBase();
            skinComboBoxDatabase.DataSource = r;
            using (FileStream fileStream =
                new FileStream("appconfig.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var modelConfig = JsonConvert.SerializeObject(_dbConfig);
                var b = Encoding.UTF8.GetBytes(modelConfig);
                fileStream.Write(b,0, b.Length);
            }
            DataBaseType GetBaseType()
            {
                DataBaseType dataBaseType = DataBaseType.MsSQL;
                switch (skinComboxDatabaseName.SelectedIndex)
                {
                    case 0:
                        dataBaseType = DataBaseType.MsSQL;
                        break;
                    case 1:
                        dataBaseType = DataBaseType.MySQL;
                        break;
                }
                return dataBaseType;
            }
        }

        private void skinBtnBuilder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _dbConfig.Database = skinComboBoxDatabase.SelectedValue.ToString();
                DbGenerate dbGenerate=new DbGenerate(_dbConfig);
                dbGenerate.DbContext = skinCheckBoxContext.Checked;
                dbGenerate.RemoveLine = skinRemoveBoxUnderline.Checked;
                dbGenerate.DownloadPath= dialog.SelectedPath;
                dbGenerate.Save();
                MessageBox.Show("实体生成成功！", "提 示", MessageBoxButtons.OK);
            }
        }

        private void skinRepositoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _dbConfig.Database = skinComboBoxDatabase.SelectedValue.ToString();
                DbGenerate dbGenerate = new DbGenerate(_dbConfig);
                RepositoryGenerate rg=new RepositoryGenerate(dbGenerate);
                rg.DownloadPath = dialog.SelectedPath;
                rg.Save();
                MessageBox.Show("数据访问层生成成功！", "提 示", MessageBoxButtons.OK);
            }
        }
    }
}