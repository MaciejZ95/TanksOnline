using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline.ProjektPZ.Game
{
    using ProjectPZ.HttpListener;
    using Views;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var listener = new HttpListener();
            var room = listener.GetRoom().Result;

            Application.Run(new GameWindow(room, room.Players.First()));
            //Application.Run(new TestWindow());
        }
    }
}
