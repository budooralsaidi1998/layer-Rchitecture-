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
    [PrimaryKey(nameof(Dnumber), nameof(Dlocation))]
    public class DeptLocation
    {
        [ForeignKey("Department")]
        public int Dnumber { get; set; }
        public virtual Department Department { get; set; }


        public string Dlocation { get; set; }

    }
}
