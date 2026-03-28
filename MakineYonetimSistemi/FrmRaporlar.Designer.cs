namespace MakineYonetimSistemi
{
    partial class FrmRaporlar
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlFiltre = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRaporTipi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.btnRaporla = new System.Windows.Forms.Button();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.pnlKartlar = new System.Windows.Forms.Panel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.chartRapor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvListe = new System.Windows.Forms.DataGridView();
            this.pnlFiltre.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlKartlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRapor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListe)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFiltre
            // 
            this.pnlFiltre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFiltre.Controls.Add(this.btnRaporla);
            this.pnlFiltre.Controls.Add(this.dtBitis);
            this.pnlFiltre.Controls.Add(this.label3);
            this.pnlFiltre.Controls.Add(this.dtBaslangic);
            this.pnlFiltre.Controls.Add(this.label2);
            this.pnlFiltre.Controls.Add(this.cmbRaporTipi);
            this.pnlFiltre.Controls.Add(this.label1);
            this.pnlFiltre.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFiltre.Location = new System.Drawing.Point(964, 0);
            this.pnlFiltre.Name = "pnlFiltre";
            this.pnlFiltre.Size = new System.Drawing.Size(300, 681);
            this.pnlFiltre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rapor Tipi";
            // 
            // cmbRaporTipi
            // 
            this.cmbRaporTipi.FormattingEnabled = true;
            this.cmbRaporTipi.Location = new System.Drawing.Point(107, 54);
            this.cmbRaporTipi.Name = "cmbRaporTipi";
            this.cmbRaporTipi.Size = new System.Drawing.Size(121, 21);
            this.cmbRaporTipi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Başlangıç Tarihi";
            // 
            // dtBaslangic
            // 
            this.dtBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBaslangic.Location = new System.Drawing.Point(107, 101);
            this.dtBaslangic.Name = "dtBaslangic";
            this.dtBaslangic.Size = new System.Drawing.Size(121, 20);
            this.dtBaslangic.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // dtBitis
            // 
            this.dtBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBitis.Location = new System.Drawing.Point(107, 143);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(121, 20);
            this.dtBitis.TabIndex = 5;
            // 
            // btnRaporla
            // 
            this.btnRaporla.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRaporla.ForeColor = System.Drawing.Color.White;
            this.btnRaporla.Location = new System.Drawing.Point(107, 186);
            this.btnRaporla.Name = "btnRaporla";
            this.btnRaporla.Size = new System.Drawing.Size(75, 40);
            this.btnRaporla.TabIndex = 6;
            this.btnRaporla.Text = "Raporla";
            this.btnRaporla.UseVisualStyleBackColor = false;
            this.btnRaporla.Click += new System.EventHandler(this.btnRaporla_Click);
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.White;
            this.pnlDashboard.Controls.Add(this.dgvListe);
            this.pnlDashboard.Controls.Add(this.chartRapor);
            this.pnlDashboard.Controls.Add(this.pnlKartlar);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(964, 681);
            this.pnlDashboard.TabIndex = 1;
            // 
            // pnlKartlar
            // 
            this.pnlKartlar.Controls.Add(this.lbl4);
            this.pnlKartlar.Controls.Add(this.lbl3);
            this.pnlKartlar.Controls.Add(this.lbl2);
            this.pnlKartlar.Controls.Add(this.lbl1);
            this.pnlKartlar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKartlar.Location = new System.Drawing.Point(0, 0);
            this.pnlKartlar.Name = "pnlKartlar";
            this.pnlKartlar.Size = new System.Drawing.Size(964, 100);
            this.pnlKartlar.TabIndex = 0;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl1.Location = new System.Drawing.Point(28, 46);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(0, 24);
            this.lbl1.TabIndex = 0;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl2.Location = new System.Drawing.Point(250, 46);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(0, 24);
            this.lbl2.TabIndex = 1;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl3.Location = new System.Drawing.Point(442, 46);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(0, 24);
            this.lbl3.TabIndex = 2;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl4.Location = new System.Drawing.Point(609, 46);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(0, 24);
            this.lbl4.TabIndex = 3;
            // 
            // chartRapor
            // 
            chartArea6.Name = "ChartArea1";
            this.chartRapor.ChartAreas.Add(chartArea6);
            this.chartRapor.Dock = System.Windows.Forms.DockStyle.Top;
            legend6.Name = "Legend1";
            this.chartRapor.Legends.Add(legend6);
            this.chartRapor.Location = new System.Drawing.Point(0, 100);
            this.chartRapor.Name = "chartRapor";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartRapor.Series.Add(series6);
            this.chartRapor.Size = new System.Drawing.Size(964, 300);
            this.chartRapor.TabIndex = 1;
            this.chartRapor.Text = "chart1";
            // 
            // dgvListe
            // 
            this.dgvListe.BackgroundColor = System.Drawing.Color.White;
            this.dgvListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListe.Location = new System.Drawing.Point(0, 400);
            this.dgvListe.Name = "dgvListe";
            this.dgvListe.Size = new System.Drawing.Size(964, 281);
            this.dgvListe.TabIndex = 2;
            // 
            // FrmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.pnlFiltre);
            this.Name = "FrmRaporlar";
            this.Text = "FrmRaporlar";
            this.Load += new System.EventHandler(this.FrmRaporlar_Load);
            this.pnlFiltre.ResumeLayout(false);
            this.pnlFiltre.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlKartlar.ResumeLayout(false);
            this.pnlKartlar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRapor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFiltre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtBaslangic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRaporTipi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRaporla;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Panel pnlKartlar;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRapor;
        private System.Windows.Forms.DataGridView dgvListe;
    }
}