/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
namespace MCM8.UC
{
    partial class UCASIO
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbAsio = new System.Windows.Forms.GroupBox();
            this.DeviceAsioOutBox = new System.Windows.Forms.ComboBox();
            this.rb8 = new System.Windows.Forms.RadioButton();
            this.labelAsioStatus = new System.Windows.Forms.Label();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb6 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbAsio.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Controls.Add(this.gbAsio);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 53);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MCM8.Properties.Resources.asio;
            this.pictureBox1.Location = new System.Drawing.Point(7, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // gbAsio
            // 
            this.gbAsio.Controls.Add(this.DeviceAsioOutBox);
            this.gbAsio.Controls.Add(this.rb8);
            this.gbAsio.Controls.Add(this.labelAsioStatus);
            this.gbAsio.Controls.Add(this.rb2);
            this.gbAsio.Controls.Add(this.rb6);
            this.gbAsio.Controls.Add(this.rb4);
            this.gbAsio.Location = new System.Drawing.Point(113, 6);
            this.gbAsio.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.gbAsio.Name = "gbAsio";
            this.gbAsio.Size = new System.Drawing.Size(675, 46);
            this.gbAsio.TabIndex = 0;
            this.gbAsio.TabStop = false;
            this.gbAsio.Text = "Channels Out";
            // 
            // DeviceAsioOutBox
            // 
            this.DeviceAsioOutBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceAsioOutBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeviceAsioOutBox.FormattingEnabled = true;
            this.DeviceAsioOutBox.Location = new System.Drawing.Point(6, 15);
            this.DeviceAsioOutBox.Name = "DeviceAsioOutBox";
            this.DeviceAsioOutBox.Size = new System.Drawing.Size(310, 23);
            this.DeviceAsioOutBox.TabIndex = 1;
            this.DeviceAsioOutBox.SelectedValueChanged += new System.EventHandler(this.DeviceAsioOutBox_SelectedValueChanged);
            // 
            // rb8
            // 
            this.rb8.AutoSize = true;
            this.rb8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb8.Location = new System.Drawing.Point(460, 17);
            this.rb8.Name = "rb8";
            this.rb8.Size = new System.Drawing.Size(30, 19);
            this.rb8.TabIndex = 3;
            this.rb8.TabStop = true;
            this.rb8.Tag = "8";
            this.rb8.Text = "8";
            this.rb8.UseVisualStyleBackColor = true;
            this.rb8.CheckedChanged += new System.EventHandler(this.rb8_CheckedChanged);
            // 
            // labelAsioStatus
            // 
            this.labelAsioStatus.AutoSize = true;
            this.labelAsioStatus.Location = new System.Drawing.Point(512, 19);
            this.labelAsioStatus.Name = "labelAsioStatus";
            this.labelAsioStatus.Size = new System.Drawing.Size(38, 15);
            this.labelAsioStatus.TabIndex = 3;
            this.labelAsioStatus.Text = "- off -";
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb2.Location = new System.Drawing.Point(349, 17);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(30, 19);
            this.rb2.TabIndex = 0;
            this.rb2.TabStop = true;
            this.rb2.Tag = "2";
            this.rb2.Text = "2";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // rb6
            // 
            this.rb6.AutoSize = true;
            this.rb6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb6.Location = new System.Drawing.Point(423, 17);
            this.rb6.Name = "rb6";
            this.rb6.Size = new System.Drawing.Size(30, 19);
            this.rb6.TabIndex = 2;
            this.rb6.TabStop = true;
            this.rb6.Tag = "6";
            this.rb6.Text = "6";
            this.rb6.UseVisualStyleBackColor = true;
            this.rb6.CheckedChanged += new System.EventHandler(this.rb6_CheckedChanged);
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb4.Location = new System.Drawing.Point(386, 17);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(30, 19);
            this.rb4.TabIndex = 1;
            this.rb4.TabStop = true;
            this.rb4.Tag = "4";
            this.rb4.Text = "4";
            this.rb4.UseVisualStyleBackColor = true;
            this.rb4.CheckedChanged += new System.EventHandler(this.rb4_CheckedChanged);
            // 
            // UCASIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UCASIO";
            this.Size = new System.Drawing.Size(800, 56);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbAsio.ResumeLayout(false);
            this.gbAsio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        private GroupBox gbAsio;
        private ComboBox DeviceAsioOutBox;
        private RadioButton rb8;
        private Label labelAsioStatus;
        private RadioButton rb2;
        private RadioButton rb6;
        private RadioButton rb4;
    }
}
