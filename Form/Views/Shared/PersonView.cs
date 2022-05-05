using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restourantManagerForm.Views.Shared
{
    public partial class PersonView : Form
    {
        public PersonView()
        {
            InitializeComponent();
        }

        private void Person_Load(object sender, EventArgs e)
        {
            var p = new Models.Person();
            PanelAUD pnl = new PanelAUD(p,1);
           
         
        //    pnl.LoadPageAddControlsProperty(p);
            pnl.ShowDialog();
        }
    }
}
