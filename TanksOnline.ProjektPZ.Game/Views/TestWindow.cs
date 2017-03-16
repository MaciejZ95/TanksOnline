using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace TanksOnline.ProjektPZ.Game.Views
{
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;

    public partial class TestWindow : Form
    {
        public TestWindow()
        {
            InitializeComponent();

            this.TankPreview.RunPreview();
        }

        private void Red_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.TankPreview.RED = byte.Parse(Red.Text);
            }
            catch (FormatException) { }
        }

        private void Green_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.TankPreview.GREEN = byte.Parse(Green.Text);
            }
            catch (FormatException) { }
        }

        private void Blue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.TankPreview.BLUE = byte.Parse(Blue.Text);
            }
            catch (FormatException) { }
        }
    }
}
