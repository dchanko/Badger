namespace BadgerAddin2010.UI
{
    partial class BadgerPrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BadgerPrompt));
            this.btnEuropean = new System.Windows.Forms.Button();
            this.btnAmerican = new System.Windows.Forms.Button();
            this.btnHoney = new System.Windows.Forms.Button();
            this.btnDontCare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEuropean
            // 
            this.btnEuropean.Location = new System.Drawing.Point(12, 74);
            this.btnEuropean.Name = "btnEuropean";
            this.btnEuropean.Size = new System.Drawing.Size(75, 23);
            this.btnEuropean.TabIndex = 0;
            this.btnEuropean.Tag = "1";
            this.btnEuropean.Text = "European";
            this.btnEuropean.UseVisualStyleBackColor = true;
            this.btnEuropean.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnAmerican
            // 
            this.btnAmerican.Location = new System.Drawing.Point(93, 74);
            this.btnAmerican.Name = "btnAmerican";
            this.btnAmerican.Size = new System.Drawing.Size(75, 23);
            this.btnAmerican.TabIndex = 1;
            this.btnAmerican.Tag = "2";
            this.btnAmerican.Text = "American";
            this.btnAmerican.UseVisualStyleBackColor = true;
            this.btnAmerican.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnHoney
            // 
            this.btnHoney.Location = new System.Drawing.Point(174, 74);
            this.btnHoney.Name = "btnHoney";
            this.btnHoney.Size = new System.Drawing.Size(75, 23);
            this.btnHoney.TabIndex = 2;
            this.btnHoney.Tag = "3";
            this.btnHoney.Text = "Honey";
            this.btnHoney.UseVisualStyleBackColor = true;
            this.btnHoney.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDontCare
            // 
            this.btnDontCare.Location = new System.Drawing.Point(262, 74);
            this.btnDontCare.Name = "btnDontCare";
            this.btnDontCare.Size = new System.Drawing.Size(265, 23);
            this.btnDontCare.TabIndex = 3;
            this.btnDontCare.Tag = "0";
            this.btnDontCare.Text = "Honestly, I\'m just going through the motions.";
            this.btnDontCare.UseVisualStyleBackColor = true;
            this.btnDontCare.Click += new System.EventHandler(this.btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 52);
            this.label1.TabIndex = 4;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // BadgerPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 105);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDontCare);
            this.Controls.Add(this.btnHoney);
            this.Controls.Add(this.btnAmerican);
            this.Controls.Add(this.btnEuropean);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BadgerPrompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Badger?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEuropean;
        private System.Windows.Forms.Button btnAmerican;
        private System.Windows.Forms.Button btnHoney;
        private System.Windows.Forms.Button btnDontCare;
        private System.Windows.Forms.Label label1;
    }
}