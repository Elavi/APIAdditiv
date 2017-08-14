using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.DAL.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public EyesColor EyesColor { get; set; }

        [MaxLength(100)]
        [Required]
        [Index(IsUnique = true)]
        public string PassportId { get; set; }
    }
}