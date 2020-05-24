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
    public partial class FormSpare : Form
    {
        public FormSpare()
        {
            InitializeComponent();
            ShowCars();
            ShowSpare();
        }
        void ShowCars()
        {
            comboBoxCar.Items.Clear();
            foreach (CarSet carSet in Program.OilerDb.CarSet)
            {
                string[] item = { carSet.Id.ToString() + ".", carSet.Mark + " " + carSet.Model };
                comboBoxCar.Items.Add(string.Join(" ", item));
            }
        }
        void ShowSpare()
        {
            listViewSpare.Items.Clear();
            foreach (SpareSet spareSet in Program.OilerDb.SpareSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    spareSet.Id.ToString(),
                    spareSet.CarSet.Mark + " " + spareSet.CarSet.Model,
                    spareSet.Name, 
                    spareSet.Maker,
                    spareSet.Count.ToString(), spareSet.Price.ToString()
                });
                item.Tag = spareSet;
                listViewSpare.Items.Add(item);
            }
            listViewSpare.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SpareSet spareSet = new SpareSet();
                if (comboBoxCar.SelectedItem != null) { spareSet.IdCar = Convert.ToInt32(comboBoxCar.SelectedItem.ToString().Split('.')[0]); }
                if (textBoxNameSpare.Text != "") { spareSet.Name = textBoxNameSpare.Text; }
                if (textBoxMaker.Text != "") { spareSet.Maker = textBoxMaker.Text; }
                if (textBoxCount.Text != "") { spareSet.Count = Convert.ToInt32(textBoxCount.Text); }
                if (textBoxPrice.Text != "") { spareSet.Price = Convert.ToDouble(textBoxPrice.Text); }
                Program.OilerDb.SpareSet.Add(spareSet);
                Program.OilerDb.SaveChanges();
                ShowSpare();
            }
            catch
            { MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if ((comboBoxCar.SelectedItem != null) && (textBoxNameSpare.Text != "") && (textBoxMaker.Text != "")
                && (textBoxCount.Text != "") && (textBoxPrice.Text != ""))
            {
                if (listViewSpare.SelectedItems.Count == 1)
                {
                    SpareSet spareSet = listViewSpare.SelectedItems[0].Tag as SpareSet;
                    spareSet.IdCar = Convert.ToInt32(comboBoxCar.SelectedItem.ToString().Split('.')[0]);
                    spareSet.Name = textBoxNameSpare.Text;
                    spareSet.Maker = textBoxMaker.Text;
                    spareSet.Count = Convert.ToInt32(textBoxCount.Text);
                    spareSet.Price = Convert.ToDouble(textBoxPrice.Text);
                    Program.OilerDb.SaveChanges();
                    ShowSpare();
                }
            }
            else
            {
                MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewSpare.SelectedItems.Count == 1)
                {
                    SpareSet spareSet = listViewSpare.SelectedItems[0].Tag as SpareSet;
                    Program.OilerDb.SpareSet.Remove(spareSet);
                    Program.OilerDb.SaveChanges();
                    ShowSpare();
                }
                comboBoxCar.SelectedItem = null;
                textBoxNameSpare.Text = "";
                textBoxMaker.Text = "";
                textBoxCount.Text = "";
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewSpare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSpare.SelectedItems.Count == 1)
            {
                SpareSet spareSet = listViewSpare.SelectedItems[0].Tag as SpareSet;
                comboBoxCar.SelectedIndex = comboBoxCar.FindString(spareSet.IdCar.ToString());
                textBoxNameSpare.Text = spareSet.Name;
                textBoxMaker.Text = spareSet.Maker;
                textBoxCount.Text = spareSet.Count.ToString();
                textBoxPrice.Text = spareSet.Price.ToString();
            }
            else
            {
                comboBoxCar.SelectedItem = null;
                textBoxNameSpare.Text = "";
                textBoxMaker.Text = "";
                textBoxCount.Text = "";
                textBoxPrice.Text = "";
            }
        }
    }
}
