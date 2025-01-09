using System.Data.SqlClient;


namespace Dispansary_Managment_System
{
    public partial class Medicine_Prescription : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");

        public Medicine_Prescription()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txt_pid.Text;

            if (id.Length != 8)
            {
                MessageBox.Show("Enter A valid ID.");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tbl_consult WHERE p_id = @p_id AND date = @date", con);
                cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                string p_id = txt_pid.Text;
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                if (count < 1)
                {
                    MessageBox.Show("No Patient With This ID " + txt_pid.Text + " Had Consulted Today!! ");
                    return;
                }
            }
            con.Close();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT p_name, M1, M1_dose, M1_times, M1_tablets, M2, M2_dose, M2_times, M2_tablets, M3, M3_dose, M3_times, M3_tablets, M4, M4_dose, M4_times, M4_tablets, M5, M5_dose, M5_times, M5_tablets, M6, M6_dose, M6_times, M6_tablets, M7, M7_dose, M7_times, M7_tablets, M8, M8_dose, M8_times, M8_tablets, cost FROM Tbl_consult WHERE p_id = @p_id AND date = @date", con);
                cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string name = dr["p_name"].ToString();
                    lbl_name.Text = name;
                    int cost = Convert.ToInt32(dr["cost"]);
                    lbl_cost.Text = cost.ToString();


                    string m1 = dr["M1"].ToString();
                    string m1Dose = dr["M1_dose"].ToString();
                    string m1Times = dr["M1_times"].ToString();
                    int m1Tablets = Convert.ToInt32(dr["M1_tablets"]);
                    lbl_m1.Text = m1;
                    lbl_dft1.Text = m1Dose;
                    lbl_tfd1.Text = m1Times;
                    lbl_tab1.Text = m1Tablets.ToString();

                    string m2 = dr["M2"].ToString();
                    string m2Dose = dr["M2_dose"].ToString();
                    string m2Times = dr["M2_times"].ToString();
                    int m2Tablets = Convert.ToInt32(dr["M2_tablets"]);
                    lbl_m2.Text = m2;
                    lbl_dft2.Text = m2Dose;
                    lbl_tfd2.Text = m2Times;
                    lbl_tab2.Text = m2Tablets.ToString();

                    string m3 = dr["M3"].ToString();
                    string m3Dose = dr["M3_dose"].ToString();
                    string m3Times = dr["M3_times"].ToString();
                    int m3Tablets = Convert.ToInt32(dr["M3_tablets"]);
                    lbl_m3.Text = m3;
                    lbl_dft3.Text = m3Dose;
                    lbl_tfd3.Text = m3Times;
                    lbl_tab3.Text = m3Tablets.ToString();

                    string m4 = dr["M4"].ToString();
                    string m4Dose = dr["M4_dose"].ToString();
                    string m4Times = dr["M4_times"].ToString();
                    int m4Tablets = Convert.ToInt32(dr["M4_tablets"]);
                    lbl_m4.Text = m4;
                    lbl_dft4.Text = m4Dose;
                    lbl_tfd4.Text = m4Times;
                    lbl_tab4.Text = m4Tablets.ToString();

                    string m5 = dr["M5"].ToString();
                    string m5Dose = dr["M5_dose"].ToString();
                    string m5Times = dr["M5_times"].ToString();
                    int m5Tablets = Convert.ToInt32(dr["M5_tablets"]);
                    lbl_m5.Text = m5;
                    lbl_dft5.Text = m5Dose;
                    lbl_tfd5.Text = m5Times;
                    lbl_tab5.Text = m5Tablets.ToString();

                    string m6 = dr["M6"].ToString();
                    string m6Dose = dr["M6_dose"].ToString();
                    string m6Times = dr["M6_times"].ToString();
                    int m6Tablets = Convert.ToInt32(dr["M6_tablets"]);
                    lbl_m6.Text = m6;
                    lbl_dft6.Text = m6Dose;
                    lbl_tfd6.Text = m6Times;
                    lbl_tab6.Text = m6Tablets.ToString();

                    string m7 = dr["M7"].ToString();
                    string m7Dose = dr["M7_dose"].ToString();
                    string m7Times = dr["M7_times"].ToString();
                    int m7Tablets = Convert.ToInt32(dr["M7_tablets"]);
                    lbl_m7.Text = m7;
                    lbl_dft7.Text = m7Dose;
                    lbl_tfd7.Text = m7Times;
                    lbl_tab7.Text = m7Tablets.ToString();

                    string m8 = dr["M8"].ToString();
                    string m8Dose = dr["M8_dose"].ToString();
                    string m8Times = dr["M8_times"].ToString();
                    int m8Tablets = Convert.ToInt32(dr["M8_tablets"]);
                    lbl_m8.Text = m8;
                    lbl_dft8.Text = m8Dose;
                    lbl_tfd8.Text = m8Times;
                    lbl_tab8.Text = m8Tablets.ToString();
                }
                con.Close();

            }

        } //Search priscription

        private void clear() 
        {
            txt_pid.Text = "P-";
            lbl_name.Text = "";
            lbl_cost.Text = "";
            lbl_m1.Text = "";
            lbl_dft1.Text = "";
            lbl_tfd1.Text = "";
            lbl_tab1.Text = "";
            lbl_m2.Text = "";
            lbl_dft2.Text = "";
            lbl_tfd2.Text = "";
            lbl_tab2.Text = "";
            lbl_m3.Text = "";
            lbl_dft3.Text = "";
            lbl_tfd3.Text = "";
            lbl_tab3.Text = "";
            lbl_m4.Text = "";
            lbl_dft4.Text = "";
            lbl_tfd4.Text = "";
            lbl_tab4.Text = "";
            lbl_m5.Text = "";
            lbl_dft5.Text = "";
            lbl_tfd5.Text = "";
            lbl_tab5.Text = "";
            lbl_m6.Text = "";
            lbl_dft6.Text = "";
            lbl_tfd6.Text = "";
            lbl_tab6.Text = "";
            lbl_m7.Text = "";
            lbl_dft7.Text = "";
            lbl_tfd7.Text = "";
            lbl_tab7.Text = "";
            lbl_m8.Text = "";
            lbl_dft8.Text = "";
            lbl_tfd8.Text = "";
            lbl_tab8.Text = "";
            lbl_cost.Text = "";
            txt_pmethod.Text = "";
        }// clear
        private void Medicine_Prescription_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
        }

        private void txt_pid_TextChanged(object sender, EventArgs e)
        {
            if (!txt_pid.Text.StartsWith("P-"))
            {
                txt_pid.Text = "P-";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_pmethod.Text == "")
            {
                MessageBox.Show("Select A Method Of Payment");
            }
            else
            {
                con.Open();
                SqlCommand getMaxIdCmd = new SqlCommand("SELECT MAX(pay_id) FROM Tbl_payment", con);
                object result = getMaxIdCmd.ExecuteScalar();
                int maxId = result == DBNull.Value ? 0 : Convert.ToInt32(result);

                SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_payment (pay_id, p_id, date, amount, payment_method) VALUES (@pay_id, @p_id, @date, @amount, @payment_method)", con);
                cmd.Parameters.AddWithValue("@pay_id", maxId + 1);
                cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@amount", int.Parse(lbl_cost.Text));
                cmd.Parameters.AddWithValue("@payment_method", txt_pmethod.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Payment successful...");
                con.Close();
                clear();

            }

        }
    }
}
