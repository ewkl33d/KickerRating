using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;

namespace KickerRating
{
    public partial class Itog : Form
    {
        public Itog()
        {
            InitializeComponent();
        }

        public void UpdateTable() 
        {
            SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
            con.Open();
            var cmdSelect = con.CreateCommand();
            cmdSelect.CommandText = "SELECT Имя, РейтингПосле, (РейтингПосле - РейтингДо) as Разница from ИтогТурнира order by Разница desc";
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataSet ds = new DataSet();
            ds.Tables.Clear();
            da.Fill(ds);
            ItogGridView.DataSource = ds.Tables["Table"];
            con.Close();
        }
        private void Itog_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
            con.Open();
            var cmdSelect = con.CreateCommand();
            cmdSelect.CommandText = "SELECT Команда1, convert(nvarchar(1),Команда1Счет) + ':' + convert(nvarchar(1),Команда2Счет) as _, Команда2, Рейтинг = case when ((Команда1 like ('%" + comboBox.Text+"%') and Победа = 1) or Команда2 like ('%"+comboBox.Text+ "%')and Победа = 2) then '+' + Изменение_Рейтинга when ((Команда1 like ('%"+comboBox.Text+ "%') and Победа = 2) or Команда2 like ('%"+comboBox.Text+"%')and Победа = 1) then '-' + Изменение_Рейтинга else '+ 0' end from ИгрыТурнира where Команда1 like ('%" + comboBox.Text+ "%') or Команда2 like ('%"+comboBox.Text+"%')";
            SqlParameter p = new SqlParameter("@Name", SqlDbType.NVarChar, 100)
            {
                Value = "%" + comboBox.Text + "%"
            };
            cmdSelect.Parameters.AddWithValue(p.ParameterName, p.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataSet ds = new DataSet();
            ds.Tables.Clear();
            da.Fill(ds);
            GamesGridView.DataSource = ds.Tables["Table"];
            con.Close();
        }
        public void Fillcombo(Tournament tour) 
        {

            comboBox.Items.Clear();
            foreach (Player player in tour.players) 
            {
                comboBox.Items.Add(player._name);
            }
        }

        private void Itog_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
            con.Open();
            var cmdSelect = con.CreateCommand();
            cmdSelect.CommandText = "delete from ИгрыТурнира";
            cmdSelect.ExecuteNonQuery();
            con.Close();
        }
    }
}
