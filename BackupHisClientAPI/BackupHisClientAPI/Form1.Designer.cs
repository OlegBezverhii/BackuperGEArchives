namespace BackupHisClientAPI
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.labelConn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtHistorianSRV = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDataStores = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvArchives = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.querybutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchives)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(325, 26);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 38);
            this.btnDisconnect.TabIndex = 25;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // labelConn
            // 
            this.labelConn.AutoSize = true;
            this.labelConn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelConn.Location = new System.Drawing.Point(100, 9);
            this.labelConn.Name = "labelConn";
            this.labelConn.Size = new System.Drawing.Size(61, 13);
            this.labelConn.TabIndex = 24;
            this.labelConn.Text = "Состояние";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Имя сервера";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(258, 26);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(61, 38);
            this.btnConnect.TabIndex = 22;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtHistorianSRV
            // 
            this.txtHistorianSRV.Location = new System.Drawing.Point(12, 26);
            this.txtHistorianSRV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHistorianSRV.Multiline = true;
            this.txtHistorianSRV.Name = "txtHistorianSRV";
            this.txtHistorianSRV.Size = new System.Drawing.Size(227, 38);
            this.txtHistorianSRV.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Data Store Name";
            // 
            // cmbDataStores
            // 
            this.cmbDataStores.FormattingEnabled = true;
            this.cmbDataStores.Location = new System.Drawing.Point(113, 77);
            this.cmbDataStores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDataStores.Name = "cmbDataStores";
            this.cmbDataStores.Size = new System.Drawing.Size(206, 21);
            this.cmbDataStores.TabIndex = 32;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Archive Details";
            // 
            // dgvArchives
            // 
            this.dgvArchives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchives.Location = new System.Drawing.Point(12, 129);
            this.dgvArchives.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvArchives.Name = "dgvArchives";
            this.dgvArchives.Size = new System.Drawing.Size(540, 128);
            this.dgvArchives.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Лог программы";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 290);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(388, 132);
            this.textBox1.TabIndex = 36;
            // 
            // querybutton
            // 
            this.querybutton.Location = new System.Drawing.Point(327, 77);
            this.querybutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.querybutton.Name = "querybutton";
            this.querybutton.Size = new System.Drawing.Size(73, 38);
            this.querybutton.TabIndex = 38;
            this.querybutton.Text = "Запросить";
            this.querybutton.UseVisualStyleBackColor = true;
            this.querybutton.Click += new System.EventHandler(this.querybutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 77);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 38);
            this.button1.TabIndex = 39;
            this.button1.Text = "Переместить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.querybutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dgvArchives);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbDataStores);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.labelConn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtHistorianSRV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Backup Historian Client API";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchives)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label labelConn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtHistorianSRV;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDataStores;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dgvArchives;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button querybutton;
        private System.Windows.Forms.Button button1;
    }
}

