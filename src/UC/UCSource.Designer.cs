/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
namespace MCM8.UC
{
    partial class UCSource
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param Name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
            this.flPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.gbSourceCtrl = new System.Windows.Forms.GroupBox();
            this.lbName = new System.Windows.Forms.Label();
            this.volumeMeter = new NAudio.Gui.VolumeMeter();
            this.cmDevicesBox = new System.Windows.Forms.ComboBox();
            this.imgDeviceIconBox = new System.Windows.Forms.PictureBox();
            this.potVolume = new NAudio.Gui.Pot();
            this.chkEnableBox = new System.Windows.Forms.CheckBox();
            this.gbSourceChannel2 = new System.Windows.Forms.GroupBox();
            this.lbChannel2 = new System.Windows.Forms.Label();
            this.rbn28 = new System.Windows.Forms.RadioButton();
            this.rbn27 = new System.Windows.Forms.RadioButton();
            this.rbn26 = new System.Windows.Forms.RadioButton();
            this.rbn25 = new System.Windows.Forms.RadioButton();
            this.rbn24 = new System.Windows.Forms.RadioButton();
            this.rbn23 = new System.Windows.Forms.RadioButton();
            this.rbn22 = new System.Windows.Forms.RadioButton();
            this.rbn21 = new System.Windows.Forms.RadioButton();
            this.gbSourceChannel1 = new System.Windows.Forms.GroupBox();
            this.lbChannel1 = new System.Windows.Forms.Label();
            this.rbn18 = new System.Windows.Forms.RadioButton();
            this.rbn17 = new System.Windows.Forms.RadioButton();
            this.rbn16 = new System.Windows.Forms.RadioButton();
            this.rbn15 = new System.Windows.Forms.RadioButton();
            this.rbn14 = new System.Windows.Forms.RadioButton();
            this.rbn13 = new System.Windows.Forms.RadioButton();
            this.rbn12 = new System.Windows.Forms.RadioButton();
            this.rbn11 = new System.Windows.Forms.RadioButton();
            this.flPanel.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.gbSourceCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDeviceIconBox)).BeginInit();
            this.gbSourceChannel2.SuspendLayout();
            this.gbSourceChannel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flPanel
            // 
            this.flPanel.Controls.Add(this.gbSource);
            this.flPanel.Location = new System.Drawing.Point(3, 3);
            this.flPanel.Name = "flPanel";
            this.flPanel.Size = new System.Drawing.Size(776, 76);
            this.flPanel.TabIndex = 0;
            // 
            // gbSource
            // 
            this.gbSource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbSource.Controls.Add(this.gbSourceCtrl);
            this.gbSource.Controls.Add(this.gbSourceChannel2);
            this.gbSource.Controls.Add(this.gbSourceChannel1);
            this.gbSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbSource.Location = new System.Drawing.Point(3, 3);
            this.gbSource.Name = "gbSource";
            this.gbSource.Padding = new System.Windows.Forms.Padding(0);
            this.gbSource.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbSource.Size = new System.Drawing.Size(773, 74);
            this.gbSource.TabIndex = 0;
            this.gbSource.TabStop = false;
            // 
            // gbSourceCtrl
            // 
            this.gbSourceCtrl.Controls.Add(this.lbName);
            this.gbSourceCtrl.Controls.Add(this.volumeMeter);
            this.gbSourceCtrl.Controls.Add(this.cmDevicesBox);
            this.gbSourceCtrl.Controls.Add(this.imgDeviceIconBox);
            this.gbSourceCtrl.Controls.Add(this.potVolume);
            this.gbSourceCtrl.Controls.Add(this.chkEnableBox);
            this.gbSourceCtrl.Location = new System.Drawing.Point(338, 9);
            this.gbSourceCtrl.Name = "gbSourceCtrl";
            this.gbSourceCtrl.Size = new System.Drawing.Size(428, 56);
            this.gbSourceCtrl.TabIndex = 20;
            this.gbSourceCtrl.TabStop = false;
            this.gbSourceCtrl.Text = "Source ";
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbName.Location = new System.Drawing.Point(117, 17);
            this.lbName.Name = "lbName";
            this.lbName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbName.Size = new System.Drawing.Size(259, 16);
            this.lbName.TabIndex = 16;
            this.lbName.Text = "-";
            this.lbName.Visible = false;
            // 
            // volumeMeter
            // 
            this.volumeMeter.Amplitude = 0F;
            this.volumeMeter.ForeColor = System.Drawing.Color.DimGray;
            this.volumeMeter.Location = new System.Drawing.Point(117, 40);
            this.volumeMeter.MaxDb = 18F;
            this.volumeMeter.MinDb = -60F;
            this.volumeMeter.Name = "volumeMeter";
            this.volumeMeter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.volumeMeter.Size = new System.Drawing.Size(259, 10);
            this.volumeMeter.TabIndex = 1;
            // 
            // cmDevicesBox
            // 
            this.cmDevicesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmDevicesBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmDevicesBox.FormattingEnabled = true;
            this.cmDevicesBox.Location = new System.Drawing.Point(117, 13);
            this.cmDevicesBox.Name = "cmDevicesBox";
            this.cmDevicesBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmDevicesBox.Size = new System.Drawing.Size(259, 23);
            this.cmDevicesBox.TabIndex = 13;
            this.cmDevicesBox.SelectedValueChanged += new System.EventHandler(this.cmDevicesBox_SelectedValueChanged);
            // 
            // imgDeviceIconBox
            // 
            this.imgDeviceIconBox.Location = new System.Drawing.Point(6, 13);
            this.imgDeviceIconBox.Name = "imgDeviceIconBox";
            this.imgDeviceIconBox.Size = new System.Drawing.Size(39, 37);
            this.imgDeviceIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgDeviceIconBox.TabIndex = 12;
            this.imgDeviceIconBox.TabStop = false;
            // 
            // potVolume
            // 
            this.potVolume.ForeColor = System.Drawing.Color.DimGray;
            this.potVolume.Location = new System.Drawing.Point(63, 13);
            this.potVolume.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.potVolume.Maximum = 1D;
            this.potVolume.Minimum = 0D;
            this.potVolume.Name = "potVolume";
            this.potVolume.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.potVolume.Size = new System.Drawing.Size(37, 37);
            this.potVolume.TabIndex = 15;
            this.potVolume.Value = 0.5D;
            this.potVolume.ValueChanged += new System.EventHandler(this.potVolume_VolumeChanged);
            this.potVolume.DoubleClick += new System.EventHandler(this.potVolume_DoubleClick);
            this.potVolume.MouseClick += new System.Windows.Forms.MouseEventHandler(this.potVolume_MouseClick);
            // 
            // chkEnableBox
            // 
            this.chkEnableBox.AutoSize = true;
            this.chkEnableBox.Checked = true;
            this.chkEnableBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnableBox.Location = new System.Drawing.Point(396, 25);
            this.chkEnableBox.Name = "chkEnableBox";
            this.chkEnableBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkEnableBox.Size = new System.Drawing.Size(12, 11);
            this.chkEnableBox.TabIndex = 14;
            this.chkEnableBox.UseVisualStyleBackColor = true;
            this.chkEnableBox.CheckedChanged += new System.EventHandler(this.chkEnableBox_CheckedChanged);
            // 
            // gbSourceChannel2
            // 
            this.gbSourceChannel2.Controls.Add(this.lbChannel2);
            this.gbSourceChannel2.Controls.Add(this.rbn28);
            this.gbSourceChannel2.Controls.Add(this.rbn27);
            this.gbSourceChannel2.Controls.Add(this.rbn26);
            this.gbSourceChannel2.Controls.Add(this.rbn25);
            this.gbSourceChannel2.Controls.Add(this.rbn24);
            this.gbSourceChannel2.Controls.Add(this.rbn23);
            this.gbSourceChannel2.Controls.Add(this.rbn22);
            this.gbSourceChannel2.Controls.Add(this.rbn21);
            this.gbSourceChannel2.Location = new System.Drawing.Point(11, 37);
            this.gbSourceChannel2.Margin = new System.Windows.Forms.Padding(0);
            this.gbSourceChannel2.Name = "gbSourceChannel2";
            this.gbSourceChannel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbSourceChannel2.Size = new System.Drawing.Size(322, 28);
            this.gbSourceChannel2.TabIndex = 19;
            this.gbSourceChannel2.TabStop = false;
            // 
            // lbChannel2
            // 
            this.lbChannel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbChannel2.AutoSize = true;
            this.lbChannel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbChannel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbChannel2.Location = new System.Drawing.Point(293, 9);
            this.lbChannel2.Name = "lbChannel2";
            this.lbChannel2.Size = new System.Drawing.Size(28, 17);
            this.lbChannel2.TabIndex = 9;
            this.lbChannel2.Text = "1/2";
            // 
            // rbn28
            // 
            this.rbn28.AutoSize = true;
            this.rbn28.Location = new System.Drawing.Point(10, 11);
            this.rbn28.Name = "rbn28";
            this.rbn28.Size = new System.Drawing.Size(14, 13);
            this.rbn28.TabIndex = 7;
            this.rbn28.Tag = "7";
            this.rbn28.UseVisualStyleBackColor = true;
            // 
            // rbn27
            // 
            this.rbn27.AutoSize = true;
            this.rbn27.Location = new System.Drawing.Point(45, 11);
            this.rbn27.Name = "rbn27";
            this.rbn27.Size = new System.Drawing.Size(14, 13);
            this.rbn27.TabIndex = 6;
            this.rbn27.Tag = "6";
            this.rbn27.UseVisualStyleBackColor = true;
            // 
            // rbn26
            // 
            this.rbn26.AutoSize = true;
            this.rbn26.Location = new System.Drawing.Point(80, 11);
            this.rbn26.Name = "rbn26";
            this.rbn26.Size = new System.Drawing.Size(14, 13);
            this.rbn26.TabIndex = 5;
            this.rbn26.Tag = "5";
            this.rbn26.UseVisualStyleBackColor = true;
            // 
            // rbn25
            // 
            this.rbn25.AutoSize = true;
            this.rbn25.Location = new System.Drawing.Point(115, 11);
            this.rbn25.Name = "rbn25";
            this.rbn25.Size = new System.Drawing.Size(14, 13);
            this.rbn25.TabIndex = 4;
            this.rbn25.Tag = "4";
            this.rbn25.UseVisualStyleBackColor = true;
            // 
            // rbn24
            // 
            this.rbn24.AutoSize = true;
            this.rbn24.Location = new System.Drawing.Point(150, 11);
            this.rbn24.Name = "rbn24";
            this.rbn24.Size = new System.Drawing.Size(14, 13);
            this.rbn24.TabIndex = 3;
            this.rbn24.Tag = "3";
            this.rbn24.UseVisualStyleBackColor = true;
            // 
            // rbn23
            // 
            this.rbn23.AutoSize = true;
            this.rbn23.Location = new System.Drawing.Point(185, 11);
            this.rbn23.Name = "rbn23";
            this.rbn23.Size = new System.Drawing.Size(14, 13);
            this.rbn23.TabIndex = 2;
            this.rbn23.Tag = "2";
            this.rbn23.UseVisualStyleBackColor = true;
            // 
            // rbn22
            // 
            this.rbn22.AutoSize = true;
            this.rbn22.Location = new System.Drawing.Point(220, 11);
            this.rbn22.Name = "rbn22";
            this.rbn22.Size = new System.Drawing.Size(14, 13);
            this.rbn22.TabIndex = 1;
            this.rbn22.Tag = "1";
            this.rbn22.UseVisualStyleBackColor = true;
            // 
            // rbn21
            // 
            this.rbn21.AutoSize = true;
            this.rbn21.Location = new System.Drawing.Point(254, 11);
            this.rbn21.Name = "rbn21";
            this.rbn21.Size = new System.Drawing.Size(14, 13);
            this.rbn21.TabIndex = 0;
            this.rbn21.Tag = "0";
            this.rbn21.UseVisualStyleBackColor = true;
            // 
            // gbSourceChannel1
            // 
            this.gbSourceChannel1.Controls.Add(this.lbChannel1);
            this.gbSourceChannel1.Controls.Add(this.rbn18);
            this.gbSourceChannel1.Controls.Add(this.rbn17);
            this.gbSourceChannel1.Controls.Add(this.rbn16);
            this.gbSourceChannel1.Controls.Add(this.rbn15);
            this.gbSourceChannel1.Controls.Add(this.rbn14);
            this.gbSourceChannel1.Controls.Add(this.rbn13);
            this.gbSourceChannel1.Controls.Add(this.rbn12);
            this.gbSourceChannel1.Controls.Add(this.rbn11);
            this.gbSourceChannel1.Location = new System.Drawing.Point(11, 9);
            this.gbSourceChannel1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.gbSourceChannel1.Name = "gbSourceChannel1";
            this.gbSourceChannel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbSourceChannel1.Size = new System.Drawing.Size(322, 28);
            this.gbSourceChannel1.TabIndex = 18;
            this.gbSourceChannel1.TabStop = false;
            // 
            // lbChannel1
            // 
            this.lbChannel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbChannel1.AutoSize = true;
            this.lbChannel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbChannel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbChannel1.Location = new System.Drawing.Point(293, 9);
            this.lbChannel1.Name = "lbChannel1";
            this.lbChannel1.Size = new System.Drawing.Size(28, 17);
            this.lbChannel1.TabIndex = 8;
            this.lbChannel1.Text = "1/1";
            // 
            // rbn18
            // 
            this.rbn18.AutoSize = true;
            this.rbn18.Location = new System.Drawing.Point(10, 11);
            this.rbn18.Name = "rbn18";
            this.rbn18.Size = new System.Drawing.Size(14, 13);
            this.rbn18.TabIndex = 7;
            this.rbn18.Tag = "7";
            this.rbn18.UseVisualStyleBackColor = true;
            // 
            // rbn17
            // 
            this.rbn17.AutoSize = true;
            this.rbn17.Location = new System.Drawing.Point(45, 11);
            this.rbn17.Name = "rbn17";
            this.rbn17.Size = new System.Drawing.Size(14, 13);
            this.rbn17.TabIndex = 6;
            this.rbn17.Tag = "6";
            this.rbn17.UseVisualStyleBackColor = true;
            // 
            // rbn16
            // 
            this.rbn16.AutoSize = true;
            this.rbn16.Location = new System.Drawing.Point(80, 11);
            this.rbn16.Name = "rbn16";
            this.rbn16.Size = new System.Drawing.Size(14, 13);
            this.rbn16.TabIndex = 5;
            this.rbn16.Tag = "5";
            this.rbn16.UseVisualStyleBackColor = true;
            // 
            // rbn15
            // 
            this.rbn15.AutoSize = true;
            this.rbn15.Location = new System.Drawing.Point(115, 11);
            this.rbn15.Name = "rbn15";
            this.rbn15.Size = new System.Drawing.Size(14, 13);
            this.rbn15.TabIndex = 4;
            this.rbn15.Tag = "4";
            this.rbn15.UseVisualStyleBackColor = true;
            // 
            // rbn14
            // 
            this.rbn14.AutoSize = true;
            this.rbn14.Location = new System.Drawing.Point(150, 11);
            this.rbn14.Name = "rbn14";
            this.rbn14.Size = new System.Drawing.Size(14, 13);
            this.rbn14.TabIndex = 3;
            this.rbn14.Tag = "3";
            this.rbn14.UseVisualStyleBackColor = true;
            // 
            // rbn13
            // 
            this.rbn13.AutoSize = true;
            this.rbn13.Location = new System.Drawing.Point(185, 11);
            this.rbn13.Name = "rbn13";
            this.rbn13.Size = new System.Drawing.Size(14, 13);
            this.rbn13.TabIndex = 2;
            this.rbn13.Tag = "2";
            this.rbn13.UseVisualStyleBackColor = true;
            // 
            // rbn12
            // 
            this.rbn12.AutoSize = true;
            this.rbn12.Location = new System.Drawing.Point(220, 11);
            this.rbn12.Name = "rbn12";
            this.rbn12.Size = new System.Drawing.Size(14, 13);
            this.rbn12.TabIndex = 1;
            this.rbn12.Tag = "1";
            this.rbn12.UseVisualStyleBackColor = true;
            // 
            // rbn11
            // 
            this.rbn11.AutoSize = true;
            this.rbn11.Location = new System.Drawing.Point(254, 11);
            this.rbn11.Name = "rbn11";
            this.rbn11.Size = new System.Drawing.Size(14, 13);
            this.rbn11.TabIndex = 0;
            this.rbn11.Tag = "0";
            this.rbn11.UseVisualStyleBackColor = true;
            // 
            // UCSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flPanel);
            this.Name = "UCSource";
            this.Size = new System.Drawing.Size(782, 80);
            this.flPanel.ResumeLayout(false);
            this.gbSource.ResumeLayout(false);
            this.gbSourceCtrl.ResumeLayout(false);
            this.gbSourceCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDeviceIconBox)).EndInit();
            this.gbSourceChannel2.ResumeLayout(false);
            this.gbSourceChannel2.PerformLayout();
            this.gbSourceChannel1.ResumeLayout(false);
            this.gbSourceChannel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flPanel;
        private GroupBox gbSource;
        private NAudio.Gui.Pot potVolume;
        private CheckBox chkEnableBox;
        private ComboBox cmDevicesBox;
        private PictureBox imgDeviceIconBox;
        private GroupBox gbSourceChannel2;
        private Label lbChannel2;
        private RadioButton rbn28;
        private RadioButton rbn27;
        private RadioButton rbn26;
        private RadioButton rbn25;
        private RadioButton rbn24;
        private RadioButton rbn23;
        private RadioButton rbn22;
        private RadioButton rbn21;
        private GroupBox gbSourceChannel1;
        private Label lbChannel1;
        private RadioButton rbn18;
        private RadioButton rbn17;
        private RadioButton rbn16;
        private RadioButton rbn15;
        private RadioButton rbn14;
        private RadioButton rbn13;
        private RadioButton rbn12;
        private RadioButton rbn11;
        private GroupBox gbSourceCtrl;
        private NAudio.Gui.VolumeMeter volumeMeter;
        private Label lbName;
    }
}
