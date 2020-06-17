namespace vippoks
{
    partial class DealsAdd
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
            this.need = new System.Windows.Forms.ComboBox();
            this.offer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sell = new System.Windows.Forms.Label();
            this.buy = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.realtorbuy = new System.Windows.Forms.Label();
            this.realtorsell = new System.Windows.Forms.Label();
            this.company = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // need
            // 
            this.need.FormattingEnabled = true;
            this.need.Location = new System.Drawing.Point(123, 53);
            this.need.Name = "need";
            this.need.Size = new System.Drawing.Size(177, 21);
            this.need.TabIndex = 36;
            // 
            // offer
            // 
            this.offer.FormattingEnabled = true;
            this.offer.Location = new System.Drawing.Point(123, 26);
            this.offer.Name = "offer";
            this.offer.Size = new System.Drawing.Size(177, 21);
            this.offer.TabIndex = 35;
            this.offer.SelectedIndexChanged += new System.EventHandler(this.offer_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Необходимо";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Предложение";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 206);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 42);
            this.button5.TabIndex = 32;
            this.button5.Text = "Подтвердить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(248, 206);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 42);
            this.button4.TabIndex = 31;
            this.button4.Text = "Отмена";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Коммисия для продавца";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Коммисия для покупателя";
            // 
            // sell
            // 
            this.sell.AutoSize = true;
            this.sell.Location = new System.Drawing.Point(214, 89);
            this.sell.Name = "sell";
            this.sell.Size = new System.Drawing.Size(0, 13);
            this.sell.TabIndex = 39;
            // 
            // buy
            // 
            this.buy.AutoSize = true;
            this.buy.Location = new System.Drawing.Point(214, 112);
            this.buy.Name = "buy";
            this.buy.Size = new System.Drawing.Size(0, 13);
            this.buy.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AccessibleName = "realtor";
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Оплата риелтора продавца";
            // 
            // label
            // 
            this.label.AccessibleName = "";
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(35, 133);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(155, 13);
            this.label.TabIndex = 42;
            this.label.Text = "Оплата риелтора покупателя";
            // 
            // label6
            // 
            this.label6.AccessibleName = "realtor";
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Оплата компании";
            // 
            // realtorbuy
            // 
            this.realtorbuy.AutoSize = true;
            this.realtorbuy.Location = new System.Drawing.Point(214, 133);
            this.realtorbuy.Name = "realtorbuy";
            this.realtorbuy.Size = new System.Drawing.Size(0, 13);
            this.realtorbuy.TabIndex = 45;
            // 
            // realtorsell
            // 
            this.realtorsell.AutoSize = true;
            this.realtorsell.Location = new System.Drawing.Point(214, 156);
            this.realtorsell.Name = "realtorsell";
            this.realtorsell.Size = new System.Drawing.Size(0, 13);
            this.realtorsell.TabIndex = 46;
            // 
            // company
            // 
            this.company.AutoSize = true;
            this.company.Location = new System.Drawing.Point(214, 178);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(0, 13);
            this.company.TabIndex = 47;
            // 
            // DealsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 260);
            this.Controls.Add(this.company);
            this.Controls.Add(this.realtorsell);
            this.Controls.Add(this.realtorbuy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buy);
            this.Controls.Add(this.sell);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.need);
            this.Controls.Add(this.offer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Name = "DealsAdd";
            this.Text = "DealsAdd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DealsAdd_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox need;
        private System.Windows.Forms.ComboBox offer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sell;
        private System.Windows.Forms.Label buy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label realtorbuy;
        private System.Windows.Forms.Label realtorsell;
        private System.Windows.Forms.Label company;
    }
}