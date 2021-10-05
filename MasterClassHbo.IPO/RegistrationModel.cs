using System.ComponentModel.DataAnnotations;

namespace MasterClassHbo.Ipo
{
    public class RegistrationModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [Range(1, 500)]
        public int Amount { get; set; }
        public bool Stocks { get; set; }
        public bool Certificates { get; set; }

        public bool Derivatives { get; set; }
    }
}
