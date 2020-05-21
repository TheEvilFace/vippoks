using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vippoks
{
    public partial class Главное_меню : Form
    {
        public Главное_меню()
        {
            InitializeComponent();
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client f1 = new client();
            f1.Show();
        }

        private void риелторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rieltor f1 = new rieltor();
            f1.Show();
        }

        private void недвижимостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realties f1 = new realties();
            f1.Show();
        }
    }
}
