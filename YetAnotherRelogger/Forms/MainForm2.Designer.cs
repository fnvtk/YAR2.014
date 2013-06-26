namespace YetAnotherRelogger.Forms
{
    public partial class MainForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Auto position");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Ping Check");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Ip + Host Check");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Internet Check", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Relogger", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Profile Kickstart");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Anti Idle");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Hotkeys");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Stats");
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm2));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClone = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.restartAllDb = new System.Windows.Forms.Button();
            this.checkBoxForce = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.TotalGold = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CurrentCash = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CashPerHour = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GoldStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.MemoryUsage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CpuUsage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.CommConnections = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelStats = new System.Windows.Forms.Label();
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.logDirectoryTT = new System.Windows.Forms.ToolTip(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GoldStats)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemoryUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CpuUsage)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommConnections)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(685, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "机器人";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2MinSize = 75;
            this.splitContainer1.Size = new System.Drawing.Size(679, 385);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnClone);
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.restartAllDb);
            this.groupBox1.Controls.Add(this.checkBoxForce);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnStopAll);
            this.groupBox1.Controls.Add(this.btnStartAll);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "机器人";
            // 
            // btnClone
            // 
            this.btnClone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClone.Location = new System.Drawing.Point(508, 195);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(52, 21);
            this.btnClone.TabIndex = 7;
            this.btnClone.Text = "复制";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPause.Location = new System.Drawing.Point(227, 195);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(44, 21);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // restartAllDb
            // 
            this.restartAllDb.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.restartAllDb.Location = new System.Drawing.Point(277, 196);
            this.restartAllDb.Name = "restartAllDb";
            this.restartAllDb.Size = new System.Drawing.Size(83, 21);
            this.restartAllDb.TabIndex = 8;
            this.restartAllDb.Text = "重启所有DB";
            this.restartAllDb.UseVisualStyleBackColor = true;
            this.restartAllDb.Click += new System.EventHandler(this.restartAllDb_Click);
            // 
            // checkBoxForce
            // 
            this.checkBoxForce.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxForce.AutoSize = true;
            this.checkBoxForce.Location = new System.Drawing.Point(11, 197);
            this.checkBoxForce.Name = "checkBoxForce";
            this.checkBoxForce.Size = new System.Drawing.Size(54, 16);
            this.checkBoxForce.TabIndex = 5;
            this.checkBoxForce.Text = " 强制";
            this.checkBoxForce.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.Location = new System.Drawing.Point(566, 195);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(45, 21);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNew.Location = new System.Drawing.Point(617, 195);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(47, 21);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStopAll.Location = new System.Drawing.Point(146, 195);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(75, 21);
            this.btnStopAll.TabIndex = 2;
            this.btnStopAll.Text = "全部停止";
            this.btnStopAll.UseVisualStyleBackColor = true;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // btnStartAll
            // 
            this.btnStartAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStartAll.Location = new System.Drawing.Point(65, 195);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(75, 21);
            this.btnStartAll.TabIndex = 1;
            this.btnStartAll.Text = "全部开始";
            this.btnStartAll.UseVisualStyleBackColor = true;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(667, 175);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Location = new System.Drawing.Point(6, 14);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(667, 137);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SettingsPanel);
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(685, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Location = new System.Drawing.Point(185, 0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(501, 376);
            this.SettingsPanel.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 6);
            this.treeView1.Name = "treeView1";
            treeNode11.Name = "General";
            treeNode11.Text = "General";
            treeNode12.Name = "AutoPos";
            treeNode12.Text = "Auto position";
            treeNode13.Name = "PingCheck";
            treeNode13.Text = "Ping Check";
            treeNode14.Name = "IpHostCheck";
            treeNode14.Text = "Ip + Host Check";
            treeNode15.Name = "ConnectionCheck";
            treeNode15.Text = "Internet Check";
            treeNode16.Checked = true;
            treeNode16.Name = "Node0";
            treeNode16.Text = "Relogger";
            treeNode17.Name = "ProfileKickstart";
            treeNode17.Text = "Profile Kickstart";
            treeNode18.Name = "AntiIdle";
            treeNode18.Text = "Anti Idle";
            treeNode19.Name = "HotKeys";
            treeNode19.Text = "Hotkeys";
            treeNode20.Name = "Stats";
            treeNode20.Text = "Stats";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
            this.treeView1.Size = new System.Drawing.Size(173, 365);
            this.treeView1.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabControl2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(685, 388);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "状态";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(12, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(667, 365);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.TotalGold);
            this.tabPage7.Controls.Add(this.label4);
            this.tabPage7.Controls.Add(this.CurrentCash);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.CashPerHour);
            this.tabPage7.Controls.Add(this.label1);
            this.tabPage7.Controls.Add(this.GoldStats);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(659, 339);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Bots";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // TotalGold
            // 
            this.TotalGold.AutoSize = true;
            this.TotalGold.Location = new System.Drawing.Point(95, 145);
            this.TotalGold.Name = "TotalGold";
            this.TotalGold.Size = new System.Drawing.Size(11, 12);
            this.TotalGold.TabIndex = 11;
            this.TotalGold.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total Gold:";
            // 
            // CurrentCash
            // 
            this.CurrentCash.AutoSize = true;
            this.CurrentCash.Location = new System.Drawing.Point(95, 165);
            this.CurrentCash.Name = "CurrentCash";
            this.CurrentCash.Size = new System.Drawing.Size(29, 12);
            this.CurrentCash.TabIndex = 9;
            this.CurrentCash.Text = "0 元";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Gold as cash:";
            // 
            // CashPerHour
            // 
            this.CashPerHour.AutoSize = true;
            this.CashPerHour.Location = new System.Drawing.Point(95, 125);
            this.CashPerHour.Name = "CashPerHour";
            this.CashPerHour.Size = new System.Drawing.Size(29, 12);
            this.CashPerHour.TabIndex = 7;
            this.CashPerHour.Text = "0 元";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cash per hour:";
            // 
            // GoldStats
            // 
            chartArea5.Name = "ChartArea1";
            this.GoldStats.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.GoldStats.Legends.Add(legend5);
            this.GoldStats.Location = new System.Drawing.Point(6, 6);
            this.GoldStats.Name = "GoldStats";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.GoldStats.Series.Add(series5);
            this.GoldStats.Size = new System.Drawing.Size(643, 97);
            this.GoldStats.TabIndex = 5;
            this.GoldStats.Text = "GoldStats";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.MemoryUsage);
            this.tabPage5.Controls.Add(this.CpuUsage);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(659, 339);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "System";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // MemoryUsage
            // 
            this.MemoryUsage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea6.Name = "ChartArea1";
            this.MemoryUsage.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.MemoryUsage.Legends.Add(legend6);
            this.MemoryUsage.Location = new System.Drawing.Point(0, 165);
            this.MemoryUsage.MinimumSize = new System.Drawing.Size(650, 129);
            this.MemoryUsage.Name = "MemoryUsage";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.MemoryUsage.Series.Add(series6);
            this.MemoryUsage.Size = new System.Drawing.Size(650, 129);
            this.MemoryUsage.TabIndex = 2;
            this.MemoryUsage.Text = "chart1";
            // 
            // CpuUsage
            // 
            this.CpuUsage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea7.Name = "ChartArea1";
            this.CpuUsage.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.CpuUsage.Legends.Add(legend7);
            this.CpuUsage.Location = new System.Drawing.Point(3, 18);
            this.CpuUsage.MinimumSize = new System.Drawing.Size(650, 129);
            this.CpuUsage.Name = "CpuUsage";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.CpuUsage.Series.Add(series7);
            this.CpuUsage.Size = new System.Drawing.Size(650, 129);
            this.CpuUsage.TabIndex = 1;
            this.CpuUsage.Text = "chart1";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.CommConnections);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(659, 339);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Relogger";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // CommConnections
            // 
            chartArea8.Name = "ChartArea1";
            this.CommConnections.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.CommConnections.Legends.Add(legend8);
            this.CommConnections.Location = new System.Drawing.Point(6, 6);
            this.CommConnections.Name = "CommConnections";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.CommConnections.Series.Add(series8);
            this.CommConnections.Size = new System.Drawing.Size(643, 97);
            this.CommConnections.TabIndex = 4;
            this.CommConnections.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.pictureBox3);
            this.tabPage3.Controls.Add(this.linkLabel3);
            this.tabPage3.Controls.Add(this.linkLabel2);
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.pictureBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(685, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "购买与教程";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(558, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 150);
            this.button2.TabIndex = 21;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "快捷购买";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(557, 27);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(90, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Location = new System.Drawing.Point(175, 66);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(119, 12);
            this.linkLabel3.TabIndex = 18;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "【YAR自动登陆教程】";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(175, 37);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(65, 12);
            this.linkLabel2.TabIndex = 17;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "【DB下载】";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(239, 37);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(89, 12);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "【DB使用教程】";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(174, 213);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(66, 23);
            this.button8.TabIndex = 13;
            this.button8.Text = "DB年卡";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "月卡";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(28, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(621, 431);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 21);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.forceStartToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.toolStripSeparator1,
            this.statsToolStripMenuItem,
            this.toolStripSeparator2,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 170);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "开始";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // forceStartToolStripMenuItem
            // 
            this.forceStartToolStripMenuItem.Name = "forceStartToolStripMenuItem";
            this.forceStartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.forceStartToolStripMenuItem.Text = "强制开始";
            this.forceStartToolStripMenuItem.Click += new System.EventHandler(this.forceStartToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopToolStripMenuItem.Text = "停止";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cloneToolStripMenuItem.Text = "复制";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.CheckOnClick = true;
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.statsToolStripMenuItem.Text = "状态";
            this.statsToolStripMenuItem.Click += new System.EventHandler(this.statsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "编辑";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "删除";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Text = "Yet Another Relogger";
            this.TrayIcon.Visible = true;
            // 
            // labelStats
            // 
            this.labelStats.AutoSize = true;
            this.labelStats.Location = new System.Drawing.Point(25, 414);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(0, 12);
            this.labelStats.TabIndex = 2;
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenLog.Location = new System.Drawing.Point(527, 431);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(88, 21);
            this.btnOpenLog.TabIndex = 9;
            this.btnOpenLog.Text = "打开日志";
            this.logDirectoryTT.SetToolTip(this.btnOpenLog, "Shift-click to open log directory");
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button7.Location = new System.Drawing.Point(25, 431);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(99, 21);
            this.button7.TabIndex = 10;
            this.button7.Text = "重新摆放窗口";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 460);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.labelStats);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(730, 498);
            this.Name = "MainForm2";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yet Another Relogger";
            this.Load += new System.EventHandler(this.MainForm2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GoldStats)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MemoryUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CpuUsage)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CommConnections)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem forceStartToolStripMenuItem;
        private System.Windows.Forms.Panel SettingsPanel;
        public System.Windows.Forms.Label labelStats;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.DataVisualization.Charting.Chart MemoryUsage;
        public System.Windows.Forms.DataVisualization.Charting.Chart CpuUsage;
        private System.Windows.Forms.TabPage tabPage6;
        public System.Windows.Forms.DataVisualization.Charting.Chart CommConnections;
        private System.Windows.Forms.TabPage tabPage7;
        public System.Windows.Forms.DataVisualization.Charting.Chart GoldStats;
        public System.Windows.Forms.Label CashPerHour;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label CurrentCash;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label TotalGold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.Button btnOpenLog;
        private System.Windows.Forms.ToolTip logDirectoryTT;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button restartAllDb;
        private System.Windows.Forms.CheckBox checkBoxForce;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.Button btnStartAll;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}