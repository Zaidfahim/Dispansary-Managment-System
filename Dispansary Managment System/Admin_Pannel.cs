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
    public partial class Admin_Pannel : Form
    {
        public Admin_Pannel()
        {
            InitializeComponent();
        }

        private void Admin_Pannel_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle= FormBorderStyle.None;
            home1.BringToFront();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
     
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMax.Visible = false;
            BtnNom.Location = BtnMax.Location;
            BtnNom.Visible = true;
            
            
        }

        private void BtnNom_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnNom.Visible = false;
            BtnMax.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
       
        private void btnhome_Click(object sender, EventArgs e)
        {
            home1.Visible = true;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = false;
            patient_Report1.Visible = false;
            consultation_Report1.Visible = false;
            paayment_Details1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            consultation1.Visible = true;
            home1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = false;
            patient_Report1.Visible = false;
            consultation_Report1.Visible = false;
            paayment_Details1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = true;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = false;
            patient_Report1.Visible = false;
            consultation_Report1.Visible = false;
            paayment_Details1.Visible = false;

        }

        private void btnAppoinment_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = true;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = false;
            patient_Report1.Visible = false;
            consultation_Report1.Visible = false;
            paayment_Details1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = true;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = false;
            patient_Report1.Visible = false;
            consultation_Report1.Visible = false;
            paayment_Details1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = false;
            patient_Report1.Visible = false;
            consultation_Report1.Visible = false;
            paayment_Details1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = true;
            stock_Report1.Visible = false;
            patient_Report1.Visible = false;
            consultation_Report1.Visible = false;
            paayment_Details1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = true;
            patient_Report1.Visible = false;
            consultation_Report1.Visible = false;
            paayment_Details1.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = false;
            patient_Report1.Visible = true;
            consultation_Report1.Visible = false;
            paayment_Details1.Visible = false;
 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            paayment_Details1.Visible = true;
            home1.Visible = false;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = false;
            patient_Report1.Visible = false;
            consultation_Report1.Visible = false;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            consultation_Report1.Visible = true;
            home1.Visible = false;
            consultation1.Visible = false;
            patient_Search_And_Register1.Visible = false;
            appoinment1.Visible = false;
            diagnose_And_Deliver1.Visible = false;
            stock_maintenance1.Visible = false;
            stock_Report1.Visible = false;
            patient_Report1.Visible = false;
            paayment_Details1.Visible = false;
        }
    }
}
