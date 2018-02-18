using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XlToDb.Model
{
    [Table("Vendedores")]
    public class Vendedor
    {
        public int Id { get; set; }

        public string Representante { get; set; }

        [Display(Name = "% comissão")]
        public float PctComissao { get; set; }

        [StringLength(32)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }
    }
}
