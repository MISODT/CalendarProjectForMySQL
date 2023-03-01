using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
    }
}