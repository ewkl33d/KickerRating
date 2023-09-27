using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KickerRating
{
    internal class MathAndSaveToBD
    {

        public static Tournament saveInfoTour(Tournament tour) 
        {
            SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("insert into Турнир (ID, Название, Дата) values (@ID, @Название, @Дата)", con);
            SqlParameter Parameter = new SqlParameter("@ID", tour._id);
            cmd1.Parameters.Add(Parameter);
            Parameter = new SqlParameter("@Название", tour.name);
            cmd1.Parameters.Add(Parameter);
            Parameter = new SqlParameter("@Дата", tour.created);
            cmd1.Parameters.Add(Parameter);
            cmd1.ExecuteNonQuery();
            foreach (Player player in tour.players) 
            {
                cmd1 = new SqlCommand("select Рейтинг from Игрок where Имя = @Имя", con);
                Parameter = new SqlParameter("@Имя", player._name);
                cmd1.Parameters.Add(Parameter);
                int ratebefore = (int)cmd1.ExecuteScalar();
                player.ratebefore = ratebefore;
                player.ratenow = ratebefore;
            }
            return tour;
        }
        public static void gamesAnalisys(Tournament tour) 
        {
            SqlConnection con = new SqlConnection("Data Source =DESKTOP-SRIFGCI\\MSMSMS;" + "Initial Catalog = KickerRate;" + "Integrated Security = True;" + "TrustServerCertificate = True");
            con.Open();
            foreach (Round1 round in tour.rounds) 
            {
                foreach (Play game in round.plays) 
                {
                    if (!game.skipped || !game.deactivated) 
                    {
                        int team1Result = game.disciplines[0].sets[0].team1;
                        int team2Result = game.disciplines[0].sets[0].team2;
                        string team1player1name = "";
                        string team1player2name = "";
                        string team2player1name = "";
                        string team2player2name = "";
                        string team1player1id = "";
                        string team1player2id = "";
                        string team2player1id = "";
                        string team2player2id = "";
                        int team1player1rate = 0;
                        int team1player2rate = 0;
                        int team2player1rate = 0;
                        int team2player2rate = 0;
                        foreach (Team team in tour.teams) 
                        {
                            if (team._id.Equals(game.team1._id)) 
                            {
                                team1player1id = team.players[0]._id;
                                team1player2id = team.players[1]._id;
                            }
                            if (team._id.Equals(game.team2._id)) 
                            {
                                team2player1id = team.players[0]._id;
                                team2player2id = team.players[1]._id;
                            }
                        }
                        foreach (Player player in tour.players)
                            {
                            if (player._id.Equals(team1player1id)) { team1player1name = player._name; team1player1rate = player.ratenow; }
                            if (player._id.Equals(team1player2id)) { team1player2name = player._name; team1player2rate = player.ratenow; }
                            if (player._id.Equals(team2player1id)) { team2player1name = player._name; team2player1rate = player.ratenow; }
                            if (player._id.Equals(team2player2id)) { team2player2name = player._name; team2player2rate = player.ratenow; }
                            }
                        int ratediff = MathAndSaveToBD.rateDiff(game.disciplines[0].sets[0].team1, game.disciplines[0].sets[0].team2, team1player1rate, team1player2rate, team2player1rate, team2player2rate);
                        
                        SqlCommand cmd = new SqlCommand("insert into Игра values (@IDTour, @IDgame, @team1 ,@team2, @RateChange)", con);
                        SqlParameter Parameter = new SqlParameter("@IDTour", tour._id);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@IDgame", game._id);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@team1", game.disciplines[0].sets[0].team1);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@team2", game.disciplines[0].sets[0].team2);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@RateChange", Math.Abs(ratediff));
                        cmd.Parameters.Add(Parameter);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                        Parameter = new SqlParameter("@IDTour", tour._id);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@IDgame", game._id);
                        cmd.Parameters.Add(Parameter);
                        SqlCommand cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                        Parameter = new SqlParameter("@Имя", team1player1name);
                        cmd1.Parameters.Add(Parameter);
                        int par = (int)cmd1.ExecuteScalar();
                        Parameter = new SqlParameter("@IDplayer", par);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@team", 1);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@RateBefore", team1player1rate);
                        cmd.Parameters.Add(Parameter);
                        cmd.ExecuteNonQuery();


                        cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                        Parameter = new SqlParameter("@IDTour", tour._id);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@IDgame", game._id);
                        cmd.Parameters.Add(Parameter);
                        cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                        Parameter = new SqlParameter("@Имя", team1player2name);
                        cmd1.Parameters.Add(Parameter);
                        par = (int)cmd1.ExecuteScalar();
                        Parameter = new SqlParameter("@IDplayer", par);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@team", 1);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@RateBefore", team1player2rate);
                        cmd.Parameters.Add(Parameter);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                        Parameter = new SqlParameter("@IDTour", tour._id);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@IDgame", game._id);
                        cmd.Parameters.Add(Parameter);
                        cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                        Parameter = new SqlParameter("@Имя", team2player1name);
                        cmd1.Parameters.Add(Parameter);
                        par = (int)cmd1.ExecuteScalar();
                        Parameter = new SqlParameter("@IDplayer", par);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@team", 2);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@RateBefore", team2player1rate);
                        cmd.Parameters.Add(Parameter);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                        Parameter = new SqlParameter("@IDTour", tour._id);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@IDgame", game._id);
                        cmd.Parameters.Add(Parameter);
                        cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                        Parameter = new SqlParameter("@Имя", team2player2name);
                        cmd1.Parameters.Add(Parameter);
                        par = (int)cmd1.ExecuteScalar();
                        Parameter = new SqlParameter("@IDplayer", par);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@team", 2);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@RateBefore", team2player2rate);
                        cmd.Parameters.Add(Parameter);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("insert into ИгрыТурнира values (@IDTour, @IDgame, @IDplayer ,@team, @a, @RateBefore)", con);
                        Parameter = new SqlParameter("@IDTour", team1player1name +"/"+team1player2name);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@IDgame", team2player1name + "/" + team2player2name);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@IDplayer", team1Result);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@team", team2Result);
                        cmd.Parameters.Add(Parameter);
                        int pobeda = 0;
                        if (team1Result > team2Result) { pobeda = 1; }
                        if (team1Result < team2Result) { pobeda = 2; }
                        if (team1Result == team2Result) { if (team1player1rate + team1player2rate > team2player1rate + team2player2rate) { pobeda = 2; } if (team1player1rate + team1player2rate < team2player1rate + team2player2rate) { pobeda = 1; } if (team1player1rate + team1player2rate == team2player1rate + team2player2rate) { pobeda = 0; } }
                        Parameter = new SqlParameter("@a", pobeda);
                        cmd.Parameters.Add(Parameter);
                        Parameter = new SqlParameter("@RateBefore", ratediff);
                        cmd.Parameters.Add(Parameter);
                        cmd.ExecuteNonQuery();

                        foreach (Player player in tour.players)
                        {
                            if (player._id.Equals(team1player1id)) { player.ratenow = player.ratenow + ratediff; }
                            if (player._id.Equals(team1player2id)) { player.ratenow = player.ratenow + ratediff; }
                            if (player._id.Equals(team2player1id)) { player.ratenow = player.ratenow - ratediff; }
                            if (player._id.Equals(team2player2id)) { player.ratenow = player.ratenow - ratediff; }
                        }
                    }
                }
            }
            foreach (Ko round in tour.ko)
            {
                foreach (Level lvl in round.levels)
                {

                    foreach (Play2 game in lvl.plays)
                    {
                        try
                        {
                            if (!game.skipped || !game.deactivated)
                            {
                                for (int i = 0; i < game.disciplines[0].sets.Length; i++)
                                {
                                    int team1Result = game.disciplines[0].sets[i].team1;
                                    int team2Result = game.disciplines[0].sets[i].team2;
                                    string team1player1name = "";
                                    string team1player2name = "";
                                    string team2player1name = "";
                                    string team2player2name = "";
                                    string team1player1id = "";
                                    string team1player2id = "";
                                    string team2player1id = "";
                                    string team2player2id = "";
                                    int team1player1rate = 0;
                                    int team1player2rate = 0;
                                    int team2player1rate = 0;
                                    int team2player2rate = 0;
                                    foreach (Team team in tour.teams)
                                    {
                                        try
                                        {
                                            if (team._id.Equals(game.team1._id))
                                            {
                                                team1player1id = team.players[0]._id;
                                                team1player2id = team.players[1]._id;
                                            }
                                            if (team._id.Equals(game.team2._id))
                                            {
                                                team2player1id = team.players[0]._id;
                                                team2player2id = team.players[1]._id;
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    foreach (Player player in tour.players)
                                    {
                                        if (player._id.Equals(team1player1id)) { team1player1name = player._name; team1player1rate = player.ratenow; }
                                        if (player._id.Equals(team1player2id)) { team1player2name = player._name; team1player2rate = player.ratenow; }
                                        if (player._id.Equals(team2player1id)) { team2player1name = player._name; team2player1rate = player.ratenow; }
                                        if (player._id.Equals(team2player2id)) { team2player2name = player._name; team2player2rate = player.ratenow; }
                                    }
                                    int ratediff = MathAndSaveToBD.playoffRateDiff(game.disciplines[0].sets[i].team1, game.disciplines[0].sets[i].team2, team1player1rate, team1player2rate, team2player1rate, team2player2rate);

                                    SqlCommand cmd = new SqlCommand("insert into Плейофф values (@IDTour, @IDgame, @match, @team1 ,@team2, @RateChange, @stad)", con);
                                    SqlParameter Parameter = new SqlParameter("@IDTour", tour._id);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@IDgame", game._id);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@match", i + 1);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@team1", game.disciplines[0].sets[i].team1);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@team2", game.disciplines[0].sets[i].team2);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@RateChange", Math.Abs(ratediff));
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@stad", lvl.name);
                                    cmd.Parameters.Add(Parameter);
                                    cmd.ExecuteNonQuery();
                                    if (i == 0)
                                    {
                                        cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                                        Parameter = new SqlParameter("@IDTour", tour._id);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@IDgame", game._id);
                                        cmd.Parameters.Add(Parameter);
                                        SqlCommand cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                                        Parameter = new SqlParameter("@Имя", team1player1name);
                                        cmd1.Parameters.Add(Parameter);
                                        int par = (int)cmd1.ExecuteScalar();
                                        Parameter = new SqlParameter("@IDplayer", par);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@team", 1);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@RateBefore", team1player1rate);
                                        cmd.Parameters.Add(Parameter);
                                        cmd.ExecuteNonQuery();


                                        cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                                        Parameter = new SqlParameter("@IDTour", tour._id);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@IDgame", game._id);
                                        cmd.Parameters.Add(Parameter);
                                        cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                                        Parameter = new SqlParameter("@Имя", team1player2name);
                                        cmd1.Parameters.Add(Parameter);
                                        par = (int)cmd1.ExecuteScalar();
                                        Parameter = new SqlParameter("@IDplayer", par);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@team", 1);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@RateBefore", team1player2rate);
                                        cmd.Parameters.Add(Parameter);
                                        cmd.ExecuteNonQuery();

                                        cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                                        Parameter = new SqlParameter("@IDTour", tour._id);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@IDgame", game._id);
                                        cmd.Parameters.Add(Parameter);
                                        cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                                        Parameter = new SqlParameter("@Имя", team2player1name);
                                        cmd1.Parameters.Add(Parameter);
                                        par = (int)cmd1.ExecuteScalar();
                                        Parameter = new SqlParameter("@IDplayer", par);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@team", 2);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@RateBefore", team2player1rate);
                                        cmd.Parameters.Add(Parameter);
                                        cmd.ExecuteNonQuery();

                                        cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                                        Parameter = new SqlParameter("@IDTour", tour._id);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@IDgame", game._id);
                                        cmd.Parameters.Add(Parameter);
                                        cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                                        Parameter = new SqlParameter("@Имя", team2player2name);
                                        cmd1.Parameters.Add(Parameter);
                                        par = (int)cmd1.ExecuteScalar();
                                        Parameter = new SqlParameter("@IDplayer", par);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@team", 2);
                                        cmd.Parameters.Add(Parameter);
                                        Parameter = new SqlParameter("@RateBefore", team2player2rate);
                                        cmd.Parameters.Add(Parameter);
                                        cmd.ExecuteNonQuery();
                                    }

                                    foreach (Player player in tour.players)
                                    {
                                        if (player._id.Equals(team1player1id)) { player.ratenow = player.ratenow + ratediff; }
                                        if (player._id.Equals(team1player2id)) { player.ratenow = player.ratenow + ratediff; }
                                        if (player._id.Equals(team2player1id)) { player.ratenow = player.ratenow - ratediff; }
                                        if (player._id.Equals(team2player2id)) { player.ratenow = player.ratenow - ratediff; }
                                    }
                                    cmd = new SqlCommand("insert into ИгрыТурнира values (@IDTour, @IDgame, @IDplayer ,@team, @a, @RateBefore)", con);
                                    Parameter = new SqlParameter("@IDTour", team1player1name + "/" + team1player2name);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@IDgame", team2player1name + "/" + team2player2name);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@IDplayer", team1Result);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@team", team2Result);
                                    cmd.Parameters.Add(Parameter);
                                    int pobeda = 0;
                                    if (team1Result > team2Result) { pobeda = 1; }
                                    if (team1Result < team2Result) { pobeda = 2; }
                                    if (team1Result == team2Result) { if (team1player1rate + team1player2rate > team2player1rate + team2player2rate) { pobeda = 2; } if (team1player1rate + team1player2rate < team2player1rate + team2player2rate) { pobeda = 1; } if (team1player1rate + team1player2rate == team2player1rate + team2player2rate) { pobeda = 0; } }
                                    Parameter = new SqlParameter("@a", pobeda);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@RateBefore", ratediff);
                                    cmd.Parameters.Add(Parameter);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                        }
                        catch (Exception ex) { }
                        }
                }
                foreach (Play1 game in round.third.plays)
                { try {
                        if (!game.skipped || !game.deactivated)
                        {
                            for (int i = 0; i < game.disciplines[0].sets.Length; i++)
                            {
                                int team1Result = game.disciplines[0].sets[i].team1;
                                int team2Result = game.disciplines[0].sets[i].team2;
                                string team1player1name = "";
                                string team1player2name = "";
                                string team2player1name = "";
                                string team2player2name = "";
                                string team1player1id = "";
                                string team1player2id = "";
                                string team2player1id = "";
                                string team2player2id = "";
                                int team1player1rate = 0;
                                int team1player2rate = 0;
                                int team2player1rate = 0;
                                int team2player2rate = 0;
                                foreach (Team team in tour.teams)
                                {
                                    if (team._id.Equals(game.team1._id))
                                    {
                                        team1player1id = team.players[0]._id;
                                        team1player2id = team.players[1]._id;
                                    }
                                    if (team._id.Equals(game.team2._id))
                                    {
                                        team2player1id = team.players[0]._id;
                                        team2player2id = team.players[1]._id;
                                    }
                                }
                                foreach (Player player in tour.players)
                                {
                                    if (player._id.Equals(team1player1id)) { team1player1name = player._name; team1player1rate = player.ratenow; }
                                    if (player._id.Equals(team1player2id)) { team1player2name = player._name; team1player2rate = player.ratenow; }
                                    if (player._id.Equals(team2player1id)) { team2player1name = player._name; team2player1rate = player.ratenow; }
                                    if (player._id.Equals(team2player2id)) { team2player2name = player._name; team2player2rate = player.ratenow; }
                                }
                                int ratediff = MathAndSaveToBD.playoffRateDiff(game.disciplines[0].sets[0].team1, game.disciplines[0].sets[0].team2, team1player1rate, team1player2rate, team2player1rate, team2player2rate);

                                SqlCommand cmd = new SqlCommand("insert into Плейофф values (@IDTour, @IDgame, @match, @team1 ,@team2, @RateChange, @stad)", con);
                                SqlParameter Parameter = new SqlParameter("@IDTour", tour._id);
                                cmd.Parameters.Add(Parameter);
                                Parameter = new SqlParameter("@IDgame", game._id);
                                cmd.Parameters.Add(Parameter);
                                Parameter = new SqlParameter("@match", i + 1);
                                cmd.Parameters.Add(Parameter);
                                Parameter = new SqlParameter("@team1", game.disciplines[0].sets[i].team1);
                                cmd.Parameters.Add(Parameter);
                                Parameter = new SqlParameter("@team2", game.disciplines[0].sets[i].team2);
                                cmd.Parameters.Add(Parameter);
                                Parameter = new SqlParameter("@RateChange", Math.Abs(ratediff));
                                cmd.Parameters.Add(Parameter);
                                Parameter = new SqlParameter("@stad", "Third");
                                cmd.Parameters.Add(Parameter);
                                cmd.ExecuteNonQuery();
                                if (i == 0)
                                {
                                    cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                                    Parameter = new SqlParameter("@IDTour", tour._id);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@IDgame", game._id);
                                    cmd.Parameters.Add(Parameter);
                                    SqlCommand cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                                    Parameter = new SqlParameter("@Имя", team1player1name);
                                    cmd1.Parameters.Add(Parameter);
                                    int par = (int)cmd1.ExecuteScalar();
                                    Parameter = new SqlParameter("@IDplayer", par);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@team", 1);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@RateBefore", team1player1rate);
                                    cmd.Parameters.Add(Parameter);
                                    cmd.ExecuteNonQuery();


                                    cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                                    Parameter = new SqlParameter("@IDTour", tour._id);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@IDgame", game._id);
                                    cmd.Parameters.Add(Parameter);
                                    cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                                    Parameter = new SqlParameter("@Имя", team1player2name);
                                    cmd1.Parameters.Add(Parameter);
                                    par = (int)cmd1.ExecuteScalar();
                                    Parameter = new SqlParameter("@IDplayer", par);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@team", 1);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@RateBefore", team1player2rate);
                                    cmd.Parameters.Add(Parameter);
                                    cmd.ExecuteNonQuery();

                                    cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                                    Parameter = new SqlParameter("@IDTour", tour._id);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@IDgame", game._id);
                                    cmd.Parameters.Add(Parameter);
                                    cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                                    Parameter = new SqlParameter("@Имя", team2player1name);
                                    cmd1.Parameters.Add(Parameter);
                                    par = (int)cmd1.ExecuteScalar();
                                    Parameter = new SqlParameter("@IDplayer", par);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@team", 2);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@RateBefore", team2player1rate);
                                    cmd.Parameters.Add(Parameter);
                                    cmd.ExecuteNonQuery();

                                    cmd = new SqlCommand("insert into [Игрок В Игре] values (@IDTour, @IDgame, @IDplayer ,@team, @RateBefore)", con);
                                    Parameter = new SqlParameter("@IDTour", tour._id);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@IDgame", game._id);
                                    cmd.Parameters.Add(Parameter);
                                    cmd1 = new SqlCommand("select ID from Игрок where Имя = @Имя", con);
                                    Parameter = new SqlParameter("@Имя", team2player2name);
                                    cmd1.Parameters.Add(Parameter);
                                    par = (int)cmd1.ExecuteScalar();
                                    Parameter = new SqlParameter("@IDplayer", par);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@team", 2);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@RateBefore", team2player2rate);
                                    cmd.Parameters.Add(Parameter);
                                    cmd.ExecuteNonQuery();

                                    cmd = new SqlCommand("insert into ИгрыТурнира values (@IDTour, @IDgame, @IDplayer ,@team, @a, @RateBefore)", con);
                                    Parameter = new SqlParameter("@IDTour", team1player1name + "/" + team1player2name);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@IDgame", team2player1name + "/" + team2player2name);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@IDplayer", team1Result);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@team", team2Result);
                                    cmd.Parameters.Add(Parameter);
                                    int pobeda = 0;
                                    if (team1Result > team2Result) { pobeda = 1; }
                                    if (team1Result < team2Result) { pobeda = 2; }
                                    if (team1Result == team2Result) { if (team1player1rate + team1player2rate > team2player1rate + team2player2rate) { pobeda = 2; } if (team1player1rate + team1player2rate < team2player1rate + team2player2rate) { pobeda = 1; } if (team1player1rate + team1player2rate == team2player1rate + team2player2rate) { pobeda = 0; } }
                                    Parameter = new SqlParameter("@a", pobeda);
                                    cmd.Parameters.Add(Parameter);
                                    Parameter = new SqlParameter("@RateBefore", ratediff);
                                    cmd.Parameters.Add(Parameter);
                                    cmd.ExecuteNonQuery();
                                }

                                foreach (Player player in tour.players)
                                {
                                    if (player._id.Equals(team1player1id)) { player.ratenow = player.ratenow + ratediff; }
                                    if (player._id.Equals(team1player2id)) { player.ratenow = player.ratenow + ratediff; }
                                    if (player._id.Equals(team2player1id)) { player.ratenow = player.ratenow - ratediff; }
                                    if (player._id.Equals(team2player2id)) { player.ratenow = player.ratenow - ratediff; }
                                }
                            }
                        }
                    }
                    catch (Exception ex) { }
                    }
            }
            foreach (Player player in tour.players)
            {
                SqlCommand cmd1 = new SqlCommand("update Игрок set Рейтинг = @Рейтинг where Имя = @Имя", con);
                SqlParameter Parameter = new SqlParameter("@Имя", player._name);
                cmd1.Parameters.Add(Parameter);
                Parameter = new SqlParameter("@Рейтинг", player.ratenow);
                cmd1.Parameters.Add(Parameter);
                cmd1.ExecuteNonQuery();
                cmd1 = new SqlCommand("insert into ИтогТурнира values (@Имя,@РейтингДо,@РейтингПосле)", con);
                Parameter = new SqlParameter("@Имя", player._name);
                cmd1.Parameters.Add(Parameter);
                Parameter = new SqlParameter("@РейтингДо", player.ratebefore);
                cmd1.Parameters.Add(Parameter);
                Parameter = new SqlParameter("@РейтингПосле", player.ratenow);
                cmd1.Parameters.Add(Parameter);
                cmd1.ExecuteNonQuery();
            }
            con.Close();
            Itog newItog = new Itog();
            newItog.Fillcombo(tour);
            newItog.Show();
            con.Open();
            SqlCommand cmd2 = new SqlCommand("delete from ИтогТурнира", con);
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        public static int rateDiff(int team1Result, int team2Result, int team1player1rate, int team1player2rate, int team2player1rate, int team2player2rate) 
        {
            //Если апнулась первая - то результат плюсовый, нет - отрицательный
            int team1rate = 0;
            if (team1player1rate > team1player2rate) { team1rate = (2 * team1player1rate + team1player2rate) / 3; }
            else { team1rate = (2 * team1player2rate + team1player1rate) / 3;}
            int team2rate = 0;
            if (team2player1rate > team2player2rate) { team2rate = (2 * team2player1rate + team2player2rate) / 3; }
            else { team2rate = (2 * team2player2rate + team2player1rate) / 3; }
            int ratediff = 1;
            if (team1Result<team2Result) {
                ratediff = ((int)(Math.Abs(team1Result - team2Result) * 8 * (1 - (1 / (Math.Pow(10.0, (((double)team1rate - (double)team2rate) / 400)) + 1)))));
            }
            if (team1Result > team2Result)
            {
                ratediff = ((int)(Math.Abs(team1Result - team2Result) * 8 * (1 - (1 / (Math.Pow(10.0, (((double)team2rate - (double)team1rate) / 400)) + 1)))));
            }
            if (team1Result < team2Result) { ratediff = -ratediff; }
            if (team1Result == team2Result) {
                if (team1rate > team2rate)
                {
                    ratediff = ((int)(-4 * (1 - (1 / (Math.Pow(10.0, ((double)team1rate - (double)team2rate) / 400) + 1)))));
                }
                if (team1rate < team2rate)
                {
                    ratediff = ((int)(4 * (1 - (1 / (Math.Pow(10.0, ((double)team2rate - (double)team1rate) / 400) + 1)))));
                }
            }
            return ratediff;
        }

        public static int playoffRateDiff(int team1Result, int team2Result, int team1player1rate, int team1player2rate, int team2player1rate, int team2player2rate)
        {
            int team1rate = 0;
            if (team1player1rate > team1player2rate) { team1rate = (2 * team1player1rate + team1player2rate) / 3; }
            else { team1rate = (2 * team1player2rate + team1player1rate) / 3; }
            int team2rate = 0;
            if (team2player1rate > team2player2rate) { team2rate = (2 * team2player1rate + team2player2rate) / 3; }
            else { team2rate = (2 * team2player2rate + team2player1rate) / 3; }
            int ratediff = 1;
            if (team1Result < team2Result)
            {
                ratediff = ((int)(Math.Abs(team1Result - team2Result) * 8 * (1 - (1 / ( Math.Pow(10.0, (((double)team1rate - (double)team2rate) / 400)) + 1)))));
            }
            if (team1Result > team2Result)
            {
                ratediff = ((int)(Math.Abs(team1Result - team2Result) * 8 * (1 - (1 / (Math.Pow(10.0, (((double)team2rate - (double)team1rate) / 400)) + 1)))));
            }
            if (team1Result < team2Result) { ratediff = -ratediff; }
            if (team1Result == team2Result)
            {
                if (team1rate > team2rate)
                {
                    ratediff = ((int)(-4 * (1 - (1 / (Math.Pow(10.0, ((double)team1rate - (double)team2rate) / 400) + 1)))));
                }
                if (team1rate < team2rate)
                {
                    ratediff = ((int)(4 * (1 - (1 / (Math.Pow(10.0, ((double)team2rate - (double)team1rate) / 400) + 1)))));
                }
            }
            return ratediff;
        }
    }
}
