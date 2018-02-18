using System.ComponentModel.DataAnnotations;

namespace XlToDb.Model
{
    public class Uf
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string Sigla { get; set; }

        [StringLength(32)]
        public string Nome { get; set; }
    }
}
