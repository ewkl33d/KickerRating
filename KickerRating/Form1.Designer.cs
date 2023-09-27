namespace KickerRating
{
    partial class Form1
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
            this.ButtonProvodnik = new System.Windows.Forms.Button();
            this.GamesGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GamesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonProvodnik
            // 
            this.ButtonProvodnik.Location = new System.Drawing.Point(936, 41);
            this.ButtonProvodnik.Name = "ButtonProvodnik";
            this.ButtonProvodnik.Size = new System.Drawing.Size(142, 50);
            this.ButtonProvodnik.TabIndex = 0;
            this.ButtonProvodnik.Text = "Проводник";
            this.ButtonProvodnik.UseVisualStyleBackColor = true;
            this.ButtonProvodnik.Click += new System.EventHandler(this.ButtonProvodnik_Click);
            // 
            // GamesGridView
            // 
            this.GamesGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GamesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GamesGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GamesGridView.ColumnHeadersVisible = false;
            this.GamesGridView.GridColor = System.Drawing.SystemColors.Control;
            this.GamesGridView.Location = new System.Drawing.Point(135, 59);
            this.GamesGridView.Name = "GamesGridView";
            this.GamesGridView.ReadOnly = true;
            this.GamesGridView.RowHeadersVisible = false;
            this.GamesGridView.RowTemplate.Height = 25;
            this.GamesGridView.Size = new System.Drawing.Size(731, 610);
            this.GamesGridView.TabIndex = 2;
            this.GamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GamesGridView_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 723);
            this.Controls.Add(this.GamesGridView);
            this.Controls.Add(this.ButtonProvodnik);
            this.Name = "Form1";
            this.Text = "Рейтинги";
            ((System.ComponentModel.ISupportInitialize)(this.GamesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button ButtonProvodnik;
        private DataGridView GamesGridView;
    }
}