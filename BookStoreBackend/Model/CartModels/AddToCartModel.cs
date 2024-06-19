﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CartModels
{
    public class AddToCartModel
    {
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool IsOrdered { get; set; }
        public bool IsUnCarted { get; set; }
    }
}
