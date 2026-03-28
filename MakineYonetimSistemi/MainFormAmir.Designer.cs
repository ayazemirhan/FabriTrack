namespace MakineYonetimSistemi
{
    partial class MainFormAmir
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnMyTeam = new System.Windows.Forms.Button();
            this.btnMyMachines = new System.Windows.Forms.Button();
            this.btnRaporlar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBakim = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.btnBakim);
            this.panel1.Controls.Add(this.btnRaporlar);
            this.panel1.Controls.Add(this.btnMyMachines);
            this.panel1.Controls.Add(this.btnMyTeam);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 681);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(220, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 60);
            this.panel2.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1044, 621);
            this.pnlContent.TabIndex = 3;
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
            this.btnDashboard.Size = new System.Drawing.Size(220, 50);
            this.btnDashboard.TabIndex = 4;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnMyTeam
            // 
            this.btnMyTeam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyTeam.FlatAppearance.BorderSize = 0;
            this.btnMyTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyTeam.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnMyTeam.ForeColor = System.Drawing.Color.White;
            this.btnMyTeam.Location = new System.Drawing.Point(0, 50);
            this.btnMyTeam.Name = "btnMyTeam";
            this.btnMyTeam.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMyTeam.Size = new System.Drawing.Size(220, 50);
            this.btnMyTeam.TabIndex = 5;
            this.btnMyTeam.Text = "Ekibim";
            this.btnMyTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyTeam.UseVisualStyleBackColor = true;
            this.btnMyTeam.Click += new System.EventHandler(this.btnMyTeam_Click);
            // 
            // btnMyMachines
            // 
            this.btnMyMachines.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyMachines.FlatAppearance.BorderSize = 0;
            this.btnMyMachines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyMachines.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnMyMachines.ForeColor = System.Drawing.Color.White;
            this.btnMyMachines.Location = new System.Drawing.Point(0, 100);
            this.btnMyMachines.Name = "btnMyMachines";
            this.btnMyMachines.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMyMachines.Size = new System.Drawing.Size(220, 50);
            this.btnMyMachines.TabIndex = 6;
            this.btnMyMachines.Text = "Sorumlu Makineler";
            this.btnMyMachines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyMachines.UseVisualStyleBackColor = true;
            this.btnMyMachines.Click += new System.EventHandler(this.btnMyMachines_Click);
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRaporlar.FlatAppearance.BorderSize = 0;
            this.btnRaporlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaporlar.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnRaporlar.ForeColor = System.Drawing.Color.White;
            this.btnRaporlar.Location = new System.Drawing.Point(0, 150);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRaporlar.Size = new System.Drawing.Size(220, 50);
            this.btnRaporlar.TabIndex = 7;
            this.btnRaporlar.Text = "Raporlar";
            this.btnRaporlar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRaporlar.UseVisualStyleBackColor = true;
            this.btnRaporlar.Click += new System.EventHandler(this.btnRaporlar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1044, 60);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(148, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hoş geldin, Amir!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "FabriTrack";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(969, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnBakim
            // 
            this.btnBakim.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBakim.FlatAppearance.BorderSize = 0;
            this.btnBakim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBakim.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnBakim.ForeColor = System.Drawing.Color.White;
            this.btnBakim.Location = new System.Drawing.Point(0, 200);
            this.btnBakim.Name = "btnBakim";
            this.btnBakim.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBakim.Size = new System.Drawing.Size(220, 50);
            this.btnBakim.TabIndex = 8;
            this.btnBakim.Text = "Bakım ve Onay";
            this.btnBakim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBakim.UseVisualStyleBackColor = true;
            this.btnBakim.Click += new System.EventHandler(this.btnBakim_Click);
            // 
            // MainFormAmir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainFormAmir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amir Paneli";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnMyTeam;
        private System.Windows.Forms.Button btnMyMachines;
        private System.Windows.Forms.Button btnRaporlar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBakim;
    }
}