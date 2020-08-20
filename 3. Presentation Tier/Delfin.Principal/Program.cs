using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delfin.Principal
{
   static class Program
   {
      static public Splash frmSp;
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         #region [ Splash ]

         frmSp = new Splash();
         frmSp.Show();
         System.Threading.Thread.Sleep(1000);

         #endregion

         Application.Run(new MainWindow());
      }
   }
}
