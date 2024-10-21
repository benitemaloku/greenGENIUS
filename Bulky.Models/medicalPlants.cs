using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class medicalPlants
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Please stick to using characters such as -Aa-")]
        public string Name { get; set; }


        [Required]
        public string Season { get; set; } //dropdown list

        [Required]
        public string? Condition { get; set; } //heart problems, flu...

        [Required]
        public string Environment { get; set; } //indoor,outdoor

        [Required]
        [StringLength(200)]
        public string Introduction { get; set; }

        [Required]
        [Display(Name = "Health Benefits")]
        public string healthBenefits { get; set; }


        [Display(Name = "Side Effects")]
        public string? Warning { get; set; }


        [Required]
        public string Care { get; set; }

        [Required]
        [Display(Name = "Foraging Tips")]
        public string? foragingTips { get; set; }


        public byte[]? Photo { get; set; }




        //public string Review { get; set; }
        //levanshtajn
    }
}