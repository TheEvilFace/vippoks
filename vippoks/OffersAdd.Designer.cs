namespace vippoks
{
    partial class OffersAdd
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.MaskedTextBox();
            this.client = new System.Windows.Forms.ComboBox();
            this.realtor = new System.Windows.Forms.ComboBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Подтвердить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Цена";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Клиент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Риелтор";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Тип";
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(101, 38);
            this.price.Name = "price";
            this.price.Mask = "#####.##";
            this.price.Size = new System.Drawing.Size(100, 20);
            this.price.TabIndex = 6;
            // 
            // client
            // 
            this.client.FormattingEnabled = true;
            this.client.Location = new System.Drawing.Point(101, 64);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(100, 21);
            this.client.TabIndex = 7;
            // 
            // realtor
            // 
            this.realtor.FormattingEnabled = true;
            this.realtor.Location = new System.Drawing.Point(101, 91);
            this.realtor.Name = "realtor";
            this.realtor.Size = new System.Drawing.Size(100, 21);
            this.realtor.TabIndex = 8;
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(101, 118);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(100, 21);
            this.type.TabIndex = 9;
            // 
            // OffersAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 244);
            this.Controls.Add(this.type);
            this.Controls.Add(this.realtor);
            this.Controls.Add(this.client);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "OffersAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OffersAdd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OffersAdd_FormClosing);
            this.Load += new System.EventHandler(this.OffersAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox price;
        private System.Windows.Forms.ComboBox client;
        private System.Windows.Forms.ComboBox realtor;
        private System.Windows.Forms.ComboBox type;
    }
}