using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline.ProjektPZ.Game.Controls
{
    public partial class PauseMenu : UserControl
    {
        public PauseMenu()
        {
            InitializeComponent();
        }

        private void ExitGame_Click(object sender, EventArgs e)
        {
            // TODO RK: Docelowo ma to przerzucać do okien od Maćka
            Application.Exit();
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
