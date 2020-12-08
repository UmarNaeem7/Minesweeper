using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var easyForm = new EasyMode();
            easyForm.Closed += (s, args) => this.Close();
            easyForm.Show();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
