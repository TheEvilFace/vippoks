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
            pictureBox2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client f1 = new Client();
            f1.Show();
        }

        private void риелторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Realtor f1 = new Realtor();
            f1.Show();
        }

        private void недвижимостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Realties f1 = new Realties();
            f1.Show();
        }

        private void предложенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Offers f = new Offers();
            f.Show();
        }

        private void потребностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Needs f = new Needs();
            f.Show();
        }

        private void Главное_меню_Load(object sender, EventArgs e)
        {

        }

        private void сделкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deals f = new Deals();
            f.Show();
        }
    }
}
