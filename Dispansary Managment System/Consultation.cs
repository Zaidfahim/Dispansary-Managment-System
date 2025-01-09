using System.Data;
using System.Data.SqlClient;



namespace Dispansary_Managment_System
{
    public partial class Consultation : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");

        public Consultation()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void Clear_Medi()
        { 
            txt_m1.Text = "";
            txt_m2.Text = "";
            txt_m3.Text = "";
            txt_m4.Text = "";
            txt_m5.Text = "";
            txt_m6.Text = "";
            txt_m7.Text = "";
            txt_m8.Text = "";

        }

        private void Consultation_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled= false;
            FillComboBox();
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txt_pid.Text == "P-")
            {
                MessageBox.Show("Enter A ID");
            }
            else if (MessageBox.Show("Do You Want To Confirm?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert  into Tbl_consult values (@p_id,@p_name,@age,@date,@diagnosis, @M1,@M1_dose,@M1_times,@M1_tablets, " +
                    "@M2,@M2_dose,@M2_times,@M2_tablets, @M3,@M3_dose,@M3_times,@M3_tablets, @M4,@M4_dose,@M4_times,@M4_tablets, @M5,@M5_dose,@M5_times,@M5_tablets, " +
                    "@M6,@M6_dose,@M6_times,@M6_tablets, @M7,@M7_dose,@M7_times,@M7_tablets, @M8,@M8_dose,@M8_times,@M8_tablets,@cost)", con);
 
                cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                cmd.Parameters.AddWithValue("@p_name", lbl_name.Text);
                cmd.Parameters.AddWithValue("@age", lbl_age.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker2.Text));
                cmd.Parameters.AddWithValue("@diagnosis", txt_diagnosis.Text);
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
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success..");
                
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
                
           


            }
            else
            {
                MessageBox.Show("Confirmation Cancelled!!", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }// Add Details

        private void clear()
        {
            
            txt_pid.Text = "P-";
            lbl_name.Text = "Name...";
            lbl_age.Text = "Age...";
            txt_diagnosis.Text = "";
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

        } // clear all 

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            if (!txt_pid.Text.StartsWith("P-"))
            {
                txt_pid.Text = "P-" ;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
                this.Refresh();


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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (txt_pid.Text == "P-" || txt_pid.Text=="")
            {
                MessageBox.Show("Enter The Patient Id");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tbl_registrations WHERE p_id = @p_id", con);
                cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                string p_id = txt_pid.Text;
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                if (count < 1)
                {
                    MessageBox.Show("The Patient ID " + txt_pid.Text + " Is Not Registered To Consult...");
                    return;
                }
                con.Close();

                con.Open();
                cmd = new SqlCommand("SELECT p_name,age FROM Tbl_registrations WHERE p_id = @p_id", con);
                cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lbl_name.Text = dr["p_name"].ToString();
                    lbl_age.Text = dr["age"].ToString();
                }
                con.Close();
                FillComboBox();
                Clear_Medi();

                con.Open();
                cmd = new SqlCommand("SELECT date, diagnosis, M1, M2, M3, M4, M5, M6, M7, M8 FROM Tbl_consult WHERE p_id = @p_id ORDER BY date ASC", con);
                cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                cmd = new SqlCommand("select p_name,age from  Tbl_consult where p_id = '" + txt_pid.Text + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader["p_name"].ToString();
                    int age = (int)reader["age"];

                    lbl_name.Text = "" + name;
                    lbl_age.Text = "" + age;
                }
                reader.Close();
                con.Close();

            }
       
        } //Search Patient With ID

        private void txt_m2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void m1_tab_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            var newForm = new Delete_Consultation();
            this.Hide();
            newForm.Show();
            

        }

        private void txt_m8_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txt_m7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_m6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_m4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_m3_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txt_cost_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
