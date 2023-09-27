using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KickerRating
{

    
    public partial class ChangeName : Form
    {
        public bool AllPlayersSaved = false;
        bool saved = false;
        public int i;
        string name;
        public Tournament tournament;
        public ChangeName(Tournament tour)
        {
            InitializeComponent();
            tournament = tour;
        }
        public void AllPlayersSavedSet(bool a)
        {
            AllPlayersSaved = a;
        }
        public Boolean getSaved() 
        {
            return saved;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
                SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
                con.Open();
                saved = false;
                SqlCommand cmd1 = new SqlCommand("select * from Игрок where Имя = @Имя", con);
                SqlParameter Parameter = new SqlParameter("@Имя", FIOBox.Text);
                cmd1.Parameters.Add(Parameter);
                var str = cmd1.ExecuteReader();
                if (str.HasRows)
                {
                str.Close();
                    if (FIOBox.Text != "")
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(name + " это существующий игрок с ФИО " + FIOBox.Text + "?", "Добавление", buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            saved = true;
                        tournament.players[i-1]._name = FIOBox.Text;
                        }
                    }
                }
                else
                {
                str.Close();
                if (FIOBox.Text != "")
                    {
                        int rate;
                        if (RateBox.Text != "")
                        {
                            rate = Convert.ToInt32(RateBox.Text);
                        }
                        else
                        {
                            rate = 1200;
                        }
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show("Добавить игрока " + name + " под именем " + FIOBox.Text + " с рейтингом " + rate, "Добавление", buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                        cmd1 = new SqlCommand("select max(id) from Игрок ", con);
                        saved = true;
                        int id = 0;
                        var a = cmd1.ExecuteScalar();
                        if (a is not System.DBNull) {
                            id = (int)cmd1.ExecuteScalar();
                        }
                        str.Close();
                        SqlCommand cmd2 = new SqlCommand("insert into Игрок (ID ,Имя, Первое, Второе, Третье, Рейтинг) values (@ID,@ФИО,0,0,0,@Рейтинг)", con);
                        
                        id = id + 1;
                        Parameter = new SqlParameter("@ID", id);
                        cmd2.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@ФИО", FIOBox.Text);
                        cmd2.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@Рейтинг", rate);
                        cmd2.Parameters.Add(Parameter);
                        cmd2.ExecuteNonQuery();
                        tournament.players[i-1]._name = FIOBox.Text;
                    }
                    }
                }
                con.Close();
            if (saved) { Parser.tournirAnalisys(tournament, i, this);}
        }
        public void changeFIO(string name,int j, Tournament tour)
        {
            FIOBox.Text = name;
            this.name = name;
            i = j + 1;
            tournament = tour;
        }

       
        private void ChangeName_Load(object sender, EventArgs e)
        {

        }
    }
    }
