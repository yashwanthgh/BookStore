﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool IsOrdered { get; set; } = false;
        public bool IsUnCarted { get; set; } = false;
    }
}
