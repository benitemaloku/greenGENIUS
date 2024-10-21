using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class aestheticPlants
    {

        [Key]           //është një atribut që specifikon se kjo pronë është çelësi primar i entitetit.
        [Required]                  // study annotation, qysh me lidh me error displaying...
        public int Id { get; set; }

        [Required] //bën që fusha Name të jetë e detyrueshme
        [StringLength(30)]  //specifikon që fusha Name mund të ketë maksimumi 30 karaktere.
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Please stick to using characters such as -Aa-")] //përcakton një shprehje të rregullt për validimin e të dhënave të futura. Kjo shprehje kërkon që Name të fillojë me një shkronjë të madhe dhe të përmbajë vetëm karaktere alfabetike dhe hapësira. Në rast të një gabimi, mesazhi "Please stick to using characters such as -Aa-" do të shfaqet.
        public string Name { get; set; }


        [Required] //atribut që tregon se kjo pronë është e detyrueshme dhe nuk mund të jetë null.
        public string Color { get; set; }

        [Required]
        public string Season { get; set; }

        [Required]
        public string Environment { get; set; }//Atribut

        [Required]
        public string Introduction { get; set; }

        [Required]
        public string Care { get; set; }

        public string Blooming { get; set; } //Fusha Blooming nuk është e detyrueshme, pra mund të jetë null.

        public byte[]? Photo { get; set; }

        //vazhdoje  ma vone
        //levanshtajn
    }

}