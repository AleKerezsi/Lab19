using System.ComponentModel.DataAnnotations;

namespace Lab19WebApi.DTO
{
    public class AddressToUpdateDto
    {
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Trebuie introdusa o strada, campul Strada nu poate fi lasat gol.")]
        public string Strada { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "Trebuie introdus orasul, campul oras nu poate fi lasat gol.")]
        public string Oras { get; set; }
        
        [Range(1, int.MaxValue)]
        public int Numar { get; set; }
    }
}
