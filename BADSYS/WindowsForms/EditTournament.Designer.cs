namespace WindowsForms
{
    partial class EditTournament
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTournament));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox_tournamentSystem = new System.Windows.Forms.ComboBox();
            this.button_updatetournament = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_tournamentAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_tournamentMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_tournamentMin = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker_tournamentEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_tournamentStart = new System.Windows.Forms.DateTimePicker();
            this.textBox_tournamentname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.comboBox_tournamentStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tournamentMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tournamentMin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(170, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "UPDATE TOURNAMENT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox_tournamentSystem
            // 
            this.comboBox_tournamentSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tournamentSystem.FormattingEnabled = true;
            this.comboBox_tournamentSystem.Items.AddRange(new object[] {
            "ROUND ROBIN",
            "SINGLE ELIMINATION",
            "DOUBLE ELIMINATION"});
            this.comboBox_tournamentSystem.Location = new System.Drawing.Point(326, 368);
            this.comboBox_tournamentSystem.Name = "comboBox_tournamentSystem";
            this.comboBox_tournamentSystem.Size = new System.Drawing.Size(112, 23);
            this.comboBox_tournamentSystem.TabIndex = 32;
            // 
            // button_updatetournament
            // 
            this.button_updatetournament.Location = new System.Drawing.Point(271, 424);
            this.button_updatetournament.Name = "button_updatetournament";
            this.button_updatetournament.Size = new System.Drawing.Size(167, 45);
            this.button_updatetournament.TabIndex = 31;
            this.button_updatetournament.Text = "Update Tournament";
            this.button_updatetournament.UseVisualStyleBackColor = true;
            this.button_updatetournament.Click += new System.EventHandler(this.button_updatetournament_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(487, 424);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 15);
            this.label8.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 15);
            this.label7.TabIndex = 29;
            this.label7.Text = "Tournament System";
            // 
            // textBox_tournamentAddress
            // 
            this.textBox_tournamentAddress.Location = new System.Drawing.Point(511, 274);
            this.textBox_tournamentAddress.Name = "textBox_tournamentAddress";
            this.textBox_tournamentAddress.Size = new System.Drawing.Size(120, 23);
            this.textBox_tournamentAddress.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(511, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Address";
            // 
            // numericUpDown_tournamentMax
            // 
            this.numericUpDown_tournamentMax.Location = new System.Drawing.Point(511, 210);
            this.numericUpDown_tournamentMax.Name = "numericUpDown_tournamentMax";
            this.numericUpDown_tournamentMax.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown_tournamentMax.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(511, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Maximum Players";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Minimum Players";
            // 
            // numericUpDown_tournamentMin
            // 
            this.numericUpDown_tournamentMin.Location = new System.Drawing.Point(511, 142);
            this.numericUpDown_tournamentMin.Name = "numericUpDown_tournamentMin";
            this.numericUpDown_tournamentMin.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown_tournamentMin.TabIndex = 23;
            // 
            // dateTimePicker_tournamentEnd
            // 
            this.dateTimePicker_tournamentEnd.Location = new System.Drawing.Point(201, 264);
            this.dateTimePicker_tournamentEnd.Name = "dateTimePicker_tournamentEnd";
            this.dateTimePicker_tournamentEnd.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker_tournamentEnd.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Start Date";
            // 
            // dateTimePicker_tournamentStart
            // 
            this.dateTimePicker_tournamentStart.Location = new System.Drawing.Point(201, 200);
            this.dateTimePicker_tournamentStart.Name = "dateTimePicker_tournamentStart";
            this.dateTimePicker_tournamentStart.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker_tournamentStart.TabIndex = 19;
            // 
            // textBox_tournamentname
            // 
            this.textBox_tournamentname.Location = new System.Drawing.Point(201, 142);
            this.textBox_tournamentname.Name = "textBox_tournamentname";
            this.textBox_tournamentname.Size = new System.Drawing.Size(237, 23);
            this.textBox_tournamentname.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Tournament Name / Description";
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(464, 424);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(167, 45);
            this.button_cancel.TabIndex = 33;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // comboBox_tournamentStatus
            // 
            this.comboBox_tournamentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tournamentStatus.FormattingEnabled = true;
            this.comboBox_tournamentStatus.Items.AddRange(new object[] {
            "ROUND ROBIN",
            "SINGLE ELIMINATION",
            "DOUBLE ELIMINATION"});
            this.comboBox_tournamentStatus.Location = new System.Drawing.Point(464, 368);
            this.comboBox_tournamentStatus.Name = "comboBox_tournamentStatus";
            this.comboBox_tournamentStatus.Size = new System.Drawing.Size(112, 23);
            this.comboBox_tournamentStatus.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 15);
            this.label10.TabIndex = 34;
            this.label10.Text = "Tournament Status";
            // 
            // EditTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 504);
            this.Controls.Add(this.comboBox_tournamentStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.comboBox_tournamentSystem);
            this.Controls.Add(this.button_updatetournament);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_tournamentAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown_tournamentMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_tournamentMin);
            this.Controls.Add(this.dateTimePicker_tournamentEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_tournamentStart);
            this.Controls.Add(this.textBox_tournamentname);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "EditTournament";
            this.Text = "EditTournament";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tournamentMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tournamentMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private ComboBox comboBox_tournamentSystem;
        private Button button_updatetournament;
        private Label label8;
        private Label label7;
        private TextBox textBox_tournamentAddress;
        private Label label6;
        private NumericUpDown numericUpDown_tournamentMax;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown_tournamentMin;
        private DateTimePicker dateTimePicker_tournamentEnd;
        private Label label3;
        private Label label2;
        private DateTimePicker dateTimePicker_tournamentStart;
        private TextBox textBox_tournamentname;
        private Label label9;
        private Button button_cancel;
        private ComboBox comboBox_tournamentStatus;
        private Label label10;
    }
}