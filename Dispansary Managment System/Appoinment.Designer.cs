namespace Dispansary_Managment_System
{
    partial class Appoinment
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.Appoinment_Date = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_AppNo = new System.Windows.Forms.TextBox();
            this.txt_PhoneNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Age = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(539, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appoinment";
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Name.Location = new System.Drawing.Point(120, 254);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(206, 27);
            this.txt_Name.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "7AM - 8AM",
            "12PM - 2PM",
            "5PM - 9PM",
            "After 7PM",
            "After 8PM"});
            this.comboBox1.Location = new System.Drawing.Point(154, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 28);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.Appoinment_Date);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.txt_AppNo);
            this.groupBox1.Controls.Add(this.txt_PhoneNo);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_Age);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(102, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 586);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Make Appoinments";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Chocolate;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.Location = new System.Drawing.Point(290, 319);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(81, 39);
            this.button6.TabIndex = 14;
            this.button6.Text = "CLear";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Appoinment_Date
            // 
            this.Appoinment_Date.CustomFormat = "MM/dd/yyyy";
            this.Appoinment_Date.Location = new System.Drawing.Point(76, 37);
            this.Appoinment_Date.Name = "Appoinment_Date";
            this.Appoinment_Date.Size = new System.Drawing.Size(250, 27);
            this.Appoinment_Date.TabIndex = 13;
            this.Appoinment_Date.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.YellowGreen;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(120, 173);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(167, 50);
            this.button4.TabIndex = 8;
            this.button4.Text = "Search Appoinment";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkOrange;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(71, 475);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 55);
            this.button2.TabIndex = 6;
            this.button2.Text = "Update Appoinment";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LimeGreen;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(141, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 55);
            this.button3.TabIndex = 7;
            this.button3.Text = "Make An Appoinment";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_AppNo
            // 
            this.txt_AppNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_AppNo.Location = new System.Drawing.Point(227, 81);
            this.txt_AppNo.Name = "txt_AppNo";
            this.txt_AppNo.Size = new System.Drawing.Size(66, 27);
            this.txt_AppNo.TabIndex = 12;
            // 
            // txt_PhoneNo
            // 
            this.txt_PhoneNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_PhoneNo.Location = new System.Drawing.Point(120, 331);
            this.txt_PhoneNo.Name = "txt_PhoneNo";
            this.txt_PhoneNo.Size = new System.Drawing.Size(154, 27);
            this.txt_PhoneNo.TabIndex = 10;
            this.txt_PhoneNo.TextChanged += new System.EventHandler(this.txt_PhoneNo_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(203, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 55);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancel Appoinment";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(75, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Appoinment NO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(28, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phone NO";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txt_Age
            // 
            this.txt_Age.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Age.Location = new System.Drawing.Point(120, 292);
            this.txt_Age.Name = "txt_Age";
            this.txt_Age.Size = new System.Drawing.Size(154, 27);
            this.txt_Age.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(59, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Time Slot";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(42, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(42, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(511, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(799, 437);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.RowDividerDoubleClick += new System.Windows.Forms.DataGridViewRowDividerDoubleClickEventHandler(this.dataGridView1_RowDividerDoubleClick);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.YellowGreen;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(1155, 111);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 52);
            this.button5.TabIndex = 15;
            this.button5.Text = "Search Appoinments";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker2.Location = new System.Drawing.Point(813, 91);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(264, 27);
            this.dateTimePicker2.TabIndex = 15;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "7AM - 8AM",
            "12PM - 2PM",
            "5PM - 9PM",
            "After 7PM",
            "After 8PM"});
            this.comboBox2.Location = new System.Drawing.Point(908, 135);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(154, 28);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(816, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Time Slot";
            // 
            // Appoinment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Appoinment";
            this.Size = new System.Drawing.Size(1341, 732);
            this.Load += new System.EventHandler(this.Appoinment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txt_Name;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label3;
        private TextBox txt_AppNo;
        private TextBox txt_Age;
        private TextBox txt_PhoneNo;
        private Button button2;
        private Button button3;
        private Button button1;
        private Button button4;
        private DataGridView dataGridView1;
        private Button button5;
        private DateTimePicker Appoinment_Date;
        private Button button6;
        private DateTimePicker dateTimePicker2;
        private ComboBox comboBox2;
        private Label label7;
    }
}
