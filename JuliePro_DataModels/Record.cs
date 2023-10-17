using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataModels
{
    public class Record
    {
        [Display(Name="Id")] public int Id { get; set; }
        [Display(Name="Date")] public DateTime Date { get; set; }
        [ForeignKey("Discipline")]
        [Display(Name="Discipline_Id")] public int? Discipline_Id { get; set; }
        [Display(Name="Discipline")] public virtual Discipline Discipline { get; set; }
        [Display(Name="Amount")] public Decimal Amount { get; set; }
        [Display(Name="Unit")] public string Unit { get; set; }

        [ForeignKey("Trainer")]
        [Display(Name="Trainer_Id")] public int? Trainer_Id { get; set; }
        [Display(Name="Trainer")] public virtual Trainer Trainer { get; set; }

    }
}
