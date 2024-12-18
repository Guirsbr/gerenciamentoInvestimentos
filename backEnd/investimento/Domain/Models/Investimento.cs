using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace investimento.Domain.Models
{
    [Table("investimento")]
    public class Investimento
    {
        [Key]
        public int id { get; private set; }
        [Required]
        public double valor_inicial { get; private set; }
        [Required]
        public double valor_atual { get; private set; }
        [Required]
        public string rentabilidade { get; private set; }
        [Required]
        public DateTime data_atualizacao { get; private set; }
        [Required]
        public DateTime data_investimento { get; private set; }
        [Required]
        public int id_banco { get; private set; }
        [Required]
        public int id_tipo_investimento { get; private set; }
        [Required]
        public int id_usuario { get; private set; }

        public Investimento(
            double valor_inicial, double valor_atual, string rentabilidade,
            int id_banco, int id_tipo_investimento, int id_usuario)
        {
            this.valor_inicial = valor_inicial;
            this.valor_atual = valor_atual;
            this.rentabilidade = rentabilidade;
            data_atualizacao = DateTime.UtcNow;
            data_investimento = DateTime.UtcNow;
            this.id_banco = id_banco;
            this.id_tipo_investimento = id_tipo_investimento;
            this.id_usuario = id_usuario;
        }
    }
}
