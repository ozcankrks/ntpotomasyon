namespace ProjeOdevim
{
    partial class frmsifremiunuttum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsifremiunuttum));
            this.btnsifremibul = new System.Windows.Forms.Button();
            this.txtkuladi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtgizsorcevabi = new System.Windows.Forms.TextBox();
            this.btnonayla = new System.Windows.Forms.Button();
            this.lblgizlis = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsifremibul
            // 
            this.btnsifremibul.Location = new System.Drawing.Point(96, 73);
            this.btnsifremibul.Name = "btnsifremibul";
            this.btnsifremibul.Size = new System.Drawing.Size(100, 23);
            this.btnsifremibul.TabIndex = 0;
            this.btnsifremibul.Text = "Şifremi Bul";
            this.btnsifremibul.UseVisualStyleBackColor = true;
            this.btnsifremibul.Click += new System.EventHandler(this.btnsifremibul_Click);
            // 
            // txtkuladi
            // 
            this.txtkuladi.Location = new System.Drawing.Point(96, 47);
            this.txtkuladi.Name = "txtkuladi";
            this.txtkuladi.Size = new System.Drawing.Size(100, 20);
            this.txtkuladi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Adınız :";
            // 
            // txtgizsorcevabi
            // 
            this.txtgizsorcevabi.Location = new System.Drawing.Point(12, 125);
            this.txtgizsorcevabi.Name = "txtgizsorcevabi";
            this.txtgizsorcevabi.Size = new System.Drawing.Size(184, 20);
            this.txtgizsorcevabi.TabIndex = 4;
            // 
            // btnonayla
            // 
            this.btnonayla.Location = new System.Drawing.Point(12, 152);
            this.btnonayla.Name = "btnonayla";
            this.btnonayla.Size = new System.Drawing.Size(184, 23);
            this.btnonayla.TabIndex = 5;
            this.btnonayla.Text = "Onayla";
            this.btnonayla.UseVisualStyleBackColor = true;
            this.btnonayla.Click += new System.EventHandler(this.btnonayla_Click);
            // 
            // lblgizlis
            // 
            this.lblgizlis.AutoSize = true;
            this.lblgizlis.Location = new System.Drawing.Point(9, 99);
            this.lblgizlis.Name = "lblgizlis";
            this.lblgizlis.Size = new System.Drawing.Size(37, 13);
            this.lblgizlis.TabIndex = 6;
            this.lblgizlis.Text = "----------";
            // 
            // btn
            // 
            this.btn.Image = ((System.Drawing.Image)(resources.GetObject("btn.Image")));
            this.btn.Location = new System.Drawing.Point(3, 2);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(84, 39);
            this.btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn.TabIndex = 18;
            this.btn.TabStop = false;
            this.btn.Click += new System.EventHandler(this.btngeri_Click);
            // 
            // frmsifremiunuttum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(233, 212);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.lblgizlis);
            this.Controls.Add(this.btnonayla);
            this.Controls.Add(this.txtgizsorcevabi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtkuladi);
            this.Controls.Add(this.btnsifremibul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmsifremiunuttum";
            this.Text = "Şifremi Unuttum";
            this.Load += new System.EventHandler(this.frmsifremiunuttum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsifremibul;
        private System.Windows.Forms.TextBox txtkuladi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtgizsorcevabi;
        private System.Windows.Forms.Button btnonayla;
        private System.Windows.Forms.Label lblgizlis;
        private System.Windows.Forms.PictureBox btn;
    }
}