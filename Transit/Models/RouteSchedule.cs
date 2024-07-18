using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class RouteSchedule : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required]
        public short StopNumber { get; set; }
        
        [Required]
        public short Timepoint { get; set; }
        
        [ForeignKey("StopNumber")]
        public RouteStop RouteStop { get; set; }
    }
}
