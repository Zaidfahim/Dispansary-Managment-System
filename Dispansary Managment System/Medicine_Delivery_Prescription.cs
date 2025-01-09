
using System.Data;
using System.Data.SqlClient;


namespace Dispansary_Managment_System
{
    public partial class Medicine_Delivery_Prescription : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");
        public Medicine_Delivery_Prescription()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Medicine_Delivery_Prescription_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            con.Open();
            DateTime selectedDate = dateTimePicker1.Value.Date;
            SqlCommand cmd = new SqlCommand("SELECT p_id, p_name, phone, address, diagnosis , M1, M1_dose, M1_times, M1_tablets, M2, M2_dose, M2_times, M2_tablets, " +
                "M3, M3_dose, M3_times, M3_tablets, M4, M4_dose, M4_times, M4_tablets, M5, M5_dose, M5_times, M5_tablets, M6, M6_dose, M6_times, M6_tablets, " +
                "M7, M7_dose, M7_times, M7_tablets, M8, M8_dose, M8_times, M8_tablets, cost, delivery_time, payment_method  FROM Tbl_diagnose_delivery WHERE date = @selectedDate", con);
            cmd.Parameters.AddWithValue("@selectedDate", selectedDate);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns["diagnosis"].Visible = false;

            dataGridView1.Columns["M1"].Visible = false;
            dataGridView1.Columns["M1_dose"].Visible = false;
            dataGridView1.Columns["M1_times"].Visible = false;
            dataGridView1.Columns["M1_tablets"].Visible = false;

            dataGridView1.Columns["M2"].Visible = false;
            dataGridView1.Columns["M2_dose"].Visible = false;
            dataGridView1.Columns["M2_times"].Visible = false;
            dataGridView1.Columns["M2_tablets"].Visible = false;

            dataGridView1.Columns["M3"].Visible = false;
            dataGridView1.Columns["M3_dose"].Visible = false;
            dataGridView1.Columns["M3_times"].Visible = false;
            dataGridView1.Columns["M3_tablets"].Visible = false;

            dataGridView1.Columns["M4"].Visible = false;
            dataGridView1.Columns["M4_dose"].Visible = false;
            dataGridView1.Columns["M4_times"].Visible = false;
            dataGridView1.Columns["M4_tablets"].Visible = false;

            dataGridView1.Columns["M5"].Visible = false;
            dataGridView1.Columns["M5_dose"].Visible = false;
            dataGridView1.Columns["M5_times"].Visible = false;
            dataGridView1.Columns["M5_tablets"].Visible = false;

            dataGridView1.Columns["M6"].Visible = false;
            dataGridView1.Columns["M6_dose"].Visible = false;
            dataGridView1.Columns["M6_times"].Visible = false;
            dataGridView1.Columns["M6_tablets"].Visible = false;

            dataGridView1.Columns["M7"].Visible = false;
            dataGridView1.Columns["M7_dose"].Visible = false;
            dataGridView1.Columns["M7_times"].Visible = false;
            dataGridView1.Columns["M7_tablets"].Visible = false;

            dataGridView1.Columns["M8"].Visible = false;
            dataGridView1.Columns["M8_dose"].Visible = false;
            dataGridView1.Columns["M8_times"].Visible = false;
            dataGridView1.Columns["M8_tablets"].Visible = false;

