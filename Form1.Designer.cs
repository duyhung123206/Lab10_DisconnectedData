namespace Lab10_DisconnectedData
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnSaveXml = new System.Windows.Forms.Button();
            this.btnReadXml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(743, 253);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(98, 343);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(86, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Chấp nhận";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.Form1_Load);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(286, 342);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Hoàn tác";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.Form1_Load);
            // 
            // btnSaveXml
            // 
            this.btnSaveXml.Location = new System.Drawing.Point(98, 395);
            this.btnSaveXml.Name = "btnSaveXml";
            this.btnSaveXml.Size = new System.Drawing.Size(75, 23);
            this.btnSaveXml.TabIndex = 3;
            this.btnSaveXml.Text = "Lưu XML";
            this.btnSaveXml.UseVisualStyleBackColor = true;
            this.btnSaveXml.Click += new System.EventHandler(this.btnSaveXml_Click);
            // 
            // btnReadXml
            // 
            this.btnReadXml.Location = new System.Drawing.Point(286, 395);
            this.btnReadXml.Name = "btnReadXml";
            this.btnReadXml.Size = new System.Drawing.Size(75, 23);
            this.btnReadXml.TabIndex = 4;
            this.btnReadXml.Text = "Đọc XML";
            this.btnReadXml.UseVisualStyleBackColor = true;
            this.btnReadXml.Click += new System.EventHandler(this.btnReadXml_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReadXml);
            this.Controls.Add(this.btnSaveXml);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnSaveXml;
        private System.Windows.Forms.Button btnReadXml;
    }
}

