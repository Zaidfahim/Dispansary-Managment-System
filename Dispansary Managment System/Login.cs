using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace Dispansary_Managment_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_Username.Text == "")
            {
                MessageBox.Show("Enter The Username");
            }
            else if (txt_Password.Text == "")
            {
                MessageBox.Show("Enter The Password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");
                    SqlCommand cmd = new SqlCommand("select * from Tbl_login where username = @username and password = @password", con);
                    cmd.Parameters.AddWithValue("@username", txt_Username.Text);
                    cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();


                  da.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        switch(dt.Rows[0]["type"]as string)
                        {
                            case "Doctor":
                                {
                                    this.Hide();
                                    new Admin_Pannel().Show();
                                    MessageBox.Show("Login Successfull");
                                    break;
                                }
                            case "Receptionist":
                                { 
                                    this.Hide();
                                    new Receptionist_Panel().Show();
                                    MessageBox.Show("Login Successfull");
                                    break;
                                }
                            default: 
                                {
                                    MessageBox.Show("Enter Correct Username And Password");
                                    break;
                                }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Correct Username And Password");
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = true;
        }
    }
}
