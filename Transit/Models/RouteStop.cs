using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class RouteStop : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        public short Order { get; set; }
        
        [Required]
        public short Number { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public List<RouteSchedule> RouteSchedules { get; } = new List<RouteSchedule>();
    }
}