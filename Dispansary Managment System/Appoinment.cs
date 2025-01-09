using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;


namespace Dispansary_Managment_System
{

    public partial class Appoinment : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");

        public Appoinment()
        {
            InitializeComponent();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void search_the_make()
        {
            if (comboBox1.Text == "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_appoinments  where app_date = '" + this.Appoinment_Date.Value.ToString("MM/dd/yyyy") + "'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                assending_data();

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_appoinments where time_slot = '" + comboBox1.Text + "' and app_date = '" + this.Appoinment_Date.Value.ToString("MM/dd/yyyy") + "'", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                assending_data();


            }
        }

        private void assending_data()
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        } //Data In Assendind order

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txt_AppNo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Appoinment_Date.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Age.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_PhoneNo.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_AppNo.Text == "")
            {
                MessageBox.Show("Enter A Appoinment Number");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Select A Time Slot");
            }
            else if (txt_Name.Text == "")
            {
                MessageBox.Show("Enter The Patient Name");
            }
            else if (txt_Age.Text == "")
            {
                MessageBox.Show("Enter The Age");
            }
            else if (!txt_PhoneNo.Text.All(char.IsDigit) || txt_PhoneNo.Text.Length != 10)
            {
                MessageBox.Show("Enter A Valid 10 Digit Phone Number");
            }

            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from Tbl_appoinments where phone=@phone and name=@name", con);
                cmd.Parameters.AddWithValue("@phone", int.Parse(txt_PhoneNo.Text));
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                if (count > 0)
                {
                    MessageBox.Show("This appointment already exists for this patient");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("insert  into Tbl_appoinments values (@app_No,@app_date,@time_slot,@name,@age,@phone)", con);
                    cmd.Parameters.AddWithValue("@app_No", int.Parse(txt_AppNo.Text));
                    cmd.Parameters.AddWithValue("@app_date", DateTime.Parse(Appoinment_Date.Text));
                    cmd.Parameters.AddWithValue("@time_slot", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                    cmd.Parameters.AddWithValue("@age", int.Parse(txt_Age.Text));
                    cmd.Parameters.AddWithValue("@phone", int.Parse(txt_PhoneNo.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Made Your Appoinment");
                    con.Close();
                    button6_Click(sender, e);
                    search_the_make();
                }
            }


        } // Make appoinment

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_appoinments  where app_date = '" + this.dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                assending_data();

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_appoinments where time_slot = '" + comboBox2.Text + "' and app_date = '" + this.dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                assending_data();


            }
        } // Search with date and time_slot 
        private void Appoinment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_AppNo.Text == "" || comboBox1.Text == "" || txt_Name.Text == "" || txt_PhoneNo.Text == "" )
            {
                MessageBox.Show("Search / Enter the Patient Details to Cancel the Appoinment");
            }
           
            else if (MessageBox.Show("Do You Want To Cancel The Appoinment", "Cancel Appoinment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from Tbl_appoinments where app_No =  '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and  phone = '" + txt_PhoneNo.Text + "' and time_slot = '" + comboBox1.Text + "' and app_date = '" + this.Appoinment_Date.Value.ToString("MM/dd/yyyy") + "'", con);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                con.Close();
                MessageBox.Show("Appoinment Cancelled Successfuly");
                button6_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Your Appoinment Is Not Cancelled", "Cancel Appoinment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           

        } // Select perticular row to cancel apponment

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text == "" && txt_AppNo.Text == "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_appoinments where app_date = '" + this.Appoinment_Date.Value.ToString("MM/dd/yyyy") + "'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                assending_data();
                con.Close();
            }
            else if (txt_AppNo.Text == "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_appoinments where time_slot = '" + comboBox1.Text + "' and app_date = '" + this.Appoinment_Date.Value.ToString("MM/dd/yyyy") + "'", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                assending_data();
                con.Close();
            }
            else if (comboBox1.Text == "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_appoinments where app_date = '" + this.Appoinment_Date.Value.ToString("MM/dd/yyyy") + "' and app_No = '" + txt_AppNo.Text + "'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                assending_data(); 
                
            }
            else 
            {
                con.Open() ;
                SqlCommand cmd = new SqlCommand("select * from Tbl_appoinments where time_slot = '" + comboBox1.Text + "' and app_date = '" + this.Appoinment_Date.Value.ToString("MM/dd/yyyy") + "' and app_No = '" + txt_AppNo.Text + "'", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                assending_data();
                con.Close();
            }
        } // Search appoinment with details

        private void button6_Click(object sender, EventArgs e)
        {
            txt_AppNo.Clear();
            comboBox1.Text = "";
            txt_Name.Clear(); 
            txt_Age.Clear();
            txt_PhoneNo.Clear();
            Appoinment_Date.Value= DateTime.Now;
        } //Clear button

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
      
        }
        private void UpdateDataGridView()
        {
            con.Open();
            string todayDate = DateTime.Today.ToString("MM/dd/yyyy");
            string selectedTimeSlot = comboBox1.Text;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_appoinments WHERE app_date = @TodayDate AND time_slot = @TimeSlot", con);
            cmd.Parameters.AddWithValue("@TodayDate", todayDate);
            cmd.Parameters.AddWithValue("@TimeSlot", selectedTimeSlot);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (txt_Age.Text == "" || txt_AppNo.Text == "" || comboBox1.Text == "" || txt_Name.Text == "" || txt_PhoneNo.Text == "")
            {
                MessageBox.Show(" Search And Select To Update Appointment ");
            }
            else 
            {
                button4_Click(sender, e);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Tbl_appoinments set app_No= '" + txt_AppNo.Text + "', app_date= '" + this.dateTimePicker2.Value.ToString("MM/dd/yyyy") + "', time_slot= '" + comboBox1.Text + "', name = '" + txt_Name.Text + "', age= '" + txt_Age.Text + "', phone = '" + int.Parse(txt_PhoneNo.Text) + "' where phone = '" + int.Parse(txt_PhoneNo.Text) + "' and  name = '" + txt_Name.Text + "'", con);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully updated appointment.");
                        UpdateDataGridView();
                        button6_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("No matching phone number with name in record to update.");
                    } 

            }
        }// Update appoinment

        private void dataGridView1_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {
  
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_PhoneNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
