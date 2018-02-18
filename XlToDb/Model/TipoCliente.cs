using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XlToDb.Model
{
    [Table("TiposCliente")]
    public class TipoCliente
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [StringLength(16)]
        public string Nome { get; set; }

        [StringLength(256)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
