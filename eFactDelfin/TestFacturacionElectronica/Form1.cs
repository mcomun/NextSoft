using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eFactDelfin;

namespace TestFacturacionElectronica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eFactDelfin.eFacturacionElectronica oFactElect = new eFacturacionElectronica();
            //DataTable dtFActuracion = oFactElect.ProcesarFacturacionElectronica("17125", "marcwc@gmail.com", "sistemas");
            DataTable dtFActuracion = oFactElect.ProcesarBajaFacturacionElectronica("10272", "sistemas");
            string ver = "";
        }
    }
}