            dataGridView1.Columns["cost"].Visible = false;
            dataGridView1.Columns["delivery_time"].Visible = false;
            dataGridView1.Columns["payment_method"].Visible = false;


        } // Search  And Hide Data

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


            
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void lbl_address_Click(object sender, EventArgs e)
        {

        }

        private void lbl_phone_Click(object sender, EventArgs e)
        {

        }

        private void lbl_name_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                lbl_pid.Text = row.Cells["p_id"].Value.ToString();
                lbl_name.Text = row.Cells["p_name"].Value.ToString();
                lbl_phone.Text = row.Cells["phone"].Value.ToString();
                lbl_address.Text = row.Cells["address"].Value.ToString();
                lbll_diagnose.Text = row.Cells["diagnosis"].Value.ToString();

                lbl_m1.Text = row.Cells["M1"].Value.ToString();
                lbl_dft1.Text = row.Cells["M1_dose"].Value.ToString();
                lbl_tfd1.Text = row.Cells["M1_times"].Value.ToString();
                lbl_tab1.Text = row.Cells["M1_tablets"].Value.ToString();

                lbl_m2.Text = row.Cells["M2"].Value.ToString();
                lbl_dft2.Text = row.Cells["M2_dose"].Value.ToString();
                lbl_tfd2.Text = row.Cells["M2_times"].Value.ToString();
                lbl_tab2.Text = row.Cells["M2_tablets"].Value.ToString();

                lbl_m3.Text = row.Cells["M3"].Value.ToString();
                lbl_dft3.Text = row.Cells["M3_dose"].Value.ToString();
                lbl_tfd3.Text = row.Cells["M3_times"].Value.ToString();
                lbl_tab3.Text = row.Cells["M3_tablets"].Value.ToString();

                lbl_m4.Text = row.Cells["M4"].Value.ToString();
                lbl_dft4.Text = row.Cells["M4_dose"].Value.ToString();
                lbl_tfd4.Text = row.Cells["M4_times"].Value.ToString();
                lbl_tab4.Text = row.Cells["M4_tablets"].Value.ToString();

                lbl_m5.Text = row.Cells["M5"].Value.ToString();
                lbl_dft5.Text = row.Cells["M5_dose"].Value.ToString();
                lbl_tfd5.Text = row.Cells["M5_times"].Value.ToString();
                lbl_tab5.Text = row.Cells["M5_tablets"].Value.ToString();

                lbl_m6.Text = row.Cells["M6"].Value.ToString();
                lbl_dft6.Text = row.Cells["M6_dose"].Value.ToString();
                lbl_tfd6.Text = row.Cells["M6_times"].Value.ToString();
                lbl_tab6.Text = row.Cells["M6_tablets"].Value.ToString();

                lbl_m7.Text = row.Cells["M7"].Value.ToString();
                lbl_dft7.Text = row.Cells["M7_dose"].Value.ToString();
                lbl_tfd7.Text = row.Cells["M7_times"].Value.ToString();
                lbl_tab7.Text = row.Cells["M7_tablets"].Value.ToString();

                lbl_m8.Text = row.Cells["M8"].Value.ToString();
                lbl_dft8.Text = row.Cells["M8_dose"].Value.ToString();
                lbl_tfd8.Text = row.Cells["M8_times"].Value.ToString();
                lbl_tab8.Text = row.Cells["M8_tablets"].Value.ToString();

                lbl_cost.Text = row.Cells["cost"].Value.ToString();
                lbl_delitime.Text = row.Cells["delivery_time"].Value.ToString();
                lbl_paymethord.Text = row.Cells["payment_method"].Value.ToString();


            }  // To Get From Datagridview To Lables
        } // dataGridView

        private void clear()
        {
            lbl_pid.Text = "";
            lbl_name.Text = "Name...";
            lbll_diagnose.Text = "...";
            lbl_address.Text = "Address...";
            lbl_cost.Text = "...";
            lbl_delitime.Text = "...";
            lbl_paymethord.Text = "...";
            lbl_phone.Text = "Phone...";
            lbl_cost.Text = "...";
            lbl_m1.Text = "...";
            lbl_dft1.Text = "...";
            lbl_tfd1.Text = "...";
            lbl_tab1.Text = "...";
            lbl_m2.Text = "...";
            lbl_dft2.Text = "...";
            lbl_tfd2.Text = "...";
            lbl_tab2.Text = "...";
            lbl_m3.Text = "...";
            lbl_dft3.Text = "...";
            lbl_tfd3.Text = "...";
            lbl_tab3.Text = "...";
            lbl_m4.Text = "...";
            lbl_dft4.Text = "...";
            lbl_tfd4.Text = "...";
            lbl_tab4.Text = "...";
            lbl_m5.Text = "...";
            lbl_dft5.Text = "...";
            lbl_tfd5.Text = "...";
            lbl_tab5.Text = "...";
            lbl_m6.Text = "...";
            lbl_dft6.Text = "...";
            lbl_tfd6.Text = "...";
            lbl_tab6.Text = "...";
            lbl_m7.Text = "...";
            lbl_dft7.Text = "...";
            lbl_tfd7.Text = "...";
            lbl_tab7.Text = "...";
            lbl_m8.Text = "...";
            lbl_dft8.Text = "...";
            lbl_tfd8.Text = "...";
            lbl_tab8.Text = "...";
            lbl_cost.Text = "...";
        }// clear

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Confirm?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" INSERT INTO Tbl_diagnose_deliverys_confirm VALUES (@p_id, @p_name, @phone, @address, @date, @diagnosis, @M1, @M1_dose, @M1_times, @M1_tablets, @M2, @M2_dose, @M2_times, @M2_tablets, @M3, @M3_dose, @M3_times, @M3_tablets, @M4, @M4_dose, @M4_times, @M4_tablets, @M5, @M5_dose, @M5_times, @M5_tablets, @M6, @M6_dose, @M6_times, @M6_tablets, @M7, @M7_dose, @M7_times, @M7_tablets, @M8, @M8_dose, @M8_times, @M8_tablets, @cost, @delivery_time, @payment_method)", con);

                cmd.Parameters.AddWithValue("@p_id", lbl_pid.Text);
                cmd.Parameters.AddWithValue("@p_name", lbl_name.Text);
                cmd.Parameters.AddWithValue("@phone", lbl_phone.Text);
                cmd.Parameters.AddWithValue("@address", lbl_address.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@diagnosis", lbll_diagnose.Text);
                cmd.Parameters.AddWithValue("@M1", lbl_m1.Text);
                cmd.Parameters.AddWithValue("@M1_dose", lbl_dft1.Text);
                cmd.Parameters.AddWithValue("@M1_times", lbl_tfd1.Text);
                cmd.Parameters.AddWithValue("@M1_tablets", lbl_tab1.Text);
                cmd.Parameters.AddWithValue("@M2", lbl_m2.Text);
                cmd.Parameters.AddWithValue("@M2_dose", lbl_dft2.Text);
                cmd.Parameters.AddWithValue("@M2_times", lbl_tfd2.Text);
                cmd.Parameters.AddWithValue("@M2_tablets", lbl_tab2.Text);
                cmd.Parameters.AddWithValue("@M3", lbl_m3.Text);
                cmd.Parameters.AddWithValue("@M3_dose", lbl_dft3.Text);
                cmd.Parameters.AddWithValue("@M3_times", lbl_tfd3.Text);
                cmd.Parameters.AddWithValue("@M3_tablets", lbl_tab3.Text);
                cmd.Parameters.AddWithValue("@M4", lbl_m4.Text);
                cmd.Parameters.AddWithValue("@M4_dose", lbl_dft4.Text);
                cmd.Parameters.AddWithValue("@M4_times", lbl_tfd4.Text);
                cmd.Parameters.AddWithValue("@M4_tablets", lbl_tab4.Text);
                cmd.Parameters.AddWithValue("@M5", lbl_m5.Text);
                cmd.Parameters.AddWithValue("@M5_dose", lbl_dft5.Text);
                cmd.Parameters.AddWithValue("@M5_times", lbl_tfd5.Text);
                cmd.Parameters.AddWithValue("@M5_tablets", lbl_tab5.Text);
                cmd.Parameters.AddWithValue("@M6", lbl_m6.Text);
                cmd.Parameters.AddWithValue("@M6_dose", lbl_dft6.Text);
                cmd.Parameters.AddWithValue("@M6_times", lbl_tfd6.Text);
                cmd.Parameters.AddWithValue("@M6_tablets", lbl_tab6.Text);
                cmd.Parameters.AddWithValue("@M7", lbl_m7.Text);
                cmd.Parameters.AddWithValue("@M7_dose", lbl_dft7.Text);
                cmd.Parameters.AddWithValue("@M7_times", lbl_tfd7.Text);
                cmd.Parameters.AddWithValue("@M7_tablets", lbl_tab7.Text);
                cmd.Parameters.AddWithValue("@M8", lbl_m8.Text);
                cmd.Parameters.AddWithValue("@M8_dose", lbl_dft8.Text);
                cmd.Parameters.AddWithValue("@M8_times", lbl_tfd8.Text);
                cmd.Parameters.AddWithValue("@M8_tablets", lbl_tab8.Text);
                cmd.Parameters.AddWithValue("@cost", lbl_cost.Text);
                cmd.Parameters.AddWithValue("@delivery_time", lbl_delitime.Text);
                cmd.Parameters.AddWithValue("@payment_method", lbl_paymethord.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success..");
                con.Close();

                string selectedRowID = dataGridView1.SelectedRows[0].Cells["p_id"].Value.ToString();
                con.Open();
                string sql = "DELETE FROM Tbl_diagnose_delivery WHERE p_id = @p_id";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@p_id", selectedRowID);
                cmd.ExecuteNonQuery();
                con.Close();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                clear();
            }
            else
            {
                MessageBox.Show("Confirmation Cancelled!!", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        } //Delivery Confirmed
    }
}
