namespace shootarama.GameTypes
{
    public abstract class BaseGameType
    {
        protected int GameID;

        public abstract void CreateNewGame(string teamName);
    }
}