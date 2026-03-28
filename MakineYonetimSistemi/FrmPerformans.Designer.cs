namespace MakineYonetimSistemi
{
    partial class FrmPerformans
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
            this.flowMakineler = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSecilenMakine = new System.Windows.Forms.Label();
            this.panelAltKisim = new System.Windows.Forms.Panel();
            this.dgvMetrikler = new System.Windows.Forms.DataGridView();
            this.panelSagBilgi = new System.Windows.Forms.Panel();
            this.listBakimTarih = new System.Windows.Forms.ListBox();
            this.listBakimYapan = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAltKisim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetrikler)).BeginInit();
            this.panelSagBilgi.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowMakineler
            // 
            this.flowMakineler.AutoScroll = true;
            this.flowMakineler.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowMakineler.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowMakineler.Location = new System.Drawing.Point(0, 0);
            this.flowMakineler.Name = "flowMakineler";
            this.flowMakineler.Padding = new System.Windows.Forms.Padding(20);
            this.flowMakineler.Size = new System.Drawing.Size(1264, 350);
            this.flowMakineler.TabIndex = 0;
            // 
            // lblSecilenMakine
            // 
            this.lblSecilenMakine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSecilenMakine.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSecilenMakine.Location = new System.Drawing.Point(0, 350);
            this.lblSecilenMakine.Name = "lblSecilenMakine";
            this.lblSecilenMakine.Size = new System.Drawing.Size(1264, 60);
            this.lblSecilenMakine.TabIndex = 1;
            this.lblSecilenMakine.Text = "Detayları Görmek İçin Yukarıdan Bir Makine Seçiniz...";
            this.lblSecilenMakine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAltKisim
            // 
            this.panelAltKisim.Controls.Add(this.dgvMetrikler);
            this.panelAltKisim.Controls.Add(this.panelSagBilgi);
            this.panelAltKisim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAltKisim.Location = new System.Drawing.Point(0, 410);
            this.panelAltKisim.Name = "panelAltKisim";
            this.panelAltKisim.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panelAltKisim.Size = new System.Drawing.Size(1264, 271);
            this.panelAltKisim.TabIndex = 2;
            // 
            // dgvMetrikler
            // 
            this.dgvMetrikler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMetrikler.BackgroundColor = System.Drawing.Color.White;
            this.dgvMetrikler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetrikler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMetrikler.Location = new System.Drawing.Point(10, 0);
            this.dgvMetrikler.Name = "dgvMetrikler";
            this.dgvMetrikler.Size = new System.Drawing.Size(944, 261);
            this.dgvMetrikler.TabIndex = 1;
            // 
            // panelSagBilgi
            // 
            this.panelSagBilgi.Controls.Add(this.listBakimTarih);
            this.panelSagBilgi.Controls.Add(this.listBakimYapan);
            this.panelSagBilgi.Controls.Add(this.label2);
            this.panelSagBilgi.Controls.Add(this.label1);
            this.panelSagBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSagBilgi.Location = new System.Drawing.Point(954, 0);
            this.panelSagBilgi.Name = "panelSagBilgi";
            this.panelSagBilgi.Size = new System.Drawing.Size(300, 261);
            this.panelSagBilgi.TabIndex = 0;
            // 
            // listBakimTarih
            // 
            this.listBakimTarih.FormattingEnabled = true;
            this.listBakimTarih.Location = new System.Drawing.Point(161, 95);
            this.listBakimTarih.Name = "listBakimTarih";
            this.listBakimTarih.Size = new System.Drawing.Size(120, 95);
            this.listBakimTarih.TabIndex = 3;
            // 
            // listBakimYapan
            // 
            this.listBakimYapan.FormattingEnabled = true;
            this.listBakimYapan.Location = new System.Drawing.Point(18, 95);
            this.listBakimYapan.Name = "listBakimYapan";
            this.listBakimYapan.Size = new System.Drawing.Size(120, 95);
            this.listBakimYapan.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(204, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tarih";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Son Bakım Yapan";
            // 
            // FrmPerformans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelAltKisim);
            this.Controls.Add(this.lblSecilenMakine);
            this.Controls.Add(this.flowMakineler);
            this.Name = "FrmPerformans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performans Metrikleri ve Makine Durumları";
            this.panelAltKisim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetrikler)).EndInit();
            this.panelSagBilgi.ResumeLayout(false);
            this.panelSagBilgi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowMakineler;
        private System.Windows.Forms.Label lblSecilenMakine;
        private System.Windows.Forms.Panel panelAltKisim;
        private System.Windows.Forms.Panel panelSagBilgi;
        private System.Windows.Forms.DataGridView dgvMetrikler;
        private System.Windows.Forms.ListBox listBakimTarih;
        private System.Windows.Forms.ListBox listBakimYapan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}