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
            MainForm.levelDifficult = "Easy";
            MainForm.zombCount = 8;
            MainForm.ChangeScreen(this, "GameScreen");
        }
        private void mediumButton_Click(object sender, EventArgs e)
        {
            MainForm.levelDifficult = "Medium";
            MainForm.zombCount = 9;
            MainForm.ChangeScreen(this, "GameScreen");
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            MainForm.levelDifficult = "Hard";
            MainForm.zombCount = 10;
            MainForm.ChangeScreen(this, "GameScreen");
        }

    }
}
