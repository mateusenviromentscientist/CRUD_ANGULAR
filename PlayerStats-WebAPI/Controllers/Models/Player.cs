namespace PlayerStats_WebAPI{
    public class Player          
    {
        private int v1;
        private string v2;

        public Player(){}

        public Player(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Player(int id, string nome, string clube){
            this.id = id;
            this.nome = nome;
            this.clube = clube;
        }

        public int id {get; set;}

        public string nome {get; set;}

        public string clube {get; set;}
    }
}    