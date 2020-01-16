namespace GravityTest
{
    partial class GameScreen
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.zombieBox = new System.Windows.Forms.PictureBox();
            this.bulletBox = new System.Windows.Forms.PictureBox();
            this.heroBox = new System.Windows.Forms.PictureBox();
            this.bulletLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.zombieBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulletBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // zombieBox
            // 
            this.zombieBox.BackColor = System.Drawing.Color.Transparent;
            this.zombieBox.BackgroundImage = global::GameTemplateTest.Properties.Resources.Zombie_Shirt_left;
            this.zombieBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.zombieBox.Location = new System.Drawing.Point(338, 457);
            this.zombieBox.Name = "zombieBox";
            this.zombieBox.Size = new System.Drawing.Size(100, 111);
            this.zombieBox.TabIndex = 5;
            this.zombieBox.TabStop = false;
            // 
            // bulletBox
            // 
            this.bulletBox.BackColor = System.Drawing.Color.Red;
            this.bulletBox.Location = new System.Drawing.Point(142, 356);
            this.bulletBox.Name = "bulletBox";
            this.bulletBox.Size = new System.Drawing.Size(19, 19);
            this.bulletBox.TabIndex = 7;
            this.bulletBox.TabStop = false;
            // 
            // heroBox
            // 
            this.heroBox.BackColor = System.Drawing.Color.Transparent;
            this.heroBox.BackgroundImage = global::GameTemplateTest.Properties.Resources.marco_left;
            this.heroBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heroBox.Location = new System.Drawing.Point(0, 419);
            this.heroBox.Name = "heroBox";
            this.heroBox.Size = new System.Drawing.Size(100, 163);
            this.heroBox.TabIndex = 6;
            this.heroBox.TabStop = false;
            // 
            // bulletLabel
            // 
            this.bulletLabel.AutoSize = true;
            this.bulletLabel.Location = new System.Drawing.Point(366, 11);
            this.bulletLabel.Name = "bulletLabel";
            this.bulletLabel.Size = new System.Drawing.Size(51, 20);
            this.bulletLabel.TabIndex = 9;
            this.bulletLabel.Text = "label1";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GameTemplateTest.Properties.Resources.cityBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.bulletLabel);
            this.Controls.Add(this.heroBox);
            this.Controls.Add(this.bulletBox);
            this.Controls.Add(this.zombieBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1653, 606);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.zombieBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulletBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox zombieBox;
        private System.Windows.Forms.PictureBox bulletBox;
        private System.Windows.Forms.PictureBox heroBox;
        private System.Windows.Forms.Label bulletLabel;
    }
}
