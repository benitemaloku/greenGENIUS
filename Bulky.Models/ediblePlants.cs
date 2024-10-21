using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class ediblePlants
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Please stick to using characters such as -Aa-")]
        public string Name { get; set; }

        [Required]
        public string Season { get; set; }

        [Required]
        public string Type { get; set; } //fruit or vegetable fixed vers:(tall growing, low growing)

        [Required]
        public string Environment { get; set; } //indoors or outdoors

        [Required]
        [StringLength(200)]
        public string Introduction { get; set; }

        [Required]
        public string Recipes { get; set; }

        [Required]
        public string Benefits { get; set; } //nutritional and all that stuff 

        public string Warning { get; set; }

        [Required]
        public string Care { get; set; }

        public byte[]? Photo { get; set; }





        //public string Review { get; set; }
        //levanshtajn
    }
}