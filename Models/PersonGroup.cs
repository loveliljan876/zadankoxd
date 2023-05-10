using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Models
{
    public class PersonGroup
    {
        public int PersonId { get; set; } //klucz obcy do Person
        public Person Person { get; set; }
        public int GroupId { get; set; } //klucz obcy do Group
        public Group Group { get; set; }
    }
}
