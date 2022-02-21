using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT_BusProject
{
    public partial class FormShipping : UserControl
    {
        public FormShipping()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar1);
        }

        private void FormShipping_Load(object sender, EventArgs e)
        {
           //bunifuRadioButton1.Checked = true;
           //bunifuRadioButton4.Checked = true;
            bunifuDropdown2.SelectedIndex = 0;
            bunifuVScrollBar1.BorderRadius = 14;
            bunifuDatePicker1.MinDate = DateTime.Now.Date;
            this.Dock = DockStyle.Fill;
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {

        }
    }
}
