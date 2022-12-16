/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
using MCM8.Audio;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnStop = new Button();
            btnStart = new Button();
            textBox1 = new TextBox();
            btnSaveSettings = new Button();
            groupBox2 = new GroupBox();
            btnClearLog = new Button();
            btnASIOSettings = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new UC.ProgressBarEx();
            timer1 = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            btnDefaultChannels = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            ucSource1 = new UC.UCSource();
            ucSource2 = new UC.UCSource();
            ucSource3 = new UC.UCSource();
            ucSource4 = new UC.UCSource();
            ucAsio = new UC.UCASIO();
            ucPlayer = new UC.UCPlayer();
            gbPlayerNumber = new GroupBox();
            lbPlayer4 = new Label();
            lbPlayer3 = new Label();
            lbPlayer2 = new Label();
            lbPlayer1 = new Label();
            groupBox2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            gbPlayerNumber.SuspendLayout();
            SuspendLayout();
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Location = new Point(557, 458);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(90, 29);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Enabled = false;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Location = new Point(653, 458);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(132, 29);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(10, 22);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(386, 97);
            textBox1.TabIndex = 4;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.FlatStyle = FlatStyle.Flat;
            btnSaveSettings.Location = new Point(456, 458);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(95, 29);
            btnSaveSettings.TabIndex = 6;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Location = new Point(0, 493);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(405, 125);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Logs:";
            // 
            // btnClearLog
            // 
            btnClearLog.FlatStyle = FlatStyle.Flat;
            btnClearLog.Location = new Point(10, 458);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(113, 29);
            btnClearLog.TabIndex = 12;
            btnClearLog.Text = "Clear logging";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // btnASIOSettings
            // 
            btnASIOSettings.Enabled = false;
            btnASIOSettings.FlatStyle = FlatStyle.Flat;
            btnASIOSettings.Location = new Point(345, 458);
            btnASIOSettings.Name = "btnASIOSettings";
            btnASIOSettings.Size = new Size(105, 29);
            btnASIOSettings.TabIndex = 13;
            btnASIOSettings.Text = "ASIO Settings";
            btnASIOSettings.UseVisualStyleBackColor = true;
            btnASIOSettings.Click += btnASIOSettings_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Cursor = Cursors.AppStarting;
            progressBar1.ForeColor = Color.DimGray;
            progressBar1.Location = new Point(335, 19);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(425, 10);
            progressBar1.TabIndex = 14;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "7.1 Multi Channel Mixer";
            notifyIcon1.Visible = true;
            notifyIcon1.Click += notifyIcon1_Click;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(265, 15);
            label9.Name = "label9";
            label9.Size = new Size(16, 17);
            label9.TabIndex = 24;
            label9.Text = "1";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(230, 15);
            label10.Name = "label10";
            label10.Size = new Size(16, 17);
            label10.TabIndex = 25;
            label10.Text = "2";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.BorderStyle = BorderStyle.Fixed3D;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(195, 15);
            label11.Name = "label11";
            label11.Size = new Size(16, 17);
            label11.TabIndex = 26;
            label11.Text = "3";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.BorderStyle = BorderStyle.Fixed3D;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(160, 15);
            label12.Name = "label12";
            label12.Size = new Size(16, 17);
            label12.TabIndex = 27;
            label12.Text = "4";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.BorderStyle = BorderStyle.Fixed3D;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(125, 15);
            label13.Name = "label13";
            label13.Size = new Size(16, 17);
            label13.TabIndex = 27;
            label13.Text = "5";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.BorderStyle = BorderStyle.Fixed3D;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(90, 15);
            label14.Name = "label14";
            label14.Size = new Size(16, 17);
            label14.TabIndex = 28;
            label14.Text = "6";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.BorderStyle = BorderStyle.Fixed3D;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(55, 15);
            label15.Name = "label15";
            label15.Size = new Size(16, 17);
            label15.TabIndex = 29;
            label15.Text = "7";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.BorderStyle = BorderStyle.Fixed3D;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(20, 15);
            label16.Name = "label16";
            label16.Size = new Size(16, 17);
            label16.TabIndex = 30;
            label16.Text = "8";
            // 
            // btnDefaultChannels
            // 
            btnDefaultChannels.FlatStyle = FlatStyle.Flat;
            btnDefaultChannels.Location = new Point(226, 458);
            btnDefaultChannels.Name = "btnDefaultChannels";
            btnDefaultChannels.Size = new Size(113, 29);
            btnDefaultChannels.TabIndex = 31;
            btnDefaultChannels.Text = "Default Channels";
            btnDefaultChannels.UseVisualStyleBackColor = true;
            btnDefaultChannels.Click += btnDefaultChannels_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Controls.Add(ucSource1);
            flowLayoutPanel1.Controls.Add(ucSource2);
            flowLayoutPanel1.Controls.Add(ucSource3);
            flowLayoutPanel1.Controls.Add(ucSource4);
            flowLayoutPanel1.Location = new Point(0, 57);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 393);
            flowLayoutPanel1.TabIndex = 37;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(progressBar1);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label12);
            groupBox1.Location = new Point(10, 3);
            groupBox1.Margin = new Padding(10, 3, 3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(775, 40);
            groupBox1.TabIndex = 37;
            groupBox1.TabStop = false;
            // 
            // ucSource1
            // 
            ucSource1.Channels = (new int[] { -2, -1 });
            ucSource1.ControlEnabled = true;
            ucSource1.DevicesList = null;
            ucSource1.Location = new Point(3, 49);
            ucSource1.Name = "ucSource1";
            ucSource1.SelectedDevice = null;
            ucSource1.Size = new Size(782, 80);
            ucSource1.SourceId = SourceNumber.Source_None;
            ucSource1.TabIndex = 38;
            ucSource1.Volume = 0.5D;
            ucSource1.VolumeEnable = true;
            ucSource1.VolumeMute = false;
            // 
            // ucSource2
            // 
            ucSource2.Channels = (new int[] { -2, -1 });
            ucSource2.ControlEnabled = true;
            ucSource2.DevicesList = null;
            ucSource2.Location = new Point(3, 135);
            ucSource2.Name = "ucSource2";
            ucSource2.SelectedDevice = null;
            ucSource2.Size = new Size(782, 80);
            ucSource2.SourceId = SourceNumber.Source_None;
            ucSource2.TabIndex = 39;
            ucSource2.Volume = 0.5D;
            ucSource2.VolumeEnable = true;
            ucSource2.VolumeMute = false;
            // 
            // ucSource3
            // 
            ucSource3.Channels = (new int[] { -2, -1 });
            ucSource3.ControlEnabled = true;
            ucSource3.DevicesList = null;
            ucSource3.Location = new Point(3, 221);
            ucSource3.Name = "ucSource3";
            ucSource3.SelectedDevice = null;
            ucSource3.Size = new Size(782, 80);
            ucSource3.SourceId = SourceNumber.Source_None;
            ucSource3.TabIndex = 40;
            ucSource3.Volume = 0.5D;
            ucSource3.VolumeEnable = true;
            ucSource3.VolumeMute = false;
            // 
            // ucSource4
            // 
            ucSource4.Channels = (new int[] { -2, -1 });
            ucSource4.ControlEnabled = true;
            ucSource4.DevicesList = null;
            ucSource4.Location = new Point(3, 307);
            ucSource4.Name = "ucSource4";
            ucSource4.SelectedDevice = null;
            ucSource4.Size = new Size(782, 80);
            ucSource4.SourceId = SourceNumber.Source_None;
            ucSource4.TabIndex = 41;
            ucSource4.Volume = 0.5D;
            ucSource4.VolumeEnable = true;
            ucSource4.VolumeMute = false;
            // 
            // ucAsio
            // 
            ucAsio.ChannelsCount = -1;
            ucAsio.ControlEnabled = true;
            ucAsio.DevicesList = null;
            ucAsio.Location = new Point(0, -7);
            ucAsio.Name = "ucAsio";
            ucAsio.SelectedDevice = null;
            ucAsio.Size = new Size(800, 61);
            ucAsio.TabIndex = 38;
            // 
            // ucPlayer
            // 
            ucPlayer.Enabled = false;
            ucPlayer.FolderPath = "";
            ucPlayer.Location = new Point(405, 487);
            ucPlayer.Margin = new Padding(0);
            ucPlayer.Name = "ucPlayer";
            ucPlayer.SelectedIndex = 0;
            ucPlayer.Size = new Size(332, 125);
            ucPlayer.StatusPlay = false;
            ucPlayer.TabIndex = 39;
            // 
            // gbPlayerNumber
            // 
            gbPlayerNumber.Controls.Add(lbPlayer4);
            gbPlayerNumber.Controls.Add(lbPlayer3);
            gbPlayerNumber.Controls.Add(lbPlayer2);
            gbPlayerNumber.Controls.Add(lbPlayer1);
            gbPlayerNumber.Location = new Point(740, 493);
            gbPlayerNumber.Name = "gbPlayerNumber";
            gbPlayerNumber.Size = new Size(45, 119);
            gbPlayerNumber.TabIndex = 40;
            gbPlayerNumber.TabStop = false;
            // 
            // lbPlayer4
            // 
            lbPlayer4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbPlayer4.AutoSize = true;
            lbPlayer4.BorderStyle = BorderStyle.Fixed3D;
            lbPlayer4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbPlayer4.Location = new Point(14, 94);
            lbPlayer4.Name = "lbPlayer4";
            lbPlayer4.Size = new Size(16, 17);
            lbPlayer4.TabIndex = 34;
            lbPlayer4.Text = "4";
            // 
            // lbPlayer3
            // 
            lbPlayer3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbPlayer3.AutoSize = true;
            lbPlayer3.BorderStyle = BorderStyle.Fixed3D;
            lbPlayer3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbPlayer3.Location = new Point(14, 69);
            lbPlayer3.Name = "lbPlayer3";
            lbPlayer3.Size = new Size(16, 17);
            lbPlayer3.TabIndex = 33;
            lbPlayer3.Text = "3";
            // 
            // lbPlayer2
            // 
            lbPlayer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbPlayer2.AutoSize = true;
            lbPlayer2.BorderStyle = BorderStyle.Fixed3D;
            lbPlayer2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbPlayer2.Location = new Point(14, 44);
            lbPlayer2.Name = "lbPlayer2";
            lbPlayer2.Size = new Size(16, 17);
            lbPlayer2.TabIndex = 32;
            lbPlayer2.Text = "2";
            // 
            // lbPlayer1
            // 
            lbPlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbPlayer1.AutoSize = true;
            lbPlayer1.BorderStyle = BorderStyle.Fixed3D;
            lbPlayer1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbPlayer1.Location = new Point(14, 18);
            lbPlayer1.Name = "lbPlayer1";
            lbPlayer1.Size = new Size(16, 17);
            lbPlayer1.TabIndex = 31;
            lbPlayer1.Text = "1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 618);
            Controls.Add(gbPlayerNumber);
            Controls.Add(ucPlayer);
            Controls.Add(ucAsio);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnDefaultChannels);
            Controls.Add(btnASIOSettings);
            Controls.Add(btnClearLog);
            Controls.Add(groupBox2);
            Controls.Add(btnSaveSettings);
            Controls.Add(btnStart);
            Controls.Add(btnStop);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206)";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            Resize += Form1_Resize;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbPlayerNumber.ResumeLayout(false);
            gbPlayerNumber.PerformLayout();
            ResumeLayout(false);
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
        private UC.UCPlayer ucPlayer;
        private GroupBox gbPlayerNumber;
        private Label lbPlayer4;
        private Label lbPlayer3;
        private Label lbPlayer2;
        private Label lbPlayer1;
    }
}