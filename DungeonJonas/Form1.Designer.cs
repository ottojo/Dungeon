namespace DungeonJonas
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
            this.button1 = new System.Windows.Forms.Button();
            this.progressBarHealth = new System.Windows.Forms.ProgressBar();
            this.textBoxInventar = new System.Windows.Forms.TextBox();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // progressBarHealth
            // 
            this.progressBarHealth.Location = new System.Drawing.Point(93, 387);
            this.progressBarHealth.Name = "progressBarHealth";
            this.progressBarHealth.Size = new System.Drawing.Size(100, 23);
            this.progressBarHealth.TabIndex = 1;
            // 
            // textBoxInventar
            // 
            this.textBoxInventar.Location = new System.Drawing.Point(738, 12);
            this.textBoxInventar.Multiline = true;
            this.textBoxInventar.Name = "textBoxInventar";
            this.textBoxInventar.ReadOnly = true;
            this.textBoxInventar.Size = new System.Drawing.Size(164, 398);
            this.textBoxInventar.TabIndex = 2;
            // 
            // textBoxCurrentItem
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(568, 347);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxCurrentItem";
            this.textBoxInfo.Size = new System.Drawing.Size(164, 63);
            this.textBoxInfo.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 422);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.textBoxInventar);
            this.Controls.Add(this.progressBarHealth);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBarHealth;
        private System.Windows.Forms.TextBox textBoxInventar;
        private System.Windows.Forms.TextBox textBoxInfo;
    }
}

