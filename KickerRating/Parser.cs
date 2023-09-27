using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KickerRating
{
    internal class Parser
    {
        public Boolean playersSaved;
        public SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
        public static Tournament Parsing(string pathToFile)
        {
            var json = File.ReadAllText(pathToFile);
            Tournament tour = Newtonsoft.Json.JsonConvert.DeserializeObject<Tournament>(json);
            return tour;
        }
        public static void tournirAnalisys(Tournament tour, int j, ChangeName ifrm)
        {
            ifrm.AllPlayersSavedSet(false);
            if (j == 0)
            {
                ifrm.Show();
            }
            if (tour.players.Length >= j + 1)
            {
                Player player = tour.players[j];
                var name = player._name;
                SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Игрок where Имя like ('"+name+"%')", con); 
                var str = cmd1.ExecuteReader();
                if (!str.HasRows)
                {
                    con.Close();
                    ifrm.changeFIO(name, j, tour);
                    str.Close();
                }
                else { 
                    int k = 0;
                        while (str.Read()) { k = k + 1; }
                        if (k == 1)
                        {
                            {
                                str.Close();
                                SqlCommand cmd2 = new SqlCommand("select Имя from Игрок where Имя like ('" + name + "%')", con);
                                player._name = (string)cmd2.ExecuteScalar();
                                j++;
                                con.Close();
                                tournirAnalisys(tour, j, ifrm);
                            }
                        }
                        else
                            {
                        con.Close();
                        ifrm.changeFIO(name, j, tour);
                        str.Close();
                    }
                    }
            }
            else 
            {
                ifrm.Hide();
                ifrm.AllPlayersSavedSet(true);
                Tournament tournament = ifrm.tournament;
                tournament = MathAndSaveToBD.saveInfoTour(tournament);
                MathAndSaveToBD.gamesAnalisys(tournament);
            }

        }
    }
}
     