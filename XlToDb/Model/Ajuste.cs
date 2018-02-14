using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XlToDb.Model
{
    public class Ajuste
    {
        public int AjusteId { get; set; }

        [StringLength(6)]
        [Display(Name = "De")]
        public string CodigoOriginal { get; set; }

        [StringLength(128)]
        [Display(Name = "Descrição")]
        public string DescricaoOriginal { get; set; }

        [Display(Name = "Unidade")]
        public int UnidadeDeId { get; set; }

        public Unidade UnidadeDe { get; set; }

        [Display(Name = "Para")]
        [ForeignKey("Atual")]
        public int AtualId { get; set; }

        public Produto Atual { get; set; }

        [Display(Name = "Unidade")]
        public int UnidadeParaId { get; set; }

        public Unidade UnidadePara { get; set; }

        public float Fator { get; set; }

        public int TipoAlteracaoId { get; set; }

        public TipoAlteracao TipoAlteracao { get; set; }

        public float Medida { get; set; }

    }
}
