using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; 

namespace GameTemplateTest
{
    public partial class DifficultySetting : UserControl
    {
        SoundPlayer song = new SoundPlayer(Properties.Resources.fightMusic);


        public DifficultySetting()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            MainForm.zombSpeed = 4;
            MainForm.zombCount = 6;
            MainForm.ChangeScreen(this, "GameScreen");
        }
        private void mediumButton_Click(object sender, EventArgs e)
        {
            MainForm.zombSpeed = 6;
            MainForm.zombCount = 8;
            MainForm.ChangeScreen(this, "GameScreen");
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            MainForm.zombSpeed = 8;
            MainForm.zombCount = 8;
            MainForm.ChangeScreen(this, "GameScreen");
        }

    }
}
