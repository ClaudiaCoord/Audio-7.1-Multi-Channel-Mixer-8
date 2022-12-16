namespace MCM8.UC
{
    public partial class UCPlayer
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dialogFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbPlayer = new System.Windows.Forms.GroupBox();
            this.btnClearControl = new System.Windows.Forms.Button();
            this.lbFolderPath = new System.Windows.Forms.LinkLabel();
            this.btnFolderSelect = new System.Windows.Forms.Button();
            this.gbPlayerControl = new System.Windows.Forms.GroupBox();
            this.pbPlayStatus = new System.Windows.Forms.PictureBox();
            this.lbPlayCounts = new System.Windows.Forms.Label();
            this.pbEnabled = new System.Windows.Forms.PictureBox();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.ucErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.gbPlayer.SuspendLayout();
            this.gbPlayerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dialogFolderBrowser
            // 
            this.dialogFolderBrowser.RootFolder = System.Environment.SpecialFolder.MyMusic;
            this.dialogFolderBrowser.ShowNewFolderButton = false;
            // 
            // cbSource
            // 
            this.cbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Items.AddRange(new object[] {
            "Player source 1",
            "Player source 2",
            "Player source 3",
            "Player source 4"});
            this.cbSource.Location = new System.Drawing.Point(6, 16);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(113, 23);
            this.cbSource.TabIndex = 0;
            this.cbSource.SelectedValueChanged += new System.EventHandler(this.cbSource_SelectedValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.gbPlayer);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(332, 125);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // gbPlayer
            // 
            this.gbPlayer.Controls.Add(this.btnClearControl);
            this.gbPlayer.Controls.Add(this.cbSource);
            this.gbPlayer.Controls.Add(this.lbFolderPath);
            this.gbPlayer.Controls.Add(this.btnFolderSelect);
            this.gbPlayer.Controls.Add(this.gbPlayerControl);
            this.gbPlayer.Location = new System.Drawing.Point(8, 3);
            this.gbPlayer.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.gbPlayer.Name = "gbPlayer";
            this.gbPlayer.Size = new System.Drawing.Size(314, 120);
            this.gbPlayer.TabIndex = 0;
            this.gbPlayer.TabStop = false;
            this.gbPlayer.Text = "Local players";
            // 
            // btnClearControl
            // 
            this.btnClearControl.Enabled = false;
            this.btnClearControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearControl.Image = global::MCM8.Properties.Resources.Close_icon_32x32;
            this.btnClearControl.Location = new System.Drawing.Point(281, 15);
            this.btnClearControl.Name = "btnClearControl";
            this.btnClearControl.Size = new System.Drawing.Size(27, 23);
            this.btnClearControl.TabIndex = 12;
            this.btnClearControl.UseVisualStyleBackColor = true;
            this.btnClearControl.Click += new System.EventHandler(this.btnClearControl_Click);
            // 
            // lbFolderPath
            // 
            this.lbFolderPath.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbFolderPath.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbFolderPath.Location = new System.Drawing.Point(6, 48);
            this.lbFolderPath.Name = "lbFolderPath";
            this.lbFolderPath.Size = new System.Drawing.Size(298, 20);
            this.lbFolderPath.TabIndex = 2;
            this.lbFolderPath.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // btnFolderSelect
            // 
            this.btnFolderSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderSelect.Location = new System.Drawing.Point(125, 15);
            this.btnFolderSelect.Name = "btnFolderSelect";
            this.btnFolderSelect.Size = new System.Drawing.Size(150, 23);
            this.btnFolderSelect.TabIndex = 1;
            this.btnFolderSelect.Text = "Select MP3 Folder";
            this.btnFolderSelect.UseVisualStyleBackColor = true;
            this.btnFolderSelect.Click += new System.EventHandler(this.btnFolderSelect_Click);
            // 
            // gbPlayerControl
            // 
            this.gbPlayerControl.Controls.Add(this.pbPlayStatus);
            this.gbPlayerControl.Controls.Add(this.lbPlayCounts);
            this.gbPlayerControl.Controls.Add(this.pbEnabled);
            this.gbPlayerControl.Enabled = false;
            this.gbPlayerControl.Location = new System.Drawing.Point(0, 71);
            this.gbPlayerControl.Name = "gbPlayerControl";
            this.gbPlayerControl.Size = new System.Drawing.Size(314, 48);
            this.gbPlayerControl.TabIndex = 11;
            this.gbPlayerControl.TabStop = false;
            // 
            // pbPlayStatus
            // 
            this.pbPlayStatus.Image = global::MCM8.Properties.Resources.Media_Controls_Stop_icon_32x32;
            this.pbPlayStatus.Location = new System.Drawing.Point(6, 12);
            this.pbPlayStatus.Name = "pbPlayStatus";
            this.pbPlayStatus.Size = new System.Drawing.Size(32, 32);
            this.pbPlayStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayStatus.TabIndex = 18;
            this.pbPlayStatus.TabStop = false;
            // 
            // lbPlayCounts
            // 
            this.lbPlayCounts.AutoSize = true;
            this.lbPlayCounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbPlayCounts.Location = new System.Drawing.Point(82, 19);
            this.lbPlayCounts.Name = "lbPlayCounts";
            this.lbPlayCounts.Size = new System.Drawing.Size(12, 15);
            this.lbPlayCounts.TabIndex = 16;
            this.lbPlayCounts.Text = "-";
            // 
            // pbEnabled
            // 
            this.pbEnabled.Image = global::MCM8.Properties.Resources.Media_Controls_Mute_icon_32x32;
            this.pbEnabled.Location = new System.Drawing.Point(44, 12);
            this.pbEnabled.Name = "pbEnabled";
            this.pbEnabled.Size = new System.Drawing.Size(32, 32);
            this.pbEnabled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEnabled.TabIndex = 8;
            this.pbEnabled.TabStop = false;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // ucErrorProvider
            // 
            this.ucErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ucErrorProvider.ContainerControl = this;
            // 
            // UCPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCPlayer";
            this.Size = new System.Drawing.Size(336, 125);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbPlayer.ResumeLayout(false);
            this.gbPlayerControl.ResumeLayout(false);
            this.gbPlayerControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FolderBrowserDialog dialogFolderBrowser;
        private ComboBox cbSource;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox gbPlayer;
        private Button btnFolderSelect;
        private LinkLabel lbFolderPath;
        private PictureBox pbEnabled;
        private GroupBox gbPlayerControl;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private Label lbPlayCounts;
        private PictureBox pbPlayStatus;
        private Button btnClearControl;
        private ErrorProvider ucErrorProvider;
    }
}
