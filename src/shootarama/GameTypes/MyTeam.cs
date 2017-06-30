using System;
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
                var teams = new List<Teams>();

                var random = new Random((int) DateTime.Now.Ticks);

                var teamNames = db.TeamNames.OrderBy(a => random.Next()).Take(Common.Constants.NUMBER_OF_TEAMS - 1).Select(a => a.Name).ToList();
                var locationNames = db.LocationNames.OrderBy(a => random.Next())
                    .Take(Common.Constants.NUMBER_OF_TEAMS - 1).Select(a => a.Name).ToList();

                for (int x = 0; x < Common.Constants.NUMBER_OF_TEAMS - 1; x++)
                {
                    var team = new Teams
                    {
                        GameID = this.GameID,
                        Name = teamNames[x],
                        Location = locationNames[x]
                    };

                    teams.Add(team);
                }

                return teams;
            }
        }

        public override void CreateNewGame(string teamName)
        {
        }
    }
}