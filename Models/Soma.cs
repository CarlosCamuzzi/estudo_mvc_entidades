using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_calculadora.Models
{
    [Table("Somas")]
    public class Soma
    {
        [Key]
        public int Id { get; set; }
        public int NumeroUm { get; set; }
        public int NumeroDois { get; set; }
        public int Resultado { get; set; }

        public int Somar()
        {
            Resultado = NumeroUm + NumeroDois;
            return Resultado;
        }

        // Não existia
		public Seta Setarvalor()
		{
			Seta novaSeta = new Seta();
			novaSeta.Setar(Resultado, Id);
            
            return novaSeta;
		}
	}
}
