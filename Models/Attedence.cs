using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsysCompany.Models
{
    [PrimaryKey(nameof(EmpleeID),nameof(month),nameof(year))]
    public class Attedence
    {
        [ForeignKey("employee")]
        public int EmpleeID { get; set; }
        public Employee employee { get; set; }
        public int AbsentDays { get; set; }
        public int year { get; set; }
        public string month {  get; set; }
    }
}
