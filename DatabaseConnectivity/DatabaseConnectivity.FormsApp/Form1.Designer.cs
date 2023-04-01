namespace DatabaseConnectivity.FormsApp
{
    partial class Form1
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
            this.gridEmployees = new System.Windows.Forms.DataGridView();
            this.gridLocations = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridEmployees
            // 
            this.gridEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmployees.Location = new System.Drawing.Point(0, 0);
            this.gridEmployees.Name = "gridEmployees";
            this.gridEmployees.RowHeadersWidth = 51;
            this.gridEmployees.Size = new System.Drawing.Size(371, 450);
            this.gridEmployees.TabIndex = 0;
            // 
            // gridLocations
            // 
            this.gridLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLocations.Location = new System.Drawing.Point(0, 0);
            this.gridLocations.Name = "gridLocations";
            this.gridLocations.RowHeadersWidth = 51;
            this.gridLocations.Size = new System.Drawing.Size(425, 450);
            this.gridLocations.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridEmployees);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridLocations);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 371;
            this.splitContainer1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocations)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridEmployees;
        private System.Windows.Forms.DataGridView gridLocations;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

