using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Dispansary_Managment_System
{
    public partial class Diagnose_And_Deliver : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");
        string Gen;

        public Diagnose_And_Deliver()
        {
            InitializeComponent();
            patient_ID();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void Diagnose_And_Deliver_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = false;
            FillComboBox();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

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


        } // Arrange Patient-ID In Order

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
                    cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker2.Text));
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
        } // Register

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
        } // Clear Button

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_age.Text == "" || txt_address.Text == "" || txt_name.Text == "" || txt_phone.Text == "" || radioButton_male.Text == "" || radioButton_female.Text == "")
            {
                MessageBox.Show(" Search your Details To Alter It..  ");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Tbl_registrations set phone= '" + txt_phone.Text + "',p_name= '" + txt_name.Text + "', age= '" + txt_age.Text + "', address= '" + txt_address.Text + "',gender= '" + Gen + "' where  p_id= '" + this.lbl_pid.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated Your Details");


                con.Open();
                SqlCommand selectCmd = new SqlCommand("SELECT p_id,p_name,age,gender,address,phone FROM Tbl_registrations WHERE p_id = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(selectCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;
                clear_after_update();
                
            }
        } // Alter Details 

        private void clear_after_update()
        {
            lbl_id.Text = "Patient ID..";
            lbl_name.Text = "Name...";
            lbl_phone.Text = "Age...";
            lbl_address.Text = "Address...";
            txt_name.Clear();
            txt_age.Clear();
            txt_address.Clear();
            txt_phone.Clear();
            radioButton_female.Checked = false;
            radioButton_male.Checked = false;
            patient_ID();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox22.Text.All(char.IsDigit) || textBox22.Text.Length != 10)
            {
                MessageBox.Show("Enter The 10 Digit Phone Number To Search");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select p_id, p_name, age, gender, address, phone from  Tbl_registrations  where phone = '" + textBox22.Text + "'", con);
                cmd.Parameters.AddWithValue("@phone", textBox22.Text.Trim());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        } // Search Details

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_male_CheckedChanged(object sender, EventArgs e)
        {
            Gen = "Male";
        }

        private void FillComboBox()
        {
            try
            {
                txt_m1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_m1.AutoCompleteSource = AutoCompleteSource.ListItems;
                txt_m2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_m2.AutoCompleteSource = AutoCompleteSource.ListItems;
                txt_m3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_m3.AutoCompleteSource = AutoCompleteSource.ListItems;
                txt_m4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_m4.AutoCompleteSource = AutoCompleteSource.ListItems;
                txt_m5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_m5.AutoCompleteSource = AutoCompleteSource.ListItems;
                txt_m6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_m6.AutoCompleteSource = AutoCompleteSource.ListItems;
                txt_m7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_m7.AutoCompleteSource = AutoCompleteSource.ListItems;
                txt_m8.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_m8.AutoCompleteSource = AutoCompleteSource.ListItems;


                SqlCommand cmd = new SqlCommand("SELECT DISTINCT m_name FROM Tbl_tablets", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                txt_m1.Items.Clear();
                txt_m2.Items.Clear();
                txt_m3.Items.Clear();
                txt_m4.Items.Clear();
                txt_m5.Items.Clear();
                txt_m6.Items.Clear();
                txt_m7.Items.Clear();
                txt_m8.Items.Clear();
                while (reader.Read())
                {
                    txt_m1.Items.Add(reader["m_name"].ToString());
                    txt_m2.Items.Add(reader["m_name"].ToString());
                    txt_m3.Items.Add(reader["m_name"].ToString());
                    txt_m4.Items.Add(reader["m_name"].ToString());
                    txt_m5.Items.Add(reader["m_name"].ToString());
                    txt_m6.Items.Add(reader["m_name"].ToString());
                    txt_m7.Items.Add(reader["m_name"].ToString());
                    txt_m8.Items.Add(reader["m_name"].ToString());
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }// To Fill The ComboBox
        private void radioButton_female_CheckedChanged(object sender, EventArgs e)
        {
            Gen = "Female";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            lbl_id.Text = "Patient ID..";
            lbl_name.Text = "Name...";
            lbl_phone.Text = "Age...";
            lbl_address.Text = "Address...";
            dateTimePicker2.Value= DateTime.Now;
            txt_diagnose.Text = "";
            txt_m1.Text = "";
            m1_dose.Text = "";
            m1_time.Text = "";
            m1_tab.Text = "";
            txt_m2.Text = "";
            m2_dose.Text = "";
            m2_time.Text = "";
            m2_tab.Text = "";
            txt_m3.Text = "";
            m3_dose.Text = "";
            m3_time.Text = "";
            m3_tab.Text = "";
            txt_m4.Text = "";
            m4_dose.Text = "";
            m4_time.Text = "";
            m4_tab.Text = "";
            txt_m5.Text = "";
            m5_dose.Text = "";
            m5_time.Text = "";
            m5_tab.Text = "";
            txt_m6.Text = "";
            m6_dose.Text = "";
            m6_time.Text = "";
            m6_tab.Text = "";
            txt_m7.Text = "";
            m7_dose.Text = "";
            m7_time.Text = "";
            m7_tab.Text = "";
            txt_m8.Text = "";
            m8_dose.Text = "";
            m8_time.Text = "";
            m8_tab.Text = "";
            txt_cost.Text = "";
            dataGridView1.DataSource = null;
            txt_deltime.Text = "";
            txt_paymethod.Text = "";
            txt_diagnose.Text = "";
            

        } //clear
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            lbl_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            lbl_pid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            lbl_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            txt_age.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            string Gen = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (Gen == "Male")
            {
                radioButton_male.Checked = true;
            }
            else
                radioButton_female.Checked = true;

            lbl_address.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_address.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            lbl_phone.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_phone.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (txt_deltime.Text == "")
            {
                MessageBox.Show("Enter A deliver Time");
            }
            else if (txt_paymethod.Text == "")
            {
                MessageBox.Show("Select A Valid Payment Method!!");
            }
            else if (MessageBox.Show("Do You Want To Confirm?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert  into Tbl_diagnose_delivery values (@p_id,@p_name,@phone,@address,@date,@diagnosis, @M1,@M1_dose,@M1_times,@M1_tablets, " +
                    "@M2,@M2_dose,@M2_times,@M2_tablets, @M3,@M3_dose,@M3_times,@M3_tablets, @M4,@M4_dose,@M4_times,@M4_tablets, @M5,@M5_dose,@M5_times,@M5_tablets, " +
                    "@M6,@M6_dose,@M6_times,@M6_tablets, @M7,@M7_dose,@M7_times,@M7_tablets, @M8,@M8_dose,@M8_times,@M8_tablets,@cost, @delivery_time,@payment_method)", con);

                cmd.Parameters.AddWithValue("@p_id", lbl_id.Text);
                cmd.Parameters.AddWithValue("@p_name", lbl_name.Text);
                cmd.Parameters.AddWithValue("@phone", lbl_phone.Text);
                cmd.Parameters.AddWithValue("@address", lbl_address.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker2.Text));
                cmd.Parameters.AddWithValue("@diagnosis", txt_diagnose.Text);
                cmd.Parameters.AddWithValue("@M1", txt_m1.Text);
                cmd.Parameters.AddWithValue("@M1_dose", m1_dose.Text);
                cmd.Parameters.AddWithValue("@M1_times", m1_time.Text);
                cmd.Parameters.AddWithValue("@M1_tablets", m1_tab.Text);
                cmd.Parameters.AddWithValue("@M2", txt_m2.Text);
                cmd.Parameters.AddWithValue("@M2_dose", m2_dose.Text);
                cmd.Parameters.AddWithValue("@M2_times", m2_time.Text);
                cmd.Parameters.AddWithValue("@M2_tablets", m2_tab.Text);
                cmd.Parameters.AddWithValue("@M3", txt_m3.Text);
                cmd.Parameters.AddWithValue("@M3_dose", m3_dose.Text);
                cmd.Parameters.AddWithValue("@M3_times", m3_time.Text);
                cmd.Parameters.AddWithValue("@M3_tablets", m3_tab.Text);
                cmd.Parameters.AddWithValue("@M4", txt_m4.Text);
                cmd.Parameters.AddWithValue("@M4_dose", m4_dose.Text);
                cmd.Parameters.AddWithValue("@M4_times", m4_time.Text);
                cmd.Parameters.AddWithValue("@M4_tablets", m4_tab.Text);
                cmd.Parameters.AddWithValue("@M5", txt_m5.Text);
                cmd.Parameters.AddWithValue("@M5_dose", m5_dose.Text);
                cmd.Parameters.AddWithValue("@M5_times", m5_time.Text);
                cmd.Parameters.AddWithValue("@M5_tablets", m5_tab.Text);
                cmd.Parameters.AddWithValue("@M6", txt_m6.Text);
                cmd.Parameters.AddWithValue("@M6_dose", m6_dose.Text);
                cmd.Parameters.AddWithValue("@M6_times", m6_time.Text);
                cmd.Parameters.AddWithValue("@M6_tablets", m6_tab.Text);
                cmd.Parameters.AddWithValue("@M7", txt_m7.Text);
                cmd.Parameters.AddWithValue("@M7_dose", m7_dose.Text);
                cmd.Parameters.AddWithValue("@M7_times", m7_time.Text);
                cmd.Parameters.AddWithValue("@M7_tablets", m7_tab.Text);
                cmd.Parameters.AddWithValue("@M8", txt_m8.Text);
                cmd.Parameters.AddWithValue("@M8_dose", m8_dose.Text);
                cmd.Parameters.AddWithValue("@M8_times", m8_time.Text);
                cmd.Parameters.AddWithValue("@M8_tablets", m8_tab.Text);
                cmd.Parameters.AddWithValue("@cost", txt_cost.Text);
                cmd.Parameters.AddWithValue("@delivery_time", txt_deltime.Text);
                cmd.Parameters.AddWithValue("@payment_method", txt_paymethod.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success..");
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Patient not registered");
                    textBox22.Clear();
                }


                int tabletsToUse, subtractedValue;
                for (int i = 1; i <= 8; i++)
                {
                    ComboBox txtM = (ComboBox)Controls.Find("txt_m" + i, true)[0];
                    TextBox mTab = (TextBox)Controls.Find("m" + i + "_tab", true)[0];
                    string mName = txtM.Text;

                    cmd = new SqlCommand("SELECT total_tablets_to_use FROM Tbl_tablets WHERE m_name = @m_name", con);
                    cmd.Parameters.AddWithValue("@m_name", mName);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        tabletsToUse = (int)result;
                        subtractedValue = tabletsToUse - int.Parse(mTab.Text);

                        cmd = new SqlCommand("UPDATE Tbl_tablets SET total_tablets_to_use = @total_tablets_to_use WHERE m_name = @m_name", con);
                        cmd.Parameters.AddWithValue("@total_tablets_to_use", subtractedValue);
                        cmd.Parameters.AddWithValue("@m_name", mName);
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
                clear();
                btn_clear_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Confirmation Cancelled!!", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }// Add Details

        private void button1_Click_1(object sender, EventArgs e)
        {
            var newForm = new Consultation();
            newForm.Show();
            this.Hide();
        }
    }
}





