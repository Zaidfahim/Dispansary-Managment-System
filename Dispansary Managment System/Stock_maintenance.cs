using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Dispansary_Managment_System
{
    public partial class Stock_maintenance : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");
        private const string DMSDataTable = "Tbl_stocks";
        private const string DMSTabletsTable = "Tbl_tablets";
        public Stock_maintenance()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Stock_maintenance_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            FillComboBox();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Check if the cell value is null before converting it to a string
                if (row.Cells[0].Value != null)
                    combo_medi.Text = row.Cells[0].Value.ToString();

                if (row.Cells[1].Value != null)
                    txt_NOT.Text = row.Cells[1].Value.ToString();

                if (row.Cells[2].Value != null)
                    txt_TPT.Text = row.Cells[2].Value.ToString();

                if (row.Cells[3].Value != null)
                    lbl_total.Text = row.Cells[3].Value.ToString();

                if (row.Cells[4].Value != null)
                    dateTimePicker1.Text = row.Cells[4].Value.ToString();
            }
        


    }// dataGridView

    private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = combo_medi.Text;
            if (!Regex.IsMatch(input, @"^[a-zA-Z\s]+$") && !Regex.IsMatch(input, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Only letters or letters with numbers are allowed in this field.");
                return; // exit the method or event handler to prevent further execution
            }

            else
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tbl_stocks WHERE m_name = @m_name", con);
                con.Open();
                cmd.Parameters.AddWithValue("@m_name", combo_medi.Text);
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                if (count > 0)
                {
                    MessageBox.Show("The Medicine " + combo_medi.Text + " Already Exists In The Stock.");

                }




                else if (combo_medi.Text == "")
                {
                    MessageBox.Show("Enter A New Medicine");
                }
                else if (txt_NOT.Text == "")
                {
                    MessageBox.Show("Enter The Number Of Tins/Boxes..");
                }
                else if (txt_TPT.Text == "")
                {
                    MessageBox.Show("Enter The Number Of Tablets Per Tin/Box");
                }
                else
                { 
                    string not = txt_NOT.Text;
                    string tpt = txt_TPT.Text;
                    if (!Regex.IsMatch(not, @"^[0-9]+$") || !Regex.IsMatch(tpt, @"^[0-9]+$"))
                    {
                        MessageBox.Show("Only numbers are allowed in this field.");
                        return; 
                    }

                    else
                    {

                        con.Open();
                        cmd = new SqlCommand("INSERT INTO Tbl_stocks (m_name, no_of_tins_or_tablets, tablets_per_tin_or_box, total_no_tablets, updated_date) VALUES (@m_name, @no_of_tins_or_tablets, @tablets_per_tin_or_box, @total_no_tablets, @updated_date)", con);
                        cmd.Parameters.AddWithValue("@m_name", combo_medi.Text);
                        cmd.Parameters.AddWithValue("@no_of_tins_or_tablets", int.Parse(txt_NOT.Text));
                        cmd.Parameters.AddWithValue("@tablets_per_tin_or_box", int.Parse(txt_TPT.Text));
                        cmd.Parameters.AddWithValue("@total_no_tablets", lbl_total.Text);
                        cmd.Parameters.AddWithValue("@updated_date", DateTime.Parse(dateTimePicker1.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        cmd = new SqlCommand("INSERT INTO Tbl_tablets (m_name, total_tablets_to_use) VALUES (@m_name,@total_tablets_to_use)", con);
                        cmd.Parameters.AddWithValue("@m_name", combo_medi.Text);
                        cmd.Parameters.AddWithValue("@total_tablets_to_use", lbl_total.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully Added To Stock");
                        button6_Click(sender, e);
                        FillComboBox();
                    }


                }
            }


        } // Add Medicine

        private void lbl_total_Click(object sender, EventArgs e)
        {

        }

        private void txt_TPT_TextChanged(object sender, EventArgs e)
        {
            CAL();
            ADD();
            SUB();


        }
        private void CAL()
        {
            try
            {
                if (int.TryParse(txt_TPT.Text, out int num1) && int.TryParse(txt_NOT.Text, out int num2))
                {
                    int result = num1 * num2;
                    lbl_total.Text = result.ToString();
                }
                LBL();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }// Medicine Calculation

        private void LBL()
        {
            if (txt_NOT.Text == "" || txt_TPT.Text == "")
            {
                lbl_total.Text = "...";
            }
        }// Code To Manage The Total Medicine Lable While calculating

        private void txt_NOT_TextChanged(object sender, EventArgs e)
        {

        }

        private void FillComboBox()
        {
            try
            {
                combo_medi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combo_medi.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.Refresh();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT m_name FROM Tbl_stocks", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                combo_medi.Items.Clear();
                while (reader.Read())
                {
                    combo_medi.Items.Add(reader["m_name"].ToString());
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }// To Fill The ComboBox

        private void button4_Click(object sender, EventArgs e)
        {


            SearchData();



        }// Search Data From Datbase 
 
        private void SearchData()
        {

            try
            {
                if (combo_medi.Text == "")
                {
                    MessageBox.Show("Enter a Medicine");
                }
                else

                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tbl_stocks WHERE m_name = @m_name", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@m_name", combo_medi.Text);
                    string m_name = combo_medi.Text;
                    int count = (int)cmd.ExecuteScalar();
                    con.Close();
                    if (count < 1)
                    {
                        MessageBox.Show("The Medicine " + combo_medi.Text + " Is NOt Available In Stock.");
                        return;
                    }

                    else
                    {
                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM Tbl_stocks WHERE m_name=@m_name", con);
                        cmd.Parameters.AddWithValue("@m_name", combo_medi.SelectedItem.ToString());
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        con.Close();


                        con.Open();
                        cmd = new SqlCommand("SELECT total_tablets_to_use FROM Tbl_tablets WHERE m_name = @m_name", con);
                        cmd.Parameters.AddWithValue("@m_name", combo_medi.Text);
                        int totalTablets = (int)cmd.ExecuteScalar();
                        lbl_tottab.Text = totalTablets.ToString();
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3];

                        con.Close();
                    }
                }
            

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }// Search data from Database To ComboBox

        private void combo_medi_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchData();
       
        }

        private void button6_Click(object sender, EventArgs e)
        {
            combo_medi.Text = "";
            txt_NOT.Clear();
            txt_TPT.Clear();
            lbl_total.Text = "Total Tablets...";
            lbl_tottab.Text = "Total Tablets...";
            lbl_sub.Text = "...";
            label4.Text = "...";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }// Clear All Details 

        private void lbl_tottab_Click(object sender, EventArgs e)
        {

        }
        private void ADD()
        {
            try
            {
                if (int.TryParse(lbl_tottab.Text, out int num1) && int.TryParse(lbl_total.Text, out int num2))
                {
                    int result = num1 + num2;
                    label4.Text = result.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SUB()
        {
            try
            {
                if (int.TryParse(lbl_tottab.Text, out int num1) && int.TryParse(lbl_total.Text, out int num2))
                {
                    int result = num1 - num2;
                    lbl_sub.Text = result.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int total;
            if (txt_TPT.Text == "" && txt_NOT.Text == "")
            {
                MessageBox.Show("enter A Value");
            }
            else if (!int.TryParse(txt_NOT.Text, out int no_of_tins_or_tablets) && !int.TryParse(txt_TPT.Text, out int tablets_per_tin_or_box))
            {
                MessageBox.Show("Enter In Numbers...");
                txt_NOT.Clear();
                txt_TPT.Clear();
            }
            else if (int.TryParse(lbl_total.Text, out total) && int.TryParse(lbl_tottab.Text, out total))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_stocks (m_name, no_of_tins_or_tablets, tablets_per_tin_or_box, total_no_tablets, updated_date) VALUES (@m_name, @no_of_tins_or_tablets, @tablets_per_tin_or_box, @total_no_tablets, @updated_date)", con);
                cmd.Parameters.AddWithValue("@m_name", combo_medi.Text);
                cmd.Parameters.AddWithValue("@no_of_tins_or_tablets", int.Parse(txt_NOT.Text));
                cmd.Parameters.AddWithValue("@tablets_per_tin_or_box", int.Parse(txt_TPT.Text));
                cmd.Parameters.AddWithValue("@total_no_tablets", lbl_total.Text);
                cmd.Parameters.AddWithValue("@updated_date", DateTime.Parse(dateTimePicker1.Text));
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("update Tbl_tablets set total_tablets_to_use = '" + label4.Text + "' where  m_name= '" + this.combo_medi.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated Your Details");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                button6_Click(sender, e);

            }
            else
            {
                MessageBox.Show(" Please Add The New Medicine Before You Update ");
            }
        } // Update Medicine

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (combo_medi.Text == "" || txt_NOT.Text == "" || txt_TPT.Text == "")
            {
                MessageBox.Show("Search / Enter the Medicine Details to Delete ");
            }

            else if (MessageBox.Show("Do You Want To Delete the Selected Row", "Delete!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from Tbl_stocks where m_name =  '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and  no_of_tins_or_tablets = '" + txt_NOT.Text + "' and tablets_per_tin_or_box = '" + txt_TPT.Text + "' and  total_no_tablets= '" + lbl_total.Text + "' and updated_date = '" + this.dateTimePicker1.Value.ToString() + "'", con);
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                dataGridView1.DataSource = dataGridView1;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected ==0)
                {
                }
                con.Close();

                con.Open();
                cmd = new SqlCommand("update Tbl_tablets set total_tablets_to_use = '" + lbl_sub.Text + "' where  m_name= '" + this.combo_medi.Text + "'", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                MessageBox.Show("Deleted Successfuly");
                button6_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Your Process Had been Cancelled", "Delete!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }// Delete Medicine


        }
    }   


