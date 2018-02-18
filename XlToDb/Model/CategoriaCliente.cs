using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XlToDb.Model
{
    [Table("CategoriasCliente")]
    public class CategoriaCliente
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [StringLength(32)]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [StringLength(128)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
