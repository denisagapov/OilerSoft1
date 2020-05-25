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
    public partial class FormServices : Form
    {
        public FormServices()
        {
            InitializeComponent();
            ShowSpares();
            ShowServices();
            ShowClients();

        }
        void ShowClients()
        {
            comboBoxClient.Items.Clear();
            foreach (ClientSet clientsSet in Program.OilerDb.ClientSet)
            {
                string[] item = { clientsSet.Id.ToString() + ".", clientsSet.Name };
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }
        void Deductions()
        {
            textBoxPrice.Clear();
            if (comboBoxSpare.SelectedItem!=null)
            {
                SpareSet spareSet = Program.OilerDb.SpareSet.Find(Convert.ToInt32(comboBoxSpare.SelectedItem.ToString().Split('.')[0]));
                double Price = spareSet.Price * 1.5;
                textBoxPrice.Text = Price.ToString();
                if (textBoxDate.Text == "")
                {
                    textBoxDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
                }
            }
        }
        void ShowSpares()
        {
            comboBoxSpare.Items.Clear();
            foreach (SpareSet spareSet in Program.OilerDb.SpareSet)
            {
                string[] item = { spareSet.Id.ToString() + ".", spareSet.Name };
                comboBoxSpare.Items.Add(string.Join(" ", item));
            }
        }
        void ShowServices()
        {
            listViewServices.Items.Clear();
            foreach (Services servicesSet in Program.OilerDb.Services)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    servicesSet.Id.ToString(),servicesSet.ClientSet.Name,
                    servicesSet.SpareSet.Name, servicesSet.Description,
                    servicesSet.Price.ToString(),
                    servicesSet.Date.ToString("dd.MM.yyyy")
                });
                item.Tag = servicesSet;
                listViewServices.Items.Add(item);
            }
        }

        private void listViewServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewServices.SelectedItems.Count == 1)
            {
                Services servicesSet = listViewServices.SelectedItems[0].Tag as Services;
                comboBoxClient.SelectedIndex = comboBoxClient.FindString(servicesSet.IdClient.ToString());
                comboBoxSpare.SelectedIndex = comboBoxSpare.FindString(servicesSet.IdSpare.ToString());
                textBoxDescription.Text = servicesSet.Description;
                textBoxPrice.Text = servicesSet.Price.ToString();
                textBoxDate.Text = servicesSet.Date.ToString("dd.MM.yyyy");
            }
            else
            {
                comboBoxClient.SelectedItem = null;
                comboBoxSpare.SelectedItem = null;
                textBoxDescription.Text = "";
                textBoxPrice.Text = "";
                textBoxDate.Text = "";
            }
        }
        private void comboBoxSpare_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
             try
            {
                Services serviceSet = new Services();
                if (comboBoxClient.SelectedItem != null) { serviceSet.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]); }
                if (comboBoxSpare.SelectedItem != null) serviceSet.IdSpare = Convert.ToInt32(comboBoxSpare.SelectedItem.ToString().Split('.')[0]);
                if (textBoxPrice.Text != "") serviceSet.Price = Convert.ToDouble(textBoxPrice.Text);
                serviceSet.Date= Convert.ToDateTime(textBoxDate.Text);
                if (textBoxDescription.Text != "") serviceSet.Description = textBoxDescription.Text;
                Program.OilerDb.Services.Add(serviceSet);
                Program.OilerDb.SaveChanges();
                ShowServices();
            }
            catch
            { MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if ((comboBoxSpare.SelectedItem != null) && (textBoxDate.Text != "") && (comboBoxClient.SelectedItem!=null) 
                    && (textBoxPrice.Text!="")&&(textBoxPrice.Text!=""))
             
            {
                if (listViewServices.SelectedItems.Count == 1)
                {
                    Services serviceSet = listViewServices.SelectedItems[0].Tag as Services;
                    if (comboBoxClient.SelectedItem != null) { serviceSet.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]); }
                    if (comboBoxSpare.SelectedItem != null) serviceSet.IdSpare = Convert.ToInt32(comboBoxSpare.SelectedItem.ToString().Split('.')[0]);
                    if (textBoxPrice.Text != "") serviceSet.Price = Convert.ToDouble(textBoxPrice.Text);
                    if (textBoxDate.Text != "") serviceSet.Date = Convert.ToDateTime(textBoxDate.Text);
                    if (textBoxDescription.Text != "") serviceSet.Description = textBoxDescription.Text;
                    Program.OilerDb.SaveChanges();
                    ShowServices();
                }
                else
                {
                    MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewServices.SelectedItems.Count == 1)
                {
                    Services serviceSet = listViewServices.SelectedItems[0].Tag as Services;
                    Program.OilerDb.Services.Remove(serviceSet);
                    Program.OilerDb.SaveChanges();
                    ShowServices();
                }
                comboBoxClient.SelectedItem = null;
                comboBoxSpare.SelectedItem = null;
                textBoxDate.Text = "";
                textBoxDescription.Text = "";
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
