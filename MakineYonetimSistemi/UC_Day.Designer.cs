namespace MakineYonetimSistemi
{
    partial class UC_Day
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
            this.lblDay = new System.Windows.Forms.Label();
            this.lblJob = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDay.Location = new System.Drawing.Point(4, 4);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(19, 20);
            this.lblDay.TabIndex = 0;
            this.lblDay.Text = "1";
            // 
            // lblJob
            // 
            this.lblJob.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblJob.ForeColor = System.Drawing.Color.Red;
            this.lblJob.Location = new System.Drawing.Point(0, 75);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(148, 23);
            this.lblJob.TabIndex = 1;
            this.lblJob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_Day
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblDay);
            this.Name = "UC_Day";
            this.Size = new System.Drawing.Size(148, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblJob;
    }
}
