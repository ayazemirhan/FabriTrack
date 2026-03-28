namespace MakineYonetimSistemi
{
    partial class UC_MyMachines
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMyMachines = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyMachines)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zimmetli Makinelerim";
            // 
            // dgvMyMachines
            // 
            this.dgvMyMachines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyMachines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyMachines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyMachines.Location = new System.Drawing.Point(0, 24);
            this.dgvMyMachines.Name = "dgvMyMachines";
            this.dgvMyMachines.Size = new System.Drawing.Size(1080, 636);
            this.dgvMyMachines.TabIndex = 1;
            // 
            // UC_MyMachines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMyMachines);
            this.Controls.Add(this.label1);
            this.Name = "UC_MyMachines";
            this.Size = new System.Drawing.Size(1080, 660);
            this.Load += new System.EventHandler(this.UC_MyMachines_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyMachines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMyMachines;
    }
}
