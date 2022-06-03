namespace WindowsForms
{
    partial class EditMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMatch));
            this.comboBox_matchStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_updatematch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_player2score = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_player1score = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_matchstage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_player1 = new System.Windows.Forms.ComboBox();
            this.label_currentPlayerOne = new System.Windows.Forms.Label();
            this.label_currentPlayerTwo = new System.Windows.Forms.Label();
            this.comboBox_player2 = new System.Windows.Forms.ComboBox();
            this.label_currentstatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_player2score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_player1score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_matchStatus
            // 
            this.comboBox_matchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_matchStatus.FormattingEnabled = true;
            this.comboBox_matchStatus.Items.AddRange(new object[] {
            "ROUND ROBIN",
            "SINGLE ELIMINATION",
            "DOUBLE ELIMINATION"});
            this.comboBox_matchStatus.Location = new System.Drawing.Point(464, 350);
            this.comboBox_matchStatus.Name = "comboBox_matchStatus";
            this.comboBox_matchStatus.Size = new System.Drawing.Size(112, 23);
            this.comboBox_matchStatus.TabIndex = 56;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 317);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 15);
            this.label10.TabIndex = 55;
            this.label10.Text = "Tournament Status";
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(464, 413);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(167, 45);
            this.button_cancel.TabIndex = 54;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_updatematch
            // 
            this.button_updatematch.Location = new System.Drawing.Point(271, 413);
            this.button_updatematch.Name = "button_updatematch";
            this.button_updatematch.Size = new System.Drawing.Size(167, 45);
            this.button_updatematch.TabIndex = 52;
            this.button_updatematch.Text = "Update Match";
            this.button_updatematch.UseVisualStyleBackColor = true;
            this.button_updatematch.Click += new System.EventHandler(this.button_updatematch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(487, 413);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 15);
            this.label8.TabIndex = 51;
            // 
            // numericUpDown_player2score
            // 
            this.numericUpDown_player2score.Location = new System.Drawing.Point(466, 253);
            this.numericUpDown_player2score.Name = "numericUpDown_player2score";
            this.numericUpDown_player2score.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown_player2score.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 46;
            this.label5.Text = "Player 2 Score";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 45;
            this.label4.Text = "Player 1 Score";
            // 
            // numericUpDown_player1score
            // 
            this.numericUpDown_player1score.Location = new System.Drawing.Point(466, 189);
            this.numericUpDown_player1score.Name = "numericUpDown_player1score";
            this.numericUpDown_player1score.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown_player1score.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 42;
            this.label3.Text = "Player 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 41;
            this.label2.Text = "Player 1";
            // 
            // textBox_matchstage
            // 
            this.textBox_matchstage.Location = new System.Drawing.Point(201, 131);
            this.textBox_matchstage.Name = "textBox_matchstage";
            this.textBox_matchstage.Size = new System.Drawing.Size(237, 23);
            this.textBox_matchstage.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 38;
            this.label9.Text = "Stage";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(170, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 37);
            this.label1.TabIndex = 36;
            this.label1.Text = "UPDATE MATCH";
            // 
            // comboBox_player1
            // 
            this.comboBox_player1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_player1.FormattingEnabled = true;
            this.comboBox_player1.Location = new System.Drawing.Point(201, 189);
            this.comboBox_player1.Name = "comboBox_player1";
            this.comboBox_player1.Size = new System.Drawing.Size(237, 23);
            this.comboBox_player1.TabIndex = 57;
            // 
            // label_currentPlayerOne
            // 
            this.label_currentPlayerOne.AutoSize = true;
            this.label_currentPlayerOne.Location = new System.Drawing.Point(255, 171);
            this.label_currentPlayerOne.Name = "label_currentPlayerOne";
            this.label_currentPlayerOne.Size = new System.Drawing.Size(89, 15);
            this.label_currentPlayerOne.TabIndex = 58;
            this.label_currentPlayerOne.Text = "(current: name)";
            // 
            // label_currentPlayerTwo
            // 
            this.label_currentPlayerTwo.AutoSize = true;
            this.label_currentPlayerTwo.Location = new System.Drawing.Point(255, 235);
            this.label_currentPlayerTwo.Name = "label_currentPlayerTwo";
            this.label_currentPlayerTwo.Size = new System.Drawing.Size(89, 15);
            this.label_currentPlayerTwo.TabIndex = 59;
            this.label_currentPlayerTwo.Text = "(current: name)";
            // 
            // comboBox_player2
            // 
            this.comboBox_player2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_player2.FormattingEnabled = true;
            this.comboBox_player2.Location = new System.Drawing.Point(201, 253);
            this.comboBox_player2.Name = "comboBox_player2";
            this.comboBox_player2.Size = new System.Drawing.Size(237, 23);
            this.comboBox_player2.TabIndex = 60;
            // 
            // label_currentstatus
            // 
            this.label_currentstatus.AutoSize = true;
            this.label_currentstatus.Location = new System.Drawing.Point(464, 332);
            this.label_currentstatus.Name = "label_currentstatus";
            this.label_currentstatus.Size = new System.Drawing.Size(90, 15);
            this.label_currentstatus.TabIndex = 61;
            this.label_currentstatus.Text = "(current: status)";
            // 
            // EditMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 504);
            this.Controls.Add(this.label_currentstatus);
            this.Controls.Add(this.comboBox_player2);
            this.Controls.Add(this.label_currentPlayerTwo);
            this.Controls.Add(this.label_currentPlayerOne);
            this.Controls.Add(this.comboBox_player1);
            this.Controls.Add(this.comboBox_matchStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_updatematch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown_player2score);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_player1score);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_matchstage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "EditMatch";
            this.Text = "EditMatch";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_player2score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_player1score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBox_matchStatus;
        private Label label10;
        private Button button_cancel;
        private Button button_updatematch;
        private Label label8;
        private NumericUpDown numericUpDown_player2score;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown_player1score;
        private Label label3;
        private Label label2;
        private TextBox textBox_matchstage;
        private Label label9;
        private PictureBox pictureBox1;
        private Label label1;
        private ComboBox comboBox_player1;
        private Label label_currentPlayerOne;
        private Label label_currentPlayerTwo;
        private ComboBox comboBox_player2;
        private Label label_currentstatus;
    }
}