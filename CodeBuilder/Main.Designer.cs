
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
            this.skinComboBoxDatabase = new CCWin.SkinControl.SkinComboBox();
            this.skinDataConfigBtn = new CCWin.SkinControl.SkinButton();
            this.skinBtnBuilder = new CCWin.SkinControl.SkinButton();
            this.skinBtnConnect = new CCWin.SkinControl.SkinButton();
            this.skinTextBoxPassword = new CCWin.SkinControl.SkinTextBox();
            this.skinTextBoxAccount = new CCWin.SkinControl.SkinTextBox();
            this.skinTextBoxAddress = new CCWin.SkinControl.SkinTextBox();
            this.skinGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinGroupBox1.Controls.Add(this.skinComboBoxDatabase);
            this.skinGroupBox1.Controls.Add(this.skinDataConfigBtn);
            this.skinGroupBox1.Controls.Add(this.skinBtnBuilder);
            this.skinGroupBox1.Controls.Add(this.skinBtnConnect);
            this.skinGroupBox1.Controls.Add(this.skinTextBoxPassword);
            this.skinGroupBox1.Controls.Add(this.skinTextBoxAccount);
            this.skinGroupBox1.Controls.Add(this.skinTextBoxAddress);
            this.skinGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox1.Location = new System.Drawing.Point(8, 39);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(1067, 76);
            this.skinGroupBox1.TabIndex = 0;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "数据库实体生成";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinComboBoxDatabase
            // 
            this.skinComboBoxDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxDatabase.FormattingEnabled = true;
            this.skinComboBoxDatabase.Location = new System.Drawing.Point(701, 33);
            this.skinComboBoxDatabase.Name = "skinComboBoxDatabase";
            this.skinComboBoxDatabase.Size = new System.Drawing.Size(133, 27);
            this.skinComboBoxDatabase.TabIndex = 2;
            this.skinComboBoxDatabase.WaterText = "";
            // 
            // skinDataConfigBtn
            // 
            this.skinDataConfigBtn.BackColor = System.Drawing.Color.Transparent;
            this.skinDataConfigBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinDataConfigBtn.DownBack = null;
            this.skinDataConfigBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinDataConfigBtn.InheritColor = true;
            this.skinDataConfigBtn.Location = new System.Drawing.Point(969, 32);
            this.skinDataConfigBtn.MouseBack = null;
            this.skinDataConfigBtn.Name = "skinDataConfigBtn";
            this.skinDataConfigBtn.NormlBack = null;
            this.skinDataConfigBtn.Size = new System.Drawing.Size(92, 28);
            this.skinDataConfigBtn.TabIndex = 1;
            this.skinDataConfigBtn.Text = "配置生成规则";
            this.skinDataConfigBtn.UseVisualStyleBackColor = false;
            this.skinDataConfigBtn.Click += new System.EventHandler(this.skinDataConfigBtn_Click);
            // 
            // skinBtnBuilder
            // 
            this.skinBtnBuilder.BackColor = System.Drawing.Color.Transparent;
            this.skinBtnBuilder.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinBtnBuilder.DownBack = null;
            this.skinBtnBuilder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinBtnBuilder.InheritColor = true;
            this.skinBtnBuilder.Location = new System.Drawing.Point(857, 32);
            this.skinBtnBuilder.MouseBack = null;
            this.skinBtnBuilder.Name = "skinBtnBuilder";
            this.skinBtnBuilder.NormlBack = null;
            this.skinBtnBuilder.Size = new System.Drawing.Size(92, 28);
            this.skinBtnBuilder.TabIndex = 1;
            this.skinBtnBuilder.Text = "生成实体";
            this.skinBtnBuilder.UseVisualStyleBackColor = false;
            this.skinBtnBuilder.Click += new System.EventHandler(this.skinBtnBuilder_Click);
            // 
            // skinBtnConnect
            // 
            this.skinBtnConnect.BackColor = System.Drawing.Color.Transparent;
            this.skinBtnConnect.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinBtnConnect.DownBack = null;
            this.skinBtnConnect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinBtnConnect.InheritColor = true;
            this.skinBtnConnect.Location = new System.Drawing.Point(596, 32);
            this.skinBtnConnect.MouseBack = null;
            this.skinBtnConnect.Name = "skinBtnConnect";
            this.skinBtnConnect.NormlBack = null;
            this.skinBtnConnect.Size = new System.Drawing.Size(77, 28);
            this.skinBtnConnect.TabIndex = 1;
            this.skinBtnConnect.Text = "连 接";
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
            this.skinTextBoxAccount.Lines = new string[] {
        "sa"};
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
            this.skinTextBoxAccount.SkinTxt.Text = "sa";
            this.skinTextBoxAccount.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxAccount.SkinTxt.WaterText = "数据库账号";
            this.skinTextBoxAccount.TabIndex = 1;
            this.skinTextBoxAccount.Text = "sa";
            this.skinTextBoxAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxAccount.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxAccount.WaterText = "数据库账号";
            this.skinTextBoxAccount.WordWrap = true;
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
        "127.0.0.1:80"};
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
            this.skinTextBoxAddress.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.skinTextBoxAddress.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxAddress.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxAddress.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxAddress.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxAddress.SkinTxt.Name = "BaseText";
            this.skinTextBoxAddress.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.skinTextBoxAddress.SkinTxt.TabIndex = 0;
            this.skinTextBoxAddress.SkinTxt.Text = "127.0.0.1:80";
            this.skinTextBoxAddress.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxAddress.SkinTxt.WaterText = "请输入数据库地址";
            this.skinTextBoxAddress.TabIndex = 0;
            this.skinTextBoxAddress.Text = "127.0.0.1:80";
            this.skinTextBoxAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxAddress.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxAddress.WaterText = "请输入数据库地址";
            this.skinTextBoxAddress.WordWrap = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 450);
            this.Controls.Add(this.skinGroupBox1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowDrawIcon = false;
            this.Text = "代码构造器";
            this.TitleCenter = true;
            this.skinGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinTextBox skinTextBoxAddress;
        private CCWin.SkinControl.SkinButton skinBtnConnect;
        private CCWin.SkinControl.SkinComboBox skinComboBoxDatabase;
        private CCWin.SkinControl.SkinButton skinBtnBuilder;
        private CCWin.SkinControl.SkinButton skinDataConfigBtn;
        private CCWin.SkinControl.SkinTextBox skinTextBoxAccount;
        private CCWin.SkinControl.SkinTextBox skinTextBoxPassword;
    }
}

