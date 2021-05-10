
namespace CodeBuilder
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.skinComboxDatabaseName = new CCWin.SkinControl.SkinComboBox();
            this.skinComboBoxDatabase = new CCWin.SkinControl.SkinComboBox();
            this.skinBtnConnect = new CCWin.SkinControl.SkinButton();
            this.skinTextBoxPassword = new CCWin.SkinControl.SkinTextBox();
            this.skinTextBoxAccount = new CCWin.SkinControl.SkinTextBox();
            this.skinTextBoxPort = new CCWin.SkinControl.SkinTextBox();
            this.skinTextBoxAddress = new CCWin.SkinControl.SkinTextBox();
            this.skinGroupBox3 = new CCWin.SkinControl.SkinGroupBox();
            this.skinCheckBox2 = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBoxContext = new CCWin.SkinControl.SkinCheckBox();
            this.skinRemoveBoxUnderline = new CCWin.SkinControl.SkinCheckBox();
            this.skinTextNamespace = new CCWin.SkinControl.SkinTextBox();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.skinButton5 = new CCWin.SkinControl.SkinButton();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.skinRepositoryButton = new CCWin.SkinControl.SkinButton();
            this.skinCheckBox8 = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox4 = new CCWin.SkinControl.SkinCheckBox();
            this.skinTextBox1 = new CCWin.SkinControl.SkinTextBox();
            this.skinCheckBox3 = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox1 = new CCWin.SkinControl.SkinCheckBox();
            this.skinGroupBox4 = new CCWin.SkinControl.SkinGroupBox();
            this.skinButton3 = new CCWin.SkinControl.SkinButton();
            this.skinCheckBox6 = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox7 = new CCWin.SkinControl.SkinCheckBox();
            this.skinTextBox2 = new CCWin.SkinControl.SkinTextBox();
            this.skinButton4 = new CCWin.SkinControl.SkinButton();
            this.skinProgressBar1 = new CCWin.SkinControl.SkinProgressBar();
            this.skinGroupBox1.SuspendLayout();
            this.skinGroupBox3.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            this.skinGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinGroupBox1.Controls.Add(this.skinComboxDatabaseName);
            this.skinGroupBox1.Controls.Add(this.skinComboBoxDatabase);
            this.skinGroupBox1.Controls.Add(this.skinBtnConnect);
            this.skinGroupBox1.Controls.Add(this.skinTextBoxPassword);
            this.skinGroupBox1.Controls.Add(this.skinTextBoxAccount);
            this.skinGroupBox1.Controls.Add(this.skinTextBoxPort);
            this.skinGroupBox1.Controls.Add(this.skinTextBoxAddress);
            this.skinGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox1.Location = new System.Drawing.Point(8, 39);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(970, 76);
            this.skinGroupBox1.TabIndex = 0;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "数据库配置";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinComboxDatabaseName
            // 
            this.skinComboxDatabaseName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboxDatabaseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboxDatabaseName.FormattingEnabled = true;
            this.skinComboxDatabaseName.Items.AddRange(new object[] {
            "MsSQL",
            "MySQL"});
            this.skinComboxDatabaseName.Location = new System.Drawing.Point(588, 34);
            this.skinComboxDatabaseName.Name = "skinComboxDatabaseName";
            this.skinComboxDatabaseName.Size = new System.Drawing.Size(89, 27);
            this.skinComboxDatabaseName.TabIndex = 2;
            this.skinComboxDatabaseName.WaterText = "请选择数据库";
            // 
            // skinComboBoxDatabase
            // 
            this.skinComboBoxDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxDatabase.FormattingEnabled = true;
            this.skinComboBoxDatabase.Location = new System.Drawing.Point(821, 34);
            this.skinComboBoxDatabase.Name = "skinComboBoxDatabase";
            this.skinComboBoxDatabase.Size = new System.Drawing.Size(133, 27);
            this.skinComboBoxDatabase.TabIndex = 2;
            this.skinComboBoxDatabase.WaterText = "";
            // 
            // skinBtnConnect
            // 
            this.skinBtnConnect.BackColor = System.Drawing.Color.Transparent;
            this.skinBtnConnect.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinBtnConnect.DownBack = null;
            this.skinBtnConnect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinBtnConnect.InheritColor = true;
            this.skinBtnConnect.Location = new System.Drawing.Point(716, 33);
            this.skinBtnConnect.MouseBack = null;
            this.skinBtnConnect.Name = "skinBtnConnect";
            this.skinBtnConnect.NormlBack = null;
            this.skinBtnConnect.Size = new System.Drawing.Size(77, 28);
            this.skinBtnConnect.TabIndex = 1;
            this.skinBtnConnect.Text = "测试连接";
            this.skinBtnConnect.UseVisualStyleBackColor = false;
            this.skinBtnConnect.Click += new System.EventHandler(this.skinBtnConnect_Click);
            // 
            // skinTextBoxPassword
            // 
            this.skinTextBoxPassword.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxPassword.DownBack = null;
            this.skinTextBoxPassword.Icon = null;
            this.skinTextBoxPassword.IconIsButton = false;
            this.skinTextBoxPassword.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxPassword.IsPasswordChat = '\0';
            this.skinTextBoxPassword.IsSystemPasswordChar = false;
            this.skinTextBoxPassword.Lines = new string[0];
            this.skinTextBoxPassword.Location = new System.Drawing.Point(385, 33);
            this.skinTextBoxPassword.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxPassword.MaxLength = 32767;
            this.skinTextBoxPassword.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxPassword.MouseBack = null;
            this.skinTextBoxPassword.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxPassword.Multiline = false;
            this.skinTextBoxPassword.Name = "skinTextBoxPassword";
            this.skinTextBoxPassword.NormlBack = null;
            this.skinTextBoxPassword.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxPassword.ReadOnly = false;
            this.skinTextBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxPassword.Size = new System.Drawing.Size(179, 28);
            // 
            // 
            // 
            this.skinTextBoxPassword.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxPassword.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxPassword.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxPassword.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxPassword.SkinTxt.Name = "BaseText";
            this.skinTextBoxPassword.SkinTxt.Size = new System.Drawing.Size(169, 18);
            this.skinTextBoxPassword.SkinTxt.TabIndex = 0;
            this.skinTextBoxPassword.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxPassword.SkinTxt.WaterText = "请输入数据库密码";
            this.skinTextBoxPassword.TabIndex = 2;
            this.skinTextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxPassword.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxPassword.WaterText = "请输入数据库密码";
            this.skinTextBoxPassword.WordWrap = true;
            // 
            // skinTextBoxAccount
            // 
            this.skinTextBoxAccount.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxAccount.DownBack = null;
            this.skinTextBoxAccount.Icon = null;
            this.skinTextBoxAccount.IconIsButton = false;
            this.skinTextBoxAccount.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxAccount.IsPasswordChat = '\0';
            this.skinTextBoxAccount.IsSystemPasswordChar = false;
            this.skinTextBoxAccount.Lines = new string[0];
            this.skinTextBoxAccount.Location = new System.Drawing.Point(235, 33);
            this.skinTextBoxAccount.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxAccount.MaxLength = 32767;
            this.skinTextBoxAccount.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxAccount.MouseBack = null;
            this.skinTextBoxAccount.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxAccount.Multiline = false;
            this.skinTextBoxAccount.Name = "skinTextBoxAccount";
            this.skinTextBoxAccount.NormlBack = null;
            this.skinTextBoxAccount.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxAccount.ReadOnly = false;
            this.skinTextBoxAccount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxAccount.Size = new System.Drawing.Size(127, 28);
            // 
            // 
            // 
            this.skinTextBoxAccount.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxAccount.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxAccount.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxAccount.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxAccount.SkinTxt.Name = "BaseText";
            this.skinTextBoxAccount.SkinTxt.Size = new System.Drawing.Size(117, 18);
            this.skinTextBoxAccount.SkinTxt.TabIndex = 0;
            this.skinTextBoxAccount.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxAccount.SkinTxt.WaterText = "数据库账号";
            this.skinTextBoxAccount.TabIndex = 1;
            this.skinTextBoxAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxAccount.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxAccount.WaterText = "数据库账号";
            this.skinTextBoxAccount.WordWrap = true;
            // 
            // skinTextBoxPort
            // 
            this.skinTextBoxPort.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxPort.DownBack = null;
            this.skinTextBoxPort.Icon = null;
            this.skinTextBoxPort.IconIsButton = false;
            this.skinTextBoxPort.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxPort.IsPasswordChat = '\0';
            this.skinTextBoxPort.IsSystemPasswordChar = false;
            this.skinTextBoxPort.Lines = new string[0];
            this.skinTextBoxPort.Location = new System.Drawing.Point(160, 34);
            this.skinTextBoxPort.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxPort.MaxLength = 32767;
            this.skinTextBoxPort.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxPort.MouseBack = null;
            this.skinTextBoxPort.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxPort.Multiline = false;
            this.skinTextBoxPort.Name = "skinTextBoxPort";
            this.skinTextBoxPort.NormlBack = null;
            this.skinTextBoxPort.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxPort.ReadOnly = false;
            this.skinTextBoxPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxPort.Size = new System.Drawing.Size(47, 28);
            // 
            // 
            // 
            this.skinTextBoxPort.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxPort.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxPort.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxPort.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxPort.SkinTxt.Name = "BaseText";
            this.skinTextBoxPort.SkinTxt.Size = new System.Drawing.Size(37, 18);
            this.skinTextBoxPort.SkinTxt.TabIndex = 0;
            this.skinTextBoxPort.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxPort.SkinTxt.WaterText = "端口";
            this.skinTextBoxPort.TabIndex = 0;
            this.skinTextBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxPort.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxPort.WaterText = "端口";
            this.skinTextBoxPort.WordWrap = true;
            // 
            // skinTextBoxAddress
            // 
            this.skinTextBoxAddress.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxAddress.DownBack = null;
            this.skinTextBoxAddress.Icon = null;
            this.skinTextBoxAddress.IconIsButton = false;
            this.skinTextBoxAddress.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxAddress.IsPasswordChat = '\0';
            this.skinTextBoxAddress.IsSystemPasswordChar = false;
            this.skinTextBoxAddress.Lines = new string[] {
        "127.0.0.1"};
            this.skinTextBoxAddress.Location = new System.Drawing.Point(22, 32);
            this.skinTextBoxAddress.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxAddress.MaxLength = 32767;
            this.skinTextBoxAddress.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxAddress.MouseBack = null;
            this.skinTextBoxAddress.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxAddress.Multiline = false;
            this.skinTextBoxAddress.Name = "skinTextBoxAddress";
            this.skinTextBoxAddress.NormlBack = null;
            this.skinTextBoxAddress.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxAddress.ReadOnly = false;
            this.skinTextBoxAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxAddress.Size = new System.Drawing.Size(124, 28);
            // 
            // 
            // 
            this.skinTextBoxAddress.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxAddress.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxAddress.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxAddress.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxAddress.SkinTxt.Name = "BaseText";
            this.skinTextBoxAddress.SkinTxt.Size = new System.Drawing.Size(114, 18);
            this.skinTextBoxAddress.SkinTxt.TabIndex = 0;
            this.skinTextBoxAddress.SkinTxt.Text = "127.0.0.1";
            this.skinTextBoxAddress.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxAddress.SkinTxt.WaterText = "请输入数据库地址";
            this.skinTextBoxAddress.TabIndex = 0;
            this.skinTextBoxAddress.Text = "127.0.0.1";
            this.skinTextBoxAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxAddress.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxAddress.WaterText = "请输入数据库地址";
            this.skinTextBoxAddress.WordWrap = true;
            // 
            // skinGroupBox3
            // 
            this.skinGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinGroupBox3.Controls.Add(this.skinCheckBox2);
            this.skinGroupBox3.Controls.Add(this.skinCheckBoxContext);
            this.skinGroupBox3.Controls.Add(this.skinRemoveBoxUnderline);
            this.skinGroupBox3.Controls.Add(this.skinTextNamespace);
            this.skinGroupBox3.Controls.Add(this.skinButton2);
            this.skinGroupBox3.Controls.Add(this.skinButton5);
            this.skinGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox3.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox3.Location = new System.Drawing.Point(8, 115);
            this.skinGroupBox3.Name = "skinGroupBox3";
            this.skinGroupBox3.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox3.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox3.Size = new System.Drawing.Size(970, 76);
            this.skinGroupBox3.TabIndex = 2;
            this.skinGroupBox3.TabStop = false;
            this.skinGroupBox3.Text = "数据库实体生成";
            this.skinGroupBox3.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox3.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox3.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinCheckBox2
            // 
            this.skinCheckBox2.AutoSize = true;
            this.skinCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox2.DownBack = null;
            this.skinCheckBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox2.Location = new System.Drawing.Point(588, 37);
            this.skinCheckBox2.MouseBack = null;
            this.skinCheckBox2.Name = "skinCheckBox2";
            this.skinCheckBox2.NormlBack = null;
            this.skinCheckBox2.SelectedDownBack = null;
            this.skinCheckBox2.SelectedMouseBack = null;
            this.skinCheckBox2.SelectedNormlBack = null;
            this.skinCheckBox2.Size = new System.Drawing.Size(99, 21);
            this.skinCheckBox2.TabIndex = 4;
            this.skinCheckBox2.Text = "生成视图实体";
            this.skinCheckBox2.UseVisualStyleBackColor = false;
            // 
            // skinCheckBoxContext
            // 
            this.skinCheckBoxContext.AutoSize = true;
            this.skinCheckBoxContext.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBoxContext.Checked = true;
            this.skinCheckBoxContext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBoxContext.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBoxContext.DownBack = null;
            this.skinCheckBoxContext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBoxContext.Location = new System.Drawing.Point(385, 37);
            this.skinCheckBoxContext.MouseBack = null;
            this.skinCheckBoxContext.Name = "skinCheckBoxContext";
            this.skinCheckBoxContext.NormlBack = null;
            this.skinCheckBoxContext.SelectedDownBack = null;
            this.skinCheckBoxContext.SelectedMouseBack = null;
            this.skinCheckBoxContext.SelectedNormlBack = null;
            this.skinCheckBoxContext.Size = new System.Drawing.Size(111, 21);
            this.skinCheckBoxContext.TabIndex = 4;
            this.skinCheckBoxContext.Text = "生成上下文实体";
            this.skinCheckBoxContext.UseVisualStyleBackColor = false;
            // 
            // skinRemoveBoxUnderline
            // 
            this.skinRemoveBoxUnderline.AutoSize = true;
            this.skinRemoveBoxUnderline.BackColor = System.Drawing.Color.Transparent;
            this.skinRemoveBoxUnderline.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinRemoveBoxUnderline.DownBack = null;
            this.skinRemoveBoxUnderline.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinRemoveBoxUnderline.Location = new System.Drawing.Point(235, 37);
            this.skinRemoveBoxUnderline.MouseBack = null;
            this.skinRemoveBoxUnderline.Name = "skinRemoveBoxUnderline";
            this.skinRemoveBoxUnderline.NormlBack = null;
            this.skinRemoveBoxUnderline.SelectedDownBack = null;
            this.skinRemoveBoxUnderline.SelectedMouseBack = null;
            this.skinRemoveBoxUnderline.SelectedNormlBack = null;
            this.skinRemoveBoxUnderline.Size = new System.Drawing.Size(104, 21);
            this.skinRemoveBoxUnderline.TabIndex = 4;
            this.skinRemoveBoxUnderline.Text = "移除表名中的_";
            this.skinRemoveBoxUnderline.UseVisualStyleBackColor = false;
            // 
            // skinTextNamespace
            // 
            this.skinTextNamespace.BackColor = System.Drawing.Color.Transparent;
            this.skinTextNamespace.DownBack = null;
            this.skinTextNamespace.Icon = null;
            this.skinTextNamespace.IconIsButton = false;
            this.skinTextNamespace.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextNamespace.IsPasswordChat = '\0';
            this.skinTextNamespace.IsSystemPasswordChar = false;
            this.skinTextNamespace.Lines = new string[] {
        "Aescr.Model"};
            this.skinTextNamespace.Location = new System.Drawing.Point(22, 32);
            this.skinTextNamespace.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextNamespace.MaxLength = 32767;
            this.skinTextNamespace.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextNamespace.MouseBack = null;
            this.skinTextNamespace.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextNamespace.Multiline = false;
            this.skinTextNamespace.Name = "skinTextNamespace";
            this.skinTextNamespace.NormlBack = null;
            this.skinTextNamespace.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextNamespace.ReadOnly = false;
            this.skinTextNamespace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextNamespace.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.skinTextNamespace.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextNamespace.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextNamespace.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextNamespace.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextNamespace.SkinTxt.Name = "BaseText";
            this.skinTextNamespace.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.skinTextNamespace.SkinTxt.TabIndex = 0;
            this.skinTextNamespace.SkinTxt.Text = "Aescr.Model";
            this.skinTextNamespace.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextNamespace.SkinTxt.WaterText = "设置命名空间";
            this.skinTextNamespace.TabIndex = 2;
            this.skinTextNamespace.Text = "Aescr.Model";
            this.skinTextNamespace.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextNamespace.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextNamespace.WaterText = "设置命名空间";
            this.skinTextNamespace.WordWrap = true;
            // 
            // skinButton2
            // 
            this.skinButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton2.InheritColor = true;
            this.skinButton2.Location = new System.Drawing.Point(716, 33);
            this.skinButton2.MouseBack = null;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.Size = new System.Drawing.Size(77, 28);
            this.skinButton2.TabIndex = 1;
            this.skinButton2.Text = "预览生成";
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Click += new System.EventHandler(this.skinBtnBuilder_Click);
            // 
            // skinButton5
            // 
            this.skinButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinButton5.BackColor = System.Drawing.Color.Transparent;
            this.skinButton5.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton5.DownBack = null;
            this.skinButton5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton5.InheritColor = true;
            this.skinButton5.Location = new System.Drawing.Point(821, 33);
            this.skinButton5.MouseBack = null;
            this.skinButton5.Name = "skinButton5";
            this.skinButton5.NormlBack = null;
            this.skinButton5.Size = new System.Drawing.Size(131, 28);
            this.skinButton5.TabIndex = 1;
            this.skinButton5.Text = "生成实体";
            this.skinButton5.UseVisualStyleBackColor = false;
            this.skinButton5.Click += new System.EventHandler(this.skinBtnBuilder_Click);
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinGroupBox2.Controls.Add(this.skinRepositoryButton);
            this.skinGroupBox2.Controls.Add(this.skinCheckBox8);
            this.skinGroupBox2.Controls.Add(this.skinCheckBox4);
            this.skinGroupBox2.Controls.Add(this.skinTextBox1);
            this.skinGroupBox2.Controls.Add(this.skinCheckBox3);
            this.skinGroupBox2.Controls.Add(this.skinCheckBox1);
            this.skinGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox2.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox2.Location = new System.Drawing.Point(8, 191);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.Size = new System.Drawing.Size(970, 76);
            this.skinGroupBox2.TabIndex = 3;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "数据访问层";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinRepositoryButton
            // 
            this.skinRepositoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinRepositoryButton.BackColor = System.Drawing.Color.Transparent;
            this.skinRepositoryButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinRepositoryButton.DownBack = null;
            this.skinRepositoryButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinRepositoryButton.InheritColor = true;
            this.skinRepositoryButton.Location = new System.Drawing.Point(821, 25);
            this.skinRepositoryButton.MouseBack = null;
            this.skinRepositoryButton.Name = "skinRepositoryButton";
            this.skinRepositoryButton.NormlBack = null;
            this.skinRepositoryButton.Size = new System.Drawing.Size(131, 28);
            this.skinRepositoryButton.TabIndex = 1;
            this.skinRepositoryButton.Text = "生成增删改查";
            this.skinRepositoryButton.UseVisualStyleBackColor = false;
            this.skinRepositoryButton.Click += new System.EventHandler(this.skinRepositoryButton_Click);
            // 
            // skinCheckBox8
            // 
            this.skinCheckBox8.AutoSize = true;
            this.skinCheckBox8.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox8.Checked = true;
            this.skinCheckBox8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox8.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox8.DownBack = null;
            this.skinCheckBox8.Enabled = false;
            this.skinCheckBox8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox8.Location = new System.Drawing.Point(716, 29);
            this.skinCheckBox8.MouseBack = null;
            this.skinCheckBox8.Name = "skinCheckBox8";
            this.skinCheckBox8.NormlBack = null;
            this.skinCheckBox8.SelectedDownBack = null;
            this.skinCheckBox8.SelectedMouseBack = null;
            this.skinCheckBox8.SelectedNormlBack = null;
            this.skinCheckBox8.Size = new System.Drawing.Size(92, 21);
            this.skinCheckBox8.TabIndex = 4;
            this.skinCheckBox8.Text = "输入/出实体";
            this.skinCheckBox8.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox4
            // 
            this.skinCheckBox4.AutoSize = true;
            this.skinCheckBox4.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox4.Checked = true;
            this.skinCheckBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox4.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox4.DownBack = null;
            this.skinCheckBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox4.Location = new System.Drawing.Point(588, 29);
            this.skinCheckBox4.MouseBack = null;
            this.skinCheckBox4.Name = "skinCheckBox4";
            this.skinCheckBox4.NormlBack = null;
            this.skinCheckBox4.SelectedDownBack = null;
            this.skinCheckBox4.SelectedMouseBack = null;
            this.skinCheckBox4.SelectedNormlBack = null;
            this.skinCheckBox4.Size = new System.Drawing.Size(87, 21);
            this.skinCheckBox4.TabIndex = 4;
            this.skinCheckBox4.Text = "单字段更新";
            this.skinCheckBox4.UseVisualStyleBackColor = false;
            // 
            // skinTextBox1
            // 
            this.skinTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox1.DownBack = null;
            this.skinTextBox1.Icon = null;
            this.skinTextBox1.IconIsButton = false;
            this.skinTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.IsPasswordChat = '\0';
            this.skinTextBox1.IsSystemPasswordChar = false;
            this.skinTextBox1.Lines = new string[] {
        "Aescr.Repository"};
            this.skinTextBox1.Location = new System.Drawing.Point(21, 28);
            this.skinTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox1.MaxLength = 32767;
            this.skinTextBox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox1.MouseBack = null;
            this.skinTextBox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.Multiline = false;
            this.skinTextBox1.Name = "skinTextBox1";
            this.skinTextBox1.NormlBack = null;
            this.skinTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox1.ReadOnly = false;
            this.skinTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox1.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.skinTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox1.SkinTxt.Name = "BaseText";
            this.skinTextBox1.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.skinTextBox1.SkinTxt.TabIndex = 0;
            this.skinTextBox1.SkinTxt.Text = "Aescr.Repository";
            this.skinTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox1.SkinTxt.WaterText = "设置命名空间";
            this.skinTextBox1.TabIndex = 2;
            this.skinTextBox1.Text = "Aescr.Repository";
            this.skinTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox1.WaterText = "设置命名空间";
            this.skinTextBox1.WordWrap = true;
            // 
            // skinCheckBox3
            // 
            this.skinCheckBox3.AutoSize = true;
            this.skinCheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox3.Checked = true;
            this.skinCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox3.DownBack = null;
            this.skinCheckBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox3.Location = new System.Drawing.Point(385, 29);
            this.skinCheckBox3.MouseBack = null;
            this.skinCheckBox3.Name = "skinCheckBox3";
            this.skinCheckBox3.NormlBack = null;
            this.skinCheckBox3.SelectedDownBack = null;
            this.skinCheckBox3.SelectedMouseBack = null;
            this.skinCheckBox3.SelectedNormlBack = null;
            this.skinCheckBox3.Size = new System.Drawing.Size(63, 21);
            this.skinCheckBox3.TabIndex = 4;
            this.skinCheckBox3.Text = "实现层";
            this.skinCheckBox3.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox1
            // 
            this.skinCheckBox1.AutoSize = true;
            this.skinCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox1.Checked = true;
            this.skinCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox1.DownBack = null;
            this.skinCheckBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox1.Location = new System.Drawing.Point(235, 29);
            this.skinCheckBox1.MouseBack = null;
            this.skinCheckBox1.Name = "skinCheckBox1";
            this.skinCheckBox1.NormlBack = null;
            this.skinCheckBox1.SelectedDownBack = null;
            this.skinCheckBox1.SelectedMouseBack = null;
            this.skinCheckBox1.SelectedNormlBack = null;
            this.skinCheckBox1.Size = new System.Drawing.Size(63, 21);
            this.skinCheckBox1.TabIndex = 4;
            this.skinCheckBox1.Text = "接口层";
            this.skinCheckBox1.UseVisualStyleBackColor = false;
            // 
            // skinGroupBox4
            // 
            this.skinGroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinGroupBox4.Controls.Add(this.skinButton3);
            this.skinGroupBox4.Controls.Add(this.skinCheckBox6);
            this.skinGroupBox4.Controls.Add(this.skinCheckBox7);
            this.skinGroupBox4.Controls.Add(this.skinTextBox2);
            this.skinGroupBox4.Controls.Add(this.skinButton4);
            this.skinGroupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox4.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox4.Location = new System.Drawing.Point(8, 267);
            this.skinGroupBox4.Name = "skinGroupBox4";
            this.skinGroupBox4.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox4.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox4.Size = new System.Drawing.Size(970, 76);
            this.skinGroupBox4.TabIndex = 4;
            this.skinGroupBox4.TabStop = false;
            this.skinGroupBox4.Text = "服务层";
            this.skinGroupBox4.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox4.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox4.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinButton3
            // 
            this.skinButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinButton3.BackColor = System.Drawing.Color.Transparent;
            this.skinButton3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton3.DownBack = null;
            this.skinButton3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton3.InheritColor = true;
            this.skinButton3.Location = new System.Drawing.Point(821, 25);
            this.skinButton3.MouseBack = null;
            this.skinButton3.Name = "skinButton3";
            this.skinButton3.NormlBack = null;
            this.skinButton3.Size = new System.Drawing.Size(131, 28);
            this.skinButton3.TabIndex = 1;
            this.skinButton3.Text = "生成增删改查";
            this.skinButton3.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox6
            // 
            this.skinCheckBox6.AutoSize = true;
            this.skinCheckBox6.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox6.Checked = true;
            this.skinCheckBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox6.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox6.DownBack = null;
            this.skinCheckBox6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox6.Location = new System.Drawing.Point(385, 29);
            this.skinCheckBox6.MouseBack = null;
            this.skinCheckBox6.Name = "skinCheckBox6";
            this.skinCheckBox6.NormlBack = null;
            this.skinCheckBox6.SelectedDownBack = null;
            this.skinCheckBox6.SelectedMouseBack = null;
            this.skinCheckBox6.SelectedNormlBack = null;
            this.skinCheckBox6.Size = new System.Drawing.Size(63, 21);
            this.skinCheckBox6.TabIndex = 4;
            this.skinCheckBox6.Text = "实现层";
            this.skinCheckBox6.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox7
            // 
            this.skinCheckBox7.AutoSize = true;
            this.skinCheckBox7.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox7.Checked = true;
            this.skinCheckBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox7.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox7.DownBack = null;
            this.skinCheckBox7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox7.Location = new System.Drawing.Point(235, 29);
            this.skinCheckBox7.MouseBack = null;
            this.skinCheckBox7.Name = "skinCheckBox7";
            this.skinCheckBox7.NormlBack = null;
            this.skinCheckBox7.SelectedDownBack = null;
            this.skinCheckBox7.SelectedMouseBack = null;
            this.skinCheckBox7.SelectedNormlBack = null;
            this.skinCheckBox7.Size = new System.Drawing.Size(63, 21);
            this.skinCheckBox7.TabIndex = 4;
            this.skinCheckBox7.Text = "接口层";
            this.skinCheckBox7.UseVisualStyleBackColor = false;
            // 
            // skinTextBox2
            // 
            this.skinTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox2.DownBack = null;
            this.skinTextBox2.Icon = null;
            this.skinTextBox2.IconIsButton = false;
            this.skinTextBox2.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox2.IsPasswordChat = '\0';
            this.skinTextBox2.IsSystemPasswordChar = false;
            this.skinTextBox2.Lines = new string[] {
        "Aescr.Service"};
            this.skinTextBox2.Location = new System.Drawing.Point(22, 26);
            this.skinTextBox2.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox2.MaxLength = 32767;
            this.skinTextBox2.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox2.MouseBack = null;
            this.skinTextBox2.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox2.Multiline = false;
            this.skinTextBox2.Name = "skinTextBox2";
            this.skinTextBox2.NormlBack = null;
            this.skinTextBox2.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox2.ReadOnly = false;
            this.skinTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox2.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.skinTextBox2.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox2.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox2.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox2.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox2.SkinTxt.Name = "BaseText";
            this.skinTextBox2.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.skinTextBox2.SkinTxt.TabIndex = 0;
            this.skinTextBox2.SkinTxt.Text = "Aescr.Service";
            this.skinTextBox2.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox2.SkinTxt.WaterText = "设置命名空间";
            this.skinTextBox2.TabIndex = 2;
            this.skinTextBox2.Text = "Aescr.Service";
            this.skinTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox2.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox2.WaterText = "设置命名空间";
            this.skinTextBox2.WordWrap = true;
            // 
            // skinButton4
            // 
            this.skinButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinButton4.BackColor = System.Drawing.Color.Transparent;
            this.skinButton4.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton4.DownBack = null;
            this.skinButton4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton4.InheritColor = true;
            this.skinButton4.Location = new System.Drawing.Point(716, 26);
            this.skinButton4.MouseBack = null;
            this.skinButton4.Name = "skinButton4";
            this.skinButton4.NormlBack = null;
            this.skinButton4.Size = new System.Drawing.Size(77, 28);
            this.skinButton4.TabIndex = 1;
            this.skinButton4.Text = "预览生成";
            this.skinButton4.UseVisualStyleBackColor = false;
            this.skinButton4.Click += new System.EventHandler(this.skinBtnBuilder_Click);
            // 
            // skinProgressBar1
            // 
            this.skinProgressBar1.Back = null;
            this.skinProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.skinProgressBar1.BarBack = null;
            this.skinProgressBar1.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinProgressBar1.ForeColor = System.Drawing.Color.Red;
            this.skinProgressBar1.Location = new System.Drawing.Point(53, 384);
            this.skinProgressBar1.Name = "skinProgressBar1";
            this.skinProgressBar1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinProgressBar1.Size = new System.Drawing.Size(875, 23);
            this.skinProgressBar1.TabIndex = 5;
            this.skinProgressBar1.TrackBack = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(986, 450);
            this.Controls.Add(this.skinProgressBar1);
            this.Controls.Add(this.skinGroupBox4);
            this.Controls.Add(this.skinGroupBox2);
            this.Controls.Add(this.skinGroupBox3);
            this.Controls.Add(this.skinGroupBox1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowDrawIcon = false;
            this.Text = "代码构造器";
            this.TitleCenter = true;
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox3.ResumeLayout(false);
            this.skinGroupBox3.PerformLayout();
            this.skinGroupBox2.ResumeLayout(false);
            this.skinGroupBox2.PerformLayout();
            this.skinGroupBox4.ResumeLayout(false);
            this.skinGroupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinTextBox skinTextBoxAddress;
        private CCWin.SkinControl.SkinButton skinBtnConnect;
        private CCWin.SkinControl.SkinComboBox skinComboBoxDatabase;
        private CCWin.SkinControl.SkinTextBox skinTextBoxAccount;
        private CCWin.SkinControl.SkinTextBox skinTextBoxPassword;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox3;
        private CCWin.SkinControl.SkinButton skinButton5;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private CCWin.SkinControl.SkinTextBox skinTextNamespace;
        private CCWin.SkinControl.SkinCheckBox skinRemoveBoxUnderline;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox2;
        private CCWin.SkinControl.SkinCheckBox skinCheckBoxContext;
        private CCWin.SkinControl.SkinComboBox skinComboxDatabaseName;
        private CCWin.SkinControl.SkinTextBox skinTextBoxPort;
        private CCWin.SkinControl.SkinButton skinRepositoryButton;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox1;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox3;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox4;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox8;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox4;
        private CCWin.SkinControl.SkinButton skinButton3;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox6;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox7;
        private CCWin.SkinControl.SkinTextBox skinTextBox1;
        private CCWin.SkinControl.SkinTextBox skinTextBox2;
        private CCWin.SkinControl.SkinProgressBar skinProgressBar1;
        private CCWin.SkinControl.SkinButton skinButton4;
    }
}

