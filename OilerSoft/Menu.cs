using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
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
            if (FormAuthorization.users.type == "user")
            {
                buttonClient.Enabled = false;
            }
            labelUserInfo.Text = "Привет, "+FormAuthorization.users.login;
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

        private void buttonOrderSpare_Click(object sender, EventArgs e)
        {
            Form formOrder = new FormOrder();
            formOrder.Show();
        }

        private void buttonServices_Click(object sender, EventArgs e)
        {
            Form formServices = new FormServices();
            formServices.Show();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
            Form formAuthorization = new FormAuthorization();
            formAuthorization.Show();
        }
    }
}
