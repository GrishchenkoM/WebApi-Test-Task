using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain
{
    public class EntitiesModel
    {
        public ComputerName ComputerName { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public IList<UserName> UserNames { get; set; }
    }
}
