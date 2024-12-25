namespace DocumentsProtector
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trackBar1 = new TrackBar();
            label1 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            label2 = new Label();
            trackBarWatermarkSize = new TrackBar();
            radioButtonLeft = new RadioButton();
            radioButtonCentre = new RadioButton();
            radioButtonRight = new RadioButton();
            label3 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            btn_watermark = new Button();
            pictureBox1 = new PictureBox();
            btn_AddSourcesFiles = new Button();
            listBoxSourcesFiles = new ListBox();
            label4 = new Label();
            btn_Clear = new Button();
            btn_ResultFolder = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarWatermarkSize).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 2;
            trackBar1.Location = new Point(6, 50);
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(321, 50);
            trackBar1.TabIndex = 0;
            trackBar1.Value = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Name = "label1";
            label1.Size = new Size(52, 17);
            label1.TabIndex = 1;
            label1.Text = "Opacity";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(543, 472);
            button1.Name = "button1";
            button1.Size = new Size(83, 25);
            button1.TabIndex = 2;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(350, 205);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(84, 21);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "GrayScale";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 103);
            label2.Name = "label2";
            label2.Size = new Size(98, 17);
            label2.TabIndex = 5;
            label2.Text = "Watermark Size";
            // 
            // trackBarWatermarkSize
            // 
            trackBarWatermarkSize.LargeChange = 2;
            trackBarWatermarkSize.Location = new Point(6, 132);
            trackBarWatermarkSize.Maximum = 3;
            trackBarWatermarkSize.Name = "trackBarWatermarkSize";
            trackBarWatermarkSize.Size = new Size(321, 50);
            trackBarWatermarkSize.TabIndex = 4;
            trackBarWatermarkSize.Value = 1;
            // 
            // radioButtonLeft
            // 
            radioButtonLeft.AutoSize = true;
            radioButtonLeft.Location = new Point(6, 205);
            radioButtonLeft.Name = "radioButtonLeft";
            radioButtonLeft.Size = new Size(47, 21);
            radioButtonLeft.TabIndex = 6;
            radioButtonLeft.Text = "Left";
            radioButtonLeft.UseVisualStyleBackColor = true;
            // 
            // radioButtonCentre
            // 
            radioButtonCentre.AutoSize = true;
            radioButtonCentre.Location = new Point(113, 205);
            radioButtonCentre.Name = "radioButtonCentre";
            radioButtonCentre.Size = new Size(64, 21);
            radioButtonCentre.TabIndex = 7;
            radioButtonCentre.Text = "Center";
            radioButtonCentre.UseVisualStyleBackColor = true;
            // 
            // radioButtonRight
            // 
            radioButtonRight.AutoSize = true;
            radioButtonRight.Checked = true;
            radioButtonRight.Location = new Point(220, 205);
            radioButtonRight.Name = "radioButtonRight";
            radioButtonRight.Size = new Size(56, 21);
            radioButtonRight.TabIndex = 8;
            radioButtonRight.TabStop = true;
            radioButtonRight.Text = "Right";
            radioButtonRight.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 185);
            label3.Name = "label3";
            label3.Size = new Size(104, 17);
            label3.TabIndex = 9;
            label3.Text = "Watermark Align";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btn_watermark);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(trackBar1);
            groupBox1.Controls.Add(radioButtonRight);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(radioButtonCentre);
            groupBox1.Controls.Add(trackBarWatermarkSize);
            groupBox1.Controls.Add(radioButtonLeft);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(614, 234);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // btn_watermark
            // 
            btn_watermark.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_watermark.Location = new Point(448, 185);
            btn_watermark.Name = "btn_watermark";
            btn_watermark.Size = new Size(160, 25);
            btn_watermark.TabIndex = 15;
            btn_watermark.Text = "Change Watermark";
            btn_watermark.UseVisualStyleBackColor = true;
            btn_watermark.Click += btn_watermark_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.ImageLocation = "";
            pictureBox1.Location = new Point(448, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // btn_AddSourcesFiles
            // 
            btn_AddSourcesFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_AddSourcesFiles.Location = new Point(9, 472);
            btn_AddSourcesFiles.Name = "btn_AddSourcesFiles";
            btn_AddSourcesFiles.Size = new Size(86, 25);
            btn_AddSourcesFiles.TabIndex = 11;
            btn_AddSourcesFiles.Text = "Add Files";
            btn_AddSourcesFiles.UseVisualStyleBackColor = true;
            btn_AddSourcesFiles.Click += btn_AddSourcesFiles_Click;
            // 
            // listBoxSourcesFiles
            // 
            listBoxSourcesFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxSourcesFiles.FormattingEnabled = true;
            listBoxSourcesFiles.ItemHeight = 17;
            listBoxSourcesFiles.Location = new Point(12, 269);
            listBoxSourcesFiles.Name = "listBoxSourcesFiles";
            listBoxSourcesFiles.SelectionMode = SelectionMode.MultiExtended;
            listBoxSourcesFiles.Size = new Size(614, 191);
            listBoxSourcesFiles.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 249);
            label4.Name = "label4";
            label4.Size = new Size(83, 17);
            label4.TabIndex = 13;
            label4.Text = "Sources Files";
            // 
            // btn_Clear
            // 
            btn_Clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Clear.Location = new Point(101, 472);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(122, 25);
            btn_Clear.TabIndex = 14;
            btn_Clear.Text = "Remove Selected";
            btn_Clear.UseVisualStyleBackColor = true;
            btn_Clear.Click += btn_Clear_Click;
            // 
            // btn_ResultFolder
            // 
            btn_ResultFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_ResultFolder.Location = new Point(229, 472);
            btn_ResultFolder.Name = "btn_ResultFolder";
            btn_ResultFolder.Size = new Size(139, 25);
            btn_ResultFolder.TabIndex = 15;
            btn_ResultFolder.Text = "Open Output Folder";
            btn_ResultFolder.UseVisualStyleBackColor = true;
            btn_ResultFolder.Click += btn_ResultFolder_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 509);
            Controls.Add(btn_ResultFolder);
            Controls.Add(btn_Clear);
            Controls.Add(label4);
            Controls.Add(listBoxSourcesFiles);
            Controls.Add(btn_AddSourcesFiles);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            MinimumSize = new Size(654, 550);
            Name = "Form1";
            Text = "Documents Protector";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarWatermarkSize).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private Label label1;
        private Button button1;
        private CheckBox checkBox1;
        private Label label2;
        private TrackBar trackBarWatermarkSize;
        private RadioButton radioButtonLeft;
        private RadioButton radioButtonCentre;
        private RadioButton radioButtonRight;
        private Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private Button btn_AddSourcesFiles;
        private ListBox listBoxSourcesFiles;
        private Label label4;
        private Button btn_Clear;
        private Button btn_ResultFolder;
        private PictureBox pictureBox1;
        private Button btn_watermark;
    }
}
