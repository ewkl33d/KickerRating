namespace KickerRating
{
    partial class Itog
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
            this.ItogGridView = new System.Windows.Forms.DataGridView();
            this.GamesGridView = new System.Windows.Forms.DataGridView();
            this.comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ItogGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GamesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ItogGridView
            // 
            this.ItogGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItogGridView.Location = new System.Drawing.Point(12, 12);
            this.ItogGridView.Name = "ItogGridView";
            this.ItogGridView.RowTemplate.Height = 25;
            this.ItogGridView.Size = new System.Drawing.Size(344, 689);
            this.ItogGridView.TabIndex = 0;
            // 
            // GamesGridView
            // 
            this.GamesGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GamesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GamesGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GamesGridView.ColumnHeadersVisible = false;
            this.GamesGridView.GridColor = System.Drawing.SystemColors.Control;
            this.GamesGridView.Location = new System.Drawing.Point(399, 12);
            this.GamesGridView.Name = "GamesGridView";
            this.GamesGridView.ReadOnly = true;
            this.GamesGridView.RowHeadersVisible = false;
            this.GamesGridView.RowTemplate.Height = 25;
            this.GamesGridView.Size = new System.Drawing.Size(731, 610);
            this.GamesGridView.TabIndex = 1;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(598, 648);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(368, 23);
            this.comboBox.TabIndex = 2;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // Itog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 713);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.GamesGridView);
            this.Controls.Add(this.ItogGridView);
            this.Name = "Itog";
            this.Text = "Itog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Itog_FormClosed);
            this.Load += new System.EventHandler(this.Itog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItogGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GamesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView ItogGridView;
        private DataGridView GamesGridView;
        private ComboBox comboBox;
    }
}