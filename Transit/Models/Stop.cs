using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class Stop : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        public short Order { get; set; }
        
        [Required]
        public short Number { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public List<Schedule> Schedules { get; } = new List<Schedule>();
    }
}