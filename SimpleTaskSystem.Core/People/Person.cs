using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.People
{
    [Table("StsPeople")]
    public class Person:Entity
    {
        public virtual string Name { get; set; }
    }
}

