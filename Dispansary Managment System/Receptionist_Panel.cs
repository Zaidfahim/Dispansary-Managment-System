using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dispansary_Managment_System
{
    public partial class Receptionist_Panel : Form
    {
        public Receptionist_Panel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to Logout", "Logout Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var newForm = new Login();
                newForm.Show();
                this.Hide();
            }
        }

        private void Receptionist_Panel_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            home1.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNom_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnNom.Visible = false;
            BtnMax.Visible = true;
        }

        private void BtnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMax.Visible = false;
            BtnNom.Location = BtnMax.Location;
            BtnNom.Visible = true;
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            home1.Visible = true;
            appoinment1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            medicine_Prescription1.Visible = false;
            medicine_Delivery_Prescription1.Visible = false;
            stock_maintenance1.Visible = false;
        }

        private void btnAppoinment_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            appoinment1.Visible = true;
            patient_Search_And_Register1.Visible = false;
            medicine_Prescription1.Visible = false;
            medicine_Delivery_Prescription1.Visible = false;
            stock_maintenance1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            appoinment1.Visible = false;
            patient_Search_And_Register1.Visible = true;
            medicine_Prescription1.Visible = false;
            medicine_Delivery_Prescription1.Visible = false;
            stock_maintenance1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            appoinment1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            medicine_Prescription1.Visible = true;
            medicine_Delivery_Prescription1.Visible = false;
            stock_maintenance1.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            appoinment1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            medicine_Prescription1.Visible = false;
            medicine_Delivery_Prescription1.Visible = true;
            stock_maintenance1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            appoinment1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            medicine_Prescription1.Visible = false;
            medicine_Delivery_Prescription1.Visible = false;
            stock_maintenance1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            appoinment1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            medicine_Prescription1.Visible = false;
            medicine_Delivery_Prescription1.Visible = false;
            stock_maintenance1.Visible = true;
        }
    }
}
