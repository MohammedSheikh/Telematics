namespace CTEC3426_2015
{
    partial class CTEC3426
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portNameComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.baudrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRateTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.dataBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBitsTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.stopBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBitsComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.parityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parityComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.terminalTab = new System.Windows.Forms.TabPage();
            this.terminal = new System.Windows.Forms.RichTextBox();
            this.canvas = new System.Windows.Forms.TabPage();
            this.txtSetTemp = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCAN = new System.Windows.Forms.GroupBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.lblMaskStatus = new System.Windows.Forms.Label();
            this.lblIncomingStatus = new System.Windows.Forms.Label();
            this.lblBroadCastID = new System.Windows.Forms.Label();
            this.lblIncomingID = new System.Windows.Forms.Label();
            this.btnIncoming = new System.Windows.Forms.Button();
            this.txtIncoming = new System.Windows.Forms.TextBox();
            this.lblOutgoingID = new System.Windows.Forms.Label();
            this.btnOutgoing = new System.Windows.Forms.Button();
            this.txtOutgoing = new System.Windows.Forms.TextBox();
            this.lblMask = new System.Windows.Forms.Label();
            this.btnSetMask = new System.Windows.Forms.Button();
            this.txtMask = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnSetFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.gbSMS = new System.Windows.Forms.GroupBox();
            this.lblSMSMessage = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSMS = new System.Windows.Forms.TextBox();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnLED4OnOff = new System.Windows.Forms.Button();
            this.btnLED3OnOff = new System.Windows.Forms.Button();
            this.btnLED2OnOff = new System.Windows.Forms.Button();
            this.btnSwitch2OnOff = new System.Windows.Forms.Button();
            this.btnLED1OnOff = new System.Windows.Forms.Button();
            this.btnSwitch4OnOff = new System.Windows.Forms.Button();
            this.btnSwitch3OnOff = new System.Windows.Forms.Button();
            this.btnSwitch1OnOff = new System.Windows.Forms.Button();
            this.btnMotorFwdRev = new System.Windows.Forms.Button();
            this.btnMotorOnOff = new System.Windows.Forms.Button();
            this.btnHeater = new System.Windows.Forms.Button();
            this.gbKeypad = new System.Windows.Forms.GroupBox();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btnHash = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btnAsterisk = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lblDegrees = new System.Windows.Forms.Label();
            this.btnGetTemp = new System.Windows.Forms.Button();
            this.lblMDirection = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblSwitch4OnOff = new System.Windows.Forms.Label();
            this.lblSwitch3OnOff = new System.Windows.Forms.Label();
            this.lblSwitch2OnOff = new System.Windows.Forms.Label();
            this.lblSwitch1 = new System.Windows.Forms.Label();
            this.lblSwitch1OnOff = new System.Windows.Forms.Label();
            this.lblSwitch2 = new System.Windows.Forms.Label();
            this.lblSwitch4 = new System.Windows.Forms.Label();
            this.lblSwitch3 = new System.Windows.Forms.Label();
            this.lblLED4OnOff = new System.Windows.Forms.Label();
            this.lblLED3OnOff = new System.Windows.Forms.Label();
            this.lblLED2OnOff = new System.Windows.Forms.Label();
            this.lblLED1OnOff = new System.Windows.Forms.Label();
            this.lblLED4 = new System.Windows.Forms.Label();
            this.lblLED3 = new System.Windows.Forms.Label();
            this.lblLED2 = new System.Windows.Forms.Label();
            this.lblLED1 = new System.Windows.Forms.Label();
            this.lblMStatus = new System.Windows.Forms.Label();
            this.lblMotorStatus = new System.Windows.Forms.Label();
            this.lblHStatus = new System.Windows.Forms.Label();
            this.lblHeaterStatus = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.formTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSetTemp = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.terminalTab.SuspendLayout();
            this.canvas.SuspendLayout();
            this.gbCAN.SuspendLayout();
            this.gbSMS.SuspendLayout();
            this.gbControls.SuspendLayout();
            this.gbKeypad.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1135, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portNameToolStripMenuItem,
            this.baudrateToolStripMenuItem,
            this.dataBitsToolStripMenuItem,
            this.stopBitsToolStripMenuItem,
            this.parityToolStripMenuItem,
            this.toolStripSeparator1,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // portNameToolStripMenuItem
            // 
            this.portNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portNameComboBox});
            this.portNameToolStripMenuItem.Name = "portNameToolStripMenuItem";
            this.portNameToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.portNameToolStripMenuItem.Text = "Port name";
            // 
            // portNameComboBox
            // 
            this.portNameComboBox.Name = "portNameComboBox";
            this.portNameComboBox.Size = new System.Drawing.Size(121, 23);
            this.portNameComboBox.ToolTipText = "Select a value";
            this.portNameComboBox.TextChanged += new System.EventHandler(this.portNameComboBox_TextChanged);
            // 
            // baudrateToolStripMenuItem
            // 
            this.baudrateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baudRateTextBox});
            this.baudrateToolStripMenuItem.Name = "baudrateToolStripMenuItem";
            this.baudrateToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.baudrateToolStripMenuItem.Text = "Baudrate";
            // 
            // baudRateTextBox
            // 
            this.baudRateTextBox.Name = "baudRateTextBox";
            this.baudRateTextBox.Size = new System.Drawing.Size(100, 23);
            this.baudRateTextBox.ToolTipText = "Write a value";
            this.baudRateTextBox.TextChanged += new System.EventHandler(this.baudRateTextBox_TextChanged);
            // 
            // dataBitsToolStripMenuItem
            // 
            this.dataBitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataBitsTextBox});
            this.dataBitsToolStripMenuItem.Name = "dataBitsToolStripMenuItem";
            this.dataBitsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.dataBitsToolStripMenuItem.Text = "Data bits";
            // 
            // dataBitsTextBox
            // 
            this.dataBitsTextBox.Name = "dataBitsTextBox";
            this.dataBitsTextBox.Size = new System.Drawing.Size(100, 23);
            this.dataBitsTextBox.ToolTipText = "Write a value";
            this.dataBitsTextBox.TextChanged += new System.EventHandler(this.dataBitsTextBox_TextChanged);
            // 
            // stopBitsToolStripMenuItem
            // 
            this.stopBitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopBitsComboBox});
            this.stopBitsToolStripMenuItem.Name = "stopBitsToolStripMenuItem";
            this.stopBitsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.stopBitsToolStripMenuItem.Text = "Stop Bits";
            this.stopBitsToolStripMenuItem.TextChanged += new System.EventHandler(this.stopBitsToolStripMenuItem_TextChanged);
            // 
            // stopBitsComboBox
            // 
            this.stopBitsComboBox.Name = "stopBitsComboBox";
            this.stopBitsComboBox.Size = new System.Drawing.Size(121, 23);
            this.stopBitsComboBox.ToolTipText = "Select a value";
            // 
            // parityToolStripMenuItem
            // 
            this.parityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parityComboBox});
            this.parityToolStripMenuItem.Name = "parityToolStripMenuItem";
            this.parityToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.parityToolStripMenuItem.Text = "Parity";
            this.parityToolStripMenuItem.TextChanged += new System.EventHandler(this.parityToolStripMenuItem_TextChanged);
            // 
            // parityComboBox
            // 
            this.parityComboBox.Name = "parityComboBox";
            this.parityComboBox.Size = new System.Drawing.Size(121, 23);
            this.parityComboBox.ToolTipText = "Select a value";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.terminalTab);
            this.tabControl.Controls.Add(this.canvas);
            this.tabControl.Location = new System.Drawing.Point(13, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1110, 661);
            this.tabControl.TabIndex = 1;
            // 
            // terminalTab
            // 
            this.terminalTab.Controls.Add(this.terminal);
            this.terminalTab.Location = new System.Drawing.Point(4, 22);
            this.terminalTab.Name = "terminalTab";
            this.terminalTab.Padding = new System.Windows.Forms.Padding(3);
            this.terminalTab.Size = new System.Drawing.Size(1102, 635);
            this.terminalTab.TabIndex = 0;
            this.terminalTab.Text = "Terminal";
            this.terminalTab.UseVisualStyleBackColor = true;
            // 
            // terminal
            // 
            this.terminal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.terminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminal.Font = new System.Drawing.Font("Consolas", 8F);
            this.terminal.ForeColor = System.Drawing.Color.LightBlue;
            this.terminal.HideSelection = false;
            this.terminal.Location = new System.Drawing.Point(3, 3);
            this.terminal.Name = "terminal";
            this.terminal.Size = new System.Drawing.Size(1096, 629);
            this.terminal.TabIndex = 0;
            this.terminal.Text = "";
            this.terminal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.terminal_KeyPress);
            // 
            // canvas
            // 
            this.canvas.Controls.Add(this.btnSetTemp);
            this.canvas.Controls.Add(this.txtSetTemp);
            this.canvas.Controls.Add(this.btnReset);
            this.canvas.Controls.Add(this.label2);
            this.canvas.Controls.Add(this.gbCAN);
            this.canvas.Controls.Add(this.gbSMS);
            this.canvas.Controls.Add(this.gbControls);
            this.canvas.Controls.Add(this.gbKeypad);
            this.canvas.Controls.Add(this.gbStatus);
            this.canvas.Location = new System.Drawing.Point(4, 22);
            this.canvas.Name = "canvas";
            this.canvas.Padding = new System.Windows.Forms.Padding(3);
            this.canvas.Size = new System.Drawing.Size(1102, 635);
            this.canvas.TabIndex = 1;
            this.canvas.Text = "Controls";
            this.canvas.UseVisualStyleBackColor = true;
            // 
            // txtSetTemp
            // 
            this.txtSetTemp.Location = new System.Drawing.Point(449, 47);
            this.txtSetTemp.Name = "txtSetTemp";
            this.txtSetTemp.Size = new System.Drawing.Size(100, 20);
            this.txtSetTemp.TabIndex = 7;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReset.Location = new System.Drawing.Point(270, 36);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(173, 42);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "RESET CAN Board:";
            // 
            // gbCAN
            // 
            this.gbCAN.Controls.Add(this.lblFilterStatus);
            this.gbCAN.Controls.Add(this.lblMaskStatus);
            this.gbCAN.Controls.Add(this.lblIncomingStatus);
            this.gbCAN.Controls.Add(this.lblBroadCastID);
            this.gbCAN.Controls.Add(this.lblIncomingID);
            this.gbCAN.Controls.Add(this.btnIncoming);
            this.gbCAN.Controls.Add(this.txtIncoming);
            this.gbCAN.Controls.Add(this.lblOutgoingID);
            this.gbCAN.Controls.Add(this.btnOutgoing);
            this.gbCAN.Controls.Add(this.txtOutgoing);
            this.gbCAN.Controls.Add(this.lblMask);
            this.gbCAN.Controls.Add(this.btnSetMask);
            this.gbCAN.Controls.Add(this.txtMask);
            this.gbCAN.Controls.Add(this.lblFilter);
            this.gbCAN.Controls.Add(this.btnSetFilter);
            this.gbCAN.Controls.Add(this.txtFilter);
            this.gbCAN.Location = new System.Drawing.Point(812, 16);
            this.gbCAN.Name = "gbCAN";
            this.gbCAN.Size = new System.Drawing.Size(284, 609);
            this.gbCAN.TabIndex = 4;
            this.gbCAN.TabStop = false;
            this.gbCAN.Text = "CAN Controls";
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterStatus.Location = new System.Drawing.Point(175, 32);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(0, 17);
            this.lblFilterStatus.TabIndex = 18;
            // 
            // lblMaskStatus
            // 
            this.lblMaskStatus.AutoSize = true;
            this.lblMaskStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaskStatus.Location = new System.Drawing.Point(175, 182);
            this.lblMaskStatus.Name = "lblMaskStatus";
            this.lblMaskStatus.Size = new System.Drawing.Size(0, 17);
            this.lblMaskStatus.TabIndex = 17;
            // 
            // lblIncomingStatus
            // 
            this.lblIncomingStatus.AutoSize = true;
            this.lblIncomingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomingStatus.Location = new System.Drawing.Point(175, 494);
            this.lblIncomingStatus.Name = "lblIncomingStatus";
            this.lblIncomingStatus.Size = new System.Drawing.Size(0, 17);
            this.lblIncomingStatus.TabIndex = 16;
            // 
            // lblBroadCastID
            // 
            this.lblBroadCastID.AutoSize = true;
            this.lblBroadCastID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBroadCastID.Location = new System.Drawing.Point(175, 336);
            this.lblBroadCastID.Name = "lblBroadCastID";
            this.lblBroadCastID.Size = new System.Drawing.Size(0, 17);
            this.lblBroadCastID.TabIndex = 15;
            // 
            // lblIncomingID
            // 
            this.lblIncomingID.AutoSize = true;
            this.lblIncomingID.Location = new System.Drawing.Point(3, 493);
            this.lblIncomingID.Name = "lblIncomingID";
            this.lblIncomingID.Size = new System.Drawing.Size(86, 13);
            this.lblIncomingID.TabIndex = 14;
            this.lblIncomingID.Text = "Set Incoming ID:";
            // 
            // btnIncoming
            // 
            this.btnIncoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncoming.Location = new System.Drawing.Point(6, 570);
            this.btnIncoming.Name = "btnIncoming";
            this.btnIncoming.Size = new System.Drawing.Size(262, 33);
            this.btnIncoming.TabIndex = 13;
            this.btnIncoming.Text = "Set Incoming ID";
            this.btnIncoming.UseVisualStyleBackColor = true;
            this.btnIncoming.Click += new System.EventHandler(this.btnIncoming_Click);
            // 
            // txtIncoming
            // 
            this.txtIncoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncoming.Location = new System.Drawing.Point(6, 509);
            this.txtIncoming.Multiline = true;
            this.txtIncoming.Name = "txtIncoming";
            this.txtIncoming.Size = new System.Drawing.Size(262, 33);
            this.txtIncoming.TabIndex = 12;
            this.txtIncoming.TextChanged += new System.EventHandler(this.txtIncoming_TextChanged);
            // 
            // lblOutgoingID
            // 
            this.lblOutgoingID.AutoSize = true;
            this.lblOutgoingID.Location = new System.Drawing.Point(3, 336);
            this.lblOutgoingID.Name = "lblOutgoingID";
            this.lblOutgoingID.Size = new System.Drawing.Size(86, 13);
            this.lblOutgoingID.TabIndex = 11;
            this.lblOutgoingID.Text = "Set Outgoing ID:";
            // 
            // btnOutgoing
            // 
            this.btnOutgoing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutgoing.Location = new System.Drawing.Point(6, 413);
            this.btnOutgoing.Name = "btnOutgoing";
            this.btnOutgoing.Size = new System.Drawing.Size(262, 33);
            this.btnOutgoing.TabIndex = 10;
            this.btnOutgoing.Text = "Set Outgoing ID";
            this.btnOutgoing.UseVisualStyleBackColor = true;
            this.btnOutgoing.Click += new System.EventHandler(this.btnOutgoing_Click);
            // 
            // txtOutgoing
            // 
            this.txtOutgoing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutgoing.Location = new System.Drawing.Point(6, 352);
            this.txtOutgoing.Multiline = true;
            this.txtOutgoing.Name = "txtOutgoing";
            this.txtOutgoing.Size = new System.Drawing.Size(262, 33);
            this.txtOutgoing.TabIndex = 9;
            this.txtOutgoing.TextChanged += new System.EventHandler(this.txtOutgoing_TextChanged);
            // 
            // lblMask
            // 
            this.lblMask.AutoSize = true;
            this.lblMask.Location = new System.Drawing.Point(3, 181);
            this.lblMask.Name = "lblMask";
            this.lblMask.Size = new System.Drawing.Size(102, 13);
            this.lblMask.TabIndex = 8;
            this.lblMask.Text = "Set CANBUS Mask:";
            // 
            // btnSetMask
            // 
            this.btnSetMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetMask.Location = new System.Drawing.Point(6, 258);
            this.btnSetMask.Name = "btnSetMask";
            this.btnSetMask.Size = new System.Drawing.Size(262, 33);
            this.btnSetMask.TabIndex = 7;
            this.btnSetMask.Text = "Set Mask";
            this.btnSetMask.UseVisualStyleBackColor = true;
            this.btnSetMask.Click += new System.EventHandler(this.btnSetMask_Click);
            // 
            // txtMask
            // 
            this.txtMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMask.Location = new System.Drawing.Point(6, 197);
            this.txtMask.Multiline = true;
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(262, 33);
            this.txtMask.TabIndex = 6;
            this.txtMask.TextChanged += new System.EventHandler(this.txtMask_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(3, 31);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(98, 13);
            this.lblFilter.TabIndex = 5;
            this.lblFilter.Text = "Set CANBUS Filter:";
            // 
            // btnSetFilter
            // 
            this.btnSetFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetFilter.Location = new System.Drawing.Point(6, 108);
            this.btnSetFilter.Name = "btnSetFilter";
            this.btnSetFilter.Size = new System.Drawing.Size(262, 33);
            this.btnSetFilter.TabIndex = 4;
            this.btnSetFilter.Text = "Set Filter";
            this.btnSetFilter.UseVisualStyleBackColor = true;
            this.btnSetFilter.Click += new System.EventHandler(this.btnSetFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(6, 47);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(262, 33);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // gbSMS
            // 
            this.gbSMS.Controls.Add(this.lblSMSMessage);
            this.gbSMS.Controls.Add(this.lblMobile);
            this.gbSMS.Controls.Add(this.btnSend);
            this.gbSMS.Controls.Add(this.txtSMS);
            this.gbSMS.Location = new System.Drawing.Point(268, 406);
            this.gbSMS.Name = "gbSMS";
            this.gbSMS.Size = new System.Drawing.Size(308, 219);
            this.gbSMS.TabIndex = 3;
            this.gbSMS.TabStop = false;
            this.gbSMS.Text = "SMS Controls";
            // 
            // lblSMSMessage
            // 
            this.lblSMSMessage.AutoSize = true;
            this.lblSMSMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSMessage.Location = new System.Drawing.Point(16, 106);
            this.lblSMSMessage.Name = "lblSMSMessage";
            this.lblSMSMessage.Size = new System.Drawing.Size(0, 20);
            this.lblSMSMessage.TabIndex = 3;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(13, 46);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(109, 13);
            this.lblMobile.TabIndex = 2;
            this.lblMobile.Text = "Enter Mobile Number:";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(16, 136);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(262, 33);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send SMS";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSMS
            // 
            this.txtSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSMS.Location = new System.Drawing.Point(16, 62);
            this.txtSMS.Multiline = true;
            this.txtSMS.Name = "txtSMS";
            this.txtSMS.Size = new System.Drawing.Size(262, 33);
            this.txtSMS.TabIndex = 0;
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.btnLED4OnOff);
            this.gbControls.Controls.Add(this.btnLED3OnOff);
            this.gbControls.Controls.Add(this.btnLED2OnOff);
            this.gbControls.Controls.Add(this.btnSwitch2OnOff);
            this.gbControls.Controls.Add(this.btnLED1OnOff);
            this.gbControls.Controls.Add(this.btnSwitch4OnOff);
            this.gbControls.Controls.Add(this.btnSwitch3OnOff);
            this.gbControls.Controls.Add(this.btnSwitch1OnOff);
            this.gbControls.Controls.Add(this.btnMotorFwdRev);
            this.gbControls.Controls.Add(this.btnMotorOnOff);
            this.gbControls.Controls.Add(this.btnHeater);
            this.gbControls.Location = new System.Drawing.Point(585, 8);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(212, 621);
            this.gbControls.TabIndex = 2;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Board Controls";
            // 
            // btnLED4OnOff
            // 
            this.btnLED4OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLED4OnOff.Location = new System.Drawing.Point(6, 582);
            this.btnLED4OnOff.Name = "btnLED4OnOff";
            this.btnLED4OnOff.Size = new System.Drawing.Size(199, 35);
            this.btnLED4OnOff.TabIndex = 10;
            this.btnLED4OnOff.Text = "LED4 (On/Off)";
            this.btnLED4OnOff.UseVisualStyleBackColor = true;
            this.btnLED4OnOff.Click += new System.EventHandler(this.btnLED4OnOff_Click);
            // 
            // btnLED3OnOff
            // 
            this.btnLED3OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLED3OnOff.Location = new System.Drawing.Point(7, 538);
            this.btnLED3OnOff.Name = "btnLED3OnOff";
            this.btnLED3OnOff.Size = new System.Drawing.Size(199, 35);
            this.btnLED3OnOff.TabIndex = 9;
            this.btnLED3OnOff.Text = "LED3 (On/Off)";
            this.btnLED3OnOff.UseVisualStyleBackColor = true;
            this.btnLED3OnOff.Click += new System.EventHandler(this.btnLED3OnOff_Click);
            // 
            // btnLED2OnOff
            // 
            this.btnLED2OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLED2OnOff.Location = new System.Drawing.Point(7, 495);
            this.btnLED2OnOff.Name = "btnLED2OnOff";
            this.btnLED2OnOff.Size = new System.Drawing.Size(199, 35);
            this.btnLED2OnOff.TabIndex = 8;
            this.btnLED2OnOff.Text = "LED2 (On/Off)";
            this.btnLED2OnOff.UseVisualStyleBackColor = true;
            this.btnLED2OnOff.Click += new System.EventHandler(this.btnLED2OnOff_Click);
            // 
            // btnSwitch2OnOff
            // 
            this.btnSwitch2OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch2OnOff.Location = new System.Drawing.Point(7, 284);
            this.btnSwitch2OnOff.Name = "btnSwitch2OnOff";
            this.btnSwitch2OnOff.Size = new System.Drawing.Size(199, 35);
            this.btnSwitch2OnOff.TabIndex = 7;
            this.btnSwitch2OnOff.Text = "Switch 2 (On/Off)";
            this.btnSwitch2OnOff.UseVisualStyleBackColor = true;
            this.btnSwitch2OnOff.Click += new System.EventHandler(this.btnSwitch2OnOff_Click);
            // 
            // btnLED1OnOff
            // 
            this.btnLED1OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLED1OnOff.Location = new System.Drawing.Point(6, 447);
            this.btnLED1OnOff.Name = "btnLED1OnOff";
            this.btnLED1OnOff.Size = new System.Drawing.Size(199, 35);
            this.btnLED1OnOff.TabIndex = 6;
            this.btnLED1OnOff.Text = "LED1 (On/Off)";
            this.btnLED1OnOff.UseVisualStyleBackColor = true;
            this.btnLED1OnOff.Click += new System.EventHandler(this.btnLED1OnOff_Click);
            // 
            // btnSwitch4OnOff
            // 
            this.btnSwitch4OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch4OnOff.Location = new System.Drawing.Point(6, 372);
            this.btnSwitch4OnOff.Name = "btnSwitch4OnOff";
            this.btnSwitch4OnOff.Size = new System.Drawing.Size(199, 35);
            this.btnSwitch4OnOff.TabIndex = 5;
            this.btnSwitch4OnOff.Text = "Switch 4 (On/Off)";
            this.btnSwitch4OnOff.UseVisualStyleBackColor = true;
            this.btnSwitch4OnOff.Click += new System.EventHandler(this.btnSwitch4OnOff_Click);
            // 
            // btnSwitch3OnOff
            // 
            this.btnSwitch3OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch3OnOff.Location = new System.Drawing.Point(6, 327);
            this.btnSwitch3OnOff.Name = "btnSwitch3OnOff";
            this.btnSwitch3OnOff.Size = new System.Drawing.Size(199, 35);
            this.btnSwitch3OnOff.TabIndex = 4;
            this.btnSwitch3OnOff.Text = "Switch 3 (On/Off)";
            this.btnSwitch3OnOff.UseVisualStyleBackColor = true;
            this.btnSwitch3OnOff.Click += new System.EventHandler(this.btnSwitch3OnOff_Click);
            // 
            // btnSwitch1OnOff
            // 
            this.btnSwitch1OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch1OnOff.Location = new System.Drawing.Point(6, 241);
            this.btnSwitch1OnOff.Name = "btnSwitch1OnOff";
            this.btnSwitch1OnOff.Size = new System.Drawing.Size(199, 35);
            this.btnSwitch1OnOff.TabIndex = 3;
            this.btnSwitch1OnOff.Text = "Switch 1 (On/Off)";
            this.btnSwitch1OnOff.UseVisualStyleBackColor = true;
            this.btnSwitch1OnOff.Click += new System.EventHandler(this.btnSwitch1OnOff_Click);
            // 
            // btnMotorFwdRev
            // 
            this.btnMotorFwdRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMotorFwdRev.Location = new System.Drawing.Point(6, 157);
            this.btnMotorFwdRev.Name = "btnMotorFwdRev";
            this.btnMotorFwdRev.Size = new System.Drawing.Size(199, 35);
            this.btnMotorFwdRev.TabIndex = 2;
            this.btnMotorFwdRev.Text = "Motor (Fwd/Rev)";
            this.btnMotorFwdRev.UseVisualStyleBackColor = true;
            this.btnMotorFwdRev.Click += new System.EventHandler(this.btnMotorFwdRev_Click);
            // 
            // btnMotorOnOff
            // 
            this.btnMotorOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMotorOnOff.Location = new System.Drawing.Point(6, 116);
            this.btnMotorOnOff.Name = "btnMotorOnOff";
            this.btnMotorOnOff.Size = new System.Drawing.Size(199, 35);
            this.btnMotorOnOff.TabIndex = 1;
            this.btnMotorOnOff.Text = "Motor (On/Off)";
            this.btnMotorOnOff.UseVisualStyleBackColor = true;
            this.btnMotorOnOff.Click += new System.EventHandler(this.btnMotorOnOff_Click);
            // 
            // btnHeater
            // 
            this.btnHeater.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeater.Location = new System.Drawing.Point(7, 35);
            this.btnHeater.Name = "btnHeater";
            this.btnHeater.Size = new System.Drawing.Size(199, 35);
            this.btnHeater.TabIndex = 0;
            this.btnHeater.Text = "Heater (On/Off)";
            this.btnHeater.UseVisualStyleBackColor = true;
            this.btnHeater.Click += new System.EventHandler(this.btnHeater_Click);
            // 
            // gbKeypad
            // 
            this.gbKeypad.Controls.Add(this.btn7);
            this.gbKeypad.Controls.Add(this.btn8);
            this.gbKeypad.Controls.Add(this.btnHash);
            this.gbKeypad.Controls.Add(this.btn9);
            this.gbKeypad.Controls.Add(this.btn0);
            this.gbKeypad.Controls.Add(this.btn6);
            this.gbKeypad.Controls.Add(this.btnAsterisk);
            this.gbKeypad.Controls.Add(this.btn5);
            this.gbKeypad.Controls.Add(this.btn4);
            this.gbKeypad.Controls.Add(this.btn3);
            this.gbKeypad.Controls.Add(this.btn2);
            this.gbKeypad.Controls.Add(this.btn1);
            this.gbKeypad.Location = new System.Drawing.Point(267, 84);
            this.gbKeypad.Name = "gbKeypad";
            this.gbKeypad.Size = new System.Drawing.Size(308, 316);
            this.gbKeypad.TabIndex = 1;
            this.gbKeypad.TabStop = false;
            this.gbKeypad.Text = "Keypad";
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(16, 172);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(61, 57);
            this.btn7.TabIndex = 13;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(115, 172);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(61, 57);
            this.btn8.TabIndex = 12;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            // 
            // btnHash
            // 
            this.btnHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHash.Location = new System.Drawing.Point(217, 248);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(61, 57);
            this.btnHash.TabIndex = 9;
            this.btnHash.Text = "#";
            this.btnHash.UseVisualStyleBackColor = true;
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(217, 172);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(61, 57);
            this.btn9.TabIndex = 8;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(115, 248);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(61, 57);
            this.btn0.TabIndex = 10;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(217, 98);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(61, 57);
            this.btn6.TabIndex = 7;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            // 
            // btnAsterisk
            // 
            this.btnAsterisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 47.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsterisk.Location = new System.Drawing.Point(16, 248);
            this.btnAsterisk.Name = "btnAsterisk";
            this.btnAsterisk.Size = new System.Drawing.Size(61, 57);
            this.btnAsterisk.TabIndex = 11;
            this.btnAsterisk.Text = "*";
            this.btnAsterisk.UseVisualStyleBackColor = true;
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(115, 98);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(61, 57);
            this.btn5.TabIndex = 6;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(16, 98);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(61, 57);
            this.btn4.TabIndex = 5;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(217, 25);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(61, 57);
            this.btn3.TabIndex = 4;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(115, 25);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(61, 57);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(16, 25);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(61, 57);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.lblDegrees);
            this.gbStatus.Controls.Add(this.btnGetTemp);
            this.gbStatus.Controls.Add(this.lblMDirection);
            this.gbStatus.Controls.Add(this.lblDirection);
            this.gbStatus.Controls.Add(this.lblSwitch4OnOff);
            this.gbStatus.Controls.Add(this.lblSwitch3OnOff);
            this.gbStatus.Controls.Add(this.lblSwitch2OnOff);
            this.gbStatus.Controls.Add(this.lblSwitch1);
            this.gbStatus.Controls.Add(this.lblSwitch1OnOff);
            this.gbStatus.Controls.Add(this.lblSwitch2);
            this.gbStatus.Controls.Add(this.lblSwitch4);
            this.gbStatus.Controls.Add(this.lblSwitch3);
            this.gbStatus.Controls.Add(this.lblLED4OnOff);
            this.gbStatus.Controls.Add(this.lblLED3OnOff);
            this.gbStatus.Controls.Add(this.lblLED2OnOff);
            this.gbStatus.Controls.Add(this.lblLED1OnOff);
            this.gbStatus.Controls.Add(this.lblLED4);
            this.gbStatus.Controls.Add(this.lblLED3);
            this.gbStatus.Controls.Add(this.lblLED2);
            this.gbStatus.Controls.Add(this.lblLED1);
            this.gbStatus.Controls.Add(this.lblMStatus);
            this.gbStatus.Controls.Add(this.lblMotorStatus);
            this.gbStatus.Controls.Add(this.lblHStatus);
            this.gbStatus.Controls.Add(this.lblHeaterStatus);
            this.gbStatus.Controls.Add(this.lblTemp);
            this.gbStatus.Controls.Add(this.lblTemperature);
            this.gbStatus.Location = new System.Drawing.Point(6, 6);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(255, 623);
            this.gbStatus.TabIndex = 0;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Board Status";
            // 
            // lblDegrees
            // 
            this.lblDegrees.AutoSize = true;
            this.lblDegrees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDegrees.Location = new System.Drawing.Point(158, 37);
            this.lblDegrees.Name = "lblDegrees";
            this.lblDegrees.Size = new System.Drawing.Size(20, 20);
            this.lblDegrees.TabIndex = 34;
            this.lblDegrees.Text = "C";
            // 
            // btnGetTemp
            // 
            this.btnGetTemp.Location = new System.Drawing.Point(179, 35);
            this.btnGetTemp.Name = "btnGetTemp";
            this.btnGetTemp.Size = new System.Drawing.Size(75, 23);
            this.btnGetTemp.TabIndex = 33;
            this.btnGetTemp.Text = "Get TEMP";
            this.btnGetTemp.UseVisualStyleBackColor = true;
            this.btnGetTemp.Click += new System.EventHandler(this.btnGetTemp_Click);
            // 
            // lblMDirection
            // 
            this.lblMDirection.AutoSize = true;
            this.lblMDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMDirection.Location = new System.Drawing.Point(125, 191);
            this.lblMDirection.Name = "lblMDirection";
            this.lblMDirection.Size = new System.Drawing.Size(31, 20);
            this.lblMDirection.TabIndex = 32;
            this.lblMDirection.Text = "Off";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirection.Location = new System.Drawing.Point(6, 191);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(121, 20);
            this.lblDirection.TabIndex = 31;
            this.lblDirection.Text = "Motor Direction:";
            // 
            // lblSwitch4OnOff
            // 
            this.lblSwitch4OnOff.AutoSize = true;
            this.lblSwitch4OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitch4OnOff.Location = new System.Drawing.Point(121, 381);
            this.lblSwitch4OnOff.Name = "lblSwitch4OnOff";
            this.lblSwitch4OnOff.Size = new System.Drawing.Size(31, 20);
            this.lblSwitch4OnOff.TabIndex = 30;
            this.lblSwitch4OnOff.Text = "Off";
            // 
            // lblSwitch3OnOff
            // 
            this.lblSwitch3OnOff.AutoSize = true;
            this.lblSwitch3OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitch3OnOff.Location = new System.Drawing.Point(121, 337);
            this.lblSwitch3OnOff.Name = "lblSwitch3OnOff";
            this.lblSwitch3OnOff.Size = new System.Drawing.Size(31, 20);
            this.lblSwitch3OnOff.TabIndex = 29;
            this.lblSwitch3OnOff.Text = "Off";
            // 
            // lblSwitch2OnOff
            // 
            this.lblSwitch2OnOff.AutoSize = true;
            this.lblSwitch2OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitch2OnOff.Location = new System.Drawing.Point(123, 294);
            this.lblSwitch2OnOff.Name = "lblSwitch2OnOff";
            this.lblSwitch2OnOff.Size = new System.Drawing.Size(31, 20);
            this.lblSwitch2OnOff.TabIndex = 28;
            this.lblSwitch2OnOff.Text = "Off";
            // 
            // lblSwitch1
            // 
            this.lblSwitch1.AutoSize = true;
            this.lblSwitch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitch1.Location = new System.Drawing.Point(4, 246);
            this.lblSwitch1.Name = "lblSwitch1";
            this.lblSwitch1.Size = new System.Drawing.Size(73, 20);
            this.lblSwitch1.TabIndex = 23;
            this.lblSwitch1.Text = "Switch 1:";
            // 
            // lblSwitch1OnOff
            // 
            this.lblSwitch1OnOff.AutoSize = true;
            this.lblSwitch1OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitch1OnOff.Location = new System.Drawing.Point(123, 246);
            this.lblSwitch1OnOff.Name = "lblSwitch1OnOff";
            this.lblSwitch1OnOff.Size = new System.Drawing.Size(31, 20);
            this.lblSwitch1OnOff.TabIndex = 27;
            this.lblSwitch1OnOff.Text = "Off";
            // 
            // lblSwitch2
            // 
            this.lblSwitch2.AutoSize = true;
            this.lblSwitch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitch2.Location = new System.Drawing.Point(4, 294);
            this.lblSwitch2.Name = "lblSwitch2";
            this.lblSwitch2.Size = new System.Drawing.Size(73, 20);
            this.lblSwitch2.TabIndex = 24;
            this.lblSwitch2.Text = "Switch 2:";
            // 
            // lblSwitch4
            // 
            this.lblSwitch4.AutoSize = true;
            this.lblSwitch4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitch4.Location = new System.Drawing.Point(4, 381);
            this.lblSwitch4.Name = "lblSwitch4";
            this.lblSwitch4.Size = new System.Drawing.Size(73, 20);
            this.lblSwitch4.TabIndex = 26;
            this.lblSwitch4.Text = "Switch 4:";
            // 
            // lblSwitch3
            // 
            this.lblSwitch3.AutoSize = true;
            this.lblSwitch3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitch3.Location = new System.Drawing.Point(4, 337);
            this.lblSwitch3.Name = "lblSwitch3";
            this.lblSwitch3.Size = new System.Drawing.Size(73, 20);
            this.lblSwitch3.TabIndex = 25;
            this.lblSwitch3.Text = "Switch 3:";
            // 
            // lblLED4OnOff
            // 
            this.lblLED4OnOff.AutoSize = true;
            this.lblLED4OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLED4OnOff.Location = new System.Drawing.Point(123, 593);
            this.lblLED4OnOff.Name = "lblLED4OnOff";
            this.lblLED4OnOff.Size = new System.Drawing.Size(31, 20);
            this.lblLED4OnOff.TabIndex = 13;
            this.lblLED4OnOff.Text = "Off";
            // 
            // lblLED3OnOff
            // 
            this.lblLED3OnOff.AutoSize = true;
            this.lblLED3OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLED3OnOff.Location = new System.Drawing.Point(123, 549);
            this.lblLED3OnOff.Name = "lblLED3OnOff";
            this.lblLED3OnOff.Size = new System.Drawing.Size(31, 20);
            this.lblLED3OnOff.TabIndex = 12;
            this.lblLED3OnOff.Text = "Off";
            // 
            // lblLED2OnOff
            // 
            this.lblLED2OnOff.AutoSize = true;
            this.lblLED2OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLED2OnOff.Location = new System.Drawing.Point(125, 506);
            this.lblLED2OnOff.Name = "lblLED2OnOff";
            this.lblLED2OnOff.Size = new System.Drawing.Size(31, 20);
            this.lblLED2OnOff.TabIndex = 11;
            this.lblLED2OnOff.Text = "Off";
            // 
            // lblLED1OnOff
            // 
            this.lblLED1OnOff.AutoSize = true;
            this.lblLED1OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLED1OnOff.Location = new System.Drawing.Point(125, 458);
            this.lblLED1OnOff.Name = "lblLED1OnOff";
            this.lblLED1OnOff.Size = new System.Drawing.Size(31, 20);
            this.lblLED1OnOff.TabIndex = 10;
            this.lblLED1OnOff.Text = "Off";
            // 
            // lblLED4
            // 
            this.lblLED4.AutoSize = true;
            this.lblLED4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLED4.Location = new System.Drawing.Point(6, 593);
            this.lblLED4.Name = "lblLED4";
            this.lblLED4.Size = new System.Drawing.Size(54, 20);
            this.lblLED4.TabIndex = 9;
            this.lblLED4.Text = "LED4:";
            // 
            // lblLED3
            // 
            this.lblLED3.AutoSize = true;
            this.lblLED3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLED3.Location = new System.Drawing.Point(6, 549);
            this.lblLED3.Name = "lblLED3";
            this.lblLED3.Size = new System.Drawing.Size(54, 20);
            this.lblLED3.TabIndex = 8;
            this.lblLED3.Text = "LED3:";
            // 
            // lblLED2
            // 
            this.lblLED2.AutoSize = true;
            this.lblLED2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLED2.Location = new System.Drawing.Point(6, 506);
            this.lblLED2.Name = "lblLED2";
            this.lblLED2.Size = new System.Drawing.Size(54, 20);
            this.lblLED2.TabIndex = 7;
            this.lblLED2.Text = "LED2:";
            // 
            // lblLED1
            // 
            this.lblLED1.AutoSize = true;
            this.lblLED1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLED1.Location = new System.Drawing.Point(6, 458);
            this.lblLED1.Name = "lblLED1";
            this.lblLED1.Size = new System.Drawing.Size(54, 20);
            this.lblLED1.TabIndex = 6;
            this.lblLED1.Text = "LED1:";
            // 
            // lblMStatus
            // 
            this.lblMStatus.AutoSize = true;
            this.lblMStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMStatus.Location = new System.Drawing.Point(125, 144);
            this.lblMStatus.Name = "lblMStatus";
            this.lblMStatus.Size = new System.Drawing.Size(31, 20);
            this.lblMStatus.TabIndex = 5;
            this.lblMStatus.Text = "Off";
            // 
            // lblMotorStatus
            // 
            this.lblMotorStatus.AutoSize = true;
            this.lblMotorStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotorStatus.Location = new System.Drawing.Point(6, 144);
            this.lblMotorStatus.Name = "lblMotorStatus";
            this.lblMotorStatus.Size = new System.Drawing.Size(105, 20);
            this.lblMotorStatus.TabIndex = 4;
            this.lblMotorStatus.Text = "Motor Status:";
            // 
            // lblHStatus
            // 
            this.lblHStatus.AutoSize = true;
            this.lblHStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHStatus.Location = new System.Drawing.Point(125, 90);
            this.lblHStatus.Name = "lblHStatus";
            this.lblHStatus.Size = new System.Drawing.Size(31, 20);
            this.lblHStatus.TabIndex = 3;
            this.lblHStatus.Text = "Off";
            // 
            // lblHeaterStatus
            // 
            this.lblHeaterStatus.AutoSize = true;
            this.lblHeaterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaterStatus.Location = new System.Drawing.Point(6, 90);
            this.lblHeaterStatus.Name = "lblHeaterStatus";
            this.lblHeaterStatus.Size = new System.Drawing.Size(113, 20);
            this.lblHeaterStatus.TabIndex = 2;
            this.lblHeaterStatus.Text = "Heater Status:";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.Location = new System.Drawing.Point(123, 37);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(18, 20);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "0";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.Location = new System.Drawing.Point(6, 37);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(104, 20);
            this.lblTemperature.TabIndex = 0;
            this.lblTemperature.Text = "Temperature:";
            // 
            // formTimer
            // 
            this.formTimer.Interval = 2000;
            this.formTimer.Tick += new System.EventHandler(this.formTimer_Tick);
            // 
            // btnSetTemp
            // 
            this.btnSetTemp.Location = new System.Drawing.Point(449, 8);
            this.btnSetTemp.Name = "btnSetTemp";
            this.btnSetTemp.Size = new System.Drawing.Size(75, 23);
            this.btnSetTemp.TabIndex = 8;
            this.btnSetTemp.Text = "button1";
            this.btnSetTemp.UseVisualStyleBackColor = true;
            this.btnSetTemp.Click += new System.EventHandler(this.btnSetTemp_Click);
            // 
            // CTEC3426
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 701);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(660, 39);
            this.Name = "CTEC3426";
            this.Text = "CANBUS";
            this.Load += new System.EventHandler(this.CTEC3426_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.terminalTab.ResumeLayout(false);
            this.canvas.ResumeLayout(false);
            this.canvas.PerformLayout();
            this.gbCAN.ResumeLayout(false);
            this.gbCAN.PerformLayout();
            this.gbSMS.ResumeLayout(false);
            this.gbSMS.PerformLayout();
            this.gbControls.ResumeLayout(false);
            this.gbKeypad.ResumeLayout(false);
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox portNameComboBox;
        private System.Windows.Forms.ToolStripMenuItem baudrateToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox baudRateTextBox;
        private System.Windows.Forms.ToolStripMenuItem dataBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox stopBitsComboBox;
        private System.Windows.Forms.ToolStripMenuItem parityToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox dataBitsTextBox;
        private System.Windows.Forms.ToolStripComboBox parityComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage terminalTab;
        private System.Windows.Forms.TabPage canvas;
        private System.Windows.Forms.RichTextBox terminal;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblHeaterStatus;
        private System.Windows.Forms.Label lblHStatus;
        private System.Windows.Forms.Label lblMotorStatus;
        private System.Windows.Forms.Label lblMStatus;
        private System.Windows.Forms.Label lblLED4OnOff;
        private System.Windows.Forms.Label lblLED3OnOff;
        private System.Windows.Forms.Label lblLED2OnOff;
        private System.Windows.Forms.Label lblLED1OnOff;
        private System.Windows.Forms.Label lblLED4;
        private System.Windows.Forms.Label lblLED3;
        private System.Windows.Forms.Label lblLED2;
        private System.Windows.Forms.Label lblLED1;
        private System.Windows.Forms.GroupBox gbKeypad;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btnAsterisk;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Button btnHeater;
        private System.Windows.Forms.Button btnMotorOnOff;
        private System.Windows.Forms.Button btnMotorFwdRev;
        private System.Windows.Forms.Button btnSwitch1OnOff;
        private System.Windows.Forms.Button btnLED4OnOff;
        private System.Windows.Forms.Button btnLED3OnOff;
        private System.Windows.Forms.Button btnLED2OnOff;
        private System.Windows.Forms.Button btnSwitch2OnOff;
        private System.Windows.Forms.Button btnLED1OnOff;
        private System.Windows.Forms.Button btnSwitch4OnOff;
        private System.Windows.Forms.Button btnSwitch3OnOff;
        private System.Windows.Forms.GroupBox gbSMS;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSMS;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.GroupBox gbCAN;
        private System.Windows.Forms.Label lblMask;
        private System.Windows.Forms.Button btnSetMask;
        private System.Windows.Forms.TextBox txtMask;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnSetFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblIncomingID;
        private System.Windows.Forms.Button btnIncoming;
        private System.Windows.Forms.TextBox txtIncoming;
        private System.Windows.Forms.Label lblOutgoingID;
        private System.Windows.Forms.Button btnOutgoing;
        private System.Windows.Forms.TextBox txtOutgoing;
        private System.Windows.Forms.Label lblSwitch4OnOff;
        private System.Windows.Forms.Label lblSwitch3OnOff;
        private System.Windows.Forms.Label lblSwitch2OnOff;
        private System.Windows.Forms.Label lblSwitch1;
        private System.Windows.Forms.Label lblSwitch1OnOff;
        private System.Windows.Forms.Label lblSwitch2;
        private System.Windows.Forms.Label lblSwitch4;
        private System.Windows.Forms.Label lblSwitch3;
        private System.Windows.Forms.Label lblMDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGetTemp;
        private System.Windows.Forms.Label lblSMSMessage;
        private System.Windows.Forms.Timer formTimer;
        private System.Windows.Forms.Label lblDegrees;
        private System.Windows.Forms.Label lblBroadCastID;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.Label lblMaskStatus;
        private System.Windows.Forms.Label lblIncomingStatus;
        private System.Windows.Forms.TextBox txtSetTemp;
        private System.Windows.Forms.Button btnSetTemp;
    }
}

