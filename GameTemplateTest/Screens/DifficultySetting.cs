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


        public DifficultySetting()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            MainForm.zombSpeed = 4;
            MainForm.levelDifficult = "Easy";
            MainForm.zombCount = 6;
            MainForm.ChangeScreen(this, "GameScreen");
        }
        private void mediumButton_Click(object sender, EventArgs e)
        {
            MainForm.zombSpeed = 6;
            MainForm.levelDifficult = "Medium";
            MainForm.zombCount = 7;
            MainForm.ChangeScreen(this, "GameScreen");
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            MainForm.zombSpeed = 8;
            MainForm.levelDifficult = "Hard";
            MainForm.zombCount = 8;
            MainForm.ChangeScreen(this, "GameScreen");
        }

    }
}
