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
            this.bulletBox = new System.Windows.Forms.PictureBox();
            this.heroBox = new System.Windows.Forms.PictureBox();
            this.bulletLabel = new System.Windows.Forms.Label();
            this.youDiedLabel = new System.Windows.Forms.Label();
            this.deathLabel = new System.Windows.Forms.Label();
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
            // bulletBox
            // 
            this.bulletBox.BackColor = System.Drawing.Color.Transparent;
            this.bulletBox.BackgroundImage = global::GameTemplateTest.Properties.Resources.Pixel_Bullet;
            this.bulletBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bulletBox.Location = new System.Drawing.Point(159, 502);
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
            // youDiedLabel
            // 
            this.youDiedLabel.AutoSize = true;
            this.youDiedLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.youDiedLabel.Font = new System.Drawing.Font("Mistral", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.youDiedLabel.Location = new System.Drawing.Point(597, 179);
            this.youDiedLabel.Name = "youDiedLabel";
            this.youDiedLabel.Size = new System.Drawing.Size(475, 171);
            this.youDiedLabel.TabIndex = 11;
            this.youDiedLabel.Text = "You Died";
            this.youDiedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.youDiedLabel.Visible = false;
            // 
            // deathLabel
            // 
            this.deathLabel.Location = new System.Drawing.Point(-16, -17);
            this.deathLabel.Name = "deathLabel";
            this.deathLabel.Size = new System.Drawing.Size(1685, 640);
            this.deathLabel.TabIndex = 15;
            this.deathLabel.Visible = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.deathLabel);
            this.Controls.Add(this.youDiedLabel);
            this.Controls.Add(this.heroBox);
            this.Controls.Add(this.bulletLabel);
            this.Controls.Add(this.bulletBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1653, 606);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bulletBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox bulletBox;
        private System.Windows.Forms.PictureBox heroBox;
        private System.Windows.Forms.Label bulletLabel;
        private System.Windows.Forms.Label youDiedLabel;
        private System.Windows.Forms.Label deathLabel;
    }
}
