using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Address
    {
        public Guid Id { get; set; }
        public int StreetNo { get; set; }
        public string? City { get; set; }
        public string? StreetName { get; set; }
        public Employee? Employee { get; set; }
        public Guid EmployeeId { get; set; }
        //public State State { get; set; }
    }
}
