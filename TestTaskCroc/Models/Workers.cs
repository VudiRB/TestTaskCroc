using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestTaskCroc.Attributes;

namespace TestTaskCroc.Models
{
    [Table("workers", Schema = "public")]
    public class Workers
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        [MyDate(ErrorMessage ="Invalid date")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Passport number")]
        [RegularExpression(@"^\d{4} \d{6}$")]
        public string PassportNumber { get; set; }
    }
}