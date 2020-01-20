using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GameSystemServices;
using System.Diagnostics;
using GameTemplateTest;
using System.Media;
/// <summary>
/// Created by Sridhar, Calem, and Sammy
/// January 2020
/// We created a game using a game loop, this game brings everything we have learned in class all together.
/// </summary>

namespace GravityTest
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;
        Boolean isJumping = false;
        Boolean shot = false;
        Stopwatch reloadWatch = new Stopwatch();
        Stopwatch bulletDelayWatch = new Stopwatch();
        Random randGen = new Random();
        int jumpCounter = -1;
        string direction = "right";
        SoundPlayer song = new SoundPlayer(GameTemplateTest.Properties.Resources.fightMusic);
        int heroX, heroY, heroWidth, heroSpeed, jumpHeight, bulletX, bulletY, bulletSpeed, bullets, heroHealth;
        int zombieY;
        int movement;
        List<int> zombieXList = new List<int>();
        List<int> zombSpeedList = new List<int>();
        List<PictureBox> zombieList = new List<PictureBox>();


        public GameScreen()
        {
            InitializeComponent();
            InitializeGameValues();
        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method
            // each time you restart your game to reset all values.
            heroX = 0;
            heroY = 419;
            zombieY = 457;
            heroWidth = 100;
            heroSpeed = 10;
            jumpHeight = 20;
            bulletSpeed = 25;
            bulletX = this.Width;
            bulletY = this.Height;
            bullets = 30;
            bulletDelayWatch.Start();
            heroHealth = 5;
            movement = 0;
            switch(randGen.Next(1,3))
            {
                case 1:
                    this.BackgroundImage = GameTemplateTest.Properties.Resources.JungleBackground;
                    break;
                case 2:
                    this.BackgroundImage = GameTemplateTest.Properties.Resources.JungleBackground;
                    break;
            } 
            for (int i = 0; i <= MainForm.zombCount; i++)
            {
                switch (MainForm.levelDifficult)
                {
                    case "Easy":
                        switch (randGen.Next(3, 6))
                        {
                            case 3:
                                zombSpeedList.Add(3);
                                break;
                            case 4:
                                zombSpeedList.Add(4);
                                break;
                            case 5:
                                zombSpeedList.Add(5);
                                break;
                        }
                        break;
                    case "Medium":
                        switch (randGen.Next(5, 8))
                        {
                            case 5:
                                zombSpeedList.Add(5);
                                break;
                            case 6:
                                zombSpeedList.Add(6);
                                break;
                            case 7:
                                zombSpeedList.Add(7);
                                break;
                        }
                        break;
                    case "Hard":
                        switch (randGen.Next(7, 10))
                        {
                            case 7:
                                zombSpeedList.Add(7);
                                break;
                            case 8:
                                zombSpeedList.Add(8);
                                break;
                            case 9:
                                zombSpeedList.Add(9);
                                break;
                        }
                        break;
                }
            }
            for (int i = 0; i <= MainForm.zombCount; i++)
            {
                zombieXList.Add(this.Width + movement);
                movement = movement + 100;
            }
            for (int i = 0; i <= MainForm.zombCount; i++)
            {
                PictureBox zombieBox = new PictureBox();
                zombieBox.Location = new Point(zombieXList[i], 457);
                zombieBox.Size = new Size(100, 110);
                zombieBox.Visible = true;
                switch (randGen.Next(1, 3))
                {
                    case 1:
                        zombieBox.BackgroundImage = GameTemplateTest.Properties.Resources.Zombie_coat_left;
                        break;
                    case 2:
                        zombieBox.BackgroundImage = GameTemplateTest.Properties.Resources.Zombie_Shirt_left;
                        break;
                }
                zombieBox.BackgroundImageLayout = ImageLayout.Zoom;
                this.Controls.Add(zombieBox);
                zombieList.Add(zombieBox);
            }
            Thread.Sleep(5000);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // opens a pause screen is escape is pressed. Depending on what is pressed
            // on pause screen the program will either continue or exit to main menu
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (result == DialogResult.Abort)
                {
                    MainForm.ChangeScreen(this, "MenuScreen");
                }
            }

            //TODO - basic player 1 key down bools set below. Add remainging key down
            // required for player 1 or player 2 here.

            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    if (isJumping == false)
                    {
                        isJumping = true;
                    }
                    break;
                case Keys.Space:
                    spaceDown = true;
                    if (bulletDelayWatch.ElapsedMilliseconds >= 1900)
                    {
                        shot = true;
                        bulletDelayWatch.Stop();
                        bulletDelayWatch.Reset();
                    }
                    break;
                case Keys.M:
                    mDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO - basic player 1 key up bools set below. Add remainging key up
            // required for player 1 or player 2 here.

            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
            }
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Game Loop
            MoveHero();
            JumpHero();
            BulletMechanics();
            CollisionCheck();
            NPCMove();
            HeroHealthCheck();
            Refresh();
        }

        public void MoveHero()
        {
            //Moving the Hero
            if (leftArrowDown == true && heroX >= 0)
            {
                direction = "left";
                heroX = heroX - heroSpeed;
                heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_left;
            }

            if (rightArrowDown == true && heroX <= this.Width - heroWidth)
            {
                direction = "right";
                heroX = heroX + heroSpeed;
                heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_right;
            }

            heroBox.Location = new Point(heroX, heroY);
        }
        public void JumpHero()
        {
            //Junping mechanics
            if (heroY >= 65 && isJumping == true)
            {
                jumpCounter++;
                if (jumpCounter < 10)
                {
                    heroY = heroY - jumpHeight;
                    if (leftArrowDown == true && heroX >= 0)
                    {
                        direction = "left";
                        heroX = heroX - heroSpeed;
                        heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_left;
                    }

                    if (rightArrowDown == true && heroX <= this.Width - heroWidth)
                    {
                        direction = "right";
                        heroX = heroX + heroSpeed;
                        heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_right;
                    }
                    heroBox.Location = new Point(heroX, heroY);

                }
                else if (jumpCounter >= 10 && jumpCounter < 20)
                {
                    heroY = heroY + jumpHeight;
                    if (leftArrowDown == true && heroX >= 0)
                    {
                        direction = "left";
                        heroX = heroX - heroSpeed;
                        heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_left;
                    }

                    if (rightArrowDown == true && heroX <= this.Width - heroWidth)
                    {
                        direction = "right";
                        heroX = heroX + heroSpeed;
                        heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_right;
                    }
                    heroBox.Location = new Point(heroX, heroY);
                }
                else if (jumpCounter == 20)
                {
                    jumpCounter = -1;
                    heroY = 419;
                    isJumping = false;
                }
            }
        }

        public void BulletMechanics()
        {
            //bullet mechanics
            if (shot == true && bullets != 0)
            {
                shot = false;
                if (direction == "right")
                {
                    bulletX = heroX + 75;
                    bulletY = heroY + 75;
                    bullets--;
                    bulletLabel.Text = bullets + "";
                    bulletSpeed = 25;
                }
                else
                {
                    bulletX = heroX;
                    bulletY = heroY + 75;
                    bullets--;
                    bulletLabel.Text = bullets + "";
                    bulletSpeed = -25;
                }
                bulletDelayWatch.Start();
            }

            bulletX = bulletX + bulletSpeed;
            bulletBox.Location = new Point(bulletX, bulletY);

            if (bullets < 30 && mDown == true)
            {
                reloadWatch.Start();
            }

            if (reloadWatch.ElapsedMilliseconds >= 1000)
            {
                reloadWatch.Stop();
                bullets = 30;
                bulletLabel.Text = bullets + "";
                reloadWatch.Reset();
            }
        }
        public void CollisionCheck()
        {
            //TODO collisions checks 
            for (int i = 0; i < zombieXList.Count; i++)
            {
                if (zombieList[i].Bounds.IntersectsWith(bulletBox.Bounds))
                {
                    zombieList[i].Dispose();
                    zombSpeedList.RemoveAt(i);
                    zombieXList.RemoveAt(i);
                    bulletX = this.Width;
                    break;
                }
                if (heroBox.Bounds.IntersectsWith(zombieList[i].Bounds))
                {
                    heroHealth--;
                    healthLabel.Text = heroHealth + "";
                    zombieXList[i] = zombieXList[i] + 200;
                    zombieList[i].Location = new Point(zombieXList[i], 163);
                    break;
                }
            }
        }
        public void NPCMove()
        {
            //TODO move npc characters
            for (int i = 0; i < zombieXList.Count; i++)
            {
                if (zombieXList[i] > heroX)
                {
                    zombieXList[i] = zombieXList[i] - zombSpeedList[i];
                }
                else 
                {
                    zombieXList[i] = zombieXList[i] + zombSpeedList[i];
                }
                zombieList[i].Location = new Point(zombieXList[i], zombieY);
            }
        }

        public void HeroHealthCheck()
        {
            //Checks the hero's health
            if (heroHealth < 0)
            {
                healthLabel.Text = heroHealth + "";
                deathLabel.Visible = true;
                for (int i = 0; i <= 256; i = i + 5)
                {
                    deathLabel.BackColor = Color.FromArgb(i, 0, 0, 0);
                    Thread.Sleep(50);
                    Refresh();
                }
                youDiedLabel.Visible = true;
                for (int i = 0; i <= 256; i = i + 5)
                {
                    heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_dead;
                    //Graphics
                    youDiedLabel.ForeColor = Color.FromArgb(i, 255, 0, 0);
                    Thread.Sleep(50);
                    Refresh();
                }
                Application.Exit();
            }
        }
    }
}