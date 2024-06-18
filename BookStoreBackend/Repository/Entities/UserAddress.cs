using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class UserAddress
    {
        public int AddressId { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Type { get; set; }
        public int userId { get; set; }
    }
}
