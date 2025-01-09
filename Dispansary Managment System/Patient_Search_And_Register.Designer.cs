namespace Dispansary_Managment_System
{
    partial class Patient_Search_And_Register
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_pid = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_female = new System.Windows.Forms.RadioButton();
            this.radioButton_male = new System.Windows.Forms.RadioButton();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_pid);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioButton_female);
            this.groupBox1.Controls.Add(this.radioButton_male);
            this.groupBox1.Controls.Add(this.btn_clear);
            this.groupBox1.Controls.Add(this.btn_edit);
            this.groupBox1.Controls.Add(this.btn_register);
            this.groupBox1.Controls.Add(this.txt_phone);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_address);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_age);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(46, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 765);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient Registration";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbl_pid
            // 
            this.lbl_pid.AutoSize = true;
            this.lbl_pid.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_pid.ForeColor = System.Drawing.Color.Blue;
            this.lbl_pid.Location = new System.Drawing.Point(186, 63);
            this.lbl_pid.Name = "lbl_pid";
            this.lbl_pid.Size = new System.Drawing.Size(101, 28);
            this.lbl_pid.TabIndex = 26;
            this.lbl_pid.Text = "Patient ID";
            this.lbl_pid.Click += new System.EventHandler(this.lbl_pid_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Location = new System.Drawing.Point(131, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(240, 27);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(66, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 28);
            this.label2.TabIndex = 25;
            this.label2.Text = "Patient ID  -";
            // 
            // radioButton_female
            // 
            this.radioButton_female.AutoSize = true;
            this.radioButton_female.Location = new System.Drawing.Point(152, 290);
            this.radioButton_female.Name = "radioButton_female";
            this.radioButton_female.Size = new System.Drawing.Size(78, 24);
            this.radioButton_female.TabIndex = 24;
            this.radioButton_female.TabStop = true;
            this.radioButton_female.Text = "Female";
            this.radioButton_female.UseVisualStyleBackColor = true;
            this.radioButton_female.CheckedChanged += new System.EventHandler(this.radioButton_female_CheckedChanged);
            // 
            // radioButton_male
            // 
            this.radioButton_male.AutoSize = true;
            this.radioButton_male.Location = new System.Drawing.Point(28, 290);
            this.radioButton_male.Name = "radioButton_male";
            this.radioButton_male.Size = new System.Drawing.Size(63, 24);
            this.radioButton_male.TabIndex = 23;
            this.radioButton_male.TabStop = true;
            this.radioButton_male.Text = "Male";
            this.radioButton_male.UseVisualStyleBackColor = true;
            this.radioButton_male.CheckedChanged += new System.EventHandler(this.radioButton_male_CheckedChanged);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.Chocolate;
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_clear.Location = new System.Drawing.Point(249, 513);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(99, 35);
            this.btn_clear.TabIndex = 22;
            this.btn_clear.Text = "CLear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_edit.Location = new System.Drawing.Point(93, 657);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(206, 66);
            this.btn_edit.TabIndex = 16;
            this.btn_edit.Text = "Update";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_register.Location = new System.Drawing.Point(93, 569);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(206, 66);
            this.btn_register.TabIndex = 15;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(122, 480);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(156, 27);
            this.txt_phone.TabIndex = 12;
            this.txt_phone.TextChanged += new System.EventHandler(this.txt_phone_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Phone NO";
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(28, 361);
            this.txt_address.Multiline = true;
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(235, 88);
            this.txt_address.TabIndex = 10;
            this.txt_address.TextChanged += new System.EventHandler(this.txt_address_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sex";
            // 
            // txt_age
            // 
            this.txt_age.Location = new System.Drawing.Point(131, 203);
            this.txt_age.Name = "txt_age";
            this.txt_age.Size = new System.Drawing.Size(46, 27);
            this.txt_age.TabIndex = 5;
            this.txt_age.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Current Age";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(28, 149);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(250, 27);
            this.txt_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(475, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(982, 340);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search/Delete Patient";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.IndianRed;
            this.button4.Location = new System.Drawing.Point(483, 269);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 47);
            this.button4.TabIndex = 20;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.YellowGreen;
            this.button3.Location = new System.Drawing.Point(322, 269);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 47);
            this.button3.TabIndex = 17;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(912, 180);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(372, 44);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(229, 27);
            this.textBox5.TabIndex = 18;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Phone NO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(605, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(396, 41);
            this.label10.TabIndex = 21;
            this.label10.Text = "Patient Search And Register";
            // 
            // Patient_Search_And_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Patient_Search_And_Register";
            this.Size = new System.Drawing.Size(1528, 863);
            this.Load += new System.EventHandler(this.Patient_Search_And_Register_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_edit;
        private Button btn_register;
        private TextBox txt_phone;
        private Label label6;
        private TextBox txt_address;
        private Label label5;
        private Label label4;
        private TextBox txt_age;
        private Label label3;
        private TextBox txt_name;
        private Label label1;
        private GroupBox groupBox2;
        private Button button4;
        private Button button3;
        private DataGridView dataGridView1;
        private TextBox textBox5;
        private Label label7;
        private Label label10;
        private DateTimePicker dateTimePicker1;
        private Button btn_clear;
        private RadioButton radioButton_female;
        private RadioButton radioButton_male;
        private Label lbl_pid;
        private Label label2;
    }
}
