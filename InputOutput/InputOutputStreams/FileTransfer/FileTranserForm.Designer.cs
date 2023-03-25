namespace FileTransfer
{
    partial class FileTranserForm
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
            this.startBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.resumeBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.sourceLbl = new System.Windows.Forms.Label();
            this.destLbl = new System.Windows.Forms.Label();
            this.chooseSrcBtn = new System.Windows.Forms.Button();
            this.chooseDestBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(103, 79);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(265, 78);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(75, 23);
            this.pauseBtn.TabIndex = 1;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // resumeBtn
            // 
            this.resumeBtn.Location = new System.Drawing.Point(405, 77);
            this.resumeBtn.Name = "resumeBtn";
            this.resumeBtn.Size = new System.Drawing.Size(75, 23);
            this.resumeBtn.TabIndex = 2;
            this.resumeBtn.Text = "Resume";
            this.resumeBtn.UseVisualStyleBackColor = true;
            this.resumeBtn.Click += new System.EventHandler(this.resumeBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 273);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(578, 77);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // sourceLbl
            // 
            this.sourceLbl.AutoSize = true;
            this.sourceLbl.Location = new System.Drawing.Point(80, 13);
            this.sourceLbl.Name = "sourceLbl";
            this.sourceLbl.Size = new System.Drawing.Size(53, 16);
            this.sourceLbl.TabIndex = 5;
            this.sourceLbl.Text = "Source:";
            // 
            // destLbl
            // 
            this.destLbl.AutoSize = true;
            this.destLbl.Location = new System.Drawing.Point(83, 45);
            this.destLbl.Name = "destLbl";
            this.destLbl.Size = new System.Drawing.Size(74, 16);
            this.destLbl.TabIndex = 6;
            this.destLbl.Text = "Destination";
            // 
            // chooseSrcBtn
            // 
            this.chooseSrcBtn.Location = new System.Drawing.Point(568, 13);
            this.chooseSrcBtn.Name = "chooseSrcBtn";
            this.chooseSrcBtn.Size = new System.Drawing.Size(98, 23);
            this.chooseSrcBtn.TabIndex = 7;
            this.chooseSrcBtn.Text = "Choose Source";
            this.chooseSrcBtn.UseVisualStyleBackColor = true;
            this.chooseSrcBtn.Click += new System.EventHandler(this.chooseSrcBtn_Click);
            // 
            // chooseDestBtn
            // 
            this.chooseDestBtn.Location = new System.Drawing.Point(568, 37);
            this.chooseDestBtn.Name = "chooseDestBtn";
            this.chooseDestBtn.Size = new System.Drawing.Size(98, 23);
            this.chooseDestBtn.TabIndex = 8;
            this.chooseDestBtn.Text = "Destination";
            this.chooseDestBtn.UseVisualStyleBackColor = true;
            this.chooseDestBtn.Click += new System.EventHandler(this.chooseDestBtn_Click);
            // 
            // FileTranserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chooseDestBtn);
            this.Controls.Add(this.chooseSrcBtn);
            this.Controls.Add(this.destLbl);
            this.Controls.Add(this.sourceLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.resumeBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.startBtn);
            this.Name = "FileTranserForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button resumeBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label sourceLbl;
        private System.Windows.Forms.Label destLbl;
        private System.Windows.Forms.Button chooseSrcBtn;
        private System.Windows.Forms.Button chooseDestBtn;
    }
}

