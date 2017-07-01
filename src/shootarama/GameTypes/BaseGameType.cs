using System;
using System.Collections.Generic;
using System.Linq;

using shootarama.DB;
using shootarama.DB.Tables;

namespace shootarama.GameTypes
{
    public abstract class BaseGameType
    {
        protected int GameID;

        protected List<Teams> CreateTeams(string teamName)
        {
            using (var db = new DBManager())
            {
                var teams = new List<Teams>();

                var random = new Random((int)DateTime.Now.Ticks);

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

                    db.SaveChanges();
                    
                    teams.Add(team);
                }

                return teams;
            }
        }

        protected List<Players> CreatePlayers(List<Teams> teams)
        {
            var players = new List<Players>();
            
            var random = new Random((int)DateTime.Now.Ticks);

            using (var db = new DBManager())
            {
                var playerNames = db.PlayerNames.OrderBy(a => random.Next())
                    .Take(teams.Count * Common.Constants.NUMBER_OF_PLAYERS_PER_TEAM).ToList();

                for (var x = 0; x < teams.Count; x++)
                {
                    var player = new Players
                    {
                        FirstName = playerNames[x].FirstName,
                        LastName = playerNames[x].LastName
                    };

                    db.SaveChanges();

                    players.Add(player);
                }
            }

            return players;
        }

        protected void GenerateGame(string firstName, string lastName)
        {
            using (var db = new DBManager())
            {
                var game = new Games
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                db.Games.Add(game);
                db.SaveChanges();

                GameID = game.ID;
            }
        }

        public abstract void CreateNewGame(string firstName, string lastName, string teamName);
    }
}