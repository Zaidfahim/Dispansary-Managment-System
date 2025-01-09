using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;


namespace Dispansary_Managment_System
{
    public partial class Stock_Report : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");

        public Stock_Report()
        {
            InitializeComponent();
        }

        private void Stock_Report_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }
        private void FillComboBox()
        {
            try
            {
                combo_medi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combo_medi.AutoCompleteSource = AutoCompleteSource.ListItems;


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

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start_date = dateTimePicker1.Value;
            DateTime end_date = dateTimePicker2.Value;
            string name = combo_medi.Text.Trim();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT m_name, no_of_tins_or_tablets, tablets_per_tin_or_box, total_no_tablets, updated_date FROM Tbl_stocks WHERE (updated_date BETWEEN @start_date AND @end_date) AND (m_name LIKE '%' + @m_name + '%') ", con);
                {
                    cmd.Parameters.AddWithValue("@start_date", start_date);
                    cmd.Parameters.AddWithValue("@end_date", end_date);
                    cmd.Parameters.AddWithValue("@m_name", name);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("There are no search results to print.");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            PrintDialog pdialog = new PrintDialog();
            pdialog.Document = pd;
            DialogResult result = pdialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pd.Print();
                MessageBox.Show("Printing Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font dataFont = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            float x = 100;
            float y = 100;

            // Draw headers
            e.Graphics.DrawString("Medicine Name", headerFont, brush, x -50, y);
            e.Graphics.DrawString("No of Tins/Tablets", headerFont, brush, x + 90, y);
            e.Graphics.DrawString("Tablets per Tin/Box", headerFont, brush, x + 250, y);
            e.Graphics.DrawString("Total No of Tablets", headerFont, brush, x + 420, y);
            e.Graphics.DrawString("Updated Date", headerFont, brush, x + 590, y);

            y += headerFont.GetHeight();

            // Draw data
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string m_name = row.Cells["m_name"].Value != null ? row.Cells["m_name"].Value.ToString() : "";
                int no_of_tins_or_tablets = row.Cells["no_of_tins_or_tablets"].Value != null ? (int)row.Cells["no_of_tins_or_tablets"].Value : 0;
                int tablets_per_tin_or_box = row.Cells["tablets_per_tin_or_box"].Value != null ? (int)row.Cells["tablets_per_tin_or_box"].Value : 0;
                int total_no_of_tablets = row.Cells["total_no_tablets"].Value != null ? (int)row.Cells["total_no_tablets"].Value : 0;
                DateTime updated_date = row.Cells["updated_date"].Value != null ? (DateTime)row.Cells["updated_date"].Value : DateTime.MinValue;

                e.Graphics.DrawString(m_name, dataFont, brush, x-50, y);
                e.Graphics.DrawString(no_of_tins_or_tablets.ToString(), dataFont, brush, x + 90, y);
                e.Graphics.DrawString(tablets_per_tin_or_box.ToString(), dataFont, brush, x +250, y);
                e.Graphics.DrawString(total_no_of_tablets.ToString(), dataFont, brush, x + 420, y);
                e.Graphics.DrawString(updated_date.ToString("dd/MM/yyyy"), dataFont, brush, x + 590, y);

                y += dataFont.GetHeight();
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
