using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appToy.Models
{
    public class Juguete
    {
        [Key, Index(IsUnique = true), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;
        [Required, Column(TypeName = "varchar"), StringLength(50)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar"), StringLength(100)]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
        [Column(TypeName = "int")]
        public int? RestriccionEdad { get; set; }
        [Required, Column(TypeName = "varchar"), StringLength(50)]
        [DataType(DataType.Text)]
        public string Compania { get; set; }
        [Required, Column(TypeName = "decimal"), RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Precio { get; set; }
    }
}