using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT_BusProject
{
    public partial class FormBooking : UserControl
    {
        
        public FormBooking()
        {
            InitializeComponent();

            
            // Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(bunifuDataGridView1, bunifuVScrollBar1);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
          
            
            this.Dock = DockStyle.Fill;
           // bunifuDataGridView1.ScrollBars = ScrollBars.Both;
           // bunifuDataGridView1.ColumnHeadersHeight = 38;
       
           

           
        }
     
       
      

        private void bunifuHScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuHScrollBar.ScrollEventArgs e)
        {
          
        }

        private void bunifuDataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
           
        }

        private void bunifuDataGridView1_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
               // bunifuHScrollBar1.Maximum = bunifuDataGridView1.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
