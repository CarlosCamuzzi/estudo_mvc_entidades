using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_calculadora.Models
{
    [Table("Setados")]
    public class Seta
    {
        public static int Contador { get; set; }
		
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
        public int Valor { get; set; }

        public int SomaId { get; set; }
        [ForeignKey("SomaId")]
        public Soma Soma { get; set; }

        // Passava todos
        public void Setar(int resultado, int somaId)        
        {
            // Id = 2; // só aceita setando manual
            Id = 1;
            SomaId = somaId;     
            Valor = resultado * 2;
        }
    }
}
