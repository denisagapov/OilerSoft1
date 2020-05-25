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
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
            ShowSpares();
            ShowOrder();
        }
        void Date()
        {
            if (textBoxDate.Text == "")
                textBoxDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
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
        void ShowOrder()
        {
            listViewOrders.Items.Clear();
            foreach (OrderSpareSet orderspare in Program.OilerDb.OrderSpareSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    orderspare.Id.ToString(), orderspare.SpareSet.Name,
                    orderspare.Date.ToString("dd.MM.yyyy")
                });
                item.Tag = orderspare;
                listViewOrders.Items.Add(item);
            }
        }
        private void listViewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 1)
            {
                OrderSpareSet orderSpare = listViewOrders.SelectedItems[0].Tag as OrderSpareSet;
                comboBoxSpare.SelectedIndex = comboBoxSpare.FindString(orderSpare.IdSpare.ToString());
                textBoxDate.Text = orderSpare.Date.ToString("dd.MM.yyyy");
            }
            else
            {
                comboBoxSpare.SelectedItem = null;
                textBoxDate.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OrderSpareSet orderSpare = new OrderSpareSet();
                if (comboBoxSpare.SelectedItem != null) { orderSpare.IdSpare = Convert.ToInt32(comboBoxSpare.SelectedItem.ToString().Split('.')[0]); }
                orderSpare.Date = Convert.ToDateTime(textBoxDate.Text);
                Program.OilerDb.OrderSpareSet.Add(orderSpare);
                Program.OilerDb.SaveChanges();
            }
            catch
            {
                { MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
                ShowOrder();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if ((comboBoxSpare.SelectedItem != null) && (textBoxDate.Text != ""))
            {
                if (listViewOrders.SelectedItems.Count == 1)
                {
                    OrderSpareSet orderSpare = listViewOrders.SelectedItems[0].Tag as OrderSpareSet;
                    if (comboBoxSpare.SelectedItem!=null) orderSpare.IdSpare = Convert.ToInt32(comboBoxSpare.SelectedItem.ToString().Split('.')[0]);
                    if (textBoxDate.Text!="") orderSpare.Date = Convert.ToDateTime(textBoxDate.Text);
                    Program.OilerDb.SaveChanges();
                    ShowOrder();
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
                if (listViewOrders.SelectedItems.Count == 1)
                {
                    OrderSpareSet orderSpare = listViewOrders.SelectedItems[0].Tag as OrderSpareSet;
                    Program.OilerDb.OrderSpareSet.Remove(orderSpare);
                    Program.OilerDb.SaveChanges();
                    ShowOrder();
                }
                comboBoxSpare.SelectedItem = null;
                textBoxDate.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxSpare_SelectedIndexChanged(object sender, EventArgs e)
        {
            Date();
        }
    }
}
