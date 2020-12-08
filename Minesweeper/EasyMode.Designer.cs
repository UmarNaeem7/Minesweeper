namespace Minesweeper
{
    partial class EasyMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyMode));
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreCount = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.scoreCount);
            this.buttonsPanel.Controls.Add(this.resetButton);
            this.buttonsPanel.Controls.Add(this.scoreLabel);
            this.buttonsPanel.Location = new System.Drawing.Point(30, 40);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(386, 367);
            this.buttonsPanel.TabIndex = 0;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(33, 29);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(48, 15);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Score:";
            // 
            // scoreCount
            // 
            this.scoreCount.AutoSize = true;
            this.scoreCount.Location = new System.Drawing.Point(87, 31);
            this.scoreCount.Name = "scoreCount";
            this.scoreCount.Size = new System.Drawing.Size(0, 13);
            this.scoreCount.TabIndex = 2;
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.resetButton.Location = new System.Drawing.Point(173, 19);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(33, 36);
            this.resetButton.TabIndex = 3;
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // EasyMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 429);
            this.Controls.Add(this.buttonsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EasyMode";
            this.Text = "EasyMode";
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreCount;
        private System.Windows.Forms.Button resetButton;
    }
}