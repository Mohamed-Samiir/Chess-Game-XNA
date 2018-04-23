namespace Chess
{
    partial class PromotionForm
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
            this.queenbtn = new System.Windows.Forms.Button();
            this.rookbtn = new System.Windows.Forms.Button();
            this.bishopbtn = new System.Windows.Forms.Button();
            this.knightbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // queenbtn
            // 
            this.queenbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.queenbtn.Location = new System.Drawing.Point(86, 118);
            this.queenbtn.Name = "queenbtn";
            this.queenbtn.Size = new System.Drawing.Size(92, 87);
            this.queenbtn.TabIndex = 0;
            this.queenbtn.UseVisualStyleBackColor = true;
            this.queenbtn.Click += new System.EventHandler(this.queenbtn_Click);
            // 
            // rookbtn
            // 
            this.rookbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rookbtn.Location = new System.Drawing.Point(227, 118);
            this.rookbtn.Name = "rookbtn";
            this.rookbtn.Size = new System.Drawing.Size(92, 87);
            this.rookbtn.TabIndex = 1;
            this.rookbtn.UseVisualStyleBackColor = true;
            this.rookbtn.Click += new System.EventHandler(this.rookbtn_Click);
            // 
            // bishopbtn
            // 
            this.bishopbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bishopbtn.Location = new System.Drawing.Point(374, 118);
            this.bishopbtn.Name = "bishopbtn";
            this.bishopbtn.Size = new System.Drawing.Size(92, 87);
            this.bishopbtn.TabIndex = 2;
            this.bishopbtn.UseVisualStyleBackColor = true;
            this.bishopbtn.Click += new System.EventHandler(this.bishopbtn_Click);
            // 
            // knightbtn
            // 
            this.knightbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.knightbtn.Location = new System.Drawing.Point(515, 118);
            this.knightbtn.Name = "knightbtn";
            this.knightbtn.Size = new System.Drawing.Size(92, 87);
            this.knightbtn.TabIndex = 3;
            this.knightbtn.UseVisualStyleBackColor = true;
            this.knightbtn.Click += new System.EventHandler(this.knightbtn_Click);
            // 
            // PromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 368);
            this.Controls.Add(this.knightbtn);
            this.Controls.Add(this.bishopbtn);
            this.Controls.Add(this.rookbtn);
            this.Controls.Add(this.queenbtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromotionForm";
            this.Text = "PromotionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button queenbtn;
        private System.Windows.Forms.Button rookbtn;
        private System.Windows.Forms.Button bishopbtn;
        private System.Windows.Forms.Button knightbtn;
    }
}