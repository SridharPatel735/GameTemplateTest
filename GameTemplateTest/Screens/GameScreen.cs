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
        //PictureBox zombieBox = new PictureBox();
        SoundPlayer song = new SoundPlayer(GameTemplateTest.Properties.Resources.fightMusic);
        //TODO create your global game variables here
        int heroX, heroY, heroWidth, heroSpeed, jumpHeight, bulletX, bulletY, bulletSpeed, bullets, heroHealth;
        int zombieY;
        int location;
        List<int> zombieX = new List<int>();
        List<int> zombSpeed = new List<int>();
        List<PictureBox> zombieBox = new List<PictureBox>();


        public GameScreen()
        {
            InitializeComponent();
            location = 0;
            for (int i = 0; i <= MainForm.zombCount; i++)
            {
                switch (MainForm.levelDifficult)
                {
                    case "Easy":
                        switch (randGen.Next(2, 5))
                        {
                            case 2:
                                zombSpeed[i].Add(2);
                                break;
                            case 3:
                                zombSpeed[i].Add(3);
                                break;
                            case 4:
                                zombSpeed[i].Add(4);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Medium":
                        zombSpeed.Add(i);
                        break;
                    case "Hard":
                        zombSpeed.Add(i);
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i <= MainForm.zombCount; i++)
            {
                zombieX.Add(this.Width + location);
                location = location + 150;
            }
            for (int i = 0; i <= MainForm.zombCount; i++)
            {
                zombieBox[i].Location = new Point(zombieX[i], 457);
                zombieBox[i].Size = new Size(100, 110);
                switch (randGen.Next(1, 3))
                {
                    case 1:
                        zombieBox[i].BackgroundImage = GameTemplateTest.Properties.Resources.Zombie_coat_left;
                        break;
                    case 2:
                        zombieBox[i].BackgroundImage = GameTemplateTest.Properties.Resources.Zombie_Shirt_left;
                        break;
                    default:
                        break;
                }
                zombieBox[i].BackgroundImageLayout = ImageLayout.Zoom;
                this.Controls.Add(zombieBox[i]);
            }
            InitializeGameValues();
        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method
            // each time you restart your game to reset all values.
            heroX = 0;
            heroY = 419;
            //zombieX = 1444;
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
            Rectangle bulletRec = new Rectangle(bulletX, bulletY, 19, 19);
            Rectangle heroRec = new Rectangle(heroX, heroY, 100, 163);

            for (int i = 0; i <= MainForm.zombCount; i++)
            {
                Rectangle zombieRec = new Rectangle(zombieX[i], zombieY, 100, 163);
                if (zombieRec.IntersectsWith(bulletRec))
                {
                    zombieBox[i].Dispose();
                    bulletX = this.Width;
                }
                if (heroRec.IntersectsWith(zombieRec))
                {
                    heroHealth--;
                    zombieX[i] = zombieX[i] + 200;
                    zombieBox[i].Location = new Point(zombieX[i], 163);
                    zombieRec.Location = new Point(zombieX[i], 163);
                }
            }
        }
        public void NPCMove()
        {
            //TODO move npc characters
            for (int i = 0; i <= MainForm.zombCount; i++)
            {
                if (zombieX[i] > heroX)
                {
                    zombieX[i] = zombieX[i] - MainForm.zombSpeed;
                }
                else if (zombieX[i] < heroX)
                {
                    zombieX[i] = zombieX[i] + MainForm.zombSpeed;
                }
                zombieBox[i].Location = new Point(zombieX[i], zombieY);
            }
        }

        public void HeroHealthCheck()
        {
            //Checks the hero's health
            if (heroHealth == 0)
            {
                //heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_dead;
                deathLabel.Visible = true;
                for (int i = 0; i <= 256; i = i + 5)
                {
                    deathLabel.BackColor = Color.FromArgb(i, 0, 0, 0);
                    //heroBox.BackColor = Color.FromArgb(i, 0, 0, 0);
                    Thread.Sleep(50);
                    Refresh();
                }
                youDiedLabel.Visible = true;
                for (int i = 0; i <= 256; i = i + 5)
                {
                    youDiedLabel.ForeColor = Color.FromArgb(i, 255, 0, 0);
                    Thread.Sleep(50);
                    Refresh();
                }
                Application.Exit();
            }
        }
    }
}