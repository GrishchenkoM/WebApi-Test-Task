using System.Collections.Generic;
using Domain.Entities;

namespace Domain
{
    public class EntitiesModel
    {
        public Computer Computer { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public IList<User> Users { get; set; }
    }
}
