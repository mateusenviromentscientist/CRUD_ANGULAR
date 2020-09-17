using System.ComponentModel.DataAnnotations;

namespace PlayerStats_WebAPI
{
    public class Stat
    {
        public int Id {get; set;}
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]

        public string Estatistica {get ;set;}
        [MaxLength(1024, ErrorMessage="Este campo deve conter no máximo 1024 caracteres")]

        public string Clube{get; set;}
        public int Ano {get;set;}
        public int StatId {get; set;}

        [Required(ErrorMessage="Este campo é obrigatório")]
        [Range(1, int.MaxValue,ErrorMessage="player invalido")]
        public int PlayerId {get; set;} 
        public Player Player {get; set;}
        

    }
}