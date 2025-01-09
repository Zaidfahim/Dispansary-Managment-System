using System.Data;
using System.Data.SqlClient;

namespace Dispansary_Managment_System
{

    public partial class Patient_Search_And_Register : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");
        string Gen;

        public Patient_Search_And_Register()
        {
            InitializeComponent();
            patient_ID();
            
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Patient_Search_And_Register_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
        }
        private void patient_ID()
        {
       
                con.Open();
                SqlCommand cmd = new SqlCommand("select MAX(p_id) from Tbl_registrations", con);
                var maxid = cmd.ExecuteScalar() as string;
               
                if (maxid == null)
                {
                    lbl_pid.Text = "P-000001";
                }

                else
                {
                    int intval = int.Parse(maxid.Substring(2, 6));
                    intval++;
                    lbl_pid.Text = string.Format("P-{0:000000}", intval);

                }
                con.Close();
                



        } // Arrange patient-ID In Order

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "")
            {
                MessageBox.Show("Enter Your Name");
            }
            else if (txt_age.Text == "")
            {
                MessageBox.Show("Enter Your Age");
            }
            else if (radioButton_male.Checked == false && radioButton_female.Checked == false)  
            {
                MessageBox.Show("Select The Gender");
            }
            else if (txt_address.Text == "")
            {
                MessageBox.Show("Enter Your Address");
            }
            else if (!txt_phone.Text.All(char.IsDigit) || txt_phone.Text.Length != 10)
            {
                MessageBox.Show("Enter A Valid 10 Digit Phone Number");
            }
           
            else 
            {
                con.Open();
                 SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_registrations WHERE p_id = '" + lbl_pid.Text + "'", con);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 da.Fill(ds);
                 int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                    MessageBox.Show("Patient ID " + lbl_pid.Text + " Already Exists");
                    con.Close();
                    btn_clear_Click(sender, e);
                    }

                    else
                    {
                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("insert  into Tbl_registrations values (@p_id,@date,@p_name,@age,@gender,@address,@phone)", con);
                        cmd.Parameters.AddWithValue("@p_id", lbl_pid.Text);
                        cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker1.Text));
                        cmd.Parameters.AddWithValue("@p_name", txt_name.Text);
                        cmd.Parameters.AddWithValue("@age", int.Parse(txt_age.Text));
                        cmd.Parameters.AddWithValue("@gender", Gen);
                        cmd.Parameters.AddWithValue("@address", txt_address.Text);
                        cmd.Parameters.AddWithValue("@phone", int.Parse(txt_phone.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Registered");
                        con.Close();
                        btn_clear_Click(sender, e);
                        patient_ID();
                        
                    }
                

            }
        }// Register Patient 

        private void btn_clear_Click(object sender, EventArgs e) 
        {
            txt_name.Clear();
            txt_age.Clear();
            txt_address.Clear();
            txt_phone.Clear();
            radioButton_female.Checked = false;
            radioButton_male.Checked = false;
            patient_ID();
            dataGridView1.DataSource = null;

        } // clear Button

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox5.Text.All(char.IsDigit) || textBox5.Text.Length != 10)
            {
                MessageBox.Show("Enter The 10 Digit Phone Number To Search");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from  Tbl_registrations  where phone = '" + textBox5.Text + "'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Patient not registered");
                    textBox5.Clear();
                }
                con.Close();
            }
        } //Enter Phone Number To Search

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            lbl_pid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_age.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_address.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_phone.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            string Gen = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (Gen == "Male")
            {
                radioButton_male.Checked = true;
            }
            else
                radioButton_female.Checked = true;



        } // DataGridView Codes

        private void radioButton_male_CheckedChanged(object sender, EventArgs e)
        {
            Gen = "Male"; 
        }

        private void radioButton_female_CheckedChanged(object sender, EventArgs e)
        {
            Gen = "Female";
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_age.Text=="" || txt_address.Text=="" || txt_name.Text == "" || txt_phone.Text==""|| radioButton_male.Text=="" || radioButton_female.Text=="")
            {
                MessageBox.Show(" Search your Details To Alter It..  ");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Tbl_registrations set phone= '" + txt_phone.Text + "',p_name= '" + txt_name.Text + "', age= '" + txt_age.Text+ "', address= '" + txt_address.Text + "',gender= '"+Gen+"' where  p_id= '" + this.lbl_pid.Text+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated Your Details");
                

                con.Open();
                SqlCommand selectCmd = new SqlCommand("SELECT * FROM Tbl_registrations WHERE p_id = '" + lbl_pid.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(selectCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;


            }
        } // Alter Details

    
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Search the Patient to Select And Delete The Details");
            }

            else if (MessageBox.Show("Do You Want To Delete The Registration Details?", "Delete Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from Tbl_registrations where p_id =  '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and  phone = '" + textBox5.Text + "'", con);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                con.Close();
                MessageBox.Show("Details Deleted Successfuly");
                btn_clear_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Your Registration Details Is Not Deleted", "Delete Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        } //Delete Registration

        private void lbl_pid_Click(object sender, EventArgs e)
        {

        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_clear_Click(sender, e);
        }

        private void txt_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
