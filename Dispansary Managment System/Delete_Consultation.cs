using System.Data;
using System.Data.SqlClient;



namespace Dispansary_Managment_System
{
    public partial class Delete_Consultation : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");

        public Delete_Consultation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var newForm = new Consultation();
            newForm.Show();
            this.Hide();
        }

        private void lbl_m5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txt_pid.Text == "P-")
            {
                MessageBox.Show("Enter The Patient Id");
            }
            else if (MessageBox.Show("Do You Want To Delete The Registration Details?", "Delete Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from Tbl_consult where date =  '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and  p_id = '" + txt_pid.Text + "'", con);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                con.Close();

                if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index < dataGridView1.Rows.Count)
                {
                    cmd = new SqlCommand("Delete from Tbl_diagnose_delivery where date =  '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and  p_id = '" + txt_pid.Text + "'", con);
                    // execute the command and perform any other necessary actions
                }
                MessageBox.Show("Details Deleted Successfuly");

                for (int i = 1; i <= 8; i++)
                {
                    Label lblExisting = (Label)Controls.Find("lbl_m" + i, true).FirstOrDefault();
                    Label lblTab = (Label)Controls.Find("lbl_tab" + i, true).FirstOrDefault();
                    if (lblExisting != null && lblTab != null)
                    {
                        string mName = lblExisting.Text;
                        int tabletsToAdd;
                        if (int.TryParse(lblTab.Text, out tabletsToAdd))
                        {

                            con.Open();

                            // retrieve the current total_tablets_to_use value for the specified m_name
                            cmd = new SqlCommand("SELECT total_tablets_to_use FROM Tbl_tablets WHERE m_name = @m_name", con);
                            cmd.Parameters.AddWithValue("@m_name", mName);
                            object result = cmd.ExecuteScalar();

                            int tabletsExisting = 0;
                            if (result != null && result != DBNull.Value)
                            {
                                tabletsExisting = (int)result;
                            }
                            int tabletsNewTotal = tabletsExisting + tabletsToAdd;
                            cmd = new SqlCommand("UPDATE Tbl_tablets SET total_tablets_to_use = @total_tablets_to_use WHERE m_name = @m_name", con);
                            cmd.Parameters.AddWithValue("@total_tablets_to_use", tabletsNewTotal);
                            cmd.Parameters.AddWithValue("@m_name", mName);
                            cmd.ExecuteNonQuery();

                            // update the label with the new total tablets
                            lblExisting.Text = tabletsNewTotal.ToString();

                            con.Close();
                           
                        }
                    }
                }
                clear();
            }
            else
            {
                MessageBox.Show("Your Registration Details Is Not Deleted", "Delete Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }// Delete the Data
        
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_pid.Text == "P-" || txt_pid.Text == "")
            {
                MessageBox.Show("Enter The Patient Id");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT date,diagnosis, M1,M1_tablets, M2,M2_tablets, M3,M3_tablets, M4,M4_tablets, M5,M5_tablets, M6,M6_tablets, M7,M7_tablets, M8,M8_tablets FROM Tbl_consult WHERE p_id = @p_id ORDER BY date ASC", con);
                cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                cmd = new SqlCommand("select p_name,age from Tbl_consult where p_id = @p_id", con);
                cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader["p_name"].ToString();
                    int? age = reader["age"] as int?;
                    lbl_name.Text = name;
                    lbl_age.Text = age.HasValue ? age.Value.ToString() : "...";
                }
                else
                {
                    reader.Close();
                    cmd = new SqlCommand("SELECT date,diagnosis, M1,M1_tablets, M2,M2_tablets, M3,M3_tablets, M4,M4_tablets, M5,M5_tablets, M6,M6_tablets, M7,M7_tablets, M8,M8_tablets FROM Tbl_diagnose_delivery WHERE p_id = @p_id ORDER BY date ASC", con);
                    cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                    dt = new DataTable();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    cmd = new SqlCommand("select p_name from Tbl_diagnose_delivery where p_id = @p_id", con);
                    cmd.Parameters.AddWithValue("@p_id", txt_pid.Text);
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1.Read())
                    {
                        string name = reader1["p_name"].ToString();
                        lbl_name.Text = name;
                        lbl_age.Text = "...";
                    }
                    reader1.Close();
                }
                reader.Close();
                con.Close();
            }





        }// Search To Delete

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            lbl_diagnosis.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            lbl_m1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            lbl_tab1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            lbl_m2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            lbl_tab2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            
            lbl_m3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            lbl_tab3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            
            lbl_m4.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            lbl_tab4.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            
            lbl_m5.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            lbl_tab5.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            
            lbl_m6.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            lbl_tab6.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            
            lbl_m7.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            lbl_tab7.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            
            lbl_m8.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
            lbl_tab8.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
            
           
        }// DataGriidView

        private void clear()
        {
            txt_pid.Text = "";
            lbl_name.Text = "Name..";
            lbl_age.Text = "Age..";
            lbl_diagnosis.Text = "Diagnosis..";
            lbl_m1.Text = "...";
            lbl_tab1.Text = "...";
            lbl_m2.Text = "...";
            lbl_tab2.Text = "...";
            lbl_m3.Text = "...";
            lbl_tab3.Text = "...";
            lbl_m4.Text = "...";
            lbl_tab4.Text = "...";
            lbl_m5.Text = "...";
            lbl_tab5.Text = "...";
            lbl_m6.Text = "...";
            lbl_tab6.Text = "...";
            lbl_m7.Text = "...";
            lbl_tab7.Text = "";
            lbl_m8.Text = "...";
            lbl_tab8.Text = "...";
            dataGridView1.DataSource = null;

        } //Clear
        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txt_pid_TextChanged(object sender, EventArgs e)
        {
            if (!txt_pid.Text.StartsWith("P-"))
            {
                txt_pid.Text = "P-";
            }
        }

        private void Delete_Consultation_Load(object sender, EventArgs e)
        {

        }
    }
}
