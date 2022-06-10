namespace WindowsForms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button_tournamentpage = new System.Windows.Forms.Button();
            this.button_matchpage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_tournamentpage
            // 
            this.button_tournamentpage.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_tournamentpage.Location = new System.Drawing.Point(23, 122);
            this.button_tournamentpage.Name = "button_tournamentpage";
            this.button_tournamentpage.Size = new System.Drawing.Size(152, 67);
            this.button_tournamentpage.TabIndex = 2;
            this.button_tournamentpage.Text = "Tournaments";
            this.button_tournamentpage.UseVisualStyleBackColor = true;
            this.button_tournamentpage.Click += new System.EventHandler(this.button_tournamentpage_Click);
            // 
            // button_matchpage
            // 
            this.button_matchpage.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_matchpage.Location = new System.Drawing.Point(23, 214);
            this.button_matchpage.Name = "button_matchpage";
            this.button_matchpage.Size = new System.Drawing.Size(152, 67);
            this.button_matchpage.TabIndex = 3;
            this.button_matchpage.Text = "Matches";
            this.button_matchpage.UseVisualStyleBackColor = true;
            this.button_matchpage.Click += new System.EventHandler(this.button_matchpage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(202, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 467);
            this.panel1.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_matchpage);
            this.Controls.Add(this.button_tournamentpage);
            this.Name = "Main";
            this.Text = "BADSYS";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button button_tournamentpage;
        private Button button_matchpage;
        private PictureBox pictureBox1;
        private Panel panel1;
    }
}