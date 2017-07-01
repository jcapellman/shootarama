namespace shootarama.GameTypes
{
    public class MyTeam : BaseGameType
    {
        public override void CreateNewGame(string firstName, string lastName, string teamName)
        {
            GenerateGame(firstName, lastName);

            var teams = CreateTeams(teamName);

            CreatePlayers(teams);
        }
    }
}