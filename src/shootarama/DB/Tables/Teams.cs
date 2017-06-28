namespace shootarama.DB.Tables
{
    public class Teams : BaseTable
    {
        public string Name { get; set; }

        public int GameID { get; set; }

        public string Location { get; set; }
    }
}