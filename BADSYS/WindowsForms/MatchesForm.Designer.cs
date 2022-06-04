namespace WindowsForms
{
    partial class MatchesForm
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
            this.tabControl_matches = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox_tournamentselect = new System.Windows.Forms.ComboBox();
            this.button_edit = new System.Windows.Forms.Button();
            this.matchesDVG = new System.Windows.Forms.DataGridView();
            this.tabControl_matches.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDVG)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_matches
            // 
            this.tabControl_matches.Controls.Add(this.tabPage1);
            this.tabControl_matches.Location = new System.Drawing.Point(10, 8);
            this.tabControl_matches.Name = "tabControl_matches";
            this.tabControl_matches.SelectedIndex = 0;
            this.tabControl_matches.Size = new System.Drawing.Size(978, 458);
            this.tabControl_matches.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox_tournamentselect);
            this.tabPage1.Controls.Add(this.button_edit);
            this.tabPage1.Controls.Add(this.matchesDVG);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(970, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Matches Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox_tournamentselect
            // 
            this.comboBox_tournamentselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tournamentselect.FormattingEnabled = true;
            this.comboBox_tournamentselect.Location = new System.Drawing.Point(843, 102);
            this.comboBox_tournamentselect.Name = "comboBox_tournamentselect";
            this.comboBox_tournamentselect.Size = new System.Drawing.Size(121, 23);
            this.comboBox_tournamentselect.TabIndex = 2;
            this.comboBox_tournamentselect.SelectionChangeCommitted += new System.EventHandler(this.comboBox_tournamentselect_SelectionChangeCommitted);
            // 
            // button_edit
            // 
            this.button_edit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_edit.Location = new System.Drawing.Point(846, 40);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(95, 35);
            this.button_edit.TabIndex = 1;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // matchesDVG
            // 
            this.matchesDVG.AllowUserToAddRows = false;
            this.matchesDVG.AllowUserToDeleteRows = false;
            this.matchesDVG.AllowUserToOrderColumns = true;
            this.matchesDVG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.matchesDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchesDVG.Location = new System.Drawing.Point(6, 6);
            this.matchesDVG.Name = "matchesDVG";
            this.matchesDVG.ReadOnly = true;
            this.matchesDVG.RowTemplate.Height = 25;
            this.matchesDVG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.matchesDVG.Size = new System.Drawing.Size(811, 414);
            this.matchesDVG.TabIndex = 0;
            // 
            // MatchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 474);
            this.Controls.Add(this.tabControl_matches);
            this.Name = "MatchesForm";
            this.Text = "Matches";
            this.tabControl_matches.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matchesDVG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl_matches;
        private TabPage tabPage1;
        private Button button_edit;
        private DataGridView matchesDVG;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private ComboBox comboBox_tournamentselect;
    }
}