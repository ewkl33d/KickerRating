using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KickerRating
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updatetable();
        }

        private void ButtonProvodnik_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    Tournament tournament = Parser.Parsing(filePath);
                    ChangeName ifrm = new ChangeName(tournament);
                    SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select * from Турнир where ID = @ID", con);
                    SqlParameter Parameter = new SqlParameter("@ID", tournament._id);
                    cmd1.Parameters.Add(Parameter);
                    var str = cmd1.ExecuteReader();
                    if (!str.HasRows)
                    {
                        Parser.tournirAnalisys(tournament, 0, ifrm); ;
                    }
                    else 
                    {
                        MessageBox.Show("Этот турнир уже загружен","Ошибка", MessageBoxButtons.OK);
                        ifrm.AllPlayersSavedSet(false);
                    }
                }
            }
        }

        private void GamesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void updatetable() 
        {
            SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
            con.Open();
            var cmdSelect = con.CreateCommand();
            cmdSelect.CommandText = "SELECT * from Игрок order by Рейтинг desc";
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataSet ds = new DataSet();
            ds.Tables.Clear();
            da.Fill(ds);
            GamesGridView.DataSource = ds.Tables["Table"];
            con.Close();
        }
    }
}