/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
namespace MCM8
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnASIOSettings = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new MCM8.UC.ProgressBarEx();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnDefaultChannels = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucSource1 = new MCM8.UC.UCSource();
            this.ucSource2 = new MCM8.UC.UCSource();
            this.ucSource3 = new MCM8.UC.UCSource();
            this.ucSource4 = new MCM8.UC.UCSource();
            this.ucAsio = new MCM8.UC.UCASIO();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(557, 458);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 29);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(653, 458);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(132, 29);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(775, 97);
            this.textBox1.TabIndex = 4;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Location = new System.Drawing.Point(456, 458);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(95, 29);
            this.btnSaveSettings.TabIndex = 6;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 493);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 125);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logs:";
            // 
            // btnClearLog
            // 
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Location = new System.Drawing.Point(10, 458);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(113, 29);
            this.btnClearLog.TabIndex = 12;
            this.btnClearLog.Text = "Clear logging";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnASIOSettings
            // 
            this.btnASIOSettings.Enabled = false;
            this.btnASIOSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnASIOSettings.Location = new System.Drawing.Point(345, 458);
            this.btnASIOSettings.Name = "btnASIOSettings";
            this.btnASIOSettings.Size = new System.Drawing.Size(105, 29);
            this.btnASIOSettings.TabIndex = 13;
            this.btnASIOSettings.Text = "ASIO Settings";
            this.btnASIOSettings.UseVisualStyleBackColor = true;
            this.btnASIOSettings.Click += new System.EventHandler(this.btnASIOSettings_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.progressBar1.ForeColor = System.Drawing.Color.DimGray;
            this.progressBar1.Location = new System.Drawing.Point(335, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(425, 10);
            this.progressBar1.TabIndex = 14;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "7.1 Multi Channel Mixer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(265, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "1";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(230, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "2";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(195, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "3";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(160, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "4";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(125, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 17);
            this.label13.TabIndex = 27;
            this.label13.Text = "5";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(90, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 17);
            this.label14.TabIndex = 28;
            this.label14.Text = "6";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(55, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 17);
            this.label15.TabIndex = 29;
            this.label15.Text = "7";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(20, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 17);
            this.label16.TabIndex = 30;
            this.label16.Text = "8";
            // 
            // btnDefaultChannels
            // 
            this.btnDefaultChannels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefaultChannels.Location = new System.Drawing.Point(226, 458);
            this.btnDefaultChannels.Name = "btnDefaultChannels";
            this.btnDefaultChannels.Size = new System.Drawing.Size(113, 29);
            this.btnDefaultChannels.TabIndex = 31;
            this.btnDefaultChannels.Text = "Default Channels";
            this.btnDefaultChannels.UseVisualStyleBackColor = true;
            this.btnDefaultChannels.Click += new System.EventHandler(this.btnDefaultChannels_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.ucSource1);
            this.flowLayoutPanel1.Controls.Add(this.ucSource2);
            this.flowLayoutPanel1.Controls.Add(this.ucSource3);
            this.flowLayoutPanel1.Controls.Add(this.ucSource4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 57);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 393);
            this.flowLayoutPanel1.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 40);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // ucSource1
            // 
            this.ucSource1.Channels = new int[] {
        -2,
        -1};
            this.ucSource1.ControlEnabled = true;
            this.ucSource1.DevicesList = null;
            this.ucSource1.Location = new System.Drawing.Point(3, 49);
            this.ucSource1.Name = "ucSource1";
            this.ucSource1.SelectedDevice = null;
            this.ucSource1.Size = new System.Drawing.Size(782, 80);
            this.ucSource1.SourceNumber = MCM8.SourceNumber.Source_None;
            this.ucSource1.TabIndex = 38;
            this.ucSource1.Volume = 0.5D;
            this.ucSource1.VolumeEnable = true;
            this.ucSource1.VolumeMute = false;
            // 
            // ucSource2
            // 
            this.ucSource2.Channels = new int[] {
        -2,
        -1};
            this.ucSource2.ControlEnabled = true;
            this.ucSource2.DevicesList = null;
            this.ucSource2.Location = new System.Drawing.Point(3, 135);
            this.ucSource2.Name = "ucSource2";
            this.ucSource2.SelectedDevice = null;
            this.ucSource2.Size = new System.Drawing.Size(782, 80);
            this.ucSource2.SourceNumber = MCM8.SourceNumber.Source_None;
            this.ucSource2.TabIndex = 39;
            this.ucSource2.Volume = 0.5D;
            this.ucSource2.VolumeEnable = true;
            this.ucSource2.VolumeMute = false;
            // 
            // ucSource3
            // 
            this.ucSource3.Channels = new int[] {
        -2,
        -1};
            this.ucSource3.ControlEnabled = true;
            this.ucSource3.DevicesList = null;
            this.ucSource3.Location = new System.Drawing.Point(3, 221);
            this.ucSource3.Name = "ucSource3";
            this.ucSource3.SelectedDevice = null;
            this.ucSource3.Size = new System.Drawing.Size(782, 80);
            this.ucSource3.SourceNumber = MCM8.SourceNumber.Source_None;
            this.ucSource3.TabIndex = 40;
            this.ucSource3.Volume = 0.5D;
            this.ucSource3.VolumeEnable = true;
            this.ucSource3.VolumeMute = false;
            // 
            // ucSource4
            // 
            this.ucSource4.Channels = new int[] {
        -2,
        -1};
            this.ucSource4.ControlEnabled = true;
            this.ucSource4.DevicesList = null;
            this.ucSource4.Location = new System.Drawing.Point(3, 307);
            this.ucSource4.Name = "ucSource4";
            this.ucSource4.SelectedDevice = null;
            this.ucSource4.Size = new System.Drawing.Size(782, 80);
            this.ucSource4.SourceNumber = MCM8.SourceNumber.Source_None;
            this.ucSource4.TabIndex = 41;
            this.ucSource4.Volume = 0.5D;
            this.ucSource4.VolumeEnable = true;
            this.ucSource4.VolumeMute = false;
            // 
            // ucAsio
            // 
            this.ucAsio.ChannelsCount = -1;
            this.ucAsio.DevicesList = null;
            this.ucAsio.Location = new System.Drawing.Point(0, -7);
            this.ucAsio.Name = "ucAsio";
            this.ucAsio.SelectedDevice = null;
            this.ucAsio.Size = new System.Drawing.Size(800, 61);
            this.ucAsio.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 618);
            this.Controls.Add(this.ucAsio);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnDefaultChannels);
            this.Controls.Add(this.btnASIOSettings);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnStop;
        private Button btnStart;
        private TextBox textBox1;
        private Button btnSaveSettings;
        private GroupBox groupBox2;
        private Button btnClearLog;
        private Button btnASIOSettings;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private UC.ProgressBarEx progressBar1;
        private System.Windows.Forms.Timer timer1;
        private NotifyIcon notifyIcon1;
        private Label label11;
        private Label label9;
        private Label label10;
        private Label label16;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Button btnDefaultChannels;
        private UC.UCASIO ucAsio;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private UC.UCSource ucSource1;
        private UC.UCSource ucSource2;
        private UC.UCSource ucSource3;
        private UC.UCSource ucSource4;
    }
}