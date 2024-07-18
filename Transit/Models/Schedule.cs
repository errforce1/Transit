using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class Schedule : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required]
        public short StopNumber { get; set; }
        
        [Required]
        public short Timepoint { get; set; }
        
        [ForeignKey("StopNumber")]
        public Stop Stop { get; set; }
    }
}
