
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;


namespace Dispansary_Managment_System
{
    public partial class Paayment_Details : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");

        public Paayment_Details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start_date = dateTimePicker1.Value;
            DateTime end_date = dateTimePicker2.Value;
            string pid = txt_pid.Text.Trim();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT p_id, date, amount, payment_method FROM Tbl_payment WHERE (date BETWEEN @start_date AND @end_date) AND (p_id LIKE '%' + @p_id + '%') ", con);
                {
                    cmd.Parameters.AddWithValue("@start_date", start_date);
                    cmd.Parameters.AddWithValue("@end_date", end_date);
                    cmd.Parameters.AddWithValue("@p_id", pid);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                con.Close();

                decimal totalAmount = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    decimal amount;
                    if (decimal.TryParse(row.Cells[2].Value.ToString(), out amount))
                    {
                        totalAmount += amount;
                    }
                }
                lbl_amount.Text = "Total Amount: Rs " + totalAmount.ToString("0.00");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FillComboBox()
        {
            try
            {
                txt_pid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_pid.AutoCompleteSource = AutoCompleteSource.ListItems;


                SqlCommand cmd = new SqlCommand("SELECT DISTINCT p_id FROM Tbl_payment", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                txt_pid.Items.Clear();
                while (reader.Read())
                {
                    txt_pid.Items.Add(reader["p_id"].ToString());
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }// To Fill The ComboBox
        private void Paayment_Details_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void txt_pid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!txt_pid.Text.StartsWith("P-"))
            {
                txt_pid.Text = "P-";
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
            Font headerFont = new Font("Arial", 13, FontStyle.Bold);
            Font dataFont = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            float x = 100;
            float y = 70;

            // Draw headers
            e.Graphics.DrawString("Patient ID", headerFont, brush, x, y);
            e.Graphics.DrawString("Date", headerFont, brush, x + 150, y);
            e.Graphics.DrawString("Amount (Rs)", headerFont, brush, x + 300, y);
            e.Graphics.DrawString("Payment Method", headerFont, brush, x + 450, y);

            y += headerFont.GetHeight() +10;

            // Draw data
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string p_id = row.Cells["p_id"].Value != null ? row.Cells["p_id"].Value.ToString() : "";
                DateTime date = row.Cells["date"].Value != null ? (DateTime)row.Cells["date"].Value : DateTime.MinValue;
                int amountInt = row.Cells["amount"].Value != null ? (int)row.Cells["amount"].Value : 0;
                decimal amount = Convert.ToDecimal(amountInt);
                string payment_method = row.Cells["payment_method"].Value != null ? row.Cells["payment_method"].Value.ToString() : "";

                e.Graphics.DrawString(p_id, dataFont, brush, x, y);
                e.Graphics.DrawString(date.ToString("dd/MM/yyyy"), dataFont, brush, x + 150, y);
                e.Graphics.DrawString("Rs " + amount.ToString("F2"), dataFont, brush, x + 300, y);
                e.Graphics.DrawString(payment_method, dataFont, brush, x + 450, y);

                y += dataFont.GetHeight();
            }

            // Add label text
            string labelText = lbl_amount.Text;
            SizeF labelSize = e.Graphics.MeasureString(labelText, headerFont);
            float labelX = e.PageBounds.Right - labelSize.Width - 70;
            float labelY = e.PageBounds.Bottom - labelSize.Height - 60;
            e.Graphics.DrawString(labelText, headerFont, brush, labelX, labelY);
        }



    }
}
