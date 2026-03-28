namespace MakineYonetimSistemi
{
    partial class MainFormPersonel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnPerformans = new System.Windows.Forms.Button();
            this.btnRaporlar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.btnRaporlar);
            this.panel1.Controls.Add(this.btnPerformans);
            this.panel1.Controls.Add(this.btnCalendar);
            this.panel1.Controls.Add(this.btnMaintenance);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 681);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 60);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hoş geldin, Personel";
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1064, 621);
            this.pnlContent.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1064, 60);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(148, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hoş geldin, Personel!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "FabriTrack";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(969, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(200, 50);
            this.btnDashboard.TabIndex = 9;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDash_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMaintenance.FlatAppearance.BorderSize = 0;
            this.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenance.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnMaintenance.Location = new System.Drawing.Point(0, 50);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMaintenance.Size = new System.Drawing.Size(200, 50);
            this.btnMaintenance.TabIndex = 10;
            this.btnMaintenance.Text = "Bakım Arıza ";
            this.btnMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaintenance.UseVisualStyleBackColor = true;
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCalendar.FlatAppearance.BorderSize = 0;
            this.btnCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendar.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnCalendar.ForeColor = System.Drawing.Color.White;
            this.btnCalendar.Location = new System.Drawing.Point(0, 100);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCalendar.Size = new System.Drawing.Size(200, 50);
            this.btnCalendar.TabIndex = 11;
            this.btnCalendar.Text = "Takvim";
            this.btnCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalendar.UseVisualStyleBackColor = true;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // btnPerformans
            // 
            this.btnPerformans.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPerformans.FlatAppearance.BorderSize = 0;
            this.btnPerformans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerformans.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnPerformans.ForeColor = System.Drawing.Color.White;
            this.btnPerformans.Location = new System.Drawing.Point(0, 150);
            this.btnPerformans.Name = "btnPerformans";
            this.btnPerformans.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPerformans.Size = new System.Drawing.Size(200, 71);
            this.btnPerformans.TabIndex = 12;
            this.btnPerformans.Text = "Performans Metrikleri";
            this.btnPerformans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPerformans.UseVisualStyleBackColor = true;
            this.btnPerformans.Click += new System.EventHandler(this.btnPerformans_Click);
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRaporlar.FlatAppearance.BorderSize = 0;
            this.btnRaporlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaporlar.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnRaporlar.ForeColor = System.Drawing.Color.White;
            this.btnRaporlar.Location = new System.Drawing.Point(0, 221);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRaporlar.Size = new System.Drawing.Size(200, 50);
            this.btnRaporlar.TabIndex = 13;
            this.btnRaporlar.Text = "Raporlar";
            this.btnRaporlar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRaporlar.UseVisualStyleBackColor = true;
            this.btnRaporlar.Click += new System.EventHandler(this.btnRaporlar_Click);
            // 
            // MainFormPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainFormPersonel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Paneli";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnPerformans;
        private System.Windows.Forms.Button btnRaporlar;
    }
}