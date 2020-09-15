namespace PlayerStats_WebAPI{
   
 
   
    public class Player_Stats{

        public Player_Stats()
        {
       
        }
        public Player_Stats(int PlayerId, int StatsId)
        {
            this.Id = Id;
            this.StatsId = StatsId;
            this.PlayerId = PlayerId;
        }
       
        public int Id{get; set;}

        public int PlayerId{get;set;}

        public Player Player {get; set;}

        public int StatsId {get; set;}

        public Stat Stat {get; set;}

    }
}