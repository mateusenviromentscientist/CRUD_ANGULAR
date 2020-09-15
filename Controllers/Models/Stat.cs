using System.Collections.Generic;

namespace PlayerStats_WebAPI{
    public class Stat
    {
        public Stat()
        {
            
        }

        public Stat(int id, string nacionalidade, int PlayerId)
        {
            this.id = id;  
            this.nacionalidade = nacionalidade;
            this.PlayerId = PlayerId;
        }
        public int id {get; set;}

        public IEnumerable <Player_Stats> stat {get; set;}

        public string nacionalidade {get; set;}
        
        public int PlayerId {get; set;}


    }

    
    
}





