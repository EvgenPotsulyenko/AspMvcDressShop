using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspMvcDressShop.Models
{
    public class Dress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public byte[] Img { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // тип - джинсы, платье и тд.
        public int Size { get; set; } 
        public string Model { get; set; }
        public string Colour { get; set; }
        public string Material { get; set; }
        public int Cost { get; set; }
    }
}