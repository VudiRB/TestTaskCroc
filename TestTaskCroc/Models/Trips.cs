using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestTaskCroc.Attributes;

namespace TestTaskCroc.Models
{
    [Table("trips", Schema = "public")]
    public class Trips
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.DateTime)]
        [MyDate(ErrorMessage ="Invalid date")]
        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        [MyDate(ErrorMessage ="Invalid date")]
        [Display(Name = "End time")]
        public DateTime EndTime { get; set; }
        public Workers Worker { get; set; }
        [ForeignKey("WorkerInfoKey")]
        public int? WorkerId { get; set; }
        public Cars Car { get; set; }
        [ForeignKey("CarInfoKey")]
        public int? CarId { get; set; }
        public float Range { get; set; }
        [Display(Name = "Cost of spent fuel")]
        public float CostOfSpentFuel { get; set; }
    }
}