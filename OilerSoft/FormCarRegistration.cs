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
    public partial class FormCarRegistration : Form
    {
        public FormCarRegistration()
        {
            InitializeComponent();
            ShowClients();
            ShowCar();
        }
        void ShowClients()
        {
            comboBoxClient.Items.Clear();
            foreach (ClientSet clientsSet in Program.OilerDb.ClientSet)
            {
                string[] item = { clientsSet.Id.ToString() + ".", clientsSet.Name};
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }
        void ShowCar()
        {
            listViewCarRegistration.Items.Clear();
            foreach (CarSet car in Program.OilerDb.CarSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    car.Id.ToString(), car.ClientSet.Id.ToString(),
                    car.ClientSet.Name,
                    car.Mark,car.Model,car.Year.ToString(),
                    car.Color,car.GosNumber,car.Engine,car.VinNumber

                });
                item.Tag = car;
                listViewCarRegistration.Items.Add(item);
            }
            listViewCarRegistration.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewCarRegistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCarRegistration.SelectedItems.Count == 1)
            {
                CarSet car = listViewCarRegistration.SelectedItems[0].Tag as CarSet;
                comboBoxClient.SelectedIndex = comboBoxClient.FindString(car.IdClient.ToString());
                textBoxMark.Text = car.Mark;
                textBoxModel.Text = car.Model;
                textBoxYear.Text = car.Year.ToString();
                textBoxColor.Text = car.Color;
                textBoxNumber.Text = car.GosNumber;
                textBoxEngine.Text = car.Engine;
                textBoxVin.Text = car.VinNumber;
            }
            else
            {
                comboBoxClient.SelectedItem = null;
                textBoxMark.Text = "";
                textBoxModel.Text = "";
                textBoxYear.Text = "";
                textBoxColor.Text = "";
                textBoxNumber.Text = "";
                textBoxEngine.Text = "";
                textBoxVin.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CarSet car = new CarSet();
                if (comboBoxClient.SelectedItem != null) { car.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]); }
                if (textBoxMark.Text != "") { car.Mark = textBoxMark.Text; }
                if (textBoxModel.Text != "") { car.Model = textBoxModel.Text; }
                if (textBoxYear.Text!= "") { car.Year = Convert.ToInt32(textBoxYear.Text); }
                if (textBoxColor.Text!=""){car.Color = textBoxColor.Text;}
                if (textBoxNumber.Text != "") car.GosNumber = textBoxNumber.Text;
                if (textBoxEngine.Text != "") { car.Engine = textBoxEngine.Text; }
                if (textBoxVin.Text != "") { car.VinNumber = textBoxVin.Text; }
                Program.OilerDb.CarSet.Add(car);
                Program.OilerDb.SaveChanges();
                ShowCar();
            }
            catch
            { MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if ((comboBoxClient.SelectedItem!=null)&&(textBoxMark.Text!="")&&(textBoxModel.Text!="")
                &&(textBoxYear.Text!="")&&(textBoxColor.Text!="")&&(textBoxNumber.Text!="")
                &&(textBoxEngine.Text!="") && (textBoxVin.Text!=""))               
            {
                if (listViewCarRegistration.SelectedItems.Count == 1)
                {
                    CarSet car = listViewCarRegistration.SelectedItems[0].Tag as CarSet;
                    car.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    car.Mark = textBoxMark.Text;
                    car.Model = textBoxModel.Text;
                    car.Year = Convert.ToInt32(textBoxYear.Text);
                    car.Color = textBoxColor.Text;
                    car.GosNumber = textBoxNumber.Text;
                    car.Engine = textBoxEngine.Text;
                    car.VinNumber = textBoxVin.Text;
                    Program.OilerDb.SaveChanges();
                    ShowCar();
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
                if (listViewCarRegistration.SelectedItems.Count == 1)
                {
                    CarSet car = listViewCarRegistration.SelectedItems[0].Tag as CarSet;
                    Program.OilerDb.CarSet.Remove(car);
                    Program.OilerDb.SaveChanges();
                    ShowCar();
                }
                comboBoxClient.SelectedItem = null;
                textBoxMark.Text = "";
                textBoxModel.Text = "";
                textBoxYear.Text = "";
                textBoxColor.Text = "";
                textBoxNumber.Text = "";
                textBoxEngine.Text = "";
                textBoxVin.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
