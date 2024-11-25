using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OutsysCompany.Models
{
    [PrimaryKey(nameof(Essn), nameof(Pno))]
    public class WorksOn
    {
        [ForeignKey("Employee")]
        public int Essn { get; set; }
        public virtual Employee Employee { get; set; }


        [ForeignKey("Project")]
        public int Pno { get; set; }
        public virtual Project Project { get; set; }

        public decimal Hours { get; set; }

    }
}
