using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XlToDb.Model
{
    [Table("TiposVenda")]
    public class TipoVenda
    {
        public int Id { get; set; }

        [StringLength(3)]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [StringLength(128)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}