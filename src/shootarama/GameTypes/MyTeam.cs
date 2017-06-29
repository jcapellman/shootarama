using System.Collections.Generic;
using System.Linq;

using shootarama.DB;
using shootarama.DB.Tables;

namespace shootarama.GameTypes
{
    public class MyTeam : BaseGameType
    {
        private DBManager _dbManager;

        private List<Teams> CreateTeams(string teamName)
        {
            using (var db = new DBManager())
            {
                var teamNames = db.TeamNames.Take(Common.Constants.NUMBER_OF_TEAMS - 1).Select(a => a.Name).ToList();

                for (int x = 0; x < Common.Constants.NUMBER_OF_TEAMS - 1; x++)
                {
                    // TODO Logic to generate randomized teams
                }

                return new List<Teams>();
            }
        }

        public override int CreateNewGame(string teamName)
        {
            return 0;
        }
    }
}