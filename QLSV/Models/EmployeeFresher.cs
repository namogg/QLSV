using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class EmployeeFresher
    {
        public IEnumerable<Employee> Employee { get; set; }
        public IEnumerable<Fresher> Fresher { get; set; }
    }
}
