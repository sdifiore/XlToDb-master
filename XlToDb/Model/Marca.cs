using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XlToDb.Model
{
    [Table("Marcas")]
    public class Marca
    {
        public int Id { get; set; }

        [StringLength(16)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [StringLength(256)]
        [Display(Name = "Comentário")]
        public string Comentario { get; set; }
    }
}
