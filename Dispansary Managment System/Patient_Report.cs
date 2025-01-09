using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Dispansary_Managment_System
{
    public partial class Patient_Report : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");

        public Patient_Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start_date = dateTimePicker1.Value;
            DateTime end_date = dateTimePicker2.Value;
            string name = txt_name.Text.Trim();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT p_id, date, p_name, age, gender, address, phone FROM Tbl_registrations WHERE (date BETWEEN @start_date AND @end_date) AND (p_name LIKE '%' + @name + '%') ", con);
                {
                    cmd.Parameters.AddWithValue("@start_date", start_date);
                    cmd.Parameters.AddWithValue("@end_date", end_date);
                    cmd.Parameters.AddWithValue("@name", name);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            float x = 100;
            float y = 100;
            float rowMargin = 10;

            // Draw headers

            if (rowMargin == 10);
            {
                e.Graphics.DrawString("Patient ID", font, brush, x - 70, y);
                e.Graphics.DrawString("Date", font, brush, x + 20, y);
                e.Graphics.DrawString("Patient Name", font, brush, x + 110, y);
                e.Graphics.DrawString("Age", font, brush, x + 300, y);
                e.Graphics.DrawString("Gender", font, brush, x + 340, y);
                e.Graphics.DrawString("Address", font, brush, x + 420, y);
                e.Graphics.DrawString("Phone", font, brush, x + 620, y);
            }
            y += font.GetHeight() + rowMargin; ;

            // Draw data
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string p_id = row.Cells["p_id"].Value.ToString();
                DateTime date = (DateTime)row.Cells["date"].Value;
                string p_name = row.Cells["p_name"].Value.ToString();
                int age = (int)row.Cells["age"].Value;
                string gender = row.Cells["gender"].Value.ToString();
                string address = row.Cells["address"].Value.ToString();
                string phone = row.Cells["phone"].Value.ToString();
                
                if (rowMargin == 10) ;
                {

                    e.Graphics.DrawString(p_id, font, brush, x - 70, y);
                    e.Graphics.DrawString(date.ToShortDateString(), font, brush, x + 20, y);
                    e.Graphics.DrawString(p_name, font, brush, x + 110, y);
                    e.Graphics.DrawString(age.ToString(), font, brush, x + 300, y);
                    e.Graphics.DrawString(gender, font, brush, x + 340, y);
                    e.Graphics.DrawString(address, font, brush, x + 420, y);
                    e.Graphics.DrawString(phone, font, brush, x + 630, y);
                }

                y += font.GetHeight();
            }
        }
        private void FillComboBox()
        {
            try
            {
                txt_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_name.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.Refresh();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT p_name FROM Tbl_registrations", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                txt_name.Items.Clear();
                while (reader.Read())
                {
                    txt_name.Items.Add(reader["p_name"].ToString());
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }// To Fill The ComboBox
        private void Patient_Report_Load(object sender, EventArgs e)
        {
            FillComboBox(); 
        }

        private void txt_name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
