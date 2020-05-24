using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OilerSoft
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            Form formClients = new FormClients();
            formClients.Show();
        }

        private void buttonCarRegistration_Click(object sender, EventArgs e)
        {
            Form formCarRegistration = new FormCarRegistration();
            formCarRegistration.Show();
        }

        private void buttonSpare_Click(object sender, EventArgs e)
        {
            Form formSpare = new FormSpare();
            formSpare.Show();
        }
    }
}
