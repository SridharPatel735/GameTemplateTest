namespace GameTemplateTest
{
    partial class DifficultySetting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DifficultySetting));
            this.easyButton = new System.Windows.Forms.Button();
            this.mediumButton = new System.Windows.Forms.Button();
            this.hardDifficulty = new System.Windows.Forms.Button();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // easyButton
            // 
            this.easyButton.BackColor = System.Drawing.Color.Maroon;
            this.easyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.easyButton.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyButton.Location = new System.Drawing.Point(556, 119);
            this.easyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(191, 80);
            this.easyButton.TabIndex = 0;
            this.easyButton.Text = "Walk in the Park";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // mediumButton
            // 
            this.mediumButton.BackColor = System.Drawing.Color.DarkRed;
            this.mediumButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mediumButton.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumButton.Location = new System.Drawing.Point(556, 256);
            this.mediumButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(191, 80);
            this.mediumButton.TabIndex = 1;
            this.mediumButton.Text = "I got this";
            this.mediumButton.UseVisualStyleBackColor = false;
            this.mediumButton.Click += new System.EventHandler(this.mediumButton_Click);
            // 
            // hardDifficulty
            // 
            this.hardDifficulty.BackColor = System.Drawing.Color.Maroon;
            this.hardDifficulty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hardDifficulty.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardDifficulty.Location = new System.Drawing.Point(556, 384);
            this.hardDifficulty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hardDifficulty.Name = "hardDifficulty";
            this.hardDifficulty.Size = new System.Drawing.Size(191, 80);
            this.hardDifficulty.TabIndex = 2;
            this.hardDifficulty.Text = "Watch me die";
            this.hardDifficulty.UseVisualStyleBackColor = false;
            this.hardDifficulty.Click += new System.EventHandler(this.hardButton_Click);
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.BackColor = System.Drawing.Color.Transparent;
            this.difficultyLabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyLabel.ForeColor = System.Drawing.Color.Maroon;
            this.difficultyLabel.Location = new System.Drawing.Point(3, 0);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(546, 344);
            this.difficultyLabel.TabIndex = 3;
            this.difficultyLabel.Text = "CHOOSE YOUR DIFFICULTY";
            // 
            // DifficultySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.hardDifficulty);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.easyButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DifficultySetting";
            this.Size = new System.Drawing.Size(857, 624);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button mediumButton;
        private System.Windows.Forms.Button hardDifficulty;
        private System.Windows.Forms.Label difficultyLabel;
    }
}
