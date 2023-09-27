using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickerRating
{
   public class Tournament
    {


        
            public string _id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public DateTime created { get; set; }
            public object[] groups { get; set; }
            public Player[] players { get; set; }
            public Team[] teams { get; set; }
            public Round1[] rounds { get; set; }
            public Ko[] ko { get; set; }
            public string mode { get; set; }
            public int numRounds { get; set; }
            public Options options { get; set; }
            public string version { get; set; }
            public bool started { get; set; }
            public long lastTransactionTimestamp { get; set; }
            public int lastTransaction { get; set; }
            public Sport sport { get; set; }
        }

        public class Options
        {
            public string _id { get; set; }
            public string type { get; set; }
            public int numPoints { get; set; }
            public int numSets { get; set; }
            public bool twoAhead { get; set; }
            public bool fastInput { get; set; }
            public int pointsWin { get; set; }
            public int pointsDraw { get; set; }
            public bool fairShuffle { get; set; }
            public Discipline[] disciplines { get; set; }
            public Table[] tables { get; set; }
            public int tablesPerPlay { get; set; }
            public bool hasDisciplines { get; set; }
            public int maxLostGames { get; set; }
            public bool draw { get; set; }
            public bool byeRating { get; set; }
            public Tableconfig[] tableConfig { get; set; }
            public bool multiTableTournament { get; set; }
            public bool useCloseGameRating { get; set; }
            public int closeGameDifference { get; set; }
            public int closeGamePointsWin { get; set; }
            public int closeGamePointsLoose { get; set; }
            public int numPlayersPerTeam { get; set; }
            public bool dypMode { get; set; }
        }

        public class Discipline
        {
            public string _id { get; set; }
            public string type { get; set; }
            public int numPoints { get; set; }
            public int numSets { get; set; }
            public bool twoAhead { get; set; }
            public bool fastInput { get; set; }
        }

        public class Table
        {
            public string _id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public bool deactivated { get; set; }
        }

        public class Tableconfig
        {
            public string _id { get; set; }
            public bool ignoreSort { get; set; }
            public bool visible { get; set; }
        }

        public class Sport
        {
            public Defaultoptions defaultOptions { get; set; }
            public Modes modes { get; set; }
            public Tableconfig1 tableConfig { get; set; }
            public bool hasSets { get; set; }
            public bool hasDraw { get; set; }
            public bool hasPoints { get; set; }
            public bool hasDisciplines { get; set; }
            public bool hasCloseGameRating { get; set; }
            public bool hasByeRating { get; set; }
            public string name { get; set; }
        }

        public class Defaultoptions
        {
            public int numPoints { get; set; }
            public int pointsWin { get; set; }
            public int pointsDraw { get; set; }
            public bool draw { get; set; }
        }

        public class Modes
        {
            public bool swiz { get; set; }
            public bool monster_dyp { get; set; }
            public bool last_man_standing { get; set; }
            public bool round_robin { get; set; }
            public bool rounds { get; set; }
            public bool elimination { get; set; }
            public bool double_elimination { get; set; }
            public bool whist { get; set; }
        }

        public class Tableconfig1
        {
            public Monster_Dyp[] monster_dyp { get; set; }
            public Last_Man_Standing[] last_man_standing { get; set; }
            public Swiz[] swiz { get; set; }
            public Whist[] whist { get; set; }
            public Round_Robin[] round_robin { get; set; }
            public Round[] rounds { get; set; }
            public object[] double_elimination { get; set; }
            public object[] elimination { get; set; }
        }

        public class Monster_Dyp
        {
            public string _id { get; set; }
            public bool ignoreSort { get; set; }
            public bool visible { get; set; }
        }

        public class Last_Man_Standing
        {
            public string _id { get; set; }
            public bool ignoreSort { get; set; }
            public bool visible { get; set; }
        }

        public class Swiz
        {
            public string _id { get; set; }
            public bool ignoreSort { get; set; }
            public bool visible { get; set; }
        }

        public class Whist
        {
            public string _id { get; set; }
            public bool ignoreSort { get; set; }
            public bool visible { get; set; }
        }

        public class Round_Robin
        {
            public string _id { get; set; }
            public bool ignoreSort { get; set; }
            public bool visible { get; set; }
        }

        public class Round
        {
            public string _id { get; set; }
            public bool ignoreSort { get; set; }
            public bool visible { get; set; }
        }

        public class Player
        {
            public string _id { get; set; }
            public string type { get; set; }
            public Stats stats { get; set; }
            public Meta meta { get; set; }
            public string _name { get; set; }
            public int ratebefore { get; set; }
            public int ratenow { get; set; }
            public int weight { get; set; }
            public int startIndex { get; set; }
            public bool removed { get; set; }
            public bool markedForRemoval { get; set; }
            public bool deactivated { get; set; }
        }

        public class Stats
        {
            public string _id { get; set; }
            public string type { get; set; }
            public int games { get; set; }
            public int points { get; set; }
            public int won { get; set; }
            public int lost { get; set; }
            public int draws { get; set; }
            public int sets_won { get; set; }
            public int sets_lost { get; set; }
            public int sets_diff { get; set; }
            public int dis_won { get; set; }
            public int dis_lost { get; set; }
            public int dis_draw { get; set; }
            public int dis_diff { get; set; }
            public int goals { get; set; }
            public int goals_in { get; set; }
            public int w_l { get; set; }
            public int goal_diff { get; set; }
            public Opponents opponents { get; set; }
            public int lives { get; set; }
            public int bh1 { get; set; }
            public int bh2 { get; set; }
            public int sb { get; set; }
            public int points_per_game { get; set; }
            public int corrected_points_per_game { get; set; }
            public int place { get; set; }
            public int result_losts { get; set; }
            public int result_wins { get; set; }
            public int placeChangeIndicator { get; set; }
            public bool hidden { get; set; }
        }

        public class Opponents
        {
        }

        public class Meta
        {
            public string _id { get; set; }
            public string type { get; set; }
            public bool _addedLater { get; set; }
            public int addedInRound { get; set; }
            public bool hadBye { get; set; }
            public int tableIndex { get; set; }
        }

        public class Team
        {
            public string _id { get; set; }
            public string type { get; set; }
            public Stats1 stats { get; set; }
            public Meta1 meta { get; set; }
            public int startIndex { get; set; }
            public Player1[] players { get; set; }
            public bool removed { get; set; }
            public bool markedForRemoval { get; set; }
            public bool deactivated { get; set; }
        }

        public class Stats1
        {
            public string _id { get; set; }
            public string type { get; set; }
            public int games { get; set; }
            public int points { get; set; }
            public int won { get; set; }
            public int lost { get; set; }
            public int draws { get; set; }
            public int sets_won { get; set; }
            public int sets_lost { get; set; }
            public int sets_diff { get; set; }
            public int dis_won { get; set; }
            public int dis_lost { get; set; }
            public int dis_draw { get; set; }
            public int dis_diff { get; set; }
            public int goals { get; set; }
            public int goals_in { get; set; }
            public int w_l { get; set; }
            public int goal_diff { get; set; }
            public Opponents1 opponents { get; set; }
            public int lives { get; set; }
            public int bh1 { get; set; }
            public int bh2 { get; set; }
            public int sb { get; set; }
            public int points_per_game { get; set; }
            public int corrected_points_per_game { get; set; }
            public int place { get; set; }
            public int result_losts { get; set; }
            public int result_wins { get; set; }
            public int placeChangeIndicator { get; set; }
            public bool hidden { get; set; }
        }

        public class Opponents1
        {
        }

        public class Meta1
        {
            public string _id { get; set; }
            public string type { get; set; }
            public bool _addedLater { get; set; }
            public int addedInRound { get; set; }
            public bool hadBye { get; set; }
            public int tableIndex { get; set; }
        }

        public class Player1
        {
            public string _id { get; set; }
            public string type { get; set; }
        }

        public class Round1
        {
            public string _id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public Play[] plays { get; set; }
        }

        public class Play
        {
            public string _id { get; set; }
            public string type { get; set; }
            public bool valid { get; set; }
            public Team1 team1 { get; set; }
            public Team2 team2 { get; set; }
            public Discipline1[] disciplines { get; set; }
            public long timeStart { get; set; }
            public long timeEnd { get; set; }
            public bool deactivated { get; set; }
            public bool team1bye { get; set; }
            public bool team2bye { get; set; }
            public bool skipped { get; set; }
            public string roundId { get; set; }
        }

        public class Team1
        {
            public string _id { get; set; }
            public string type { get; set; }
        }

        public class Team2
        {
            public string _id { get; set; }
            public string type { get; set; }
        }

        public class Discipline1
        {
            public string _id { get; set; }
            public string type { get; set; }
            public Set[] sets { get; set; }
            public bool team1Confirmed { get; set; }
            public bool team2Confirmed { get; set; }
            public string playId { get; set; }
        }

        public class Set
        {
            public string _id { get; set; }
            public string type { get; set; }
            public int team1 { get; set; }
            public int team2 { get; set; }
        }

        public class Ko
        {
            public string _id { get; set; }
            public string type { get; set; }
            public Level[] levels { get; set; }
            public object[] leftLevels { get; set; }
            public Third third { get; set; }
            public int size { get; set; }
            public bool thirdPlace { get; set; }
            public bool _double { get; set; }
            public bool teamUp { get; set; }
            public bool lordHaveMercy { get; set; }
            public Options1 options { get; set; }
            public bool finished { get; set; }
        }

        public class Third
        {
            public string _id { get; set; }
            public string type { get; set; }
            public Play1[] plays { get; set; }
            public string name { get; set; }
        }

        public class Play1
        {
            public string _id { get; set; }
            public string type { get; set; }
            public bool valid { get; set; }
            public Team11 team1 { get; set; }
            public Team21 team2 { get; set; }
            public Discipline2[] disciplines { get; set; }
            public long timeStart { get; set; }
            public long timeEnd { get; set; }
            public bool deactivated { get; set; }
            public bool team1bye { get; set; }
            public bool team2bye { get; set; }
            public int winner { get; set; }
            public int team1Result { get; set; }
            public int team2Result { get; set; }
            public bool skipped { get; set; }
            public string koId { get; set; }
            public string levelId { get; set; }
        }

        public class Team11
        {
            public string _id { get; set; }
            public string type { get; set; }
        }

        public class Team21
        {
            public string _id { get; set; }
            public string type { get; set; }
        }

        public class Discipline2
        {
            public string _id { get; set; }
            public string type { get; set; }
            public Set1[] sets { get; set; }
            public bool team1Confirmed { get; set; }
            public bool team2Confirmed { get; set; }
            public string playId { get; set; }
        }

        public class Set1
        {
            public string _id { get; set; }
            public string type { get; set; }
            public int team1 { get; set; }
            public int team2 { get; set; }
        }

        public class Options1
        {
            public string _id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public int numPoints { get; set; }
            public int numSets { get; set; }
            public bool twoAhead { get; set; }
            public bool fastInput { get; set; }
            public int pointsWin { get; set; }
            public int pointsDraw { get; set; }
            public bool fairShuffle { get; set; }
            public Discipline3[] disciplines { get; set; }
            public object[] tables { get; set; }
            public int tablesPerPlay { get; set; }
            public bool hasDisciplines { get; set; }
            public int maxLostGames { get; set; }
            public bool draw { get; set; }
            public bool byeRating { get; set; }
            public bool multiTableTournament { get; set; }
            public bool useCloseGameRating { get; set; }
            public int closeGameDifference { get; set; }
            public int closeGamePointsWin { get; set; }
            public int closeGamePointsLoose { get; set; }
            public int numPlayersPerTeam { get; set; }
            public bool dypMode { get; set; }
        }

        public class Discipline3
        {
            public string _id { get; set; }
            public string type { get; set; }
            public int numPoints { get; set; }
            public int numSets { get; set; }
            public bool twoAhead { get; set; }
            public bool fastInput { get; set; }
        }

        public class Level
        {
            public string _id { get; set; }
            public string type { get; set; }
            public Play2[] plays { get; set; }
            public string name { get; set; }
        }

        public class Play2
        {
            public string _id { get; set; }
            public string type { get; set; }
            public bool valid { get; set; }
            public Team12 team1 { get; set; }
            public Team22 team2 { get; set; }
            public Discipline4[] disciplines { get; set; }
            public long timeStart { get; set; }
            public long timeEnd { get; set; }
            public bool deactivated { get; set; }
            public bool team1bye { get; set; }
            public bool team2bye { get; set; }
            public int winner { get; set; }
            public int team1Result { get; set; }
            public int team2Result { get; set; }
            public bool skipped { get; set; }
            public string koId { get; set; }
            public string levelId { get; set; }
        }

        public class Team12
        {
            public string _id { get; set; }
            public string type { get; set; }
        }

        public class Team22
        {
            public string _id { get; set; }
            public string type { get; set; }
        }

        public class Discipline4
        {
            public string _id { get; set; }
            public string type { get; set; }
            public Set2[] sets { get; set; }
            public bool team1Confirmed { get; set; }
            public bool team2Confirmed { get; set; }
            public string playId { get; set; }
        }

        public class Set2
        {
            public string _id { get; set; }
            public string type { get; set; }
            public int team1 { get; set; }
            public int team2 { get; set; }
        }



    }
