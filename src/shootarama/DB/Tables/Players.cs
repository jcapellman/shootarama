namespace shootarama.DB.Tables
{
    public class Players : BaseTable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int TeamID { get; set; }

        public int Experience { get; set; }

        public int Offense { get; set; }

        public int Defense { get; set; }

        public int Clutch { get; set; }

        public int Salary { get; set; }

        public int GameID { get; set; }
    }
}