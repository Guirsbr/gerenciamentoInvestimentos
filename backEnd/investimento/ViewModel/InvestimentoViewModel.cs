using System.ComponentModel.DataAnnotations;

namespace investimento.ViewModel
{
    public class InvestimentoViewModel
    {
        public double valor_inicial { get; set; }
        public double valor_atual { get; set; }
        public string rentabilidade { get; set; }
        public int id_banco { get; set; }
        public int id_tipo_investimento { get; set; }
        public int id_usuario { get; set; }
    }
}
