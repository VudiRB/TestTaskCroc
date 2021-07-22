using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestTaskCroc.Attributes;

namespace TestTaskCroc.Models
{
    [Table("cars", Schema = "public")]
    public class Cars
    {
        [Key]
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [RegularExpression(@"^[АВЕКМНОРСТУХ]\d{3}(?<!000)[АВЕКМНОРСТУХ]{2}\d{2,3}$")]
        [Display(Name = "Government number")]
        public string GovNumber { get; set; }
        [Display(Name = "Gear box type")]
        public Constants.GearShiftBox TypeOfGearShiftBox { get; set; }
        [Display(Name = "Engine volume")]
        [Column(TypeName = "decimal(3, 2)")]
        public decimal EngineVolume { get; set; }
        [Range(1, 2000)]
        [Display(Name = "Engine force")]
        public float EngineForce {get; set; }
        [Display(Name = "Depreciation coefficient")]
        [Column(TypeName = "decimal(3, 2)")]
        [Range(1, 2)]
        public decimal DepreciationCoef {get; set; }
        [Display(Name = "Insurance coefficient")]
        [Column(TypeName = "decimal(3, 2)")]
        [Range(1, 2)]
        public decimal InsuranceCoef {get; set; }
        [Display(Name = "Maintenance coefficient")]
        [Column(TypeName = "decimal(3, 2)")]
        [Range(1, 2)]
        public decimal MaintenanceCoef {get; set; }
        [Display(Name = "Car cost")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal CarCost {get; set; }
        [Display(Name = "Date of purchase")]
        [DataType(DataType.Date)]
        [MyDate(ErrorMessage ="Invalid date")]
        public DateTime DateOfPurchase {get; set; }
    }
}