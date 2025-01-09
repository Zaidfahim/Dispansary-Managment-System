using System.Data;
using System.Data.SqlClient;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Dispansary_Managment_System
{
    public partial class Consultation_Report : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=ZAIDs-MacBook-Pro.local;Initial Catalog=DMS;Persist Security Info=True;User ID=zaid;Password=p@ssWOrd");

        public Consultation_Report()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start_date = dateTimePicker1.Value;
            DateTime end_date = dateTimePicker2.Value;
            string name = txt_name.Text.Trim();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT p_id, p_name, age, date, diagnosis, M1, M1_dose, M1_times, M1_tablets, M2, M2_dose, M2_times, M2_tablets, M3, M3_dose, M3_times, M3_tablets, M4, M4_dose, M4_times, M4_tablets, M5, M5_dose, M5_times, M5_tablets, M6, M6_dose, M6_times, M6_tablets, M7, M7_dose, M7_times, M7_tablets, M8, M8_dose, M8_times, M8_tablets FROM Tbl_consult WHERE (date BETWEEN @start_date AND @end_date) AND (p_name LIKE '%' + @name + '%') ", con);
                {
                    cmd.Parameters.AddWithValue("@start_date", start_date);
                    cmd.Parameters.AddWithValue("@end_date", end_date);
                    cmd.Parameters.AddWithValue("@name", name);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Create a new DataTable containing the first 6 columns
                        DataTable dataTable1 = new DataTable();
                        for (int i = 0; i < 13; i++)
                        {
                            dataTable1.Columns.Add(dataTable.Columns[i].ColumnName, dataTable.Columns[i].DataType);
                        }
                        foreach (DataRow row in dataTable.Rows)
                        {
                            DataRow newRow = dataTable1.Rows.Add();
                            for (int i = 0; i < 13; i++)
                            {
                                newRow[i] = row[i];
                            }
                        }
                        dataGridView1.DataSource = dataTable1;

                        DataTable dataTable2 = new DataTable();
                        for (int i = 13; i < 25; i++)
                        {
                            dataTable2.Columns.Add(dataTable.Columns[i].ColumnName, dataTable.Columns[i].DataType);
                        }
                        foreach (DataRow row in dataTable.Rows)
                        {
                            DataRow newRow = dataTable2.Rows.Add();
                            for (int i = 13; i < 25; i++)
                            {
                                newRow[i - 13] = row[i];
                            }
                        }
                        dataGridView2.DataSource = dataTable2;

                        DataTable dataTable3 = new DataTable();
                        for (int i = 25; i < dataTable.Columns.Count; i++)
                        {
                            dataTable3.Columns.Add(dataTable.Columns[i].ColumnName, dataTable.Columns[i].DataType);
                        }
                        foreach (DataRow row in dataTable.Rows)
                        {
                            DataRow newRow = dataTable3.Rows.Add();
                            for (int i = 25; i < dataTable.Columns.Count; i++)
                            {
                                newRow[i - 25] = row[i];
                            }
                        }
                        dataGridView3.DataSource = dataTable3;
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
        private void FillComboBox()
        {
            try
            {
                txt_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_name.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.Refresh();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT p_name FROM Tbl_consult", con);
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
        private void Consultation_Report_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();
                if (selectedIndex < dataGridView2.Rows.Count)
                {
                    dataGridView2.Rows[selectedIndex].Selected = true;
                }
                if (selectedIndex < dataGridView3.Rows.Count)
                {
                    dataGridView3.Rows[selectedIndex].Selected = true;
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                int columnCount = 1;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    worksheet.Cells[1, columnCount].Value = column.HeaderText;
                    columnCount++;
                }

                int rowCount = 2;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    columnCount = 1;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.GetType() == typeof(DateTime))
                            {
                                worksheet.Cells[rowCount, columnCount].Value = ((DateTime)cell.Value).ToString("d");
                            }
                            else
                            {
                                worksheet.Cells[rowCount, columnCount].Value = cell.Value.ToString();
                            }
                        }
                        columnCount++;
                    }
                    rowCount++;
                }
                columnCount = 1;

                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    worksheet.Cells[1, columnCount + dataGridView1.Columns.Count].Value = column.HeaderText;
                    columnCount++;
                }
                rowCount = 2;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    columnCount = 1;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.GetType() == typeof(DateTime))
                            {
                                worksheet.Cells[rowCount, columnCount + dataGridView1.Columns.Count].Value = ((DateTime)cell.Value).ToString("d");
                            }
                            else
                            {
                                worksheet.Cells[rowCount, columnCount + dataGridView1.Columns.Count].Value = cell.Value.ToString();
                            }
                        }
                        columnCount++;
                    }
                    rowCount++;
                }
                columnCount = 1;

                foreach (DataGridViewColumn column in dataGridView3.Columns)
                {
                    worksheet.Cells[1, columnCount + dataGridView1.Columns.Count + dataGridView2.Columns.Count].Value = column.HeaderText;
                    columnCount++;
                }
                rowCount = 2;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    columnCount = 1;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.GetType() == typeof(DateTime))
                            {
                                worksheet.Cells[rowCount, columnCount + dataGridView1.Columns.Count + dataGridView2.Columns.Count].Value = ((DateTime)cell.Value).ToString("d");
                            }
                            else
                            {
                                worksheet.Cells[rowCount, columnCount + dataGridView1.Columns.Count + dataGridView2.Columns.Count].Value = cell.Value.ToString();
                            }
                        }
                        columnCount++;
                    }
                    rowCount++;
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                    excelPackage.SaveAs(excelFile);
                }
                MessageBox.Show("Excel file saved successfully.");
            }
        } // Print Excel
    }
}
