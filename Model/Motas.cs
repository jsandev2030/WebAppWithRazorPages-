using System.ComponentModel.DataAnnotations;

namespace MotasWebRazor.Model
{
    public class Motas
    {
        // Definição da Chave primária. 
        [Key]
        public int Id { get; set; }

        // Campo "Categoria" - obrigatório. !!!
        [Required]
        public string Categoria { get; set; }

        // Campo "Nome" - obrigatório. !!!
        [Required]
        public string Nome { get; set; }

        // Campo "Valor" - obrigatório. !!!
        [Required]
        public string Valor { get; set; }

        // Campo "Cor"
        public string Cor { get; set; }

        // Campo "Cilindrada"
        public string Cilindrada { get; set; }

        // Campo "Ano"
        public string Ano { get; set; }
    }
}
