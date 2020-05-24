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
    public partial class FormClients : Form
    {
        public FormClients()
        {
            InitializeComponent();
            ShowClient();
        }

        private void listViewClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewClients.SelectedItems.Count == 1)
            {
                ClientSet clientSet = listViewClients.SelectedItems[0].Tag as ClientSet;
                textBoxName.Text = clientSet.Name;
                textBoxAddress.Text = clientSet.Address;
                textBoxPhone.Text = clientSet.Phone;
            }
            else
            {
                textBoxName.Text = "";
                textBoxAddress.Text = "";
                textBoxPhone.Text = "";
            }
        }
        void ShowClient()
        {
            listViewClients.Items.Clear();
            foreach (ClientSet clientsSet in Program.OilerDb.ClientSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    clientsSet.Id.ToString(), clientsSet.Name, 
                    clientsSet.Address, clientsSet.Phone
                });
                item.Tag = clientsSet;
                listViewClients.Items.Add(item);
            }
            listViewClients.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClientSet clientSet = new ClientSet();
                if (textBoxName.Text != "") { clientSet.Name = textBoxName.Text; }
                if (textBoxAddress.Text != "") { clientSet.Address = textBoxAddress.Text; }
                if (textBoxPhone.Text != "") { clientSet.Phone = textBoxPhone.Text; }
                Program.OilerDb.ClientSet.Add(clientSet);
                Program.OilerDb.SaveChanges();
                ShowClient();
            }
            catch
            {
                MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxAddress.Text != "" && textBoxPhone.Text != "")
            { 
                if (listViewClients.SelectedItems.Count == 1)
                {
                    ClientSet clientSet = listViewClients.SelectedItems[0].Tag as ClientSet;
                    clientSet.Name = textBoxName.Text;
                    clientSet.Address = textBoxAddress.Text;
                    clientSet.Phone = textBoxPhone.Text;
                    Program.OilerDb.SaveChanges();
                    ShowClient();
                }
            }
            else
            { MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewClients.SelectedItems.Count == 1)
                {
                    ClientSet clientSet = listViewClients.SelectedItems[0].Tag as ClientSet;
                    Program.OilerDb.ClientSet.Remove(clientSet);
                    Program.OilerDb.SaveChanges();
                    ShowClient();
                }
                textBoxName.Text = "";
                textBoxAddress.Text = "";
                textBoxPhone.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }
    }
}

